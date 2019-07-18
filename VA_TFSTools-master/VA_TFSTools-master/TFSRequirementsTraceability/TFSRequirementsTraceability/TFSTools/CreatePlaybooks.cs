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
    public class CreatePlaybooks
    {
        private string _uri;
        private string _personalAccessToken;
        private string _project;

        private readonly HttpClient _client;
        private Logger _logger;

        public CreatePlaybooks(Properties props)
        {
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;

            _logger = props.Logger;

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Playbook> CreatePlaybookInTfs(Playbook playbook)
        {
            Playbook res = new Playbook();

            List<Object> patchDocument = new List<object>();
            patchDocument.Add(new { op = "add", path = "/fields/System.Title", value = playbook.PlaybookName });

            //serialize the fields array into a json string
            var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

            var requestUri = "APHP/" + _project + "/_apis/wit/workitems/$Playbook?api-version=3.0";
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
            string requestTxt = await request.Content.ReadAsStringAsync();
            var response = await _client.SendAsync(request);

            _logger.LogUriAndPackage(requestUri, requestTxt);
            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                res.PlaybookId = Convert.ToInt32(jo["id"]);
                res.PlaybookName = playbook.PlaybookName;
                return res;
            }
            else
            {
                return null;
            }
        }
    }
}
