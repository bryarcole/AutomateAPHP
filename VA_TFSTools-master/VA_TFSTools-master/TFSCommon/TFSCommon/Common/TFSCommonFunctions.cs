using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TFSCommon.Data;
using TFSCommon.Exceptions;
using TFSCommon.Network;

namespace TFSCommon.Common
{
    public class TFSCommonFunctions
    {
        private HttpClient _client;
        private string _project;
        private string _saveLocation;

        private Logger _logger;

        public TFSCommonFunctions(Properties props)
        {
            string _uri = props.Uri;
            string _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;
            _saveLocation = props.SaveLocation;
            _logger = props.Logger;

            HttpClientInitiator clientInitator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string GetUserName()
        {
            var requestUri = "/APHP/" + _project + "/_apis/wit/workitems/$Test Case?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            try
            {
                var response = _client.SendAsync(request).Result;

                string responseString = response.Content.ReadAsStringAsync().Result;
                var json = JObject.Parse(responseString);
                var res = json["fields"]["System.AssignedTo"].ToString();

                return res;
            }
            catch (Exception e)
            {
                string eMes = string.Format("Please enter in a valid Personal Access Token.");
                _logger.Log(eMes);
                throw new MissingPersonalAccessTokenException(eMes);
            }
        }


        public async Task<string> GatherWiqlId(string path)
        {
            string res = "";

            var requestUri = "/APHP/" + _project + "/_apis/wit/queries" + path + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseValue = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(responseValue);
                res = jo["id"].ToString();
            }

            return res;
        }
    }
}
