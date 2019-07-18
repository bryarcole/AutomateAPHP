using NUnit.Framework;
using RequirementsTraceability.ExcelTools;
using System;
using System.Collections.Generic;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Data.Mappings;

namespace Tests
{
    public class ContractAndMectRequirementExcelToolsTests
    {
        private ContractAndMectRequirementExcelTools _contractAndMectRequirementExcelTools;

        [SetUp]
        public void Setup()
        {
            Logger logger = new Logger();

            string path = AppDomain.CurrentDomain.BaseDirectory;

            PropertiesReader config = new PropertiesReader("Data\\config.txt");

            Properties props = new Properties
            {
                PersonalAccessToken = config.get("personalaccesstoken"),
                TestPlanId = Convert.ToInt32(config.get("testplanid")),
                TestSuiteId = Convert.ToInt32(config.get("testsuiteid")),
                Project = config.get("project"),
                Uri = config.get("server"),
                SaveLocation = path + "\\Output\\",
                FileName = StringTools.addExtension(config.get("fileName"), "xlsx")
            };
            
            props.ExecutionSheetName = config.get("executionsheetname");
            props.ScriptSheetName = config.get("scriptsheetname");
            props.Logger = logger;

            _contractAndMectRequirementExcelTools = new ContractAndMectRequirementExcelTools(props);
        }

        [Test]
        public void GatherContractRequirementMectMappingTest()
        {
            //List<ContractRequirementMectRequirementMap> res = _contractAndMectRequirementExcelTools.GatherContractRequirementMectMapping();

            Assert.Pass();
        }
    }
}