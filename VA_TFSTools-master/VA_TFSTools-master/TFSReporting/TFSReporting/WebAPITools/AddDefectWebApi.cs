using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSCommon.Network;

namespace TFSReporting.WebAPITools
{
    public class AddDefectWebApi
    {
        public async Task<List<Defect>> UpdateListDefects(List<Defect> entities)
        {
            List<Defect> res = new List<Defect>();

            foreach (Defect currDefect in entities)
            {
                currDefect.TestCases = null;

                HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
                HttpClient newClient = client.CreateHttpClient();
                newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var patchValue = new StringContent(JsonConvert.SerializeObject(currDefect,
                        Formatting.None,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        }), Encoding.UTF8, "application/json");

                var requestUri = "/api/Defect";
                var method = new HttpMethod("POST");
                var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
                Console.WriteLine(request.ToString());

                var response = await newClient.SendAsync(request);

                string workItem = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    res.Add(currDefect);
                }
            }

            return res;
        }
    }
}
