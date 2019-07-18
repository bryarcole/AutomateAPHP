using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TFSCommon.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace RequirementsTraceability.ExcelTools
{
    class ContractRequirementUpdateExcel
    {
        private string _fileName;
        private string _saveLocation;
        private string _executionSheetName;
        private string _scriptSheetName;

        private Excel.Application _xlApp = new Excel.Application();
        private Excel.Workbook _xlWorkbook;
        private Excel.Worksheet _xlWorksheet;
        private Excel.Range _xlRange;

        private Dictionary<string, int> _mapping;

        public ContractRequirementUpdateExcel(Properties props)
        {
            _fileName = props.FileName;
            _saveLocation = props.SaveLocation;
            _executionSheetName = props.ExecutionSheetName;
            _scriptSheetName = props.ScriptSheetName;

            try
            {
                _xlWorkbook = _xlApp.Workbooks.Open(_saveLocation + _fileName);
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

            _mapping = new Dictionary<string, int>();
        }

        public void UpdateScenarioSheet(List<ContractRequirement> contractRequirements)
        {
            _mapping = GetMapping(contractRequirements);

            //int numRow = GetUsedRows(_xlWorksheet);
            int numRow = 121;
            Console.WriteLine(numRow);
            for (int i = 3; i <= numRow; i++)
            {
                Console.WriteLine(_xlWorksheet.Cells[i, 2].Value2);
                if (_mapping.ContainsKey(_xlWorksheet.Cells[i, 2].Value2))
                {
                    _xlWorksheet.Cells[i, 1] = _mapping[_xlWorksheet.Cells[i, 2].Value2];
                }
            }

            _xlWorkbook.Save();
        }

        public int GetUsedRows(Excel.Worksheet wk)
        {
            int res = 3;
            while (wk.Cells[res, 2].Value2 != null)
            {
                res += 1;
            }
            return res - 1;
        }

        public Dictionary<string, int> GetMapping(List<ContractRequirement> contractRequirement)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            foreach (ContractRequirement currReq in contractRequirement)
            {
                res.Add(currReq.RequirementTitle, currReq.RequirementID);
            }

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
