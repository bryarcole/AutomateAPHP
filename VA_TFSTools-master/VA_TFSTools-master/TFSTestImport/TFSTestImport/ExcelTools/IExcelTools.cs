using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;

namespace TFSTestImport.ExcelTools
{
    interface IExcelTools
    {
        Properties GetProps(Properties props);
        List<TestCase> GetTestCases();
    }
}
