using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;

namespace RequirementsTraceability.WebAPITools
{
    public class TestScenarioWebApiTools
    {
        public void InsertTestScenarios(List<TestScenario> testScenarios)
        {
            Console.Write("Inserting Test Scearnios to DB...");
            using (var progress = new ProgressBar())
            {
                double totalCount = testScenarios.Count;
                double currCount = 1;
                foreach (TestScenario currTestScenario in testScenarios)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);

                    InsertSingleTestScenario(currTestScenario);
                }
                Console.WriteLine("Done... ");
            }
        }

        private async void InsertSingleTestScenario(TestScenario testScenario)
        {
            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var patchValue = new StringContent(JsonConvert.SerializeObject(testScenario,
                        Formatting.None,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        }), Encoding.UTF8, "application/json");

            var requestUri = "/api/TestScenario";
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
            var response = await newClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
    }
}
