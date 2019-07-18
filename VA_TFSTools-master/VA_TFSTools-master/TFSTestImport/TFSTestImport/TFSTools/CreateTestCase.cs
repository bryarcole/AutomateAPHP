using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;
using TFSCommon.Common;
using System.Threading.Tasks;
using TFSCommon.Network;
using TFSCommon.Data;
using TFSCommon.XMLTools;

namespace TFSTestImport.TFSTools
{
    internal class CreateTestCase
    {
        private readonly string _uri;
        private readonly string _personalAccessToken;
        private readonly string _project;
        private readonly int _testPlan;
        private readonly int _testSuite;
        private readonly string _saveLocation;
        private readonly int _iteration;
        private Logger _logger;

        private readonly HttpClient _client;

        public CreateTestCase()
        {
            _uri = "http://10.3.16.122/";
            _personalAccessToken = "EXAMPLEACCESSTOKEN";
            _project = "APHP";
            _testPlan = 156611;
            _testSuite = 156696;
            _logger = new Logger();

            HttpClientInitiator clientInitator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Constructor. Manaully set values to match your account.
        /// </summary>
        public CreateTestCase(Properties props)
        {
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;
            _saveLocation = props.SaveLocation;
            _testPlan = props.TestPlanId;
            _testSuite = props.TestSuiteId;
            _iteration = props.Iteration;

            _logger = props.Logger;

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<TestCase> TestCaseCreation(List<TestCase> testCases)
        {
            //Console.WriteLine(testCases.Count);
            List<TestCase> res = new List<TestCase>();
            //int count = 0;
            //int[] testCaseIds = { 156679 };
            foreach (var testCase in testCases) {
                WorkItem testCaseWorkItem = CreateTestCaseWorkItemAndTestStep(testCase).Result;
                if (testCaseWorkItem.Id != null)
                {
                    int testCaseId = (int) testCaseWorkItem.Id;
                    testCase.TestCaseId = testCaseId;
                    testCase.TestPlanId = _testPlan;
                    testCase.TestSuiteId = _testSuite;
                    //int testCaseId = testCaseIds[count];
                    //count++;
                    WorkItem linkedTestCase = LinkTestCaseToSuite(_testPlan, _testSuite, testCaseId).Result;
                    //WorkItem addedTestStep = AddTestStepToTestCase(testCase, testCaseId).Result;
                    if (linkedTestCase != null)
                    {
                        res.Add(testCase);
                    }
                }
            }

            return res;
        }

        public async Task<WorkItem> CreateTestCaseWorkItemAndTestStep(TestCase testCase)
        {
            string uri = _uri;
            string personalAccessToken = _personalAccessToken;
            string project = _project;
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalAccessToken)));

            //POST https://dev.azure.com/{organization}/{project}/_apis/testplan/Plans/{planId}/Suites/{suiteId}/TestCase?api-version=5.0-preview.2


            List<Object> patchDocument = new List<object>();

            string iterationPath = "APHP Virginia\\VA SIT\\Iteration " + _iteration;
            patchDocument.Add(new { op = "add", path = "/fields/System.IterationPath", value = iterationPath });

            if (!string.IsNullOrEmpty(testCase.TestCaseName))
            {
                patchDocument.Add(new { op = "add", path = "/fields/System.Title", value = testCase.TestCaseName });
                //Console.Write(testCase.TestCaseName + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.TestCaseType))
            {
                patchDocument.Add(new { op = "add", path = "/fields/APHP.ALM.TestCaseType", value = testCase.TestCaseType });
                //Console.Write(testCase.TestCaseType + "\r\n");
            }
            if (testCase.Priority != null)
            {
                patchDocument.Add(new { op = "add", path = "/fields/Microsoft.VSTS.Common.Priority", value = testCase.Priority });
                //Console.Write(testCase.Priority + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.Complexity))
            {
                patchDocument.Add(new { op = "add", path = "/fields/Avanade.ACM.Complexity", value = testCase.Complexity });
                //Console.Write(testCase.Complexity + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.ScenarioType))
            {
                patchDocument.Add(new { op = "add", path = "/fields/Avanade.ACM.ScenarioType", value = testCase.ScenarioType });
                //Console.Write(testCase.ScenarioType + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.TestObjective))
            {
                patchDocument.Add(new { op = "add", path = "/fields/Avanade.ACM.TestObjective", value = testCase.TestObjective });
                //Console.Write(testCase.TestObjective + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.TestDescription))
            {
                patchDocument.Add(new { op = "add", path = "/fields/System.Description", value = testCase.TestDescription });
                //Console.Write(testCase.TestDescription + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.PreCondition))
            {
                patchDocument.Add(new { op = "add", path = "/fields/Avanade.ACM.TestDataSetup", value = testCase.PreCondition });
                //Console.Write(testCase.PreCondition + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.Application))
            {
                patchDocument.Add(new { op = "add", path = "/fields/APHP.ALM.TestCaseApplication", value = testCase.Application });
                //Console.Write(testCase.Application + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.ApplicationArea))
            {
                patchDocument.Add(new { op = "add", path = "/fields/Microsoft.VSTS.CMMI.ApplicationArea", value = testCase.ApplicationArea });
                //Console.Write(testCase.ApplicationArea + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.ApplicationProcess))
            {
                patchDocument.Add(new { op = "add", path = "/fields/Microsoft.VSTS.CMMI.ApplicationProcess", value = testCase.ApplicationProcess });
                //Console.Write(testCase.ApplicationProcess + "\r\n");
            }
            if (!string.IsNullOrEmpty(testCase.ApplicationSubArea))
            {
                patchDocument.Add(new { op = "add", path = "/fields/APHP.ALM.TestCaseApplicationSubArea", value = testCase.ApplicationSubArea });
                //Console.Write(testCase.ApplicationSubArea + "\r\n");
            }
            if(!string.IsNullOrEmpty(testCase.UserName))
            {
                patchDocument.Add(new { op = "add", path = "/fields/Avanade.ACM.Author", value = testCase.UserName });
                //Console.Write(testCase.UserName + "\r\n");
            }

            TestStepTools xml = new TestStepTools();
            string steps = xml.CreateTestStepXML(testCase.TestSteps);
            //System.Diagnostics.Debug.WriteLine(steps);

            patchDocument.Add(new { op = "add", path = "/fields/Microsoft.VSTS.TCM.Steps", value = steps });

            HttpClientHandler handler = new HttpClientHandler();

            //using (var client = new HttpClient(handler, false))
            //{
            //    //set our headers
            //    client.BaseAddress = new Uri(uri);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                //serialize the fields array into a json string
                var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

                var requestUri = "/APHP/" + project + "/_apis/wit/workitems/$Test Case?api-version=3.0";
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
                string requestTxt = await request.Content.ReadAsStringAsync();
                var response = await _client.SendAsync(request);

                _logger.LogUriAndPackage(requestUri, requestTxt);
                string responseTxt = await response.Content.ReadAsStringAsync();
                _logger.Log(responseTxt);

                //if the response is successfull, set the result to the workitem object
                if (response.IsSuccessStatusCode)
                {
                    var workItem = await response.Content.ReadAsAsync<WorkItem>();

                    Console.WriteLine("Test Case Successfully Created: Test Case #{0}", workItem.Id);
                    return workItem;
                }
                else
                {
                    Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                    return null;
                }
            //}
        }


        public async Task<WorkItem> LinkTestCaseToSuite(int testPlanId, int testSuiteId, int testCaseId)
        {
            string uri = _uri;
            string personalAccessToken = _personalAccessToken;
            string project = _project;
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalAccessToken)));

            HttpClientHandler handler = new HttpClientHandler();

            //using (var client = new HttpClient(handler, false))
            //{
            //    //set our headers
            //    client.BaseAddress = new Uri(uri);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                var requestUri = "/APHP/" + project + " /_apis/test/plans/" + testPlanId + "/suites/" + testSuiteId + "/testcases/" + testCaseId + "?api-version=3.0";
                var method = new HttpMethod("POST");
                var request = new HttpRequestMessage(method, requestUri) { };
                var response = await _client.SendAsync(request);

                _logger.Log(requestUri);
                string responseTxt = await response.Content.ReadAsStringAsync();
                _logger.Log(responseTxt);

                //if the response is successfull, set the result to the workitem object
                if (response.IsSuccessStatusCode)
                {
                    var workItem = await response.Content.ReadAsAsync<WorkItem>();

                    Console.WriteLine("Test Case Successfully Linked to Test Plan ID #{0} and Test Suite #{1}", testPlanId, testSuiteId);
                    return workItem;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Error linking Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                    return null;
                }
            //}
        }

        //public async Task<WorkItem> AddTestStepToTestCase(TestCase testCase, int testCaseId)
        //{
        //    string uri = _uri;
        //    string personalAccessToken = _personalAccessToken;
        //    string project = _project;
        //    string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalAccessToken)));

        //    //POST https://dev.azure.com/{organization}/{project}/_apis/testplan/Plans/{planId}/Suites/{suiteId}/TestCase?api-version=5.0-preview.2
        //    //_apis / test / plans /156611/ suites /156612/ testcases /156615


        //    Object[] patchDocument = new Object[1];

        //    //String steps = "<steps id=\"0\" last=\"1\"><step id=\"2\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\">Input step 1</parameterizedString><parameterizedString isformatted=\"true\">Expectation step 1</parameterizedString><description/></step><step id=\"3\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\">Input step 2</parameterizedString><parameterizedString isformatted=\"true\">Expectation step 2</parameterizedString><description/></step><step id=\"4\" type=\"ValidateStep\"><parameterizedString isformatted=\"true\">Input step 3</parameterizedString><parameterizedString isformatted=\"true\">Expectation step 3</parameterizedString><description/></step></steps>";
        //    XMLTools.XMLTools xml = new XMLTools.XMLTools();
        //    string steps = xml.createTestStepXML(testCase.TestSteps);
        //    //System.Diagnostics.Debug.WriteLine(steps);

        //    patchDocument[0] = new { op = "add", path = "/fields/Microsoft.VSTS.TCM.Steps", value = steps };

        //    //HttpClientHandler handler = new HttpClientHandler();

        //    //using (var client = new HttpClient(handler, false))
        //    //{
        //    //    //set our headers
        //    //    client.BaseAddress = new Uri(uri);
        //    //    client.DefaultRequestHeaders.Accept.Clear();
        //    //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        //        //serialize the fields array into a json string
        //        var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");
        //        //System.Diagnostics.Debug.WriteLine(patchValue.ReadAsStringAsync().Result);

        //        var requestUri = "/APHP/_apis/wit/workitems/" + testCaseId + "?api-version=3.0";
        //        var method = new HttpMethod("PATCH");
        //        var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
        //        string requestTxt = await request.Content.ReadAsStringAsync();
        //        var response = await _client.SendAsync(request);

        //        logger.LogUriAndPackage(requestUri, requestTxt);
        //        string responseTxt = await response.Content.ReadAsStringAsync();
        //        logger.Log(responseTxt);

        //        //if the response is successfull, set the result to the workitem object
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var workItem = await response.Content.ReadAsAsync<WorkItem>();

        //            Console.WriteLine("Test Steps successfully added to Test Case: Test Case #{0}", workItem.Id);
        //            logger.Log("Test Case #" + workItem.Id + " has been successfully Created, Linked, and Test Steps Added.");
        //            return workItem;
        //        }
        //        else
        //        {
        //            System.Diagnostics.Debug.WriteLine("Error creating Test Steps: {0}", response.Content.ReadAsStringAsync().Result);
        //            return null;
        //        }
        //    //}
        //}
    }
}
