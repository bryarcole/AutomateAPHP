using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;
using TFSReporting.WebAPITools;

namespace TFSReporting.TFSTools
{
    class GetDefectWithTestCaseCount
    {
        private string _project;
        private string _fileLocation;
        private int _testPlanId;
        private int _testSuite;
        private Dictionary<int, List<TestCaseResult>> _testCaseIdToResults;

        HttpClient _client = new HttpClient();
        Logger _logger;
        TFSCommonFunctions _tfsCommonFunctions;

        List<int> _allTestCaseId;

        public GetDefectWithTestCaseCount(Properties props)
        {
            _project = props.Project;
            _fileLocation = props.SaveLocation;
            _testPlanId = props.TestPlanId;
            _testSuite = props.TestSuiteId;

            _logger = props.Logger;
            HttpClientInitiator clientInitator = new HttpClientInitiator(props.Uri, props.PersonalAccessToken);
            _client = clientInitator.CreateHttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            _testCaseIdToResults = new Dictionary<int, List<TestCaseResult>>();

            _tfsCommonFunctions = new TFSCommonFunctions(props);

            if (props.UseWebApi == 1)
            {
                _allTestCaseId = GetTestCasesWebApi.GetAllTestCaseIds().Result;
            }
            else
            {
                GetTestCasesInSuite getTestCaseInSuite = new GetTestCasesInSuite(props);
                List<TestCase> allTestCases = getTestCaseInSuite.GatherTestCases();
                _allTestCaseId = new List<int>();
                foreach (TestCase currTestCase in allTestCases)
                {
                    _allTestCaseId.Add(currTestCase.TestCaseId);
                }
            }
        }

        /// <summary>
        /// Gets a list of all defects in TFS along with relevant defect history and list of linked Test Cases.
        /// </summary>
        /// <returns>
        /// List of Defects with relevant history and test cases. 
        /// </returns>
        public List<Defect> DefectTestCaseCountTFS(DateTime? earliestDate = null)
        {
            List<Defect> allDefects = new List<Defect>();
            allDefects = GatherDefects().Result;

            using (var progress = new ProgressBar())
            {
                double totalCount = allDefects.Count;
                double currentCount = 0;

                foreach (var currDefect in allDefects)
                {
                    currentCount += 1;
                    progress.Report(currentCount / totalCount);

                    var defectWithTestCase = GetDefectWithListOfTestCases(currDefect).Result;
                }
            }

            if (earliestDate != null)
            {
                allDefects = allDefects.Where(step1 => step1.DefectCreateDate >= earliestDate).ToList<Defect>();
            }

            return allDefects;
        }

        private async Task<List<Defect>> GatherDefects()
        {
            List<Defect> defects = new List<Defect>();

            var wiqlId = _tfsCommonFunctions.GatherWiqlId("/Shared Queries/Reporting/Defect").Result;

            var requestUri = "/APHP/" + _project + "/_apis/wit/wiql/" + wiqlId + "?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                foreach (JToken item in jo["workItems"])
                {
                    Defect currDefect = new Defect();
                    currDefect.DefectId = item["id"].ToObject<int>();

                    defects.Add(currDefect);
                }
            }

            return defects;
        }

        //private async Task<string> GatherWiqlId(string path)
        //{
        //    string res = "";

        //    var requestUri = "/APHP/" + _project + "/_apis/wit/queries" + path + "?api-version=3.0";
        //    var method = new HttpMethod("GET");
        //    var request = new HttpRequestMessage(method, requestUri) { };
        //    var response = await _client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string responseValue = await response.Content.ReadAsStringAsync();
        //        JObject jo = JObject.Parse(responseValue);
        //        res = jo["id"].ToString();
        //    }

        //    return res;
        //}

        private async Task<Defect> GetDefectWithListOfTestCases(Defect currDefect)
        {
            var requestUri = "/APHP/_apis/wit/workitems/" + currDefect.DefectId + "?$expand=all&api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            Defect newDefect = currDefect; 

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                newDefect.DefectName = jo["fields"]["System.Title"].ToString();
                var tempDefectHistory = GetLatestDefectHistory(currDefect.DefectId).Result;
                if (jo["fields"]["System.History"] != null)
                {
                    newDefect.DefectHistory = jo["fields"]["System.History"].ToString();
                }
                else if (tempDefectHistory != null)
                {
                    newDefect.DefectHistory = tempDefectHistory.History;
                }

                if (jo["fields"]["APHP.ALM.DefectDefectType"] != null)
                {
                    newDefect.DefectType = jo["fields"]["APHP.ALM.DefectDefectType"].ToString();
                }
                newDefect.Status = jo["fields"]["System.State"].ToString();
                newDefect.DefectSeverity = jo["fields"]["Microsoft.VSTS.Common.Severity"].ToString();
                if (jo["fields"]["System.AssignedTo"] != null)
                {
                    newDefect.AssignedTo = jo["fields"]["System.AssignedTo"].ToString();
                }
                newDefect.DefectCreateDate = DateTime.Parse(jo["fields"]["System.CreatedDate"].ToString());
                newDefect.DefectCreatedBy = jo["fields"]["System.CreatedBy"].ToString();
                newDefect.Iteration = jo["fields"]["System.IterationPath"].ToString();
                if (jo["fields"]["Microsoft.VSTS.CMMI.ApplicationArea"] != null)
                {
                    newDefect.ApplicationArea = jo["fields"]["Microsoft.VSTS.CMMI.ApplicationArea"].ToString();
                }
                if (jo["fields"]["Microsoft.VSTS.CMMI.ApplicationProcess"] != null)
                {
                    newDefect.ApplicationProcess = jo["fields"]["Microsoft.VSTS.CMMI.ApplicationProcess"].ToString();
                }
                if (jo["fields"]["Microsoft.VSTS.CMMI.FoundInEnvironment"] != null)
                {
                    newDefect.FoundInEnvironment = jo["fields"]["Microsoft.VSTS.CMMI.FoundInEnvironment"].ToString();
                }

                if (tempDefectHistory != null)
                {
                    if (tempDefectHistory.Timestamp.Year == 9999)
                    {
                        newDefect.DiscussionDate = DateTime.Parse(jo["fields"]["System.ChangedDate"].ToString());
                    }
                    else if (newDefect.DefectHistory != null)
                    {
                        newDefect.DiscussionDate = tempDefectHistory.Timestamp;
                    }
                }

                List<DefectHistory> defectHistories = GetAllDefectHistory(newDefect.DefectId).Result;
                if (defectHistories != null)
                {
                    newDefect.DefectHistories = defectHistories;
                }

                List<string> invalidLinks = new List<String> { "ArtifactLink", "AttachedFile" };

                if (jo["relations"] != null)
                {
                    List<TestCase> currTestCases = null;

                    foreach (JToken jToken in jo["relations"])
                    {
                        string currIdString = jToken["url"].ToString();
                        if (!invalidLinks.Contains(jToken["rel"].ToString())) 
                        {
                            int currId = Convert.ToInt32(currIdString.Substring(currIdString.LastIndexOf('/') + 1));
                            if (_allTestCaseId.Contains(currId))
                            {
                                TestCase newTestCase = new TestCase
                                {
                                    TestCaseId = currId
                                };

                                if (currTestCases == null)
                                {
                                    currTestCases = new List<TestCase> { newTestCase };
                                }
                                else
                                {
                                    currTestCases.Add(newTestCase);
                                }
                            }
                        }
                    }

                    //if (currTestCases != null)
                    //{
                    //    Console.WriteLine(newDefect.DefectId + ": " + currTestCases.Count);
                    //}
                    newDefect.TestCases = currTestCases;
                }
            }

            return newDefect;
        }

        private async Task<DefectHistory> GetLatestDefectHistory(int defectId)
        {
            DefectHistory res = null;

            var requestUri = "/APHP/_apis/wit/workitems/" + defectId + "/history?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                int count = Convert.ToInt32(jo["count"].ToString());
                if (count > 0)
                {
                    res = new DefectHistory();
                    res.History = jo["value"][count - 1]["value"].ToString();
                    res.Timestamp = DateTime.Parse(jo["value"][count - 1]["revisedDate"].ToString());
                }
            }

            return res;
        }

        private async Task<List<DefectHistory>> GetAllDefectHistory(int defectId)
        {
            List<DefectHistory> res = null;

            var requestUri = "/APHP/_apis/wit/workitems/" + defectId + "/history?api-version=3.0";
            var method = new HttpMethod("GET");
            var request = new HttpRequestMessage(method, requestUri) { };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string workItem = await response.Content.ReadAsStringAsync();
                JObject jo = JObject.Parse(workItem);

                int count = Convert.ToInt32(jo["count"].ToString());
                if (count > 0)
                {
                    res = new List<DefectHistory>();
                    foreach(JToken token in jo["value"])
                    {
                        DefectHistory currDefectHistory = new DefectHistory
                        {
                            History = token["value"].ToString(),
                            Timestamp = DateTime.Parse(token["revisedDate"].ToString())
                        };

                        res.Add(currDefectHistory);
                    }
                }
            }

            return res;
        }
    }
}
