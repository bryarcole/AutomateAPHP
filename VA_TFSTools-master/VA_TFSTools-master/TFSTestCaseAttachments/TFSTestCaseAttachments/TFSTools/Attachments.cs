using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TFSCommon.Common;
using TFSCommon.Network;
using TFSCommon.Data;

namespace TFSTestCaseAttachments.TFSTools
{
    class Attachments
    {
        //readonly string _uri;
        //readonly string _personalAccessToken;
        readonly string _project;
        readonly string _saveLocation;
        readonly int _testPlanId;
        readonly int _testSuiteId;
        Logger _logger;

        Boolean _firstIteration;

        private static HttpClient _client = new HttpClient();

        /// <summary>
        /// Constructor. Manaully set values to match your account.
        /// </summary>
        public Attachments(Properties props)
        {
            string _uri = props.Uri;
            string _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;
            _saveLocation = props.SaveLocation;
            _testPlanId = props.TestPlanId;
            _testSuiteId = props.TestSuiteId;
            _firstIteration = true;

            _logger = new Logger(_saveLocation);

            HttpClientInitiator clientInitator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<TestCase> GatherLinks()
        {
            BasePath = GetTestSuiteName(_testSuiteId).Result;
            List<string> pathList = new List<string> { BasePath };
            Queue<TestSuite> subFolders = GatherSuiteSubFolder(_testSuiteId, pathList).Result;
            //foreach(var folder in subFolders)
            //{
            //    Console.WriteLine(folder.SuiteName);
            //}
            List<TestCase> res = GatherLinksFolder(_testSuiteId, pathList).Result;

            while (subFolders.Count > 0)
            {
                //foreach (string[] suite in subFolders)
                //{
                //Console.WriteLine(test.Urls);
                TestSuite suite = subFolders.Dequeue();
                List<string> currPathList = suite.TestPath.ToList<string>();
                currPathList.Add(suite.TestSuiteName);
                int currSuiteId = suite.TestSuiteId;
                List<TestCase> currSuite = GatherLinksFolder(currSuiteId, currPathList).Result;
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

            return res;
        }

        public async Task<List<TestCase>> GatherLinksFolder(int suiteId, List<string> currPath)
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
                    string testCaseId = value["testCase"]["id"].ToObject<string>();
                    //currPath.ForEach(Console.WriteLine);
                    TestCase testCaseAttachmentUrls = GetTestCaseAttachmentUrl(testCaseId, currPath).Result;

                    //testCaseAttachmentUrls.PrintUrls();
                    res.Add(testCaseAttachmentUrls);
                }

                return res;
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        private async Task<TestCase> GetTestCaseAttachmentUrl(string testCaseId, List<string> path)
        {
            TestCase res = new TestCase();
            
            var requestUri = "/APHP/_apis/wit/workitems/" + testCaseId + "?$expand=relations&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                string testCaseName = jo["fields"]["System.Title"].ToObject<string>();
                List<string> allAttachments = new List<string>();
                if (jo["relations"] != null)
                {
                    res = GetRelationsOfType(jo["relations"], "AttachedFile", Convert.ToInt32(testCaseId), res);
                }

                res.SetTestCasePathFromStringList(path);
                res.TestCaseName = StringTools.TrimEndNewLine(testCaseName);
                res.TestCaseId = Convert.ToInt32(testCaseId);

                return res;
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        private TestCase GetRelationsOfType(JToken relations, string relationType, int urlId, TestCase res)
        {
            foreach (var relation in relations)
            {
                if (relation["rel"].ToObject<string>() == relationType)
                {
                    res.AddUrl(relation["attributes"]["name"].ToObject<string>(), relation["url"].ToObject<string>(), urlId);
                }
            }

            return res;
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
