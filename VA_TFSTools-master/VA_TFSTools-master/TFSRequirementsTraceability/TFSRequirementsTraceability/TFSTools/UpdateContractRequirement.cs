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
    public class UpdateContractRequirement
    {
        private string _uri;
        private string _personalAccessToken;
        private string _project;

        private readonly HttpClient _client;
        private Logger _logger;

        private Properties _props;

        private Dictionary<string, int> _dictionary;

        public UpdateContractRequirement(Properties props)
        {
            _props = props;

            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;

            _logger = props.Logger;

            _dictionary = new Dictionary<string, int>();

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ContractRequirement>> UpdateContractRequirementsAndAllLinks(List<ContractRequirement> contractRequirements)
        {
            List<ContractRequirement> res = new List<ContractRequirement>();

            GatherAllCrpSessionAndPlaybookInTfs();

            using (var progress = new ProgressBar())
            {
                double totalCount = contractRequirements.Count;
                double currCount = 1;
                foreach (ContractRequirement curr in contractRequirements)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);

                    //List<CrpSession> newCrpSession = new List<CrpSession>();

                    //foreach(CrpSession currCrpSession in curr.CrpSession)
                    //{
                    //    CrpSession newSession = await CreateOrUpdateCrpSession(currCrpSession);
                    //    newCrpSession.Add(newSession);
                    //}

                    //List<Playbook> newPlaybooks = new List<Playbook>();

                    //foreach(Playbook currPlaybook in curr.Playbooks)
                    //{
                    //    Playbook newPlaybook = await CreateOrUpdatePlaybook(currPlaybook);
                    //    newPlaybooks.Add(newPlaybook);
                    //}

                    //ContractRequirement tempCurr = curr;
                    //tempCurr.CrpSession = newCrpSession;
                    //tempCurr.Playbooks = newPlaybooks;

                    ContractRequirement newContractRequirement = await UpdateSingleContractRequirement(curr);
                    res.Add(newContractRequirement);
                }
            }

            return res;
        }

        private async Task<ContractRequirement> UpdateSingleContractRequirement(ContractRequirement contractRequirement)
        {
            //if (contractRequirement.CrpSession.Count == 0)
            //{
            //    return null;
            //}

            List<Object> patchDocument = new List<object>();
            if (contractRequirement.Validated != null) patchDocument.Add(new { op = "add", path = "/fields/MES.Validated", value = contractRequirement.Validated });
            if (contractRequirement.DeScopeDetails != null) patchDocument.Add(new { op = "add", path = "/fields/MES.DeScopeDetails", value = contractRequirement.DeScopeDetails });
            if (contractRequirement.ValidationAssumptions != null) patchDocument.Add(new { op = "add", path = "/fields/MES.AssumtionsInValidation", value = contractRequirement.ValidationAssumptions });
            if (contractRequirement.SolutionUnderstanding != null) patchDocument.Add(new { op = "add", path = "/fields/MES.SolutionUnderstanding", value = contractRequirement.SolutionUnderstanding });
            if (contractRequirement.VendorIntegration != null) patchDocument.Add(new { op = "add", path = "/fields/MES.VendorDependency", value = contractRequirement.VendorIntegration });
            if (contractRequirement.Coverage != null) patchDocument.Add(new { op = "add", path = "/fields/MES.Coverage", value = contractRequirement.Coverage });

            foreach (CrpSession crpSession in contractRequirement.CrpSession)
            {
                string link = _uri + "APHP/_apis/wit/workitems/" + crpSession.CrpSessionId;
                patchDocument.Add(new
                {
                    op = "add",
                    path = "/relations/-",
                    value = new
                    {
                        rel = "System.LinkTypes.Related",
                        url = link
                    }
                });
            }

            if (contractRequirement.Playbooks != null)
            {
                foreach (Playbook playbook in contractRequirement.Playbooks)
                {
                    string link = _uri + "APHP/_apis/wit/workitems/" + playbook.PlaybookId;
                    patchDocument.Add(new
                    {
                        op = "add",
                        path = "/relations/-",
                        value = new
                        {
                            rel = "System.LinkTypes.Related",
                            url = link
                        }
                    });
                }
            }

            if (contractRequirement.ProductDSD != null)
            {
                foreach (ProductDsd productDsd in contractRequirement.ProductDSD)
                {
                    string link = _uri + "APHP/_apis/wit/workitems/" + productDsd.ProductDsdId;
                    patchDocument.Add(new
                    {
                        op = "add",
                        path = "/relations/-",
                        value = new
                        {
                            rel = "System.LinkTypes.Related",
                            url = link
                        }
                    });
                }
            }

            //serialize the fields array into a json string
            var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

            var requestUri = "APHP/_apis/wit/workitems/" + contractRequirement .RequirementID + "?api-version=3.0";
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
            string requestTxt = await request.Content.ReadAsStringAsync();
            var response = await _client.SendAsync(request);

            _logger.LogUriAndPackage(requestUri, requestTxt);
            string responseTxt = await response.Content.ReadAsStringAsync();
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                return contractRequirement;
            }
            else
            {
                return null;
            }
        }

        private async void GatherAllCrpSessionAndPlaybookInTfs()
        {
            string wiql = @"Select [System.Id] FROM WorkItems WHERE [System.WorkItemType] = 'CRP Session' OR [System.WorkItemType] = 'Playbook'";

            WiqlQuery query = new WiqlQuery
            {
                query = wiql
            };

            var patchValue = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");

            var requestUri = "/APHP/" + _project + "/_apis/wit/wiql?api-version=3.0";
            var method = new HttpMethod("POST");
            var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
            var requestTxt = await request.Content.ReadAsStringAsync();

            _logger.Log(requestTxt);
            var response = await _client.SendAsync(request);
            string responseTxt = response.Content.ReadAsStringAsync().Result;
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                foreach (JToken item in jo["workItems"])
                {
                    string currName = await GetWorkItemName(Convert.ToInt32(item["id"]));
                    _dictionary[currName] = Convert.ToInt32(item["id"]);
                }
            }
        }

        private async Task<string> GetWorkItemName(int id)
        {
            string res = "";

            var requestUri = "/APHP/_apis/wit/workitems/" + id + "?$api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            //_logger.Log(requestUri);

            var response = await _client.SendAsync(request);
            string responseTxt = response.Content.ReadAsStringAsync().Result;
            //_logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                return jo["fields"]["System.Title"].ToString();
            }
            else
            {
                return null;
            }
        }

        private async Task<CrpSession> CreateOrUpdateCrpSession(CrpSession crpSession)
        {
            CreateCrpSession createCrpSession = new CreateCrpSession(_props);

            CrpSession res = new CrpSession();

            if (!_dictionary.ContainsKey(crpSession.CrpSessionName))
            {
                res = await createCrpSession.CreateCrpSessionInTfs(crpSession);
            }
            else
            {
                res.CrpSessionName = crpSession.CrpSessionName;
                res.CrpSessionId = _dictionary[crpSession.CrpSessionName];
            }

            return res;
        }

        private async Task<Playbook> CreateOrUpdatePlaybook(Playbook playbook)
        {
            CreatePlaybooks createPlaybooks = new CreatePlaybooks(_props);
            Playbook res = await createPlaybooks.CreatePlaybookInTfs(playbook);

            if (!_dictionary.ContainsKey(playbook.PlaybookName))
            {
                res = await createPlaybooks.CreatePlaybookInTfs(playbook);
            }
            else
            {
                res.PlaybookName = playbook.PlaybookName;
                res.PlaybookId = _dictionary[playbook.PlaybookName];
            }

            return res;
        }
    }
}
