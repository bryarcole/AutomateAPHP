using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using OfficeOpenXml;
using System.IO;

namespace TFSReporting.ExcelTools
{
    class UpdateDailyDefect
    {
        private string _fileName;
        private string _saveLocation;
        private string _executionSheetName;
        private string _scriptSheetName;

        //private Excel.Application _xlApp = new Excel.Application();
        //private Excel.Workbook _xlWorkbook;
        //private Excel.Worksheet _scriptWorksheet;
        //private Excel.Range _scriptSheetRange;
        //private Excel.Worksheet _executionWorksheet;
        //private Excel.Range _executionSheetRange;

        private ExcelPackage _excelPackage;
        private ExcelWorkbook _excelWorkbook;
        private ExcelWorksheet _scriptWorksheet;
        private ExcelWorksheet _executionWorksheet;

        private Dictionary<int, int> _mappedScriptIdToRow;
        private Dictionary<double, int> _mappedScriptIdToTestRunId;

        public UpdateDailyDefect()
        {

        }

        public UpdateDailyDefect(Properties props)
        {
            _fileName = props.FileName;
            _saveLocation = props.SaveLocation;
            _executionSheetName = props.ExecutionSheetName;
            _scriptSheetName = props.ScriptSheetName;

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

                Console.WriteLine("Excel file is opened.");
            }
            catch
            {
                Console.Write("File Location/Name is not valid. Please press Enter and run the program again.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            _scriptWorksheet = _excelWorkbook.Worksheets[_scriptSheetName];
            _executionWorksheet = _excelWorkbook.Worksheets[_executionSheetName];

            //_scriptWorksheet = _xlWorkbook.Worksheets[_scriptSheetName];
            //_executionWorksheet = _xlWorkbook.Worksheets[_executionSheetName];
            //_scriptSheetRange = _scriptWorksheet.UsedRange;
            //_executionSheetRange = _executionWorksheet.UsedRange;

            _mappedScriptIdToRow = new Dictionary<int, int>();
            _mappedScriptIdToTestRunId = new Dictionary<double, int>();

            SetupMapping();

            //_xlApp.Calculation = Excel.XlCalculation.xlCalculationManual;
        }

        public void UpdateTestResultsSingle(List<TestCase> testCases)
        {
            int rowCount = 1;
            while (_scriptWorksheet.Cells[rowCount, 1] != null && _scriptWorksheet.Cells[rowCount, 1].Text != "")
            {
                rowCount += 1;
            }

            Dictionary<int, int> idToRowMapping = new Dictionary<int, int>();
            for (int i = 3; i < rowCount; i++)
            {
                if (_scriptWorksheet.Cells[i, 1].Text != "")
                {
                    idToRowMapping[Convert.ToInt32(_scriptWorksheet.Cells[i, 1].Text)] = i;
                }
            }

            double maxCount = testCases.Count;

            Console.Write("Writing most recent Test Results: ");

            using (var progress = new ProgressBar())
            {
                double currentCount = 0;
                foreach (TestCase tempTestCase in testCases)
                {
                    progress.Report(currentCount / maxCount);

                    if (idToRowMapping.ContainsKey(tempTestCase.TestCaseId))
                    {
                        _scriptWorksheet.Cells[idToRowMapping[tempTestCase.TestCaseId], 22].Value = tempTestCase.CurrentTestCaseResult.Result;
                        _scriptWorksheet.Cells[idToRowMapping[tempTestCase.TestCaseId], 29].Value = tempTestCase.CurrentTestCaseResult.ResultDT;
                    }

                    currentCount += 1;
                }

                Console.Write("Done.");
            }

            Console.WriteLine();

            //_excelPackage.Save();

            //_xlWorkbook.Save();
        }

        public void UpdateTestResultsActuals(List<TestCase> testCases)
        {
            // Test Case ID - Column 1
            // Test Scenarios - Column 2
            // Test Suite ID - Column 3
            // Application Area - Column 4
            // Application Process - Column 5
            // Application Sub Area - Column 6
            // Test Case Name - Column 7
            // Test Case Result - Column 13

            // 1. Gather test case data from Script worksheet that match up to the scripts in testCases
            // 2. Copy information from Script worksheet into the proper rows in Execution worksheet

            int rowCount = 2;
            while (_executionWorksheet.Cells[rowCount, 1] != null && _executionWorksheet.Cells[rowCount, 1].Text != "")
            {
                rowCount += 1;
            }

            //Console.WriteLine(rowCount);

            List<TestCase> resultByDate = new List<TestCase>();
            int currRowCount = rowCount;

            Console.Write("Writing Test Case Actuals: ");

            using (var progress = new ProgressBar())
            {
                foreach (TestCase tempTestCase in testCases)
                {
                    //Console.WriteLine(tempTestCase.TestCaseId);
                    progress.Report((double)currRowCount - rowCount / (double)testCases.Count);
                    if (_mappedScriptIdToRow.ContainsKey(tempTestCase.TestCaseId))
                    {
                        TestCase UpdatedTestCase = GatherTestScriptInformation(tempTestCase);
                        //TestCase UpdatedTestCase = tempTestCase;

                        double currHashValue = Convert.ToDouble(UpdatedTestCase.TestCaseId.ToString() +
                            UpdatedTestCase.CurrentTestCaseResult.TestRunId.ToString());
                        if (!_mappedScriptIdToTestRunId.ContainsKey(currHashValue))
                        {
                            _executionWorksheet.Cells[currRowCount, 1].Value = UpdatedTestCase.TestCaseId;
                            _executionWorksheet.Cells[currRowCount, 4].Value = UpdatedTestCase.TestSuiteId;
                            _executionWorksheet.Cells[currRowCount, 5].Value = UpdatedTestCase.TestCaseName;
                            _executionWorksheet.Cells[currRowCount, 6].Value = UpdatedTestCase.TestObjective;
                            _executionWorksheet.Cells[currRowCount, 7].Value = UpdatedTestCase.TestDescription;
                            _executionWorksheet.Cells[currRowCount, 8].Value = UpdatedTestCase.PreCondition;
                            _executionWorksheet.Cells[currRowCount, 9].Value = UpdatedTestCase.PriorityString;
                            _executionWorksheet.Cells[currRowCount, 10].Value = UpdatedTestCase.Complexity;
                            _executionWorksheet.Cells[currRowCount, 11].Value = UpdatedTestCase.ScenarioType;
                            _executionWorksheet.Cells[currRowCount, 12].Value = UpdatedTestCase.Application;
                            _executionWorksheet.Cells[currRowCount, 13].Value = UpdatedTestCase.ApplicationArea;
                            _executionWorksheet.Cells[currRowCount, 14].Value = UpdatedTestCase.ApplicationProcess;
                            _executionWorksheet.Cells[currRowCount, 15].Value = UpdatedTestCase.ApplicationSubArea;
                            _executionWorksheet.Cells[currRowCount, 16].Value = UpdatedTestCase.TestCaseType;
                            _executionWorksheet.Cells[currRowCount, 17].Value = UpdatedTestCase.CurrentIteration;
                            _executionWorksheet.Cells[currRowCount, 18].Value = UpdatedTestCase.OriginalIteration;
                            // Column 19 will be filled in by Test Lead
                            _executionWorksheet.Cells[currRowCount, 20].Value = UpdatedTestCase.ScriptLeadName;
                            _executionWorksheet.Cells[currRowCount, 21].Value = UpdatedTestCase.CurrentTestCaseResult.RunByName;
                            _executionWorksheet.Cells[currRowCount, 22].Value = UpdatedTestCase.CurrentTestCaseResult.Result;
                            // Not going to use Expected Result column
                            _executionWorksheet.Cells[currRowCount, 23].Value = UpdatedTestCase.WPTask;
                            _executionWorksheet.Cells[currRowCount, 24].Value = UpdatedTestCase.BaselineStartDate;
                            _executionWorksheet.Cells[currRowCount, 25].Value = UpdatedTestCase.BaselineEndDate;
                            _executionWorksheet.Cells[currRowCount, 26].Value = UpdatedTestCase.PlannedStartDate;
                            _executionWorksheet.Cells[currRowCount, 27].Value = UpdatedTestCase.PlannedEndDate;
                            _executionWorksheet.Cells[currRowCount, 28].Value = UpdatedTestCase.ActualStartDate;
                            _executionWorksheet.Cells[currRowCount, 29].Value = UpdatedTestCase.CurrentTestCaseResult.ResultDT.ToString();
                            _executionWorksheet.Cells[currRowCount, 30].Value = UpdatedTestCase.CurrentTestCaseResult.TestRunId;

                            //Console.WriteLine(UpdatedTestCase.BaselineEndDate);
                            //Console.WriteLine(UpdatedTestCase.PlannedStartDate);
                            //Console.WriteLine(UpdatedTestCase.PlannedEndDate);
                            //Console.WriteLine(UpdatedTestCase.ActualStartDate);

                            currRowCount += 1;

                            //Console.WriteLine("Test Exection for Test Case ID #{0} has been written", UpdatedTestCase.TestCaseId);
                        }
                    }
                    else
                    {
                        double currHashValue = Convert.ToDouble(tempTestCase.TestCaseId.ToString() +
                            tempTestCase.CurrentTestCaseResult.TestRunId.ToString());
                        if (!_mappedScriptIdToTestRunId.ContainsKey(currHashValue))
                        {
                            _executionWorksheet.Cells[currRowCount, 1].Value = tempTestCase.TestCaseId;
                            _executionWorksheet.Cells[currRowCount, 4].Value = tempTestCase.TestSuiteId;
                            _executionWorksheet.Cells[currRowCount, 5].Value = tempTestCase.TestCaseName;
                            _executionWorksheet.Cells[currRowCount, 6].Value = tempTestCase.TestObjective;
                            _executionWorksheet.Cells[currRowCount, 7].Value = tempTestCase.TestDescription;
                            _executionWorksheet.Cells[currRowCount, 8].Value = tempTestCase.PreCondition;
                            _executionWorksheet.Cells[currRowCount, 9].Value = tempTestCase.PriorityString;
                            _executionWorksheet.Cells[currRowCount, 10].Value = tempTestCase.Complexity;
                            _executionWorksheet.Cells[currRowCount, 11].Value = tempTestCase.ScenarioType;
                            _executionWorksheet.Cells[currRowCount, 12].Value = tempTestCase.Application;
                            _executionWorksheet.Cells[currRowCount, 13].Value = tempTestCase.ApplicationArea;
                            _executionWorksheet.Cells[currRowCount, 14].Value = tempTestCase.ApplicationProcess;
                            _executionWorksheet.Cells[currRowCount, 15].Value = tempTestCase.ApplicationSubArea;
                            _executionWorksheet.Cells[currRowCount, 16].Value = tempTestCase.TestCaseType;
                            _executionWorksheet.Cells[currRowCount, 17].Value = tempTestCase.CurrentIteration;
                            _executionWorksheet.Cells[currRowCount, 18].Value = tempTestCase.OriginalIteration;
                            _executionWorksheet.Cells[currRowCount, 29].Value = tempTestCase.CurrentTestCaseResult.ResultDT.ToString();
                            _executionWorksheet.Cells[currRowCount, 30].Value = tempTestCase.CurrentTestCaseResult.TestRunId;

                            currRowCount += 1;
                        }
                    }
                }

                Console.Write("Done.");
            }

            Console.WriteLine("{0} test case results have been written.", currRowCount - rowCount);
            Console.WriteLine("{0} duplicate transactions were not written.", testCases.Count - (currRowCount - rowCount));

            //_xlWorkbook.Save();

            //_excelPackage.Save();
        }

        public List<TestCase> GatherTestResultSpecificDate(List<TestCase> testCases, DateTime dateTime)
        {
            List<TestCase> res = new List<TestCase>();

            Dictionary<int, TestCase> currentDateDictionary = new Dictionary<int, TestCase>();

            foreach (TestCase currTestCase in testCases)
            {
                //if (currTestCase.TestCaseResults.Count > 0)
                //{
                //    foreach (TestCaseResult currTestCaseResult in currTestCase.TestCaseResults)
                //    {
                //        if (currTestCaseResult.Date == dateTime.Date)
                //        {
                //            res.Add(currTestCase);
                //        }
                //    }
                //}
                if (currTestCase.CurrentTestCaseResult.ResultDT.Date == dateTime.Date)
                {
                    if (!currentDateDictionary.ContainsKey(currTestCase.TestCaseId))
                    {
                        currentDateDictionary[currTestCase.TestCaseId] = currTestCase;
                    }

                    if (currTestCase.CurrentTestCaseResult.ResultDT > currentDateDictionary[currTestCase.TestCaseId].CurrentTestCaseResult.ResultDT)
                    {
                        Console.WriteLine("Repeat Execution on Same Day for Test Case {0}", currTestCase.TestCaseId);
                        currentDateDictionary[currTestCase.TestCaseId] = currTestCase;
                    }
                }
            }

            res = currentDateDictionary.Values.ToList<TestCase>();

            //Console.WriteLine(dateTime.ToString() + ": " + res.Count);

            return res;
        }

        public void SetupMapping()
        {
            //Dictionary<int, int> scriptIdToRow = new Dictionary<int, int>();

            int rowCount = GetUsedRows(_scriptWorksheet);
            //Console.WriteLine("RowCount: {0}", rowCount);

            int startRow = 3;

            for (int i = startRow; i < rowCount; i++)
            {
                _mappedScriptIdToRow[Convert.ToInt32(_scriptWorksheet.Cells[i, 1].Value)] = i;
            }

            int rowExecutionCount = GetUsedRows(_executionWorksheet);
            //Console.WriteLine("RowExecutionCount: {0}", rowExecutionCount);

            for (int j = startRow; j < rowExecutionCount; j++)
            {
                double hashValue = Convert.ToDouble(_executionWorksheet.Cells[j, 1].Text + 
                    _executionWorksheet.Cells[j, 30].Text);
                _mappedScriptIdToTestRunId[hashValue] = 0;
            }

        }

        public TestCase GatherTestScriptInformation(TestCase testCase)
        {
            // Original Iteration - Column 16
            // Current Iteration - Column 17
            // Original Baseline - Column 18
            // Script Lead Name - Column 22
            // Tester Name - Column 24
            // WP Task - Column 25
            // Baseline Start Date - Column 26
            // Baseline End Date - Column 27
            // Planned Start Date - Column 28
            // Planned End Date - Column 29
            // Actual Start Date - Column 30
            // Actual End Date - Column 31
            //Console.WriteLine(_mappedScriptIdToRow[testCase.TestCaseId]);
            if (_mappedScriptIdToRow.ContainsKey(testCase.TestCaseId))
            {
                int testScriptRow = _mappedScriptIdToRow[testCase.TestCaseId];

                //testCase.TestObjective = _scriptWorksheet.Cells[testScriptRow, 5].Text;
                //testCase.TestDescription = _scriptWorksheet.Cells[testScriptRow, 6].Text;
                //testCase.PreCondition = _scriptWorksheet.Cells[testScriptRow, 7].Text;
                //testCase.Priority = _scriptWorksheet.Cells[testScriptRow, 8].Text;
                //testCase.Priority = _scriptWorksheet.Cells[testScriptRow, 8].Text;
                //testCase.Priority = _scriptWorksheet.Cells[testScriptRow, 8].Text;
                //testCase.Priority = _scriptWorksheet.Cells[testScriptRow, 8].Text;
                testCase.PriorityString = _scriptWorksheet.Cells[testScriptRow, 9].Text;
                testCase.OriginalIteration = Convert.ToInt32(_scriptWorksheet.Cells[testScriptRow, 17].Text);
                testCase.CurrentIteration = Convert.ToInt32(_scriptWorksheet.Cells[testScriptRow, 18].Text);
                testCase.ScriptLeadName = _scriptWorksheet.Cells[testScriptRow, 20].Text;
                testCase.TesterName = _scriptWorksheet.Cells[testScriptRow, 21].Text;
                testCase.WPTask = _scriptWorksheet.Cells[testScriptRow, 23].Text;
                testCase.BaselineStartDate = _scriptWorksheet.Cells[testScriptRow, 24].Text;
                testCase.BaselineEndDate = _scriptWorksheet.Cells[testScriptRow, 25].Text;
                testCase.PlannedStartDate = _scriptWorksheet.Cells[testScriptRow, 26].Text;
                testCase.PlannedEndDate = _scriptWorksheet.Cells[testScriptRow, 27].Text;

                return testCase;
            }
            else
            {
                Console.WriteLine("Test Case does not exist in the {0} sheet", _scriptSheetName);
                return null;
            }
            
        }

        public void ExcelCleanup()
        {
            //_xlApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;

            //var fileInfo = new FileInfo(_saveLocation + _fileName + ".updated");

            //_excelWorkbook.CalcMode = ExcelCalcMode.Automatic;

            //_excelWorkbook.Calculate();
            //Console.WriteLine(_excelWorkbook.Names.ToString());
            _excelPackage.Save();

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            //Marshal.ReleaseComObject(_scriptSheetRange);
            //Marshal.ReleaseComObject(_scriptWorksheet);
            //Marshal.ReleaseComObject(_executionWorksheet);
            //Marshal.ReleaseComObject(_executionSheetRange);

            //close and release
            //_xlWorkbook.Close();
            //Marshal.ReleaseComObject(_excelWorkbook);

            //quit and release
            //_xlApp.Quit();
            //_excelPackage.Dispose();
            //Marshal.ReleaseComObject(_excelPackage);



            Console.WriteLine("File has been closed and cleaned up.");
        }

        public int GetUsedRows(ExcelWorksheet wk)
        {
            int res = 1;
            while (wk.Cells[res, 1] != null && wk.Cells[res, 1].Text != "")
            {
                res += 1;
            }
            return res;
        }
    }
}
