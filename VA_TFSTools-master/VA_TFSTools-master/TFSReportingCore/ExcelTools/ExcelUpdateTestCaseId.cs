using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSReporting.Data;
using OfficeOpenXml;
using System.IO;

namespace TFSReporting.ExcelTools
{
    class ExcelUpdateTestCaseId
    {
        private string _fileName;
        private string _saveLocation;
        private string _executionSheetName;
        private string _scriptSheetName;

        //private Excel.Application _xlApp = new Excel.Application();
        //private Excel.Workbook _xlWorkbook;
        //private Excel.Worksheet _xlWorksheet;
        //private Excel.Range _xlRange;

        private ExcelPackage _excelPackage;
        private ExcelWorkbook _excelWorkbook;
        private ExcelWorksheet _excelWorksheet;

        private int _rowCount;

        public ExcelUpdateTestCaseId()
        {

        }

        public ExcelUpdateTestCaseId(Properties props)
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

            _excelWorksheet = _excelWorkbook.Worksheets["Execution Input Data"];
        }

        public List<TestCaseRowMapping> GetTestCaseRowMappings()
        {
            List<TestCaseRowMapping> res = new List<TestCaseRowMapping>();

            int _rowCount = 3;
            while (_excelWorksheet.Cells[_rowCount, 5] != null && _excelWorksheet.Cells[_rowCount, 5].Text != "")
            {
                _rowCount += 1;
            }

            //Console.WriteLine(_rowCount);

            for (int i = 3; i < _rowCount; i++)
            {
                TestCaseRowMapping temp = new TestCaseRowMapping
                {
                    RowNumber = i,
                    TestCaseName = _excelWorksheet.Cells[i, 5].Text,
                };

                if (_excelWorksheet.Cells[i, 4] != null
                    && _excelWorksheet.Cells[i, 4].Text != null)
                {
                    if (IsDigitsOnly(_excelWorksheet.Cells[i, 4].Text))
                    {
                        temp.TestSuiteId = Convert.ToInt32(_excelWorksheet.Cells[i, 4].Text);
                        res.Add(temp);
                    }
                }
            }

            return res;
        }

        private bool IsDigitsOnly(string str)
        {
            if (str.Length == 0)
            {
                return false;
            }
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public void UpdateTestCaseId(List<TestCaseRowMapping> testCaseRowMappings)
        {
            foreach (TestCaseRowMapping curr in testCaseRowMappings)
            {
                if (_excelWorksheet.Cells[curr.RowNumber, 1].Text == "")
                {
                    _excelWorksheet.Cells[curr.RowNumber, 1].Value = curr.TestCaseId;
                }
            }

            //_excelWorkbook.Save();
        }

        public void ExcelCleanup()
        {
            _excelPackage.Save();
            _excelPackage.Dispose();

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            //Marshal.ReleaseComObject(_xlWorksheet);
            //Marshal.ReleaseComObject(_xlRange);

            //close and release
            //_xlWorkbook.Close();
            //Marshal.ReleaseComObject(_xlWorkbook);

            //quit and release
            //_xlApp.Quit();
            //Marshal.ReleaseComObject(_xlApp);

            Console.WriteLine("File has been closed and cleaned up.");
        }
    }
}
