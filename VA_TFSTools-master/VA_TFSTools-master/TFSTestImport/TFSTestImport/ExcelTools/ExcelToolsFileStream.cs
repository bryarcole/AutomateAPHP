using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace TFSTestImport.ExcelTools
{
    class ExcelToolsFileStream
    {
        private FileStream _fileStream;

        public ExcelToolsFileStream(FileStream fileStream)
        {
            _fileStream = fileStream;
        }

        public Dictionary<string, string> GetProps()
        {
            return null;
        }
    }
}
