using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;

namespace RequirementsTraceability.TFSTools
{
    class CreateTestScenario
    {
        private string _uri;
        private string _personalAccessToken;
        private string _project;

        private readonly HttpClient _client;
        private Logger _logger;

        public CreateTestScenario(Properties props)
        {
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;

            _logger = props.Logger;

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<TestScenario> CreateAndLinkTestScenarios(List<TestScenario> testScenarios)
        {
            List<TestScenario> res = new List<TestScenario>();

            foreach (TestScenario currTestScenario in testScenarios)
            {
                TestScenario updatedTestScenario = CreateSingleTestScenario(currTestScenario).Result;
                //LinkSingleTestScenario(updatedTestScenario);

                res.Add(updatedTestScenario);
            }

            return res;
        }

        public async Task<TestScenario> CreateSingleTestScenario(TestScenario scenario)
        {
            string link = _uri + "APHP/_apis/wit/workitems/" + scenario.ContractRequirementId;

            List<Object> patchDocument = new List<object>();
            patchDocument.Add(new { op = "add", path = "/fields/System.Title", value = scenario.ScenarioName });
            patchDocument.Add(new { op = "add", path = "/fields/System.Description", value = scenario.ScenarioDescription });
            //patchDocument.Add(new { op = "add", path = "/fields/Microsoft.VSTS.CMMI.ApplicationArea", value = scenario.ApplicationArea });
            //patchDocument.Add(new { op = "add", path = "/fields/Microsoft.VSTS.CMMI.ApplicationProcess", value = scenario.ApplicationProcess });

            patchDocument.Add(new
            {
                op = "add",
                path = "/relations/-",
                value = new
                {
                    rel = "System.LinkTypes.Hierarchy-Reverse",
                    url = link
                }
            });

            //serialize the fields array into a json string
            var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

            var requestUri = "APHP/" + _project + "/_apis/wit/workitems/$Test Scenario?api-version=3.0";
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
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                scenario.TestScenarioId = Convert.ToInt32(jo["id"]);

                return scenario;
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
                return null;
            }
        }

        public async void LinkSingleTestScenario(TestScenario scenario)
        {
            string link = _uri + "/APHP/_apis/wit/workitems/" + scenario.ContractRequirementId;
            List<Object> patchDocument = new List<object>();
            patchDocument.Add(new
            {
                op = "add",
                path = "/relations/-",
                value = new
                {
                    rel = "System.LinkTypes.Hierarchy-Reverse",
                    url = link
                }
            });

            var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

            var requestUri = "/APHP/" + _project + "/_apis/wit/workitems/$Test Scenario?api-version=3.0";
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
                Console.WriteLine("Successfully linked Test Scenario #{0} to Parent Contract Requirement #{1}.", scenario.TestScenarioId, scenario.ContractRequirementId);
            }
            else
            {
                Console.Write("Error creating Test Case: {0}", response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
