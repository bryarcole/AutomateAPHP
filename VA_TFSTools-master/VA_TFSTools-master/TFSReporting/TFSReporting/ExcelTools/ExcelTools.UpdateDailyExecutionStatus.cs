using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSCommon.Common;
using TFSReporting.WebAPITools;

namespace TFSReporting.ExcelTools
{
    public class UpdateDailyExecutionStatus
    {
        private string _fileName;
        private string _saveLocation;

        private Properties _props;

        private ExcelPackage _excelPackage;
        private ExcelWorkbook _excelWorkbook;

        private ExcelWorksheet _folderCountsWorksheet;

        private Dictionary<string, List<TestCaseCategory>> _sheetCategoryMapping;

        public UpdateDailyExecutionStatus(Properties props)
        {
            _fileName = props.FileName;
            _saveLocation = props.SaveLocation;

            _props = props;

            try
            {
                string fileName = _saveLocation + _fileName;
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException();
                }

                FileInfo fileInfo;
                if (File.Exists(_saveLocation + "/Updated/" + _fileName))
                {
                    fileInfo = new FileInfo(_saveLocation + "/Updated/" + _fileName);
                }
                else
                {
                    fileInfo = new FileInfo(fileName);
                }

                var newFileInfo = new FileInfo(_saveLocation + "/Updated/" + _fileName);

                _excelPackage = new ExcelPackage(newFileInfo, fileInfo);
                _excelWorkbook = _excelPackage.Workbook;

                _folderCountsWorksheet = _excelWorkbook.Worksheets[props.FolderCountsSheetName];

                if (_folderCountsWorksheet == null)
                {
                    throw new Exception("Error with Iteration Daily Mapping sheet.");
                }

                _sheetCategoryMapping = GenerateFolderPathCategoryMapping(_folderCountsWorksheet);

                Console.WriteLine("Excel file is opened.");
            }
            catch (Exception e)
            {
                Console.WriteLine("File Location/Name is not valid. Please press Enter and run the program again.");
                Console.Write(e);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        public void GatherCategoryExecutionNumbers()
        {
            Dictionary<string, List<TestCaseCategory>> sheetCategoryMappingCopy = new Dictionary<string, List<TestCaseCategory>>();
            double totalCount = 0;
            foreach(KeyValuePair<string, List<TestCaseCategory>> sheets in _sheetCategoryMapping)
            {
                foreach(TestCaseCategory testCaseCategory in sheets.Value)
                {
                    totalCount += 2;
                    totalCount += Convert.ToInt32((testCaseCategory.EndDate - testCaseCategory.StartDate).TotalDays) * 2;
                }
            }
            
            using (var progress = new ProgressBar())
            {
                double currCount = 0;
                foreach (KeyValuePair<string, List<TestCaseCategory>> sheets in _sheetCategoryMapping)
                {
                    List<TestCaseCategory> tempTestCaseCategories = new List<TestCaseCategory>();
                    foreach (TestCaseCategory testCaseCategory in sheets.Value)
                    {
                        var dates = new List<DateTime>();

                        DateTime endDate;
                        if (testCaseCategory.EndDate >= DateTime.Now)
                        {
                            endDate = DateTime.Now;
                        }
                        else
                        {
                            endDate = testCaseCategory.EndDate;
                        }
                        for (DateTime dt = testCaseCategory.StartDate; dt <= endDate; dt = dt.AddDays(1))
                        {
                            dates.Add(dt);
                        }

                        TestCaseCategory copyTestCaseCategory = testCaseCategory.CloneJson<TestCaseCategory>();
                        copyTestCaseCategory.DailyCumulativeActualExecuted = new Dictionary<DateTime, int>();
                        copyTestCaseCategory.DailyCumulativeActualPassed = new Dictionary<DateTime, int>();
                        foreach (string path in testCaseCategory.TestCasePaths)
                        {
                            string[] actualExecutedFilter = new string[] { "Passed", "Failed", "Blocked" };
                            string[] actualPassedFilter = new string[] { "Passed" };

                            progress.Report(currCount / totalCount);

                            int pathCumulativeActualExecuted = GetPathCumulativeHelper(_props.EndDate, actualExecutedFilter, path);

                            int pathCumulativeActualPassed = GetPathCumulativeHelper(_props.EndDate, actualPassedFilter, path);

                            currCount += 2;

                            copyTestCaseCategory.CumulativeActualExecuted += pathCumulativeActualExecuted;
                            copyTestCaseCategory.CumulativeActualPassed += pathCumulativeActualPassed;

                            foreach (DateTime currDate in dates)
                            {
                                //Console.WriteLine(currDate);
                                progress.Report(currCount / totalCount);

                                // Get cumulative executed on each day --> Includes Passed, Failed, and Blocked but Ready For Test
                                int pathCumulativeActualExecutedByDate = GetPathCumulativeHelper(currDate, actualExecutedFilter, path);
                                if (!copyTestCaseCategory.DailyCumulativeActualExecuted.ContainsKey(currDate))
                                {
                                    copyTestCaseCategory.DailyCumulativeActualExecuted[currDate] = pathCumulativeActualExecutedByDate;
                                }
                                else
                                {
                                    copyTestCaseCategory.DailyCumulativeActualExecuted[currDate] += pathCumulativeActualExecutedByDate;
                                }

                                // Get cumulative executed on each day --> Includes Passed
                                int pathCumulativeActualPassedByDate = GetPathCumulativeHelper(currDate, actualPassedFilter, path);
                                if (!copyTestCaseCategory.DailyCumulativeActualPassed.ContainsKey(currDate))
                                {
                                    copyTestCaseCategory.DailyCumulativeActualPassed[currDate] = pathCumulativeActualPassedByDate;
                                }
                                else
                                {
                                    copyTestCaseCategory.DailyCumulativeActualPassed[currDate] += pathCumulativeActualPassedByDate;
                                }
                                currCount += 2;
                            }
                        }

                        tempTestCaseCategories.Add(copyTestCaseCategory);
                    }

                    sheetCategoryMappingCopy[sheets.Key] = tempTestCaseCategories;
                }
            }

            _sheetCategoryMapping = sheetCategoryMappingCopy;
        }

        public void UpdateSheets()
        {
            foreach(string sheetName in _sheetCategoryMapping.Keys)
            {
                ExcelWorksheet tempSheet = _excelWorkbook.Worksheets[sheetName];
                if (tempSheet == null)
                {
                    throw new Exception(tempSheet + " does not exist");
                }

                tempSheet = UpdateSingleSheet(tempSheet, _sheetCategoryMapping[sheetName]);
            }
        }

        private ExcelWorksheet UpdateSingleSheet(ExcelWorksheet worksheet, List<TestCaseCategory> testCaseCategories)
        {
            ExcelWorksheet copyWorksheet = worksheet;
            int usedRows = 3;
            while (copyWorksheet.Cells[usedRows, 1].Value != null)
            {
                usedRows += 1;
            }
            usedRows -= 1;

            Dictionary<DateTime, int> dateTimeToRowMapping = new Dictionary<DateTime, int>();

            for (int i = 3; i <= usedRows; i++)
            {
                DateTime parsedDateTime = DateTime.Parse(copyWorksheet.Cells[i, 1].Text);
                dateTimeToRowMapping[parsedDateTime] = i;
            }

            foreach(TestCaseCategory testCaseCategory in testCaseCategories)
            {
                int startColumn = testCaseCategory.SheetColumn;
                foreach (KeyValuePair<DateTime, int> curr in testCaseCategory.DailyCumulativeActualExecuted)
                {
                    if (dateTimeToRowMapping.ContainsKey(curr.Key))
                    {
                        copyWorksheet.Cells[dateTimeToRowMapping[curr.Key], startColumn + 3].Value = curr.Value;
                    }
                }
                foreach (KeyValuePair<DateTime, int> curr in testCaseCategory.DailyCumulativeActualPassed)
                {
                    if (dateTimeToRowMapping.ContainsKey(curr.Key))
                    {
                        copyWorksheet.Cells[dateTimeToRowMapping[curr.Key], startColumn + 4].Value = curr.Value;
                    }
                }
            }

            return copyWorksheet;
        }

        private int GetPathCumulativeHelper(DateTime date, string[] category, string path)
        {
            int res = GetTestCasesWebApi.GetTestCaseExecutedCumulativeAndPathAndStatuses(date,
                            category,
                            path).Result.Count;
            return res;
        }

        private Dictionary<string, List<TestCaseCategory>> GenerateFolderPathCategoryMapping(ExcelWorksheet sheet)
        {
            Dictionary<string, Dictionary<string, TestCaseCategory>> res = new Dictionary<string, Dictionary<string, TestCaseCategory>>();

            int usedRows = 1;
            while (sheet.Cells[usedRows, 16].Value != null)
            {
                usedRows += 1;
            }
            usedRows -= 1;

            for (int i = 2; i <= usedRows; i++)
            {
                //Console.WriteLine(i);
                if (sheet.Cells[i, 16] != null && sheet.Cells[i, 16].Text != "###" && sheet.Cells[i, 18] != null && sheet.Cells[i, 18].Text != "")
                {
                    string sheetName = sheet.Cells[i, 1].Text;
                    //Console.WriteLine(sheetName);
                    if (!res.ContainsKey(sheetName))
                    {
                        res[sheetName] = new Dictionary<string, TestCaseCategory>();
                    }
                    string testCasePath = sheet.Cells[i, 6].Text;
                    string category = sheet.Cells[i, 16].Text;
                    DateTime startDate = DateTime.Parse(sheet.Cells[i, 19].Text);
                    DateTime endDate = DateTime.Parse(sheet.Cells[i, 20].Text);
                    //Console.WriteLine(sheet.Cells[i, 18].Text);
                    int column = Convert.ToInt32(sheet.Cells[i, 18].Text);
                    if (!res[sheetName].ContainsKey(category))
                    {
                        TestCaseCategory testCaseCategory = new TestCaseCategory
                        {
                            Category = category,
                            SheetColumn = column,
                            StartDate = startDate,
                            EndDate = endDate
                        };
                        testCaseCategory.TestCasePaths.Add(testCasePath);
                        res[sheetName][category] = testCaseCategory;
                    }
                    else
                    {
                        res[sheetName][category].TestCasePaths.Add(testCasePath);
                    }
                }
            }

            Dictionary<string, List<TestCaseCategory>> returnValue = new Dictionary<string, List<TestCaseCategory>>();
            foreach (KeyValuePair<string, Dictionary<string, TestCaseCategory>> pair in res)
            {
                returnValue[pair.Key] = pair.Value.Values.ToList<TestCaseCategory>();
            }
            
            return returnValue;
        }

        public void ExcelCleanup()
        {
            _excelPackage.Save();
            _excelPackage.Dispose();

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("File has been closed and cleaned up.");
        }
    }
}
