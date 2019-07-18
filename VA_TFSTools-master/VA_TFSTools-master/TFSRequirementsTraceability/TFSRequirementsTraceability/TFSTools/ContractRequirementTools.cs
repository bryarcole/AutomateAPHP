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
    class ContractRequirementTools
    {
        private string _uri;
        private string _personalAccessToken;
        private string _project;

        private readonly HttpClient _client;
        private Logger _logger;

        public ContractRequirementTools(Properties props)
        {
            _uri = props.Uri;
            _personalAccessToken = props.PersonalAccessToken;
            _project = props.Project;

            _logger = props.Logger;

            HttpClientInitiator clientInitiator = new HttpClientInitiator(_uri, _personalAccessToken);
            _client = clientInitiator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ContractRequirement>> GatherAllContractRequirements(List<ContractRequirement> requirements)
        {
            List<ContractRequirement> res = new List<ContractRequirement>();

            Dictionary<int, ContractRequirement> requirementMapping = new Dictionary<int, ContractRequirement>();
            foreach (ContractRequirement requirement in requirements)
            {
                requirementMapping[requirement.RequirementID] = requirement;
            }

            string wiql = @"Select [System.Id] FROM WorkItems WHERE [System.WorkItemType] = 'Contract Requirement' AND 
([System.Title] CONTAINS 'OPSS' OR [System.Title] CONTAINS 'PLMS')";

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

                using (var progress = new ProgressBar())
                {
                    JArray items = (JArray)jo["workItems"];
                    int count = items.Count;

                    int currCount = 1;

                    Console.Write("Gathering all Contract Requirements... ");
                    foreach (JToken currWorkItem in jo["workItems"])
                    {
                        progress.Report((double)currCount / (double)count);

                        int currentId = Convert.ToInt32(currWorkItem["id"]);
                        if (requirementMapping.ContainsKey(currentId))
                        {
                            ContractRequirement currContractRequirement = requirementMapping[currentId];
                            currContractRequirement = GatherSingleContractRequirement(currContractRequirement).Result;

                            res.Add(currContractRequirement);
                        }

                        currCount += 1;
                    }

                    Console.WriteLine();
                }
            }

            return res;
        }

        private async Task<ContractRequirement> GatherSingleContractRequirement(ContractRequirement currContractRequirement)
        {
            ContractRequirement res = currContractRequirement;

            var requestUri = "/APHP/_apis/wit/workitems/" + currContractRequirement.RequirementID + "?$expand=relations&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            _logger.Log(requestUri);

            var response = await _client.SendAsync(request);
            string responseTxt = response.Content.ReadAsStringAsync().Result;
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                JObject jo = JObject.Parse(responseTxt);

                res.RequirementID = currContractRequirement.RequirementID;

                if (jo["fields"]["System.AssignedTo"] != null)
                {
                    res.AssignedTo = jo["fields"]["System.AssignedTo"].ToString();
                }

                //if (jo["fields"]["System.Description"] != null)
                //{
                //    res.Description = jo["fields"]["System.Description"].ToString();
                //}

                //if (jo["fields"]["System.Title"] != null)
                //{
                //    res.RequirementTitle = jo["fields"]["System.Title"].ToString();
                //}

                //if (jo["fields"]["MES.ProposedLanguage"] != null)
                //{
                //    res.ProposedLanguage = jo["fields"]["MES.ProposedLanguage"].ToString();
                //}

                if (jo["fields"]["Microsoft.VSTS.Common.Priority"] != null)
                {
                    res.Priority = Convert.ToInt32(jo["fields"]["Microsoft.VSTS.Common.Priority"]);
                }

                if (jo["fields"]["System.State"] != null)
                {
                    res.State = jo["fields"]["System.State"].ToString();
                }

                //if (jo["relations"] != null)
                //{
                //    List<int> relationIds = new List<int>();
                //    foreach (JToken relation in jo["relations"])
                //    {
                //        string url = relation["url"].ToString();
                //        //Console.WriteLine(url.Substring(url.LastIndexOf("/") + 1));
                //        if (IsDigitsOnly(url.Substring(url.LastIndexOf("/") + 1)))
                //        {
                //            int tempId = Convert.ToInt32(url.Substring(url.LastIndexOf("/") + 1));
                //            relationIds.Add(tempId);
                //        }
                //    }

                //    List<MectRequirement> allMectRequirements = new List<MectRequirement>();
                //    foreach (int id in relationIds)
                //    {
                //        MectRequirement singleMectRequirement = new MectRequirement();
                //        singleMectRequirement = GatherMectRequirementFromId(id).Result;
                //        if (singleMectRequirement.MectRequirementId != 0)
                //        {
                //            //Console.WriteLine("Added MECT Requirement");
                //            allMectRequirements.Add(singleMectRequirement);
                //        }
                //    }

                //    if (allMectRequirements.Count > 0)
                //    {
                //        //Console.WriteLine("Contract Requirement {0}", allMectRequirements.Count);
                //        res.RelatedMectRequirement = allMectRequirements;
                //    }
                //}

            }

            return res;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public async Task<List<MectRequirement>> GatherAllMectRequirements()
        {
            List<MectRequirement> requirements = new List<MectRequirement>();



            return requirements;
        }

        private async Task<MectRequirement> GatherMectRequirementFromId(int id)
        {
            MectRequirement res = new MectRequirement();
            var requestUri = "/APHP/_apis/wit/workitems/" + id + "?$expand=relations&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            _logger.Log(requestUri);

            var response = await _client.SendAsync(request);
            string responseTxt = response.Content.ReadAsStringAsync().Result;
            _logger.Log(responseTxt);

            if (response.IsSuccessStatusCode)
            {
                JObject jo = JObject.Parse(responseTxt);

                if (jo["fields"]["MES.RequirementType"] != null && jo["fields"]["MES.RequirementType"].ToString() == "MECT")
                {
                    res.MectRequirementId = Convert.ToInt32(jo["id"]);
                    if (jo["fields"]["MES.MECTName"] != null)
                    {
                        res.MectName = jo["fields"]["MES.MECTName"].ToString();
                    }

                    if (jo["fields"]["MES.MECTSource"] != null)
                    {
                        res.MectSource = jo["fields"]["MES.MECTSource"].ToString();
                    }

                    if (jo["fields"]["MES.MECTCriteria"] != null)
                    {
                        res.MectCriteria = jo["fields"]["MES.MECTCriteria"].ToString();
                    }

                    if (jo["fields"]["System.Title"] != null)
                    {
                        res.MectTitle = jo["fields"]["System.Title"].ToString();
                    }

                    if (jo["fields"]["System.Description"] != null)
                    {
                        res.Description = jo["fields"]["System.Description"].ToString();
                    }

                    if (jo["fields"]["MES.Scope"] != null)
                    {
                        res.Scope = jo["fields"]["MES.Scope"].ToString();
                    }

                }

                return res;
            }
            else
            {
                return res;
            }
        }
    }



    class WiqlQuery
    {
        public string query { get; set; }
    }
}
