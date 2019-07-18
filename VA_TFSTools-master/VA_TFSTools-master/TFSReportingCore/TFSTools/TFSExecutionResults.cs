using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSCommon.Common;
using TFSCommon.Network;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TFSReporting.TFSTools
{
    class TFSExecutionResults
    {
        private string _project;
        private string _fileLocation;
        private int _testPlanId;
        private int _testSuite;
        private Dictionary<int, List<TestCaseResult>> _testCaseIdToResults; 

        HttpClient _client = new HttpClient();
        Logger _logger;

        Boolean _firstIteration = true;

        public TFSExecutionResults()
        {

        }

        public TFSExecutionResults(Properties props)
        {
            _project = props.Project;
            _fileLocation = props.SaveLocation;
            _testPlanId = props.TestPlanId;
            _testSuite = props.TestSuiteId;

            _logger = props.Logger;
            HttpClientInitiator clientInitator = new HttpClientInitiator(props.Uri, props.PersonalAccessToken);
            _client = clientInitator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            _testCaseIdToResults = new Dictionary<int, List<TestCaseResult>>();
        }

        public List<TestCase> GatherTestResultSpecificDate(List<TestCase> testCases, DateTime dateTime)
        {
            List<TestCase> res = new List<TestCase>();

            double totalCount = testCases.Count;

            Console.Write("Gathering Results for Date {0}", dateTime.Date.ToShortDateString());

            using (var progress = new ProgressBar())
            {
                double currentCount = 0;

                foreach (TestCase currTestCase in testCases)
                {
                    //progress.Report(currentCount / totalCount);

                    if (currTestCase.TestCaseResults.Count > 0)
                    {
                        //Console.WriteLine(currTestCase.TestCaseResults.Count);
                        foreach (TestCaseResult currTestCaseResult in currTestCase.TestCaseResults)
                        {
                            //Console.WriteLine(currTestCaseResult.ResultDT.Date);
                            if (currTestCaseResult.ResultDT.Date == dateTime.Date)
                            {
                                TestCase testCaseCopy = ObjectCopier.CloneJson<TestCase>(currTestCase);

                                //TestCaseResult testCaseResultCopy = new TestCaseResult(currTestCaseResult.TestCaseId,
                                //    currTestCaseResult.Result,
                                //    currTestCaseResult.ResultDT);

                                TestCaseResult testCaseResultCopy = ObjectCopier.CloneJson<TestCaseResult>(currTestCaseResult);

                                testCaseCopy.CurrentTestCaseResult = testCaseResultCopy;
                                res.Add(testCaseCopy);
                            }
                        }
                    }

                    currentCount += 1;
                }

                Console.WriteLine();
                Console.Write("Done.");
            }

            Console.WriteLine();

            return res;
        }

        public List<TestCase> GatherTestCaseResults()
        {
            List<TestCase> res = new List<TestCase>();

            List<TestRun> testCaseRuns = new List<TestRun>();
            testCaseRuns = GatherTestCaseRunsAPI().Result;

            BasePath = GetTestSuiteName(_testSuite).Result;
            List<string> pathList = new List<string> { BasePath };
            TestSuite parentTestSuite = new TestSuite(_testSuite, BasePath, pathList);
            Queue<TestSuite> subFolders = GatherSuiteSubFolder(_testSuite, pathList).Result;
            parentTestSuite.SubTestSuite = subFolders.ToList<TestSuite>();
            parentTestSuite.TestCases = GatherTestCaseInSuite(_testSuite, pathList, testCaseRuns).Result;

            res = parentTestSuite.TestCases.ToList<TestCase>();

            while (subFolders.Count > 0)
            {
                TestSuite suite = subFolders.Dequeue();
                List<string> currPathList = new List<string>(suite.TestPath);
                currPathList.Add(suite.TestSuiteName);

                int currSuiteId = suite.TestSuiteId;
                List<TestCase> currSuite = GatherTestCaseInSuite(currSuiteId, currPathList, testCaseRuns).Result;
                res.AddRange(currSuite);
                Queue<TestSuite> nextTestSuiteLevel = GatherSuiteSubFolder(currSuiteId, currPathList).Result;
                if (nextTestSuiteLevel.Count > 0)
                {
                    while (nextTestSuiteLevel.Count > 0)
                    {
                        subFolders.Enqueue(nextTestSuiteLevel.Dequeue());
                    }
                }
            }

            //Console.WriteLine(res.Count);
            return res;
        }

        public async Task<List<TestCase>> GatherTestCaseInSuite(int testSuiteId, List<string> path, List<TestRun> testCaseRuns)
        {
            List<TestCase> testCases = new List<TestCase>();

            var requestUri = "/APHP/" + _project + "/_apis/test/plans/" + _testPlanId + "/suites/" + testSuiteId + "/points?api-version=3.0";
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

                foreach (JObject value in jo["value"])
                {
                    int testCaseId = value["testCase"]["id"].ToObject<int>();
                    TestCase testCase = new TestCase(_testPlanId, testSuiteId)
                    {
                        TestCaseId = testCaseId,
                        TestCasePath = String.Join(",", path)
                    };

                    TestCase tempTestCase = null;

                    try
                    {
                        tempTestCase = GatherTestCase(testCase).Result;

                        testCase = tempTestCase;

                        if (_testCaseIdToResults.ContainsKey(testCaseId))
                        {
                            testCase.TestCaseResults = _testCaseIdToResults[testCaseId];
                        }

                        //testCaseAttachmentUrls.PrintUrls();
                        if (tempTestCase != null)
                        {
                            testCases.Add(testCase);
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                    //testCase = tempTestCase;

                    ////if (value["lastResultDetails"] != null)
                    ////{
                    ////    DateTime resultDateTime = DateTime.Parse(value["lastResultDetails"]["dateCompleted"].ToObject<string>());
                    ////    TestCaseResult result = new TestCaseResult(testCaseId, value["outcome"].ToObject<string>(), resultDateTime);
                    ////    testCase.TestCaseResults.Add(result);
                    ////}
                    
                    //if (_testCaseIdToResults.ContainsKey(testCaseId))
                    //{
                    //    testCase.TestCaseResults = _testCaseIdToResults[testCaseId];
                    //}

                    ////testCaseAttachmentUrls.PrintUrls();
                    //if (tempTestCase != null)
                    //{
                    //    testCases.Add(testCase);
                    //}
                }
                return testCases;
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        public async Task<TestCase> GatherTestCase(TestCase testCase)
        {
            var requestUri = "/api/TestCase/" + testCase.TestCaseId;
            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            //var requestUri = "/APHP/_apis/wit/workitems/" + testCase.TestCaseId + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);

            _logger.Log(requestUri);

            if (response.IsSuccessStatusCode)
            {
                string responseTxt = await response.Content.ReadAsStringAsync();
                _logger.Log(responseTxt);

                JObject jo = JObject.Parse(responseTxt);

                //JToken fields = jo["fields"];

                //if (fields["APHP.ALM.TestCaseApplication"] != null)
                //{
                //    testCase.Application = fields["APHP.ALM.TestCaseApplication"].ToObject<string>();
                //}
                //testCase.ApplicationArea = fields["Microsoft.VSTS.CMMI.ApplicationArea"].ToObject<string>();
                //testCase.ApplicationProcess = fields["Microsoft.VSTS.CMMI.ApplicationProcess"].ToObject<string>();
                //if (fields["APHP.ALM.TestCaseApplicationSubArea"] != null)
                //{
                //    testCase.ApplicationSubArea = fields["APHP.ALM.TestCaseApplicationSubArea"].ToObject<string>();
                //}
                //testCase.TestCaseName = fields["System.Title"].ToObject<string>();
                //testCase.TestObjective = fields["Avanade.ACM.TestObjective"].ToObject<string>();
                //if (fields["System.Description"] != null)
                //{
                //    testCase.TestDescription = fields["System.Description"].ToObject<string>();
                //}
                //if (fields["Avanade.ACM.TestDataSetup"] != null)
                //{
                //    testCase.PreCondition = fields["Avanade.ACM.TestDataSetup"].ToObject<string>();
                //}
                ////testCase.Priority = Convert.ToInt32(fields["Avanade.ACM.Priority"].ToObject<string>().Substring(0,0));
                //testCase.Complexity = fields["Avanade.ACM.Complexity"].ToObject<string>();
                //testCase.ScenarioType = fields["Avanade.ACM.ScenarioType"].ToObject<string>();
                //testCase.TestCaseType = fields["APHP.ALM.TestCaseType"].ToObject<string>();

                testCase.Application = jo["application"].ToString();
                testCase.ApplicationArea = jo["applicationArea"].ToString();
                testCase.ApplicationProcess = jo["applicationProcess"].ToString();
                testCase.ApplicationSubArea = jo["applicationSubArea"].ToString();
                testCase.TestCaseName = jo["testCaseName"].ToString();
                testCase.TestObjective = jo["testObjective"].ToString();
                testCase.TestDescription = jo["testDescription"].ToString();
                testCase.PreCondition = jo["preCondition"].ToString();
                testCase.Priority = Convert.ToInt32(jo["priority"]);
                testCase.Complexity = jo["complexity"].ToString();
                testCase.ScenarioType = jo["scenarioType"].ToString();
                testCase.TestCaseType = jo["testCaseType"].ToString();
                testCase.TestSuiteId = Convert.ToInt32(jo["testSuiteId"]);

                return testCase;
            }
            else
            {
                Console.Write("Error getting Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                throw new Exception();
            }

            //return testCase;
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

        private async Task<List<TestRun>> GatherTestCaseRunsAPI()
        {
            List<TestRun> res = new List<TestRun>();
            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();

            var requestUri = "api/TestRun";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string responseTxt = await response.Content.ReadAsStringAsync();
                _logger.Log(responseTxt);

                var jo = JArray.Parse(responseTxt);

                foreach(JToken currTestRun in jo)
                {
                    TestRun testRun = new TestRun();
                    testRun.TestRunId = Convert.ToInt32(currTestRun["testRunId"]);
                    testRun.TestRunName = currTestRun["testRunName"].ToString();
                    testRun.PassedTests = Convert.ToInt32(currTestRun["passedTests"]);
                    testRun.State = currTestRun["state"].ToString();

                    if (currTestRun["testSuiteId"].ToString() != "")
                    {
                        testRun.TestSuiteId = Convert.ToInt32(currTestRun["testSuiteId"]);
                    }

                    if (currTestRun["testPlanId"].ToString() != "")
                    {
                        testRun.TestPlanId = Convert.ToInt32(currTestRun["testPlanId"]);
                    }

                    List<TestCaseResult> allTestCaseResults = new List<TestCaseResult>();

                    //Console.WriteLine(currTestRun["testRunId"].ToString());
                    foreach (JToken currTestResult in currTestRun["testCaseResults"])
                    {
                        if (currTestResult["testCaseResultId"] != null)
                        {
                            TestCaseResult testCaseResult = new TestCaseResult
                            {
                                TestCaseResultId = Convert.ToInt32(currTestResult["testCaseResultId"]),
                                TestRunId = testRun.TestRunId,
                                TestCaseId = Convert.ToInt32(currTestResult["testCaseId"]),
                                Result = currTestResult["result"].ToString(),
                                RunByName = currTestResult["runByName"].ToString(),
                                ResultDT = DateTime.Parse(currTestResult["resultDT"].ToString())
                            };

                            if (!_testCaseIdToResults.ContainsKey(testCaseResult.TestCaseId))
                            {
                                _testCaseIdToResults[testCaseResult.TestCaseId] = new List<TestCaseResult> { testCaseResult };
                            }
                            else
                            {
                                _testCaseIdToResults[testCaseResult.TestCaseId].Add(testCaseResult);
                            }
                        }
                    }

                    if (allTestCaseResults.Count > 0)
                    {
                        testRun.TestCaseResults = allTestCaseResults;
                    }

                    res.Add(testRun);
                }

                return res;
            }
            else
            {
                throw new Exception();
            }
        }

        private async Task<List<TestRun>> GatherTestCaseRuns()
        {
            List<TestRun> res = new List<TestRun>();
            var requestUri = "/APHP/" + _project + "/_apis/test/runs??includerundetails=true&top=200&planid=" + _testPlanId + "&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(responseString);

                foreach(JToken testRun in jo["value"])
                {
                    TestRun currTestRun = new TestRun();
                    currTestRun.TestRunId = Convert.ToInt32(testRun["id"]);
                    currTestRun.PassedTests = Convert.ToInt32(testRun["passedTests"]);
                    currTestRun.TestPlanId = _testPlanId;
                    //string tempUri = testRun["url"].ToString();
                    //currTestRun.Url = new Uri(tempUri);

                    List<TestCaseResult> currTestCaseResults = new List<TestCaseResult>();
                    currTestCaseResults = GatherResultsInRun(currTestRun).Result;

                    currTestRun.TestCaseResults = currTestCaseResults;
                }
            }

            return res;
        }

        private async Task<List<TestCaseResult>> GatherResultsInRun(TestRun testRun)
        {
            List<TestCaseResult> res = new List<TestCaseResult>();

            var requestUri = "/APHP/" + _project + "/_apis/test/runs/" + testRun.TestRunId + "/results?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode) 
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(responseString);

                foreach(JToken testResult in jo["value"])
                {
                    int testRunId = Convert.ToInt32(testResult["id"]);
                    int testCaseId = Convert.ToInt32(testResult["testCase"]["id"]);
                    TestCaseResult currTestCaseResult = null;

                    string testOutcome = null;
                    DateTime testDateTime = default(DateTime);
                    if (testResult["outcome"] != null)
                    {
                        currTestCaseResult = new TestCaseResult();
                        testOutcome = testResult["outcome"].ToString();
                        testDateTime = DateTime.Parse(testResult["completedDate"].ToString());
                        currTestCaseResult.RunByName = testResult["runBy"]["displayName"].ToString();
                        currTestCaseResult.TestRunId = testRun.TestRunId;
                        currTestCaseResult.ResultDT = testDateTime;
                        currTestCaseResult.Result = testResult["outcome"].ToString();
                    }

                    if (currTestCaseResult != null)
                    {
                        if (!_testCaseIdToResults.ContainsKey(testCaseId))
                        {
                            _testCaseIdToResults[testCaseId] = new List<TestCaseResult> { currTestCaseResult };
                        }
                        else
                        {
                            _testCaseIdToResults[testCaseId].Add(currTestCaseResult);
                        }
                        res.Add(currTestCaseResult);
                    }
                }
            }

            return res;
        }

        private async Task<string> GetTestSuiteName(int testSuiteId)
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

        private string BasePath { get; set; }
    }
}

