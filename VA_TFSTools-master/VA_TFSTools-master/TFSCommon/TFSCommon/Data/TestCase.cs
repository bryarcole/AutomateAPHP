using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace TFSCommon.Data
{
    public class TestCase
    {
        public TestCase()
        {
            TestSteps = new List<TestStep>();
            TestCaseResults = new List<TestCaseResult>();
            Urls = new List<Url>();
            CurrentTestCaseResult = new TestCaseResult();
        }

        public TestCase(int testPlanId, int testSuiteId)
        {
            TestPlanId = testPlanId;
            TestSuiteId = testSuiteId;
            TestSteps = new List<TestStep>();
            TestCaseResults = new List<TestCaseResult>();
            Urls = new List<Url>();
            CurrentTestCaseResult = new TestCaseResult();
        }

        public void AddStep(int stepNumber, string action, string expected)
        {
            TestStep currTestStep = new TestStep(stepNumber, action, expected);
            TestSteps.Add(currTestStep);
        }

        public void AddTestScenario(TestScenario testScenario)
        {
            TestScenarios.Add(testScenario);
        }

        [ExplicitKey]
        public int TestCaseId { get; set; }

        //public string TestPlanName { get; set; }

        public int TestPlanId { get; set; }

        //public string TestSuiteName { get; set; }

        public int TestSuiteId { get; set; }

        public string TestCaseName { get; set; }

        public string TestObjective { get; set; }

        public string TestDescription { get; set; }

        public string PreCondition { get; set; }

        public int Priority { get; set; }

        public string PriorityString { get; set; }

        public string Complexity { get; set; }

        public string ScenarioType { get; set; }

        public string Application { get; set; }

        public string ApplicationArea { get; set; }

        public string ApplicationProcess { get; set; }

        public string ApplicationSubArea { get; set; }

        public string TestCaseType { get; set; }

        public string UserName { get; set; }

        public double OriginalIteration { get; set; }

        public double CurrentIteration { get; set; }

        public string Weight { get; set; }

        public string ScriptLeadName { get; set; }

        public string TesterName { get; set; }

        public string WPTask { get; set; }

        public string BaselineStartDate { get; set; }

        public string BaselineEndDate { get; set; }

        public string PlannedStartDate { get; set; }

        public string PlannedEndDate { get; set; }

        public string ActualStartDate { get; set; }

        // ActualEndDate is stored under TestCase.TestCaseResult.ResultDT

        public ICollection<TestStep> TestSteps { get; set; }

        public ICollection<TestScenario> TestScenarios { get; set; }

        public ICollection<Defect> Defects { get; set; }

        //public List<string> TestCasePath { get; set; }

        public string TestCasePath { get; set; }

        public List<string> GetTestCasePath()
        {
            var splitTestCasePath = TestCasePath.Split(',');
            var pathList = new List<string>(splitTestCasePath);
            return pathList;
        }

        public void SetTestCasePathFromStringList(List<string> path)
        {
            var combinedTestCasePath = String.Join(",", path.ToArray());
            TestCasePath = combinedTestCasePath;
        }

        public ICollection<Url> Urls { get; set; }

        public void AddUrl(string name, string urlLink, int urlId)
        {
            Urls.Add(new Url(name, urlLink, urlId));
        }

        public ICollection<TestRun> TestCaseRuns { get; set; }

        public void AddTestCaseRun(TestRun testRun)
        {
            if (!TestCaseRuns.Contains(testRun))
            {
                TestCaseRuns.Add(testRun);
            }
            foreach (TestCaseResult result in testRun.TestCaseResults)
            {
                if (TestCaseId == result.TestCaseId)
                {
                    TestCaseResults.Add(result);
                }
            }
        }

        public ICollection<TestCaseResult> TestCaseResults { get; set; }

        public void AddTestCaseResult(string result, DateTime dateTime)
        {
            TestCaseResults.Add(new TestCaseResult(TestCaseId, result, dateTime));
        }

        public TestCaseResult GetMostRecentTestCaseResult()
        {
            TestCaseResult res = new TestCaseResult();

            return res;
        }

        //public int CurrentTestCaseResultId { get; set; }

        [Write(false)]
        public TestCaseResult CurrentTestCaseResult { get; set; }
    }

    public class TestStep
    {
        public TestStep() { }

        public TestStep(int stepNumber, string action, string expected)
        {
            StepNumber = stepNumber;
            Action = action;
            Expected = expected;
        }

        [Key]
        public int TestStepId { get; set; }

        public int TestCaseId { get; set; }

        public int StepNumber { get; set; }

        public string Action { get; set; }

        public string Expected { get; set; }
    }
}
