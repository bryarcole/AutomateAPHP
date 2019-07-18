using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Network;

namespace RequirementsTraceability.WebAPITools
{
    public class TestCaseWebApiTools
    {
        public async Task<List<int>> GetAllTestCaseIds()
        {
            List<int> res = new List<int>();

            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = "/api/TestCase";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);

            string workItem = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(workItem);
                JArray ja = jObject["values"].ToObject<JArray>();

                Console.WriteLine("Parsed item");

                foreach (JObject jo in ja)
                {
                    res.Add(Convert.ToInt32(jo["testCaseId"]));
                }
            }

            return res;
        }
    }
}
