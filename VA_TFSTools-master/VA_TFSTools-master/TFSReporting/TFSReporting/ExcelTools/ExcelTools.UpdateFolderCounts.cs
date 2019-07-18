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
    class UpdateFolderCounts
    {
        private string _fileName;
        private string _saveLocation;

        //private Excel.Application _xlApp = new Excel.Application();
        //private Excel.Workbook _xlWorkbook;
        //private Excel.Worksheet _xlWorksheet;

        private ExcelPackage _excelPackage;
        private ExcelWorkbook _excelWorkbook;
        private ExcelWorksheet _excelWorksheet;

        private Dictionary<int, string> _rowToTestCasePathMapping;

        private int _rowCount;

        private Properties _props;

        public UpdateFolderCounts(Properties props)
        {
            _props = props;

            _fileName = props.FileName;
            _saveLocation = props.SaveLocation;

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

            _excelWorksheet = _excelWorkbook.Worksheets[props.FolderCountsSheetName];
            //Console.WriteLine(_xlWorksheet.Name);

            _rowToTestCasePathMapping = GenerateRowToTestCaseMapping();
        }

        public void UpdateSheet()
        {
            foreach (KeyValuePair<int, string> curr in _rowToTestCasePathMapping)
            {
                List<TestCase> testCasesFailedWithMinorDefect = GetTestCasesWebApi.GetTestCaseFailedWithMinorDefect(curr.Value).Result;
                //Console.WriteLine(curr.Value + ": " + testCasesFailedWithMinorDefect.Count);
                // Count of Test Cases that are Ready For Test with a Medium/Low defect and are in Failed status only.
                string formula = "-COUNTIFS(" + _props.ReadyForTestMediumLowSheetName + @"!D: D, 
                                    'Folder Counts'!F" + curr.Key + ", "
                                    + _props.ReadyForTestMediumLowSheetName + "!C: C, \"Failed\")";
                _excelWorksheet.Cells[curr.Key, 11].Formula = testCasesFailedWithMinorDefect.Count + "-N" + curr.Key;
            }
        }

        private Dictionary<int, string> GenerateRowToTestCaseMapping()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();

            int usedRows = 2;
            while (_excelWorksheet.Cells[usedRows, 16] != null && _excelWorksheet.Cells[usedRows, 16].Text != "")
            {
                usedRows += 1;
            }
            Console.WriteLine(usedRows);

            for (int i = 2; i < usedRows; i++)
            {
                if (_excelWorksheet.Cells[i, 16].Text != "###")
                {
                    res[i] = _excelWorksheet.Cells[i, 6].Text; 
                }
            }

            return res;
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
