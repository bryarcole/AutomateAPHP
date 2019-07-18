using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;
using TFSCommon.XMLTools;

namespace TFSTestImport.TFSTools
{
    class UpdateTestSteps
    {
        private readonly string _uri;
        private readonly string _personalAccessToken;
        private readonly string _project;
        private readonly int _testPlan;
        private readonly int _testSuite;
        private readonly string _saveLocation;
        private Logger _logger;

        private readonly HttpClient _client;

        /// <summary>
        /// Constructor. Manaully set values to match your account.
        /// </summary>
        public UpdateTestSteps(Properties props)
        {
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;
            _saveLocation = props.SaveLocation;
            _testPlan = props.TestPlanId;
            _testSuite = props.TestSuiteId;

            _logger = props.Logger;

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<TestCase> UpdateTestStepsForTestCaseList(List<TestCase> testCases)
        {
            //Console.WriteLine(testCases.Count);
            List<TestCase> res = new List<TestCase>();
            //int count = 0;
            //int[] testCaseIds = { 156679 };
            foreach (var testCase in testCases)
            {
                if (testCase.TestCaseId != 0)
                {
                    UpdateSingleTestCaseTestStep(testCase);
                }
            }

            return res;
        }

        private async void UpdateSingleTestCaseTestStep(TestCase testCase)
        {
            string uri = _uri;
            string personalAccessToken = _personalAccessToken;
            string project = _project;
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalAccessToken)));

            //POST https://dev.azure.com/{organization}/{project}/_apis/testplan/Plans/{planId}/Suites/{suiteId}/TestCase?api-version=5.0-preview.2


            List<Object> patchDocument = new List<object>();

            TestStepTools xml = new TestStepTools();
            string steps = xml.CreateTestStepXML(testCase.TestSteps);
            //System.Diagnostics.Debug.WriteLine(steps);

            patchDocument.Add(new { op = "add", path = "/fields/Microsoft.VSTS.TCM.Steps", value = steps });

            patchDocument.Add(new { op = "add", path = "/fields/Avanade.ACM.TestDataSetup", value = testCase.PreCondition });

            HttpClientHandler handler = new HttpClientHandler();

            //serialize the fields array into a json string
            var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

            var requestUri = "/APHP/_apis/wit/workitems/" + testCase.TestCaseId + "?api-version=3.0";
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
            string requestTxt = await request.Content.ReadAsStringAsync();
            var response = await _client.SendAsync(request);

            //_logger.LogUriAndPackage(requestUri, requestTxt);
            string responseTxt = await response.Content.ReadAsStringAsync();
            //_logger.Log(responseTxt);

            //if the response is successfull, set the result to the workitem object
            if (response.IsSuccessStatusCode)
            {
                var workItem = await response.Content.ReadAsAsync<WorkItem>();

                Console.WriteLine("Test Case Steps successfully updated for Test Case ID {0}", workItem.Id);
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
