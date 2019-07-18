using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TFSTestCaseAttachments.Common
{
    class HttpClientInitiator
    {
        readonly string _uri;
        readonly string _personalAccessToken;
        readonly string _credentials;

        private static HttpClient _client;

        public HttpClientInitiator(string uri, string personalAccessToken)
        {
            _uri = uri;
            _personalAccessToken = personalAccessToken;

            _credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", _personalAccessToken)));
        }

        public HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            _client = new HttpClient(handler, false);
            _client.BaseAddress = new Uri(_uri);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);

            return _client;
        }

        public HttpClient GetExitistingClient()
        {
            return _client;
        }
    }
}
