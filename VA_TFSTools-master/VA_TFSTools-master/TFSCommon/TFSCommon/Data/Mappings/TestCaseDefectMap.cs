using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSCommon.Data.Mappings
{
    public class TestCaseDefectMap
    {
        public TestCaseDefectMap() { }

        [Key]
        public int TestCaseDefectId { get; set; }

        public int TestCaseId { get; set; }

        public int DefectId { get; set; }
    }
}
