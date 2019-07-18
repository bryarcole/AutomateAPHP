using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;
using TFSCommon.XMLTools;

namespace RequirementsTraceability.TFSTools
{
    class GetTestCasesInSuite
    {
        private string _uri;
        private string _personalAccessToken;
        private string _project;
        readonly int _testPlanId;
        readonly int _testSuiteId;

        Boolean _firstIteration;

        private readonly HttpClient _client;
        private Logger _logger;
        private TestStepTools _testStepTools = new TestStepTools();
        private Properties _props;

        private double _totalCount;
        private double _currentCount;

        private ProgressBar _progress;

        public GetTestCasesInSuite(Properties props)
        {
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;
            _testPlanId = props.TestPlanId;
            _testSuiteId = props.TestSuiteId;
            _firstIteration = true;

            _logger = props.Logger;

            _props = props;

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public GetTestCasesInSuite(Properties props, int planId, int suiteId)
        {
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;
            _testPlanId = planId;
            _testSuiteId = suiteId;
            _firstIteration = true;

            _logger = props.Logger;

            _props = props;

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<TestCase> GatherTestCases()
        {
            _totalCount = GetNumberOfTestCasesInPlan().Result;
            BasePath = GetTestSuiteName(_testSuiteId).Result;
            List<string> pathList = new List<string> { BasePath };
            Queue<TestSuite> subFolders = GatherSuiteSubFolder(_testSuiteId, pathList).Result;
            _currentCount = 1;
            //foreach(var folder in subFolders)
            //{
            //    Console.WriteLine(folder.SuiteName);
            //}
            List<TestCase> res;
            _progress = new ProgressBar();

            res = GatherTestCasesInParentSuite(_testSuiteId, pathList).Result;

            while (subFolders.Count > 0)
            {
                //foreach (string[] suite in subFolders)
                //{
                //Console.WriteLine(test.Urls);
                TestSuite suite = subFolders.Dequeue();
                List<string> currPathList = suite.TestPath.ToList<string>();
                currPathList.Add(suite.TestSuiteName);
                int currSuiteId = suite.TestSuiteId;
                List<TestCase> currSuite = GatherTestCasesInParentSuite(currSuiteId, currPathList).Result;
                res.AddRange(currSuite);
                Queue<TestSuite> nextTestSuiteLevel = GatherSuiteSubFolder(currSuiteId, currPathList).Result;
                //countSubFolders += nextTestSuiteLevel.Count;
                if (nextTestSuiteLevel.Count > 0)
                {
                    while (nextTestSuiteLevel.Count > 0)
                    {
                        subFolders.Enqueue(nextTestSuiteLevel.Dequeue());
                    }
                }
            }

            _progress.Dispose();

            Console.WriteLine(res.Count);

            return res;
        }

        private async Task<int> GetNumberOfTestCasesInPlan()
        {
            int res = 0;

            TFSCommonFunctions commonFunctions = new TFSCommonFunctions(_props);
            string wiqlId = await commonFunctions.GatherWiqlId("/Shared Queries/Reporting/NumberOfTestCases");

            var requestUri = "/APHP/" + _project + "/_apis/wit/wiql/" + wiqlId + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                res = jo["workItems"].Count<JToken>();
            }

            return res;
        }

        public async Task<List<TestCase>> GatherTestCasesInParentSuite(int suiteId, List<string> currPath)
        {
            List<TestCase> res = new List<TestCase>();

            var requestUri = "/APHP/" + _project + "/_apis/test/plans/" + _testPlanId + "/suites/" + suiteId + "/testcases?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            _logger.Log(requestUri);
            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            //if the response is successfull, set the result to the workitem object
            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                //Console.WriteLine(currPath);

                foreach (JObject value in jo["value"])
                {
                    _progress.Report(_currentCount / _totalCount);
                    int testCaseId = Convert.ToInt32(value["testCase"]["id"]);
                    //currPath.ForEach(Console.WriteLine);
                    TestCase currTestCase = GetSingleTestCase(testCaseId, suiteId, currPath).Result;

                    //testCaseAttachmentUrls.PrintUrls();
                    res.Add(currTestCase);
                    _currentCount += 1;
                }
                return res;
            }
            else
            {
                Console.Write("Error getting Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        public async Task<TestCase> GetSingleTestCase(int testCaseId, int suiteId, List<string> path = null)
        {
            TestCase res = new TestCase();

            var requestUri = "/APHP/_apis/wit/workitems/" + testCaseId + "?$expand=relations&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            //Console.WriteLine(testCaseId);

            if (response.IsSuccessStatusCode)
            {
                //string workItem = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(responseTxt);
                JObject jo = JObject.Parse(responseTxt);

                string testCaseName = jo["fields"]["System.Title"].ToObject<string>();
                string tempTestSteps = null;
                if (jo["fields"]["Microsoft.VSTS.TCM.Steps"] != null)
                {
                    tempTestSteps = jo["fields"]["Microsoft.VSTS.TCM.Steps"].ToObject<string>();
                }
                string priority = jo["fields"]["Avanade.ACM.Priority"].ToString();
                string iteration = jo["fields"]["System.IterationPath"].ToString();

                res.TestCaseId = Convert.ToInt32(testCaseId);
                res.TestCaseName = StringTools.TrimEndNewLine(testCaseName);
                if (tempTestSteps != null)
                {
                    res.TestSteps = _testStepTools.ExtractTestSteps(testCaseId, tempTestSteps);
                }
                res.TestObjective = jo["fields"]["Avanade.ACM.TestObjective"].ToString();
                if (jo["fields"]["System.Description"] != null)
                {
                    res.TestDescription = jo["fields"]["System.Description"].ToString();
                }
                if (jo["fields"]["Avanade.ACM.TestDataSetup"] != null)
                {
                    res.PreCondition = jo["fields"]["Avanade.ACM.TestDataSetup"].ToString();
                }
                res.Priority = Convert.ToInt32(priority.Substring(0, 1));
                res.PriorityString = priority;
                if (jo["fields"]["Avanade.ACM.Complexity"] != null)
                {
                    res.Complexity = jo["fields"]["Avanade.ACM.Complexity"].ToString();
                }
                if (jo["fields"]["APHP.ALM.TestCaseApplication"] != null)
                {
                    res.Application = jo["fields"]["APHP.ALM.TestCaseApplication"].ToString();
                }
                if (jo["fields"]["APHP.ALM.TestCaseApplicationSubArea"] != null)
                {
                    res.ApplicationSubArea = jo["fields"]["APHP.ALM.TestCaseApplicationSubArea"].ToString();
                }
                var iterationNumber = iteration.Substring(iteration.Length - 1, 1).ToCharArray();
                if (Char.IsNumber(iterationNumber[0]))
                {
                    res.CurrentIteration = Convert.ToDouble(iteration.Substring(iteration.Length - 1, 1));
                }
                res.TestPlanId = _testPlanId;
                res.TestSuiteId = suiteId;
                res.ApplicationArea = jo["fields"]["Microsoft.VSTS.CMMI.ApplicationArea"].ToString();
                res.ApplicationProcess = jo["fields"]["Microsoft.VSTS.CMMI.ApplicationProcess"].ToString();
                res.TestCaseType = jo["fields"]["APHP.ALM.TestCaseType"].ToString();
                if (path != null)
                {
                    res.SetTestCasePathFromStringList(path);
                }
                if (jo["fields"]["Avanade.ACM.ScenarioType"] != null)
                {
                    res.ScenarioType = jo["fields"]["Avanade.ACM.ScenarioType"].ToString();
                }

                return res;
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        public async Task<string> GetTestSuiteName(int testSuiteId)
        {
            string res = "";
            var requestUri = "/APHP/" + _project + "/_apis/test/plans/" + _testPlanId + "/suites/" + testSuiteId + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(responseString);
                res = jo["name"].ToObject<string>();
            }

            return res;
        }

        public async Task<Queue<TestSuite>> GatherSuiteSubFolder(int testSuiteId, List<string> path)
        {
            Queue<TestSuite> res = new Queue<TestSuite>();

            var requestUri = "/APHP/" + _project + "/_apis/test/plans/" + _testPlanId + "/suites/" + testSuiteId + "?includeChildSuites=true&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            _logger.Log(requestUri);
            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            //if the response is successfull, set the result to the workitem object
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(responseString);

                foreach (var testSuite in jo["suites"])
                {
                    int subTestSuiteId = testSuite["id"].ToObject<int>();
                    string subTestSuiteName = testSuite["name"].ToObject<string>();
                    List<string> subTestSuitePath = path;
                    TestSuite subTestSuite = new TestSuite(subTestSuiteId, subTestSuiteName, subTestSuitePath);
                    //string[] subTestSuiteArray = { subTestSuiteId, subTestSuiteName, path };
                    res.Enqueue(subTestSuite);
                }

                if (_firstIteration)
                {
                    BasePath = jo["name"].ToObject<string>();
                    _firstIteration = false;
                }
                //Console.WriteLine("Test Case Successfully Created: Test Case #{0}", workItem.Id);
                return res;
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        public string BasePath { get; private set; }
    }
}
