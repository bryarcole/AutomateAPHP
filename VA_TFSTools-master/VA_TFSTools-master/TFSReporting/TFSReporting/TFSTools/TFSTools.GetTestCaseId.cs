using Newtonsoft.Json;
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
using TFSReporting.Data;

namespace TFSReporting.TFSTools
{
    public class GetTestCaseId
    {
        private string _project;
        private string _fileLocation;
        private int _testPlanId;
        private int _testSuite;
        private Dictionary<int, List<TestCaseResult>> _testCaseIdToResults;

        HttpClient _client = new HttpClient();
        Logger _logger;

        public GetTestCaseId()
        {

        }

        public GetTestCaseId(Properties props)
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

        public List<TestCaseRowMapping> GetTestCaseIdsFromNames(List<TestCaseRowMapping> testCaseRowMappings)
        {
            List<TestCaseRowMapping> res = new List<TestCaseRowMapping>();

            foreach(TestCaseRowMapping currTestCaseRowMapping in testCaseRowMappings)
            {
                TestCaseRowMapping updatedTestCaseRowMapping = GetTestCaseIdFromName(currTestCaseRowMapping).Result;

                if (updatedTestCaseRowMapping != null)
                {
                    res.Add(updatedTestCaseRowMapping);
                }
            }

            return res;
        }

        public async Task<TestCaseRowMapping> GetTestCaseIdFromName(TestCaseRowMapping currTestCaseRowMapping)
        {
            TestCaseRowMapping tempTestCaseRowMapping = new TestCaseRowMapping()
            {
                RowNumber = currTestCaseRowMapping.RowNumber,
                TestCaseName = currTestCaseRowMapping.TestCaseName,
                TestSuiteId = currTestCaseRowMapping.TestSuiteId
            };

            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = "/api/TestCase/TestCaseName/" + tempTestCaseRowMapping.TestCaseName;
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                if (responseString != "")
                {
                    var jo = JObject.Parse(responseString);

                    tempTestCaseRowMapping.TestCaseId = Convert.ToInt32(jo["testCaseId"]);
                }
            }

            //Console.WriteLine(tempTestCaseRowMapping.TestCaseId);

            return tempTestCaseRowMapping;

            //string stringQuery = "Select[System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = 'Test Case' AND [System.Title] = '" + tempTestCaseRowMapping.TestCaseName + "'";

            //List<Object> patchDocument = new List<object>();
            //patchDocument.Add(new
            //{
            //    query = stringQuery
            //});

            //var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

            //var requestUri = "APHP/APHP%20Virginia/_api/_wit/search?searchText=" + tempTestCaseRowMapping.TestCaseName;
            //var method = new HttpMethod("GET");
            //var request = new HttpRequestMessage(method, requestUri) { };
            //var response = await _client.SendAsync(request);

            //List<int> listOfTestCasesInSuite = new List<int>();
            //listOfTestCasesInSuite = await GetTestCaseIdsInSuite(tempTestCaseRowMapping.TestSuiteId);

            //Console.WriteLine(listOfTestCasesInSuite);

            //if (response.IsSuccessStatusCode)
            //{
            //    string responseString = await response.Content.ReadAsStringAsync();
            //    var jo = JObject.Parse(responseString);

            //    int countTestCases = jo["payload"]["rows"].Count();

            //    Console.WriteLine(countTestCases);

            //    if (countTestCases > 0)
            //    {
            //        foreach (JToken currWorkItem in jo["payload"]["rows"])
            //        {
            //            if (listOfTestCasesInSuite.Contains(Convert.ToInt32(currWorkItem[0])))
            //            {
            //                tempTestCaseRowMapping.TestCaseId = Convert.ToInt32(currWorkItem[0]);
            //                return tempTestCaseRowMapping;
            //            }
            //        }
            //    }

            //    return null;
            //}
            //else
            //{
            //    throw new Exception();
            //}
        }

        public async Task<List<int>> GetTestCaseIdsInSuite(int suiteId)
        {
            List<int> res = new List<int>();

            var requestUri = "/APHP/" + _project + "/_apis/test/plans/" + _testPlanId + "/suites/" + suiteId + "/testcases";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(responseString);

                foreach(JToken currTestCase in jo["value"])
                {
                    res.Add(Convert.ToInt32(currTestCase["testCase"]["id"]));
                }
            }

            Console.WriteLine("Number Test Cases in Suite: {0}", res.Count);

            return res;
        }

        public async Task<int> GetTestSuiteId(int testCaseId)
        {
            string res = "";

            var requestUri = "/APHP/_apis/wit/workitems/" + testCaseId;
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var jo = JObject.Parse(responseString);

                return Convert.ToInt32(jo["fields"]["System.Title"]);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
