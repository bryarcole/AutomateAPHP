using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;

namespace TFSReporting.TFSTools
{
    public class GatherTestRun
    {
        private string _project;
        private string _fileLocation;
        private int _testPlanId;
        private int _testSuite;
        private Dictionary<int, List<TestCaseResult>> _testCaseIdToResults;

        private readonly int _numberOfTestRuns;

        HttpClient _client = new HttpClient();
        Logger _logger;

        public GatherTestRun(Properties props)
        {
            _project = props.Project;
            _fileLocation = props.SaveLocation;
            _testPlanId = props.TestPlanId;
            _testSuite = props.TestSuiteId;

            _logger = props.Logger;
            HttpClientInitiator clientInitator = new HttpClientInitiator(props.Uri, props.PersonalAccessToken);
            _client = clientInitator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            _numberOfTestRuns = props.NumberOfTestRun;
        }

        public List<TestRun> GatherTestRunWithTestResult()
        {
            List<TestRun> res = new List<TestRun>();

            res = GatherAllTestRun().Result;

            return res;
        }

        private async Task<List<TestRun>> GatherAllTestRun()
        {
            Console.Write("Gathering Test Runs and Test Results...  ");

            List<TestRun> res = new List<TestRun>();

            var requestUri = "/APHP/" + _project + "/_apis/test/runs?includeRunDetails=true&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            _logger.Log(requestUri);
            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                JObject jo = JObject.Parse(responseTxt);

                //var numberOfTestRun = jo["count"];
                var numberOfTestRun = _numberOfTestRuns;

                using (var progress = new ProgressBar())
                {
                    int currentCount = 0;
                    JToken[] jTokens = jo["value"].Reverse().Take(numberOfTestRun).Reverse().ToArray();
                    foreach (JToken testRun in jTokens)
                    {
                        progress.Report((double)currentCount / (double)numberOfTestRun);

                        TestRun currTestRun = new TestRun();
                        currTestRun.TestRunId = Convert.ToInt32(testRun["id"]);
                        currTestRun.TestRunName = testRun["name"].ToString();
                        currTestRun.PassedTests = Convert.ToInt32(testRun["passedTests"]);
                        currTestRun.IncompleteTests = Convert.ToInt32(testRun["incompleteTests"]);
                        currTestRun.NotApplicableTests = Convert.ToInt32(testRun["notApplicableTests"]);
                        currTestRun.State = testRun["state"].ToString();
                        currTestRun.UnanalyzedTests = Convert.ToInt32(testRun["unalayzedTests"]);
                        currTestRun.TotalTests = Convert.ToInt32(testRun["totalTests"]);
                        if (testRun["plan"] != null)
                        {
                            currTestRun.TestPlanId = Convert.ToInt32(testRun["plan"]["id"]);
                        }

                        List<TestCaseResult> currTestRunTestCaseResult = new List<TestCaseResult>();
                        currTestRunTestCaseResult = GatherTestRunTestCaseResult(currTestRun.TestRunId).Result;

                        currTestRun.TestCaseResults = currTestRunTestCaseResult;

                        try
                        {
                            currTestRun.TestSuiteId = GatherTestCaseSuiteId(currTestRunTestCaseResult[0].TestCaseId).Result;
                        }
                        catch
                        {
                            currTestRun.TestSuiteId = null;
                        }

                        res.Add(currTestRun);
                        currentCount += 1;
                    }

                    progress.Dispose();
                }
            }
            Console.WriteLine("Done.");

            return res;
        }
        private async Task<List<TestCaseResult>> GatherTestRunTestCaseResult(int testRunId)
        {
            List<TestCaseResult> res = new List<TestCaseResult>();

            var requestUri = "/APHP/" + _project + "/_apis/test/runs/" + testRunId + "/results?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            _logger.Log(requestUri);
            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                JObject jo = JObject.Parse(responseTxt);

                foreach(JToken testCaseResult in jo["value"])
                {
                    TestCaseResult currTestCaseResult = new TestCaseResult();

                    if (testCaseResult["outcome"] != null)
                    {
                        currTestCaseResult.Result = testCaseResult["outcome"].ToString();
                    }
                    else
                    {
                        currTestCaseResult.Result = "In Progress";
                    }

                    if (testCaseResult["completedDate"] != null)
                    {
                        DateTime tempTime = DateTime.Parse(testCaseResult["completedDate"].ToString());
                        currTestCaseResult.ResultDT = tempTime.AddHours(-6.0);
                    }

                    if (testCaseResult["runBy"] != null)
                    {
                        currTestCaseResult.RunByName = testCaseResult["runBy"]["displayName"].ToString();
                    }

                    currTestCaseResult.TestCaseId = Convert.ToInt32(testCaseResult["testCase"]["id"]);
                    currTestCaseResult.TestRunId = testRunId;

                    res.Add(currTestCaseResult);
                }
            }
            else { throw new Exception(); }

            return res;
        }

        private async Task<int> GatherTestCaseSuiteId(int testCaseId)
        {
            var requestUri = "/APHP/_apis/test/suites?api-version=3.0&testCaseId=" + testCaseId;
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            _logger.Log(requestUri);
            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                JObject jo = JObject.Parse(responseTxt);

                return Convert.ToInt32(jo["value"][0]["id"]);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
