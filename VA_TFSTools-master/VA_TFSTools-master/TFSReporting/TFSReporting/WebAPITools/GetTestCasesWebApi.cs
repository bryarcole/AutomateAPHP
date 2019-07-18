using Newtonsoft.Json.Linq;
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
    public static class GetTestCasesWebApi
    {
        public static async Task<List<int>> GetAllTestCaseIds()
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

        public static async Task<List<TestCase>> GetAllTestCases()
        {
            List<TestCase> res = new List<TestCase>();

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
                    res.Add(jo.ToObject<TestCase>());
                }
            }

            return res;
        }

        public static async Task<List<TestCase>> GetTestCaseByPlan(int planId)
        {
            List<TestCase> res = new List<TestCase>();

            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = "/api/TestCase/Plan/" + planId;
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
                    res.Add(jo.ToObject<TestCase>());
                }
            }

            return res;
        }

        public static async Task<TestCase> GetTestCaseById(int id)
        {
            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = "/api/TestCase/" + id;
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);

            string workItem = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(workItem);

                return jObject.ToObject<TestCase>();
            }
            else
            {
                throw new Exception();
            }
        }

        //public async Task<List<TestCase>> GetTestCaseExecutedCumulativeAndPath(DateTime dateTime, string path)
        //{
        //    HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
        //    HttpClient newClient = client.CreateHttpClient();
        //    newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //    var requestUri = string.Format("api/TestCase/ByResultDateAndPath?dateTime={0}&");
        //    var method = new HttpMethod("GET");
        //    var request = new HttpRequestMessage(method, requestUri) { };
        //    var response = await newClient.SendAsync(request);

        //    return null;
        //}

        public static async Task<List<TestCase>> GetTestCaseExecutedCumulativeAndPathAndStatuses(DateTime dateTime, string[] statuses, string path)
        {
            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = string.Format("api/TestCase/ByResultDateAndPath?dateTime={0}&statuses={1}&path={2}&cumulative=1", 
                                                dateTime.ToString("yyyy-MM-dd"),
                                                String.Join(",", statuses),
                                                path);
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);
            string workItem = await response.Content.ReadAsStringAsync();

            List<TestCase> res = new List<TestCase>();

            if (response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(workItem);
                JArray ja = jObject["values"].ToObject<JArray>();

                foreach (JObject jo in ja)
                {
                    res.Add(jo.ToObject<TestCase>());
                }
            }

            return res;
        }

        public static async Task<List<TestCase>> GetTestCasesReadyForTest(string[] severity, string[] testCaseStatuses)
        {
            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = string.Format("api/TestCase/ReadyForTest?severity={0}&testCaseStatuses={1}", 
                                    String.Join(",", severity),
                                    String.Join(",", testCaseStatuses));

            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);
            string workItem = await response.Content.ReadAsStringAsync();

            List<TestCase> res = new List<TestCase>();

            if (response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(workItem);
                JArray ja = jObject["values"].ToObject<JArray>();

                foreach (JObject jo in ja)
                {
                    res.Add(jo.ToObject<TestCase>());
                }
            }

            return res;
        }

        public static async Task<List<TestCase>> GetTestCaseFailedWithMinorDefect(string testCasePath)
        {
            HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
            HttpClient newClient = client.CreateHttpClient();
            newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestUri = string.Format("api/TestCase/FailedWithMinorDefects?testCasePath={0}", testCasePath);

            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await newClient.SendAsync(request);
            string workItem = await response.Content.ReadAsStringAsync();

            List<TestCase> res = new List<TestCase>();
            if (response.IsSuccessStatusCode)
            {
                JObject jObject = JObject.Parse(workItem);
                JArray ja = jObject["values"].ToObject<JArray>();

                foreach (JObject jo in ja)
                {
                    res.Add(jo.ToObject<TestCase>());
                }
            }

            return res;
        }
    }
}
