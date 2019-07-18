using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TFSCommon.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace RequirementsTraceability.ExcelTools
{
    class GatherTestScenarioExcel
    {
        private string _fileLocation;
        private string _fileName;

        private Excel.Application _xlApp = new Excel.Application();
        private Excel.Workbook _xlWorkbook;
        private Excel.Worksheet _xlWorksheet;
        private Excel.Range _xlRange;

        public GatherTestScenarioExcel(Properties props)
        {
            _fileLocation = props.SaveLocation;
            _fileName = props.FileName;

            try
            {
                Console.WriteLine(_fileLocation + _fileName);

                _xlWorkbook = _xlApp.Workbooks.Open(_fileLocation + _fileName);

                Console.WriteLine("Excel file is opened.");
            }
            catch
            {
                Console.Write("File Location/Name is not valid. Please press Enter and run the program again.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            _xlWorksheet = _xlWorkbook.Worksheets["PLMSScenario"];
            _xlRange = _xlWorksheet.UsedRange;
        }

        public List<TestScenario> GatherAllTestScenario()
        {
            List<TestScenario> res = new List<TestScenario>();

            //int usedRows = GetUsedRows();
            int usedRows = 121;

            Console.WriteLine(usedRows);

            for (int i = 3; i <= usedRows; i++)
            {
                TestScenario currTestScenario = new TestScenario();
                currTestScenario.ContractRequirementId = Convert.ToInt32(_xlWorksheet.Cells[i, 1].Value2);
                currTestScenario.ScenarioName = _xlWorksheet.Cells[i, 6].Value2;
                currTestScenario.ScenarioDescription = _xlWorksheet.Cells[i, 3].Value2;
                currTestScenario.ApplicationArea = _xlWorksheet.Cells[i, 7].Value2;
                currTestScenario.ApplicationProcess = _xlWorksheet.Cells[i, 8].Value2;

                res.Add(currTestScenario);

                //Console.WriteLine(i);
            }

            return res;
        }

        public void UpdateTestScenarioId(List<TestScenario> testScenarios)
        {
            Dictionary<int, int> requirementIdToRow = new Dictionary<int, int>();
            int usedRows = GetUsedRows();
            for (int i = 3; i <= usedRows; i++)
            {
                requirementIdToRow[Convert.ToInt32(_xlWorksheet.Cells[i, 1])] = i;
            }

            foreach (TestScenario testScenario in testScenarios)
            {
                int currentRow = requirementIdToRow[testScenario.ContractRequirementId];
                _xlWorksheet.Cells[currentRow, 5] = testScenario.TestScenarioId;
            }

            _xlWorkbook.Save();
        }

        public int GetUsedRows()
        {
            int startRow = 3;
            int res = startRow;
            while (_xlWorksheet.Cells[startRow, 1] != null && _xlWorksheet.Cells[startRow, 1].Value2 > 0)
            {
                res += 1;
                Console.WriteLine(res);
            }
            Console.WriteLine(res);
            return res;
        }

        public void ExcelCleanup()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(_xlWorksheet);
            Marshal.ReleaseComObject(_xlRange);

            //close and release
            _xlWorkbook.Close();
            Marshal.ReleaseComObject(_xlWorkbook);

            //quit and release
            _xlApp.Quit();
            Marshal.ReleaseComObject(_xlApp);

            Console.WriteLine("File has been closed and cleaned up.");
        }
    }
}
