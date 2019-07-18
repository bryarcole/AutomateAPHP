using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TFSCommon.Common;
using TFSCommon.Data;
using TFSCommon.Network;
using TFSReporting.Data;
using TFSReporting.ExcelTools;
using TFSReporting.TFSTools;
using TFSReporting.WebAPITools;

namespace TFSReporting
{
    public class TFSReportingJobs : ITFSReportingJobs
    {
        private readonly Properties _props;

        public TFSReportingJobs(Properties props)
        {
            _props = props;
        }
        public void UpdateExcelTestCaseId()
        {
            UpdateTestCaseId newUpdateTestCaseId = new UpdateTestCaseId(_props);
            List<TestCaseRowMapping> temp = newUpdateTestCaseId.GetTestCaseRowMappings();

            GetTestCaseId tfsUpdateTestCaseId = new GetTestCaseId(_props);
            var updatedTemp = tfsUpdateTestCaseId.GetTestCaseIdsFromNames(temp);

            newUpdateTestCaseId.UpdateAllTestCaseId(updatedTemp);

            newUpdateTestCaseId.ExcelCleanup();
        }

        public void GatherTestRunAndResultsAndWriteToDb()
        {
            GatherTestRun gatherTestRun = new GatherTestRun(_props);
            List<TestRun> testRuns = gatherTestRun.GatherTestRunWithTestResult();

            Console.WriteLine("Number of Test Runs: {0}", testRuns.Count);

            if (_props.UseWebApi == 1)
            {
                Console.Write("Writing Test Runs to DB... ");
                PostHelper<TestRun>(testRuns, "/api/TestRun");
                Console.WriteLine();
                Console.WriteLine("Finished writing Test Runs to DB...");
            }
            else
            {
                Console.WriteLine("Not using WebAPI. Not writing to DB... ");
            }
        }

        public void UpdateExcelDailyTestCaseRun(string startDate, string endDate)
        {
            TFSExecutionResults executions = new TFSExecutionResults(_props);
            Console.WriteLine("Test Results are being gathered.");
            List<TestCase> testCases = executions.GatherTestCaseResults();
            Console.WriteLine("Test Results have been gathered.");

            DateTime inputtedStartDate = DateTime.Parse(startDate);
            DateTime inputtedEndDate = DateTime.Parse(endDate);

            List<TestCase> resultByDate = new List<TestCase>();

            for (DateTime date = inputtedStartDate; date <= inputtedEndDate; date = date.AddDays(1))
            {
                List<TestCase> currdateresult = executions.GatherTestResultSpecificDate(testCases, date);
                //Console.WriteLine(currdateresult.Count);
                resultByDate.AddRange(currdateresult);
            }

            Console.WriteLine("{0} Test Results are being written.", resultByDate.Count);

            UpdateDailyExecutionActuals updateDailyExecutionActuals = new UpdateDailyExecutionActuals(_props);
            updateDailyExecutionActuals.UpdateTestResultsActuals(resultByDate);
            //updateDailyExecutionActuals.UpdateTestResultsSingle(resultByDate);
            updateDailyExecutionActuals.ExcelCleanup();
        }

        public void UpdateExcelExecutionInputData()
        {
            List<TestCase> allTestCaseInSuite;
            if (_props.UseWebApi == 1)
            {
                allTestCaseInSuite = GetTestCasesWebApi.GetAllTestCases().Result;
            }
            else
            {
                GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props);
                allTestCaseInSuite = getTestCasesInSuite.GatherTestCases();
            }

            UpdateExecutionInputData updateInputData = new UpdateExecutionInputData(_props);
            updateInputData.UpdateExcelExecutionInputData(allTestCaseInSuite);

            updateInputData.ExcelCleanup();
        }

        public void UpdateExcelDailyExecutionStatus()
        {
            UpdateDailyExecutionStatus updateExcelDailyExecutionStatus = new UpdateDailyExecutionStatus(_props);
            updateExcelDailyExecutionStatus.GatherCategoryExecutionNumbers();
            updateExcelDailyExecutionStatus.UpdateSheets();
            updateExcelDailyExecutionStatus.ExcelCleanup();
        }

        public void UpdateExcelFolderCounts()
        {
            UpdateFolderCounts updateFolderCounts = new UpdateFolderCounts(_props);
            updateFolderCounts.UpdateSheet();
            updateFolderCounts.ExcelCleanup();
        }

        public void UpdateExcelDefectWithTestCaseCount()
        {
            //GetTestCasesWebApi getTestCasesWebApi = new GetTestCasesWebApi();
            //List<int> _allTestCaseIds = getTestCasesWebApi.GetAllTestCaseIds().Result;

            DateTime earliestTime = new DateTime(2019, 4, 1);

            GetDefectWithTestCaseCount getDefectWithTestCaseCount = new GetDefectWithTestCaseCount(_props);
            List<Defect> res = getDefectWithTestCaseCount.DefectTestCaseCountTFS(earliestTime);

            Console.WriteLine("BreakPoint");

            if (_props.UseWebApi == 1)
            {
                Console.Write("Writing Defects to DB... ");
                PostHelper<Defect>(res, "/api/Defect");
                Console.WriteLine();
                Console.WriteLine("Finished writing Defects to DB...");
            }
            else
            {
                Console.Write("Not using WebAPI. Not writing to DB... ");
            }

            List<TestCase> allTestCaseInSuite;
            if (_props.UseWebApi == 1)
            {
                allTestCaseInSuite = GetTestCasesWebApi.GetAllTestCases().Result;
            }
            else
            {
                GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(_props);
                allTestCaseInSuite = getTestCasesInSuite.GatherTestCases();
            }

            List<Defect> defectsFromTFS = GetDefectWebApi.GetDefects().Result;

            UpdateDefectWithTestCaseCount updateDefectWithTestCaseCount = new UpdateDefectWithTestCaseCount(_props);
            updateDefectWithTestCaseCount.UpdateDefectOnlySheet(defectsFromTFS, earliestTime, true);
            updateDefectWithTestCaseCount.UpdateTestCaseWithDefect(defectsFromTFS, allTestCaseInSuite);
            updateDefectWithTestCaseCount.UpdateTfsProposed(defectsFromTFS);
            updateDefectWithTestCaseCount.ExcelCleanup();

            //AddDefectWebApi addDefectWebApi = new AddDefectWebApi();
            //List<Defect> insertedDefects = addDefectWebApi.UpdateListDefects(res).Result;

            //Console.WriteLine(res.Count);
        }

        public void UpdateTestCasesReadyForTest()
        {
            UpdateTestCaseReadyForTest updateTestCaseReadyForTest = new UpdateTestCaseReadyForTest(_props);
            updateTestCaseReadyForTest.UpdateBothSheets();
            updateTestCaseReadyForTest.ExcelCleanup();
        }

        public void PostHelper<T>(IEnumerable<T> entity, string endpoint)
        {
            using (var progress = new ProgressBar())
            {
                double totalCount = entity.Count<T>();
                double currCount = 1;

                foreach (T curr in entity)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);

                    HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
                    HttpClient newClient = client.CreateHttpClient();
                    newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //currTestCase.TestCaseId = 114113;

                    var patchValue = new StringContent(JsonConvert.SerializeObject(curr,
                            Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }), Encoding.UTF8, "application/json");

                    var requestUri = endpoint;
                    var method = new HttpMethod("POST");
                    var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
                    string requestTxt = request.Content.ToString();
                    var response = newClient.SendAsync(request).Result;

                    _props.Logger.Log(requestUri);
                    _props.Logger.Log(requestTxt);
                }
            }
        }
    }
}
