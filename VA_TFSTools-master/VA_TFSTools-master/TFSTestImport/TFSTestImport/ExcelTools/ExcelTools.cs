using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using TFSCommon.Common;
using TFSCommon.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace TFSTestImport.ExcelTools
{
    class ExcelTooling : IExcelTools
    {
        private readonly string _fileLocation;
        private string _fileName; 
        private string _userName;

        private Excel.Application _xlApp = new Excel.Application();
        private Excel.Workbook _xlWorkbook;
        private Excel.Worksheet _xlWorksheet;
        private Excel.Range _xlRange; 

        public ExcelTooling(string fileLocation, string fileName)
        {
            _fileLocation = fileLocation + "\\" + fileName + ".xlsx";
            //_fileLocation = StringTools.addExtension(fileLocation + "\\" + fileName, "xlsx");
            _fileName = fileName;
            _xlWorkbook = null;
            try
            {
                _xlWorkbook = _xlApp.Workbooks.Open(_fileLocation);
            }
            catch
            {
                Console.Write("File Location/Name is not valid. Please press Enter and run the program again.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            _xlWorksheet = _xlWorkbook.Sheets["Test Cases"];
            _xlRange = _xlWorksheet.UsedRange;
            _xlApp.Calculation = Excel.XlCalculation.xlCalculationManual;
        }

        public Properties GetProps(Properties props)
        {
            //Excel.Application _xlApp = new Excel.Application();
            //Excel.Workbook _xlWorkbook = null;
            //_xlWorkbook = null;

            //try
            //{
            //    //xlWorkbook = xlApp.Workbooks.Open(_fileLocation);
            //    _xlWorkbook = _xlApp.Workbooks.Open(_fileLocation);
            //}
            //catch
            //{
            //    Console.Write("File Location/Name is not valid. Please press Enter and run the program again.");
            //    Console.ReadLine();
            //    Environment.Exit(0);
            //}

            ////Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //_xlWorksheet = _xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            Console.WriteLine("Upload properties are currently being read.");

            Dictionary<string, string> res = new Dictionary<string, string>();
            //for (int i = 1; i <= 3; i++)
            //{
            //    res.Add(_xlRange.Cells[i, 1].Value2, _xlRange.Cells[i, 2].Value2);
            //}

            res["Server"] = _xlWorksheet.Cells[1, 2].Value2.ToString();
            res["Project"] = _xlWorksheet.Cells[2, 2].Value2.ToString();
            res["Personal Access Token"] = _xlWorksheet.Cells[3, 2].Value2.ToString();
            res["Test Plan ID"] = _xlWorksheet.Cells[4, 2].Value2.ToString();
            res["Test Suite ID"] = _xlWorksheet.Cells[5, 2].Value2.ToString();
            res["Iteration"] = _xlWorksheet.Cells[1, 4].Value2.ToString();

            //Properties props = new Properties();
            props.PersonalAccessToken = res["Personal Access Token"];
            props.Project = res["Project"];
            props.Uri = res["Server"];
            props.TestPlanId = Convert.ToInt32(res["Test Plan ID"]);
            props.TestSuiteId = Convert.ToInt32(res["Test Suite ID"]);
            props.Iteration = Convert.ToInt32(res["Iteration"]);

            TFSCommonFunctions commonFunctions = new TFSCommonFunctions(props);
            //_userName = commonFunctions.GetUserName();

            return props;
        }

        public List<TestCase> GetTestCases()
        {
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(_fileLocation);
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            Console.WriteLine("Test Cases are currently being read.");

            int rowCount = _xlRange.Rows.Count;
            int colCount = _xlRange.Columns.Count;

            int headerRow = 7;

            List<int[]> rowNumbers = new List<int[]>();

            // Find subset of rows for each test case as a array of [Start, End] values
            int start = headerRow;

            for (int i = headerRow + 1; i <= rowCount; i++)
            {
                if (_xlRange.Cells[i, 4] != null && _xlRange.Cells[i, 4].Value2 != null)
                {
                    int[] currTestCase = { start, i - 1 };
                    rowNumbers.Add(currTestCase);
                    start = i;
                }
            }
            int[] lastTestCase = { start, rowCount };
            rowNumbers.Add(lastTestCase);

            //foreach (var currRows in rowNumbers)
            //{
            //    Console.WriteLine(currRows[0] + " " + currRows[1]);
            //}

            List<TestCase> res = new List<TestCase>();

            // First row is a list header row. Do not need for implementation. 
            // This is assuming that the test case upload style is standardized

            // Iterate through each subset of rows for each test case 
            using (var progress = new ProgressBar())
            {
                double totalCount = rowNumbers.Count;
                double currCount = 1; 

                foreach (var currRow in rowNumbers)
                {
                    currCount += 1;
                    progress.Report(currCount / totalCount);

                    int startRow = currRow[0];
                    int endRow = currRow[1];

                    //int testVal = (int)char.GetNumericValue(xlRange.Cells[startRow, 6].Value2[0]);
                    //System.Diagnostics.Debug.WriteLine(testVal);

                    TestCase currTestCase = new TestCase();

                    if (_xlRange.Cells[startRow, 1].Value2 != null)
                    {
                        currTestCase.TestCaseId = Convert.ToInt32(_xlRange.Cells[startRow, 1].Value2);
                    }

                    if (_xlRange.Cells[startRow, 2].Value2 != null)
                    {
                        currTestCase.TestScenarios = new List<TestScenario>();

                        string testScenarioIds = _xlRange.Cells[startRow, 2].Value2.ToString();
                        string[] testScenarioIdArray = testScenarioIds.Split(',').Select(x => x.Trim())
                                    .Where(x => !string.IsNullOrWhiteSpace(x))
                                    .ToArray();
                        foreach (string testScenarioId in testScenarioIdArray)
                        {
                            TestScenario currTestScenario = new TestScenario
                            {
                                TestScenarioId = Convert.ToInt32(testScenarioId)
                            };
                            currTestCase.TestScenarios.Add(currTestScenario);
                        }
                    }

                    currTestCase.TestCaseName = _xlRange.Cells[startRow, 4].Value2;
                    currTestCase.TestObjective = _xlRange.Cells[startRow, 5].Value2;
                    currTestCase.TestDescription = _xlRange.Cells[startRow, 6].Value2;
                    currTestCase.PreCondition = _xlRange.Cells[startRow, 7].Value2;
                    currTestCase.Priority = (int)char.GetNumericValue(_xlRange.Cells[startRow, 8].Value2[0]);
                    currTestCase.PriorityString = _xlRange.Cells[startRow, 8].Value2;
                    currTestCase.Complexity = _xlRange.Cells[startRow, 9].Value2;
                    currTestCase.ScenarioType = _xlRange.Cells[startRow, 10].Value2;
                    currTestCase.Application = _xlRange.Cells[startRow, 11].Value2;
                    currTestCase.ApplicationArea = _xlRange.Cells[startRow, 12].Value2;
                    currTestCase.ApplicationProcess = _xlRange.Cells[startRow, 13].Value2;
                    currTestCase.ApplicationSubArea = _xlRange.Cells[startRow, 14].Value2;
                    currTestCase.TestCaseType = _xlRange.Cells[startRow, 15].Value2;

                    currTestCase.UserName = _userName;

                    for (int i = startRow; i <= endRow; i++)
                    {
                        if (_xlRange.Cells[i, 16].Value2 != null && _xlRange.Cells[i, 17].Value2 != null && _xlRange.Cells[i, 18] != null)
                        {
                            currTestCase.AddStep(i - startRow + 1, _xlRange.Cells[i, 17].Value2, _xlRange.Cells[i, 18].Value2);
                        }
                        //currTestCase.AddStep(_xlRange.Cells[i, 16].Value2, _xlRange.Cells[i, 17].Value2);
                        //if (startRow == 325)
                        //{
                        //    Console.WriteLine(xlRange.Cells[i, 16].Value2 + " " + xlRange.Cells[i, 17].Value2);
                        //}
                    }

                    res.Add(currTestCase);
                }
            }

            Console.WriteLine(res.Count + " Test Cases have been read");

            return res;
        }

        public void UpdateTestCaseId(List<TestCase> testCases)
        {
            Console.WriteLine("Writing Test Case IDs");

            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(_fileLocation);
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = _xlRange.Rows.Count;
            int colCount = _xlRange.Columns.Count;

            int headerRow = 6;

            Dictionary<string, int> testCaseIdMapping = new Dictionary<string, int>();
            foreach (TestCase currCase in testCases)
            {
                testCaseIdMapping[currCase.TestCaseName] = currCase.TestCaseId;
            }

            for (int i = headerRow + 1; i <= rowCount; i++)
            {
                string currTestCaseName = _xlRange.Cells[i, 4].Value2;
                if (currTestCaseName != null && testCaseIdMapping.ContainsKey(currTestCaseName))
                {
                    //if (testCaseIdMapping.ContainsKey(currTestCaseName))
                    //{
                    _xlRange.Cells[i, 1].Value2 = testCaseIdMapping[currTestCaseName];
                    //}
                }
            }

            //string newFileNamePath = stringHelper.addExtension(_fileLocation + "\\" + _fileName + "_WithIDs", "xlsx");
            //xlWorkbook.SaveAs(@newFileNamePath);
            _xlWorkbook.Save();

            Console.WriteLine("Test Case IDs have been updated");

        }

        public void ExcelCleanup()
        {
            _xlApp.Calculation = Excel.XlCalculation.xlCalculationAutomatic;

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(_xlRange);
            Marshal.ReleaseComObject(_xlWorksheet);

            //close and release
            _xlWorkbook.Close();
            Marshal.ReleaseComObject(_xlWorkbook);

            //quit and release
            _xlApp.Quit();
            Marshal.ReleaseComObject(_xlApp);

            Console.WriteLine("File has been closed and cleaned up.");
        }

        //private string getUserName(Dictionary<string, string> props)
        //{
        //    string uri = props["Server"];
        //    string personalAccessToken = props["Personal Access Token"];
        //    string project = props["Project"];
        //    string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalAccessToken)));

        //    HttpClientHandler handler = new HttpClientHandler();
        //    var client = new HttpClient(handler, false);
        //    client.BaseAddress = new Uri(uri);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        //    var requestUri = "/APHP/" + project + "/_apis/wit/workitems/$Test Case?api-version=3.0";
        //    var method = new HttpMethod("GET");
        //    var request = new HttpRequestMessage(method, requestUri) { };
        //    var response = client.SendAsync(request).Result;

        //    string responseString = response.Content.ReadAsStringAsync().Result;
        //    var json = JObject.Parse(responseString);
        //    var res = json["fields"]["System.AssignedTo"].ToString();

        //    return res;
        //}
    }
}
