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

namespace TFSTestImport.TFSTools
{
    class LinkTestCaseToRtm
    {
        private readonly string _uri;
        private readonly string _personalAccessToken;
        private readonly string _project;
        private readonly int _testPlan;
        private readonly int _testSuite;
        private readonly string _saveLocation;
        private Logger _logger;

        private readonly HttpClient _client;

        public LinkTestCaseToRtm(Properties props)
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

        public async Task<List<TestCase>> LinkListOfTestCaseToRtm(List<TestCase> testCaseIdToRtmId)
        {
            List<TestCase> res = new List<TestCase>();
            using (var progress = new ProgressBar())
            {
                double totalCount = testCaseIdToRtmId.Count;
                double currCount = 1; 

                foreach (TestCase currTestCase in testCaseIdToRtmId)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);

                    if (currTestCase.TestScenarios != null && currTestCase.TestScenarios.Count > 0)
                    {
                        Console.WriteLine(currTestCase.TestCaseId);
                        var link = _uri + "/APHP/_apis/wit/workitems/";

                        List<Object> patchDocument = new List<object>();
                        foreach (TestScenario currTestScenario in currTestCase.TestScenarios)
                        {
                            patchDocument.Add(new
                            {
                                op = "add",
                                path = "/relations/-",
                                value = new
                                {
                                    rel = "System.LinkTypes.Related",
                                    url = link + currTestScenario.TestScenarioId
                                }
                            });
                        }

                        var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

                        var requestUri = "/APHP/_apis/wit/workitems/" + currTestCase.TestCaseId + "?api-version=3.0";
                        var method = new HttpMethod("PATCH");
                        var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
                        string requestTxt = await request.Content.ReadAsStringAsync();
                        var response = await _client.SendAsync(request);

                        _logger.LogUriAndPackage(requestUri, requestTxt);
                        string responseTxt = await response.Content.ReadAsStringAsync();
                        _logger.Log(responseTxt);


                        if (response.IsSuccessStatusCode)
                        {
                            res.Add(currTestCase);
                        }
                    }
                }
            }
             
            return res;
        }
    }
}
