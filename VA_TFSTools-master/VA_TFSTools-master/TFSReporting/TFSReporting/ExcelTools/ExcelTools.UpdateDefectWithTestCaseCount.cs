using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TFSCommon.Data;
using TFSCommon.ExcelTools;
using TFSReporting.WebAPITools;

namespace TFSReporting.ExcelTools
{
    public class UpdateDefectWithTestCaseCount
    {
        private string _fileName;
        private string _saveLocation;

        private Properties _props;

        private ExcelPackage _excelPackage;
        private ExcelWorkbook _excelWorkbook;

        private ExcelWorksheet _excelWorksheet;
        private ExcelWorksheet _testCaseWithDefect;
        private ExcelWorksheet _defectTfsPropsed;

        public UpdateDefectWithTestCaseCount()
        {

        }

        public UpdateDefectWithTestCaseCount(Properties props)
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

                _excelWorksheet = _excelWorkbook.Worksheets[props.TfsDefectsSheetName];

                _testCaseWithDefect = _excelWorkbook.Worksheets[props.TfsTestCaseWithDefectSheetName];

                _defectTfsPropsed = _excelWorkbook.Worksheets[props.TfsDefectsProposedSheetName];

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

        public void UpdateDefectOnlySheet(List<Defect> defects, DateTime earliestTime, Boolean toSort)
        {
            _excelWorksheet = TFSCommon.ExcelTools.ExcelTools.ClearExcelSheetExceptHeader(_excelWorksheet, "A", "O");

            int rowCount = 2;

            //Dictionary<int, int> idToRowMapping = new Dictionary<int, int>();
            //for (int i = 2; i < rowCount; i++)
            //{
            //    if (_excelWorksheet.Cells[i, 1].Text != "")
            //    {
            //        idToRowMapping[Convert.ToInt32(_excelWorksheet.Cells[i, 1].Text)] = i;
            //    }
            //}

            List<Defect> defectsToIterate;

            if (toSort)
            {
                defectsToIterate = defects.OrderBy(step1 => step1.DefectSeverity)
                    .ThenBy(step2 => step2.Status)
                    .ThenBy(step3 => step3.AssignedTo).ToList<Defect>();

                defectsToIterate = defectsToIterate.Where(step1 => step1.DefectCreateDate >= earliestTime).ToList<Defect>();
            }
            else
            {
                defectsToIterate = defects;
            }

            foreach (Defect curr in defectsToIterate)
            {
                int currentRow = rowCount;
                rowCount += 1;

                _excelWorksheet = WriteExcelRow(_excelWorksheet, curr, currentRow);

                //_excelWorksheet.Cells[currentRow, 1].Value = curr.DefectId;
                //_excelWorksheet.Cells[currentRow, 2].Value = curr.DefectName;

                //_excelWorksheet.Cells[currentRow, 3].Value = curr.Status;
                //_excelWorksheet.Cells[currentRow, 4].Value = curr.DefectSeverity;
                //if (curr.TestCases != null)
                //{
                //    Console.WriteLine(curr.DefectId + ": " + curr.TestCases.Count);
                //    _excelWorksheet.Cells[currentRow, 5].Value = curr.TestCases.Count;
                //}

                ////_excelWorksheet.Cells[currentRow, 6].RichText.Text = curr.DefectHistory;
                //if (curr.DefectHistory != null)
                //{
                //    //_excelWorksheet.Cells[currentRow, 6].Value = curr.DefectHistory;
                //    _excelWorksheet.Cells[currentRow, 6].Value = ScrubHtml(curr.DefectHistory);
                //}

                //if (curr.DefectHistory != null)
                //{
                //    _excelWorksheet.Cells[currentRow, 7].Value = curr.DiscussionDate.ToString();
                //}
                //_excelWorksheet.Cells[currentRow, 8].Value = curr.AssignedTo;
                //_excelWorksheet.Cells[currentRow, 10].Value = curr.Iteration;
                //_excelWorksheet.Cells[currentRow, 11].Value = curr.DefectCreateDate.ToString();
                //_excelWorksheet.Cells[currentRow, 12].Value = curr.DefectType;
                //_excelWorksheet.Cells[currentRow, 13].Value = curr.ApplicationArea;
                //_excelWorksheet.Cells[currentRow, 14].Value = curr.ApplicationProcess;
                //_excelWorksheet.Cells[currentRow, 15].Value = curr.FoundInEnvironment;
            }
        }

        public void UpdateTfsProposed(List<Defect> defects, Boolean toSort = true)
        {
            //_defectTfsPropsed = ClearExcelSheetExceptHeader(_defectTfsPropsed, "A", "O");
            _defectTfsPropsed = TFSCommon.ExcelTools.ExcelTools.ClearExcelSheetExceptHeader(_defectTfsPropsed, "A", "O");

            int rowCount = 2;

            List<String> severityFilter = new List<String> { "1 - Critical", "2 - High", "3 - Medium", "4 - Low" };

            List<Defect> defectsToIterate;

            if (toSort)
            {
                defectsToIterate = defects.Where(step1 => severityFilter.Contains(step1.DefectSeverity))
                                        .Where(step2 => step2.Status == "Proposed")
                                        .ToList<Defect>();

                defectsToIterate = defectsToIterate.OrderBy(step1 => step1.AssignedTo)
                                        .ThenBy(step2 => step2.DefectCreateDate)
                                        .ToList<Defect>();
            }
            else
            {
                defectsToIterate = defects;
            }

            foreach (Defect curr in defectsToIterate)
            {
                int currentRow = rowCount;
                rowCount += 1;

                _defectTfsPropsed = WriteExcelRow(_defectTfsPropsed, curr, currentRow);
            }
        }

        private ExcelWorksheet WriteExcelRow(ExcelWorksheet worksheet, Defect defect, int row)
        {
            ExcelWorksheet copyWorksheet = worksheet;

            copyWorksheet.Cells[row, 1].Value = defect.DefectId;
            copyWorksheet.Cells[row, 2].Value = defect.DefectName;

            copyWorksheet.Cells[row, 3].Value = defect.Status;
            copyWorksheet.Cells[row, 4].Value = defect.DefectSeverity;
            if (defect.TestCases != null)
            {
                //Console.WriteLine(defect.DefectId + ": " + defect.TestCases.Count);
                copyWorksheet.Cells[row, 5].Value = defect.TestCases.Count;
            }

            //copyWorksheet.Cells[row, 6].RichText.Text = defect.DefectHistory;
            if (defect.DefectHistory != null)
            {
                //copyWorksheet.Cells[row, 6].Value = defect.DefectHistory;
                copyWorksheet.Cells[row, 6].Value = ScrubHtml(defect.DefectHistory);
            }

            if (defect.DefectHistory != null)
            {
                copyWorksheet.Cells[row, 7].Value = defect.DiscussionDate.ToString();
            }
            copyWorksheet.Cells[row, 8].Value = defect.AssignedTo;
            copyWorksheet.Cells[row, 9].Value = defect.Iteration;
            copyWorksheet.Cells[row, 10].Value = defect.DefectCreateDate.ToString("MM/dd/yyyy");
            copyWorksheet.Cells[row, 11].Value = defect.DefectType;
            copyWorksheet.Cells[row, 12].Value = defect.ApplicationArea;
            copyWorksheet.Cells[row, 13].Value = defect.ApplicationProcess;
            copyWorksheet.Cells[row, 14].Value = defect.FoundInEnvironment;

            return copyWorksheet;
        }

        public void UpdateTestCaseWithDefect(List<Defect> defects, List<TestCase> testCases = null)
        {
            //_testCaseWithDefect = ClearExcelSheetExceptHeader(_testCaseWithDefect, "A", "I");
            TFSCommon.ExcelTools.ExcelTools.ClearExcelSheetExceptHeader(_testCaseWithDefect, "A", "I");

            int rowCount = 2;

            List<String> filterOutArray = new List<String> {  };

            //Console.WriteLine(defects.Count);

            var filteredDefects = defects.Where(o => !filterOutArray.Contains(o.Status) ).ToList<Defect>();

            //Console.WriteLine(filteredDefects.Count);

            Dictionary<int, TestCase> testCaseCollection = new Dictionary<int, TestCase>();

            Dictionary<int, TestCase> testCaseMap = null;
            if (testCases != null)
            {
                testCaseMap = new Dictionary<int, TestCase>();
                foreach(TestCase curr in testCases)
                {
                    testCaseMap[curr.TestCaseId] = curr;
                }
            }

            List<int> testCaseIdsWithDefects = new List<int>();

            foreach (Defect currDefect in defects)
            {
                if (!filterOutArray.Contains(currDefect.Status) && currDefect.TestCases != null)
                {
                    foreach (TestCase currTestCase in currDefect.TestCases)
                    {
                        TestCase gatheredTestCase;
                        if (!testCaseCollection.ContainsKey(currTestCase.TestCaseId))
                        {
                            if (testCases != null)
                            {
                                gatheredTestCase = testCaseMap[currTestCase.TestCaseId];
                            }
                            else
                            {
                                gatheredTestCase = GetTestCasesWebApi.GetTestCaseById(currTestCase.TestCaseId).Result;
                                testCaseCollection[currTestCase.TestCaseId] = gatheredTestCase;
                            }
                        }
                        else
                        {
                            gatheredTestCase = testCaseCollection[currTestCase.TestCaseId];
                        }
                        // Inserting Test Case portion
                        _testCaseWithDefect.Cells[rowCount, 1].Value = gatheredTestCase.TestCaseId;
                        _testCaseWithDefect.Cells[rowCount, 2].Value = gatheredTestCase.TestCaseName;
                        if (gatheredTestCase.CurrentTestCaseResult != null)
                        {
                            _testCaseWithDefect.Cells[rowCount, 3].Value = gatheredTestCase.CurrentTestCaseResult.Result;
                        }
                        _testCaseWithDefect.Cells[rowCount, 4].Value = gatheredTestCase.TestCasePath;

                        _testCaseWithDefect.Cells[rowCount, 12].Value = gatheredTestCase.TestCaseId + "" +
                                                                        gatheredTestCase.TestSuiteId +
                                                                        gatheredTestCase.TestCaseName;

                        //Inserting Defect portion
                        _testCaseWithDefect.Cells[rowCount, 5].Value = currDefect.DefectId;
                        _testCaseWithDefect.Cells[rowCount, 6].Value = currDefect.Status;
                        _testCaseWithDefect.Cells[rowCount, 7].Value = currDefect.DefectName;
                        _testCaseWithDefect.Cells[rowCount, 8].Value = currDefect.DefectSeverity;
                        _testCaseWithDefect.Cells[rowCount, 9].Value = currDefect.FoundInEnvironment;
                        _testCaseWithDefect.Cells[rowCount, 10].Value = currDefect.DefectCreatedBy;
                        _testCaseWithDefect.Cells[rowCount, 11].Value = currDefect.AssignedTo;

                        rowCount += 1;

                        if (!testCaseIdsWithDefects.Contains(currTestCase.TestCaseId))
                        {
                            testCaseIdsWithDefects.Add(currTestCase.TestCaseId);
                        }
                    }
                }
            }

            List<string> failedFilter = new List<string> { "Failed", "Blocked" };

            if (testCases != null)
            {
                foreach (TestCase testCase in testCases)
                {
                    //TestCase gatheredTestCase = getTestCasesWebApi.GetTestCaseById(testCase.TestCaseId).Result;
                    if (!testCaseIdsWithDefects.Contains(testCase.TestCaseId) 
                        && testCase.CurrentTestCaseResult != null
                        && failedFilter.Contains(testCase.CurrentTestCaseResult.Result))
                    {
                        _testCaseWithDefect.Cells[rowCount, 1].Value = testCase.TestCaseId;
                        _testCaseWithDefect.Cells[rowCount, 2].Value = testCase.TestCaseName;
                        if (testCase.CurrentTestCaseResult != null)
                        {
                            _testCaseWithDefect.Cells[rowCount, 3].Value = testCase.CurrentTestCaseResult.Result;
                        }
                        _testCaseWithDefect.Cells[rowCount, 4].Value = testCase.TestCasePath;

                        rowCount += 1;
                    }
                }
            }
        }

        private string ScrubHtml(string value)
        {
            string htmlTagPattern = "<.*?>";
            value = Regex.Replace(value, htmlTagPattern, string.Empty);
            value = value.Replace("&nbsp;", " ");
            value = Regex.Replace(value, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);

            return value;
        }

        public void ExcelCleanup()
        {
            _excelPackage.Save();

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("File has been closed and cleaned up.");
        }
    }
}

