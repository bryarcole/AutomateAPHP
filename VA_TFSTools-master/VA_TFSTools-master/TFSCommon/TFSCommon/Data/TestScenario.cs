using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace TFSCommon.Data
{
    public class TestScenario
    {
        [ExplicitKey]
        public int TestScenarioId { get; set; }

        public string ApplicationArea { get; set; }

        public string ApplicationProcess { get; set; }

        public string ScenarioDescription { get; set; }

        public string ScenarioName { get; set; }

        public int ContractRequirementId { get; set; }

        public List<TestCase> TestCases { get; set; }
    }
}
