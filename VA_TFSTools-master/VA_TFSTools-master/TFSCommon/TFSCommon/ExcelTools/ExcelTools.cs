using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSCommon.ExcelTools
{
    public static class ExcelTools
    {
        public static ExcelWorksheet ClearExcelSheetExceptHeader(ExcelWorksheet worksheet, string startColumn, string endColumn)
        {
            ExcelWorksheet copyWorksheet = worksheet;
            int rowCount = 2;
            while (copyWorksheet.Cells[rowCount, 1] != null && copyWorksheet.Cells[rowCount, 1].Text != "")
            {
                string currRow = startColumn + rowCount + ":" + endColumn + rowCount;
                copyWorksheet.Cells[currRow].Clear();
                rowCount += 1;
            }

            return copyWorksheet;
        }
    }
}
