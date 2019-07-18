using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSReporting.WebAPITools;

namespace TFSReporting.ExcelTools
{
    public class UpdateTestCaseReadyForTest
    {
        private string _fileName;
        private string _saveLocation;

        private Properties _props;

        private ExcelPackage _excelPackage;
        private ExcelWorkbook _excelWorkbook;

        private ExcelWorksheet _critHighDefects;
        private ExcelWorksheet _mediumLowDefects;

        public UpdateTestCaseReadyForTest(Properties props)
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

                _critHighDefects = _excelWorkbook.Worksheets[props.ReadyForTestCriticalHighSheetName];
                _mediumLowDefects = _excelWorkbook.Worksheets[props.ReadyForTestMediumLowSheetName];

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

        public void UpdateBothSheets()
        {
            string[] testCaseStatusesFilterBlockedFailed = new string[] { "Blocked", "Failed" };
            string[] testCaseStatusesFilterFailed = new string[] { "Failed" };

            string[] critHighSeverity = new string[] { "1 - Critical", "2 - High" };
            List<TestCase> critHighTestCasesReadyForTest = GetTestCasesWebApi.GetTestCasesReadyForTest(critHighSeverity, testCaseStatusesFilterBlockedFailed).Result;

            _critHighDefects = UpdateSingleSheet(_critHighDefects, critHighTestCasesReadyForTest);

            string[] medLowSeverity = new string[] { "3 - Medium", "4 - Low" };
            List<TestCase> medLowTestCasesReadyForTest = GetTestCasesWebApi.GetTestCasesReadyForTest(medLowSeverity, testCaseStatusesFilterBlockedFailed).Result;

            _mediumLowDefects = UpdateSingleSheet(_mediumLowDefects, medLowTestCasesReadyForTest);
        }

        private ExcelWorksheet UpdateSingleSheet(ExcelWorksheet worksheet, List<TestCase> testCases)
        {
            ExcelWorksheet copyWorksheet = worksheet;
            copyWorksheet = TFSCommon.ExcelTools.ExcelTools.ClearExcelSheetExceptHeader(worksheet, "A", "G");

            string[] defectStatusFilter = new string[] { "Rejected", "Closed", "Resolved" };

            int currRow = 2;
            foreach(TestCase curr in testCases)
            {
                copyWorksheet.Cells[currRow, 1].Value = curr.TestCaseId;
                copyWorksheet.Cells[currRow, 2].Value = curr.TestCaseName;
                copyWorksheet.Cells[currRow, 3].Value = curr.CurrentTestCaseResult.Result;
                copyWorksheet.Cells[currRow, 4].Value = curr.TestCasePath;

                Defect defect = null;
                foreach(Defect currDefect in curr.Defects)
                {
                    if (defectStatusFilter.Contains(currDefect.Status))
                    {
                        defect = currDefect;
                    }
                }

                if (defect != null)
                {
                    copyWorksheet.Cells[currRow, 5].Value = defect.DefectId;
                    copyWorksheet.Cells[currRow, 6].Value = defect.DefectName;
                    copyWorksheet.Cells[currRow, 7].Value = defect.Status;
                }

                currRow += 1;
            }

            return copyWorksheet;
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
