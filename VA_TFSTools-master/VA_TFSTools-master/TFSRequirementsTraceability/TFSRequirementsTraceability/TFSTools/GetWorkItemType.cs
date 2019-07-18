using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;

namespace RequirementsTraceability.TFSTools
{
    class GetWorkItemType
    {
        private string _project;
        private string _fileLocation;
        private int _testPlanId;
        private int _testSuite;

        HttpClient _client = new HttpClient();
        Logger _logger;

        public GetWorkItemType()
        {

        }

        public GetWorkItemType(Properties props)
        {
            _project = props.Project;
            _fileLocation = props.SaveLocation;
            _testPlanId = props.TestPlanId;
            _testSuite = props.TestSuiteId;

            _logger = props.Logger;
            HttpClientInitiator clientInitator = new HttpClientInitiator(props.Uri, props.PersonalAccessToken);
            _client = clientInitator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<ContractRequirement> GetContractRequirements()
        {
            List<ContractRequirement> res = new List<ContractRequirement>();

            string contractRequirementWiqlId = GetContractRequirementWiqlId().Result;

            Console.WriteLine("Before Test Case ID");
            List<int> contractRequirementIds = GetRequirementIds(contractRequirementWiqlId).Result;
            Console.WriteLine(contractRequirementIds.Count);

            Console.WriteLine("Gathering Contract Requirements");
            res = GatherContractRequirementIdsAndNames(contractRequirementIds);

            Console.WriteLine("Finished Gathering Requirements");

            return res;
        }

        public List<MectRequirement> GetMectRequirements()
        {
            List<MectRequirement> res = new List<MectRequirement>();
            string mectRequirementId = GetMectRequirementId().Result;

            Console.WriteLine("Before Test Case ID");
            List<int> mectRequirementIds = GetRequirementIds(mectRequirementId).Result;
            Console.WriteLine(mectRequirementIds.Count);

            Console.WriteLine("Gathering MECT Requirements");
            res = GatherMectRequirementIdsAndNames(mectRequirementIds);

            Console.WriteLine("Finished gathering MECT Requirements");

            return res;
        }

        private async Task<string> GetContractRequirementWiqlId()
        {
            var requestUri = "/APHP/" + _project + "/_apis/wit/queries/My Queries/GetContractRequirementOPSS?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            string workItem = await response.Content.ReadAsStringAsync();
            JObject jo = JObject.Parse(workItem);

            string wiqlId = jo["id"].ToString();

            return wiqlId;
        }

        private async Task<string> GetMectRequirementId()
        {
            var requestUri = "/APHP/" + _project + "/_apis/wit/queries/My Queries/GetMectRequirement?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            string workItem = await response.Content.ReadAsStringAsync();
            JObject jo = JObject.Parse(workItem);

            string wiqlId = jo["id"].ToString();

            return wiqlId;
        }

        private async Task<List<int>> GetRequirementIds(string wiqlId)
        {
            var requestUri = "/APHP/" + _project + "/_apis/wit/wiql/" + wiqlId + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            string wiqlWorkItem = await response.Content.ReadAsStringAsync();
            JObject jo = JObject.Parse(wiqlWorkItem);

            List<int> workItemId = new List<int>();

            foreach (JToken singleWorkItem in jo["workItems"])
            {
                int currTestCaseId = Convert.ToInt32(singleWorkItem["id"]);
                workItemId.Add(currTestCaseId);
            }

            return workItemId;
        }

        private List<ContractRequirement> GatherContractRequirementIdsAndNames(List<int> workItemIds)
        {
            List<ContractRequirement> res = new List<ContractRequirement>();

            using (var progress = new ProgressBar())
            {
                double totalCount = workItemIds.Count;

                double currCount = 1;
                foreach (int workItemId in workItemIds)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);
                    res.Add(GatherContractRequirementIdAndName(workItemId).Result);
                }
            }

            return res;
        }

        private async Task<ContractRequirement> GatherContractRequirementIdAndName(int workItemId)
        {
            var requestUri = "/APHP/_apis/wit/workitems/" + workItemId + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            string wiqlWorkItem = await response.Content.ReadAsStringAsync();
            JObject jo = JObject.Parse(wiqlWorkItem);

            ContractRequirement currRequirement = new ContractRequirement(Convert.ToInt32(jo["id"]), jo["fields"]["System.Title"].ToString());
            return currRequirement;
        }

        private List<MectRequirement> GatherMectRequirementIdsAndNames(List<int> workItemIds)
        {
            List<MectRequirement> res = new List<MectRequirement>();

            using (var progress = new ProgressBar())
            {
                double totalCount = workItemIds.Count;

                double currCount = 1;
                foreach (int workItemId in workItemIds)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);
                    res.Add(GatherMectRequirementIdAndName(workItemId).Result);
                }
            }

            return res;
        }

        private async Task<MectRequirement> GatherMectRequirementIdAndName(int workItemId)
        {
            var requestUri = "/APHP/_apis/wit/workitems/" + workItemId + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            string wiqlWorkItem = await response.Content.ReadAsStringAsync();
            JObject jo = JObject.Parse(wiqlWorkItem);

            MectRequirement currRequirement = new MectRequirement();

            currRequirement.MectRequirementId = Convert.ToInt32(jo["id"]);
            if (jo["fields"]["MES.MECTName"] != null)
            {
                currRequirement.MectName = jo["fields"]["MES.MECTName"].ToString();
            }

            if (jo["fields"]["MES.MECTSource"] != null)
            {
                currRequirement.MectSource = jo["fields"]["MES.MECTSource"].ToString();
            }

            if (jo["fields"]["MES.MECTCriteria"] != null)
            {
                currRequirement.MectCriteria = jo["fields"]["MES.MECTCriteria"].ToString();
            }

            if (jo["fields"]["System.Title"] != null)
            {
                currRequirement.MectTitle = jo["fields"]["System.Title"].ToString();
            }

            if (jo["fields"]["System.Description"] != null)
            {
                currRequirement.Description = jo["fields"]["System.Description"].ToString();
            }

            if (jo["fields"]["MES.Scope"] != null)
            {
                currRequirement.Scope = jo["fields"]["MES.Scope"].ToString();
            }

            return currRequirement;
        }
    }
}
