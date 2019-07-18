using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
//using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace TFSReporting.ExcelTools
{
    class UpdateExecutionInputData
    {
        private string _fileName;
        private string _saveLocation;
        private string _executionSheetName;
        private string _scriptSheetName;

        //private Excel.Application _xlApp = new Excel.Application();
        //private Excel.Workbook _xlWorkbook;
        //private Excel.Worksheet _xlWorksheet;

        private ExcelPackage _excelPackage;
        private ExcelWorkbook _excelWorkbook;
        private ExcelWorksheet _excelWorksheet;

        private int _rowCount;

        public UpdateExecutionInputData()
        {

        }

        public UpdateExecutionInputData(Properties props)
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
                //_excelWorkbook.CalcMode = ExcelCalcMode.Manual;

                Console.WriteLine("Excel file is opened.");
            }
            catch
            {
                Console.Write("File Location/Name is not valid. Please press Enter and run the program again.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            _excelWorksheet = _excelWorkbook.Worksheets[_scriptSheetName];
            //Console.WriteLine(_xlWorksheet.Name);
        }

        public void UpdateExcelExecutionInputData(List<TestCase> testCases)
        {
            int _rowCount = 2;

            // Generate ID to Row Mapping 
            Dictionary<int, int> idToRowMapping = new Dictionary<int, int>();

            while (_excelWorksheet.Cells[_rowCount, 5] != null && _excelWorksheet.Cells[_rowCount, 5].Text != "")
            {
                if (_excelWorksheet.Cells[_rowCount, 1] != null && _excelWorksheet.Cells[_rowCount, 1].Text != "")
                {
                    idToRowMapping[Convert.ToInt32(_excelWorksheet.Cells[_rowCount, 1].Text)] = _rowCount;
                }
                _rowCount += 1;
            }

            _excelWorksheet = TFSCommon.ExcelTools.ExcelTools.ClearExcelSheetExceptHeader(_excelWorksheet, "A", "AE");

            int currentRow = 2;
            foreach (TestCase currTestCase in testCases)
            {
                WriteToExcelRow(currTestCase, currentRow);
                currentRow += 1;
            }

            // Add in test cases if they do not exist in the ID to Row Mapping. Otherwise, update existing test case if there were changes. 
            //List<int> testCaseIdsInDb = new List<int>();
            //int currentWrittenRow = _rowCount;
            //foreach (TestCase currTestCase in testCases)
            //{
            //    if (!idToRowMapping.ContainsKey(currTestCase.TestCaseId))
            //    {
            //        WriteToExcelRow(currTestCase, currentWrittenRow);
            //        currentWrittenRow += 1;
            //    }
            //    else
            //    {
            //        _excelWorksheet.Cells[idToRowMapping[currTestCase.TestCaseId], 4].Value = currTestCase.TestSuiteId;
            //        _excelWorksheet.Cells[idToRowMapping[currTestCase.TestCaseId], 5].Value = currTestCase.TestCaseName;

            //        _excelWorksheet.Cells[idToRowMapping[currTestCase.TestCaseId], 18].Value = currTestCase.CurrentIteration;
            //        _excelWorksheet.Cells[idToRowMapping[currTestCase.TestCaseId], 28].Value = currTestCase.TestCaseId + "" +
            //                                                                                    currTestCase.TestSuiteId +
            //                                                                                    currTestCase.TestCaseName;
            //        _excelWorksheet.Cells[idToRowMapping[currTestCase.TestCaseId], 31].Value = currTestCase.TestCasePath;
            //    }

            //    testCaseIdsInDb.Add(currTestCase.TestCaseId);
            //}

            //// Clear deleted test cases (leave rows as blank)
            //foreach (int currId in idToRowMapping.Keys)
            //{
            //    if (!testCaseIdsInDb.Contains(currId))
            //    {
            //        int currRow = idToRowMapping[currId];
            //        string rangeString = "A" + currRow + ":AE" + currRow;
            //        _excelWorksheet.Cells[rangeString].Clear();
            //    }
            //}

            //// Second pass. Delete blank rows. 
            //int currCount = 2;
            //for (int i = 2; i <= idToRowMapping.Values.Count; i++)
            //{
            //    if (_excelWorksheet.Cells[currCount, 1] == null)
            //    {
            //        _excelWorksheet.DeleteRow(currCount);
            //    }
            //    else
            //    {
            //        currCount += 1;
            //    }
            //}            
        }

        private void WriteToExcelRow(TestCase testCase, int row)
        {
            _excelWorksheet.Cells[row, 1].Value = testCase.TestCaseId;
            _excelWorksheet.Cells[row, 4].Value = testCase.TestSuiteId;
            _excelWorksheet.Cells[row, 5].Value = testCase.TestCaseName;
            _excelWorksheet.Cells[row, 6].Value = testCase.TestObjective;
            _excelWorksheet.Cells[row, 7].Value = testCase.TestDescription;
            _excelWorksheet.Cells[row, 8].Value = testCase.PreCondition;
            _excelWorksheet.Cells[row, 9].Value = testCase.Priority;
            _excelWorksheet.Cells[row, 10].Value = testCase.Complexity;
            _excelWorksheet.Cells[row, 11].Value = testCase.ScenarioType;
            _excelWorksheet.Cells[row, 12].Value = testCase.Application;
            _excelWorksheet.Cells[row, 13].Value = testCase.ApplicationArea;
            _excelWorksheet.Cells[row, 14].Value = testCase.ApplicationProcess;
            _excelWorksheet.Cells[row, 15].Value = testCase.ApplicationSubArea;
            _excelWorksheet.Cells[row, 16].Value = testCase.TestCaseType;

            _excelWorksheet.Cells[row, 18].Value = testCase.CurrentIteration;

            _excelWorksheet.Cells[row, 28].Value = testCase.TestCaseId + "" + testCase.TestSuiteId + testCase.TestCaseName;

            _excelWorksheet.Cells[row, 31].Value = testCase.TestCasePath;

            // Calculated values
            string lookupCellValue = "AB" + row;
            _excelWorksheet.Cells[row, 29].Formula = "VLOOKUP(" + lookupCellValue + ",'Execution Actuals'!AB:AC,2,FALSE)";
            //_excelWorksheet.Cells[row, 28].Formula = "CONCAT(A" + row + ", D" + row + ", E" + row + ")";
            _excelWorksheet.Cells[row, 22].Formula = "INDEX('Execution Actuals'!V:V,MATCH('Execution Input Data'!" + lookupCellValue + ",'Execution Actuals'!AB:AB,FALSE),1)";
            _excelWorksheet.Cells[row, 21].Formula = "INDEX('Execution Actuals'!U:U,MATCH('Execution Input Data'!" + lookupCellValue + ",'Execution Actuals'!AB:AB,FALSE),1)";
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
