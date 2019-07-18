using Newtonsoft.Json;
using RequirementsTraceability.ExcelTools;
using RequirementsTraceability.TFSTools;
using RequirementsTraceability.WebAPITools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Data.Mappings;
using TFSCommon.Network;

namespace RequirementsTraceability
{
    public class RequirementsTraceabilityJobs : IRequirementsTracabilityJobs
    {
        private Properties _props;

        public RequirementsTraceabilityJobs(Properties props)
        {
            _props = props;
        }

        public void GatherAndWriteMectRequirementToDb()
        {
            GetWorkItemType getWorkItemType = new GetWorkItemType(_props);
            List<MectRequirement> mectRequirements = getWorkItemType.GetMectRequirements();

            Console.WriteLine("Inserting MECT Requirements to DB... ");

            PostHelper<MectRequirement>(mectRequirements, "/api/MectRequirement");

            Console.WriteLine("Finished Inserting MECT Requirements to DB.... ");
        }

        public void GatherAndWriteContractMectRequirementMappingToDb()
        {
            ContractAndMectRequirementExcelTools contractAndMectRequirementTools = new ContractAndMectRequirementExcelTools(_props);
            List<ContractRequirementMectRequirementMap> contractMectRequirementMap = contractAndMectRequirementTools.GatherContractRequirementMectMapping();
            contractAndMectRequirementTools.ExcelCleanup();

            Console.Write("Inserting Contract Requirement/Mect Requirement Map to DB... ");

            PostHelper<ContractRequirementMectRequirementMap>(contractMectRequirementMap, "/api/CrMrMap");

            Console.WriteLine("Finished Inserting Maps to DB...");
        }

        public void GatherAndWriteContractRequirementsToDb(List<ContractRequirement> requirements)
        {
            ContractRequirementTools crTools = new ContractRequirementTools(_props);
            List<ContractRequirement> temp = crTools.GatherAllContractRequirements(requirements).Result;

            Console.Write("Inserting Contract Requirements To DB... ");

            PostHelper<ContractRequirement>(temp, "/api/ContractRequirement");

            Console.WriteLine("Finished uploading Contract Requirements to DB");
        }

        public void CreateAndUpdateTestScenarios()
        {
            GatherTestScenarioExcel getTestScenario = new GatherTestScenarioExcel(_props);
            List<TestScenario> testScenarios = getTestScenario.GatherAllTestScenario();

            CreateTestScenario createTestScenario = new CreateTestScenario(_props);
            List<TestScenario> updatedTestScenarios = createTestScenario.CreateAndLinkTestScenarios(testScenarios);

            getTestScenario.UpdateTestScenarioId(updatedTestScenarios);
            getTestScenario.ExcelCleanup();

            TestScenarioWebApiTools testScenarioTools = new TestScenarioWebApiTools();
            testScenarioTools.InsertTestScenarios(updatedTestScenarios);
        }

        public void UpdateTestsCasesInDB()
        {
            Console.WriteLine("Gathering Test Cases from Test Plan ID #" + _props.TestPlanId + ": ");
            GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props);
            List<TestCase> allTestCasesInSuite = getTestCasesInSuite.GatherTestCases();
            Console.WriteLine("Finished gathering Test Cases");

            Console.WriteLine("Writing Test Cases into DB: ");

            PostHelper<TestCase>(allTestCasesInSuite, "/api/TestCase");

            Console.WriteLine("Finished inserting Test Cases to DB");

            DeleteNonExistingTestsCases(allTestCasesInSuite);
        }

        public List<TestCase> GetTestCasesInSuite()
        {
            GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props);
            List<TestCase> allTestCasesInSuite = getTestCasesInSuite.GatherTestCases();

            return allTestCasesInSuite;
        }

        public List<TestCase> GetTestCaseGivenPlanSuite(int planId, int suiteId)
        {
            GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props, planId, suiteId);
            List<TestCase> allTestCasesInSuite = getTestCasesInSuite.GatherTestCases();

            return allTestCasesInSuite;
        }
        public List<TestCase> GetTestCaseGivenPlanSuite(int suite)
        {
            GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props, 149579, suite);
            List<TestCase> allTestCasesInSuite = getTestCasesInSuite.GatherTestCases();

            return allTestCasesInSuite;
        }

        public TestCase GetSingleTestCase(int testCaseId, int suiteId)
        {
            GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props);
            TestCase singleTestCase = getTestCasesInSuite.GetSingleTestCase(testCaseId, suiteId).Result;

            return singleTestCase;
        }

        public void UpdateMectAndContractRequirementIdsToExcel()
        {
            GetWorkItemType getWorkItemType = new GetWorkItemType(_props);
            List<ContractRequirement> contractRequirements = getWorkItemType.GetContractRequirements();
            List<MectRequirement> mectRequirements = getWorkItemType.GetMectRequirements();

            ContractAndMectRequirementExcelTools contractAndMectRequirementTools = new ContractAndMectRequirementExcelTools(_props);
            contractAndMectRequirementTools.UpdateMectAndContractRequirementIds(contractRequirements, mectRequirements);
            contractAndMectRequirementTools.ExcelCleanup();
        }

        public List<ContractRequirement> GatherAndWriteContractRequirementToDb()
        {
            ContractAndMectRequirementExcelTools contractAndMectRequirementTools = new ContractAndMectRequirementExcelTools(_props);
            List<ContractRequirement> allContractRequirement = contractAndMectRequirementTools.GatherContractRequirements();

            return allContractRequirement;
        }

        public List<ContractRequirement> UpdateContractRequirementsAndAllLinks()
        {
            ContractAndMectRequirementExcelTools contractAndMectRequirementTools = new ContractAndMectRequirementExcelTools(_props);
            List<ContractRequirement> allContractRequirement = contractAndMectRequirementTools.GatherContractRequirements();

            UpdateContractRequirement updateContractRequirement = new UpdateContractRequirement(_props);
            List<ContractRequirement> res = updateContractRequirement.UpdateContractRequirementsAndAllLinks(allContractRequirement).Result;
            return res;
        }

        public List<int> DeleteNonExistingTestsCases(List<TestCase> allTestCases = null)
        {
            List<int> deletedTestCases = new List<int>();

            GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props);
            List<TestCase> allTestCasesInSuite;
            if (allTestCases == null)
            {
                allTestCasesInSuite = getTestCasesInSuite.GatherTestCases();
            }
            else
            {
                allTestCasesInSuite = allTestCases;
            }

            List<int> allTestCaseIdInSuite = new List<int>();

            foreach (TestCase curr in allTestCasesInSuite)
            {
                allTestCaseIdInSuite.Add(curr.TestCaseId);
            }

            TestCaseWebApiTools testCaseWebApiTools = new TestCaseWebApiTools();
            List<int> allTestCasesInDb = testCaseWebApiTools.GetAllTestCaseIds().Result;

            foreach (int currId in allTestCasesInDb)
            {
                if (!allTestCaseIdInSuite.Contains(currId))
                {
                    deletedTestCases.Add(currId);
                }
            }

            Console.WriteLine("Test");
            Console.WriteLine(deletedTestCases.Count);

            foreach (int curr in deletedTestCases)
            {
                Console.WriteLine(curr);
                HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
                HttpClient newClient = client.CreateHttpClient();
                newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string requestUri = "/api/TestCase/" + curr;
                var method = new HttpMethod("DELETE");
                var request = new HttpRequestMessage(method, requestUri) { };
                var response = newClient.SendAsync(request).Result;
            }

            return deletedTestCases;
        }

        public void PostHelper<T>(IEnumerable<T> entity, string endpoint)
        {
            using (var progress = new ProgressBar())
            {
                double totalCount = entity.Count<T>();
                double currCount = 1;

                foreach (T curr in entity)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);

                    HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
                    HttpClient newClient = client.CreateHttpClient();
                    newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //currTestCase.TestCaseId = 114113;

                    var patchValue = new StringContent(JsonConvert.SerializeObject(curr,
                            Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }), Encoding.UTF8, "application/json");

                    var requestUri = endpoint;
                    var method = new HttpMethod("POST");
                    var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
                    string requestTxt = request.Content.ToString();
                    var response = newClient.SendAsync(request).Result;

                    _props.Logger.Log(requestUri);
                    _props.Logger.Log(requestTxt);
                }
            }
        }
    }
}