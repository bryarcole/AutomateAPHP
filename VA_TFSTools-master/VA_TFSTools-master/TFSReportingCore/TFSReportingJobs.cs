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

namespace TFSReporting
{
    public class TFSReportingJobs : ITFSReportingJobs
    {
        public void UpdateExcelTestCaseId(Properties props)
        {
            ExcelUpdateTestCaseId newUpdateTestCaseId = new ExcelUpdateTestCaseId(props);
            List<TestCaseRowMapping> temp = newUpdateTestCaseId.GetTestCaseRowMappings();

            UpdateTestCaseId tfsUpdateTestCaseId = new UpdateTestCaseId(props);
            var updatedTemp = tfsUpdateTestCaseId.GetTestCaseIdsFromNames(temp);

            newUpdateTestCaseId.UpdateTestCaseId(updatedTemp);

            newUpdateTestCaseId.ExcelCleanup();
        }

        public void GatherTestRunAndResultsAndWriteToDb(Properties props)
        {
            GatherTestRun gatherTestRun = new GatherTestRun(props);
            List<TestRun> testRuns = gatherTestRun.GatherTestRunWithTestResult();

            Console.WriteLine("Number of Test Runs: {0}", testRuns.Count);

            Console.Write("Writing Test Runs and Test Results to DB...  ");
            int numTestRun = testRuns.Count;
            using (var progress = new ProgressBar())
            {
                int currentCount = 1;
                foreach (TestRun currTestRun in testRuns)
                {
                    progress.Report((double)currentCount / (double)numTestRun);

                    HttpClientInitiator client = new HttpClientInitiator("https://localhost:44369/");
                    HttpClient newClient = client.CreateHttpClient();
                    newClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var patchValue = new StringContent(JsonConvert.SerializeObject(currTestRun,
                            Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }), Encoding.UTF8, "application/json");

                    var requestUri = "/api/TestRun";
                    var method = new HttpMethod("PATCH");
                    var request = new HttpRequestMessage(method, requestUri) { Content = patchValue };
                    string requestTxt = request.Content.ToString();
                    var response = newClient.SendAsync(request).Result;

                    currentCount += 1;
                }

                Console.WriteLine("Done.");
            }
        }

        public void UpdateExcelDailyDefect(string startDate, string endDate, Properties props)
        {
            TFSExecutionResults executions = new TFSExecutionResults(props);
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

            UpdateDailyDefect updateDailyDefect = new UpdateDailyDefect(props);
            updateDailyDefect.UpdateTestResultsActuals(resultByDate);
            updateDailyDefect.UpdateTestResultsSingle(resultByDate);
            updateDailyDefect.ExcelCleanup();
        }

        public void UpdateExcelExecutionInputData(Properties props)
        {
            List<TestCase> allTestCaseInSuite = new List<TestCase>();
            GetTestCasesInSuite getTestCasesInSuite = new GetTestCasesInSuite(props);
            allTestCaseInSuite = getTestCasesInSuite.GatherTestCases();

            UpdateExecutionInputData updateInputData = new UpdateExecutionInputData(props);
            updateInputData.UpdateExcelExecutionInputData(allTestCaseInSuite);

            updateInputData.ExcelCleanup();
        }
    }
}
