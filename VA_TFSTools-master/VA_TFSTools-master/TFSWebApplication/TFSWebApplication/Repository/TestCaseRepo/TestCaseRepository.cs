using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSCommon.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using TFSCommon.Common;
using TFSWebApplication.Repository.TestStepRepo;
using TFSWebApplication.Repository.TestCaseResultRepo;

namespace TFSWebApplication.Repository.TestCaseRepo
{
    public class TestCaseRepository : SqlRepository<TestCase>, ITestCaseRepository
    {
        private ITestStepRepository _testStepRepository;
        private ITestCaseResultRepository _testCaseResultRepository;

        public TestCaseRepository(string connectionString) : base(connectionString)
        {
            _testStepRepository = new TestStepRepository(connectionString);
            _testCaseResultRepository = new TestCaseResultRepository(connectionString);
        }

        public override void DeleteAsync(int id)
        {
            string sql = @"DELETE FROM TFS_TestStep AS TestStep
                            WHERE TestCaseId = @id;

                            DELETE FROM TFS_Url AS URL
                            WHERE TestCaseId = @id;
                            
                            DELETE FROM TFS_TestCase AS TestCase
                            WHERE TestCaseId = @id;";
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, new { id });
            }
        }

        public override async Task<IEnumerable<TestCase>> GetAllAsync()
        {
            string sql = @"SELECT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                            LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                            LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                            LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                            LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                            LEFT JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                            LEFT JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                            ORDER BY TestCase.TestCaseId;";

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql);

            return testCaseDictionary.Values.ToList<TestCase>();
        }

        public override async Task<TestCase> GetAsync(int id)
        {
            string sql = @"SELECT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                            LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                            LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                            LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                            LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                            LEFT JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                            LEFT JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                            WHERE TestCase.TestCaseId = @TestCaseId
                            ORDER BY TestCase.TestCaseId;";

            var parameters = new DynamicParameters();
            parameters.Add("@TestCaseId", id, System.Data.DbType.Int32);

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql, parameters);

            return testCaseDictionary.Values.FirstOrDefault<TestCase>();
        }

        public async Task<List<TestCase>> GetByIterationAsync(int iteration)
        {
            var sql = @"SELECT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                        LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                        LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                        LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                        LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                        LEFT JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                        LEFT JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                        WHERE TestCase.CurrentIteration = @iteration
                        ORDER BY TestCase.TestCaseId;";

            var parameters = new DynamicParameters();
            parameters.Add("@iteration", iteration, System.Data.DbType.Int32);

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql, parameters);

            return testCaseDictionary.Values.ToList<TestCase>();
        }

        public async Task<List<TestCase>> GetByPlanAsync(int planId)
        {
            var sql = @"SELECT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                        LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                        LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                        LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                        LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                        LEFT JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                        LEFT JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                        WHERE TestCase.TestPlanId = @planId
                        ORDER BY TestCase.TestCaseId;";

            var parameters = new DynamicParameters();
            parameters.Add("@planId", planId, System.Data.DbType.Int32);

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql, parameters);

            return testCaseDictionary.Values.ToList<TestCase>();
        }

        public async Task<TestCase> GetByTestCaseName(string name)
        {
            var sql = @"SELECT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                        LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                        LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                        LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                        LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                        LEFT JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                        LEFT JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                        WHERE TestCase.TestCaseName = @name
                        ORDER BY TestCase.TestCaseId;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@name", name);

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql, parameters);

            return testCaseDictionary.Values.FirstOrDefault<TestCase>();
        }

        public async Task<IEnumerable<TestCase>> GetTestCasesExecutedOnDate(string dateTime, string[] statuses, int cumulative, string testCasePathStart = null)
        {
            // Statuses string builder
            Boolean notRun = statuses.ToList<String>().Contains("Not Run");
            Boolean blocked = statuses.ToList<String>().Contains("Blocked");
            string statusStringBuild;
            string[] tempStatus = statuses;
            if (notRun)
            {
                List<String> temp = tempStatus.ToList<String>();
                temp.Remove("Not Run");
                tempStatus = temp.ToArray();
                //statusStringBuild = "'" + String.Join("','", temp) + "'";
            }
            if (blocked)
            {
                List<String> temp = tempStatus.ToList<String>();
                temp.Remove("Blocked");
                tempStatus = temp.ToArray();
            }

            statusStringBuild = "'" + String.Join("','", tempStatus) + "'";

            //string testCasePathWithWildcard = testCasePathStart + "%";
            string testCasePathWithWildcard = testCasePathStart;

            // Date Comparator parameter 
            string dateComparator;
            if (cumulative == 1)
            {
                dateComparator = "<=";
            }
            else
            {
                dateComparator = "=";
            }

            string sql = @"SELECT TestCase.TestCaseId FROM TFS_TestCase TestCase
                            WHERE TestCase.TestCasePath LIKE @testCasePathStart
                            AND (SELECT Result FROM TFS_TestCaseResult  TCR2
                                    WHERE TCR2.TestCaseId = TestCase.TestCaseId
                                    AND DATE(TCR2.ResultDt) " + dateComparator + @" DATE(@dateTime)
                                    ORDER BY TCR2.ResultDT DESC LIMIT 1
                                ) IN (" + statusStringBuild + @") 
                            ORDER BY TestCase.TestCaseId";

            string notRunSql = @"SELECT TestCase.TestCaseId FROM TFS_TestCase TestCase
                                WHERE TestCase.TestCasePath LIKE @testCasePathStart
                                AND NOT EXISTS (SELECT * FROM TFS_TestCaseResult  TCR2
                                        WHERE TCR2.TestCaseId = TestCase.TestCaseId
                                    ) 
                                ORDER BY TestCase.TestCaseId";

            string blockedReadyForTestSql = @"SELECT DISTINCT TestCase.TestCaseId FROM TFS_TestCase TestCase
                            JOIN MP_TestCaseDefectMap ON TestCase.TestCaseId = MP_TestCaseDefectMap.TestCaseId
                            JOIN TFS_Defect Defect ON MP_TestCaseDefectMap.DefectId = Defect.DefectId
                            WHERE TestCase.TestCasePath LIKE @testCasePathStart
                            AND Defect.DefectSeverity IN ('1 - Critical', '2 - High')
                            AND Defect.Status IN ('Resolved', 'Closed', 'Rejected')
                            AND (SELECT TCR.Result FROM TFS_TestCase TC
                                JOIN TFS_TestCaseResult TCR ON TC.TestCaseId = TCR.TestCaseId
                                WHERE TC.TestCaseId = TestCase.TestCaseId
                                AND DATE(TCR.ResultDt) " + dateComparator + @" DATE(@dateTime)
                                ORDER BY TCR.ResultDT DESC
                                LIMIT 1
                            ) IN ('Blocked') 
                            AND NOT EXISTS (
                                SELECT * FROM TFS_TestCase TC
                                JOIN MP_TestCaseDefectMap TCDM ON TC.TestCaseId = TCDM.TestCaseId
                                JOIN TFS_Defect D ON TCDM.DefectId = D.DefectId
                                WHERE TC.TestCaseId = TestCase.TestCaseId
                                AND D.DefectId != Defect.DefectId
                                AND D.Status NOT IN ('Resolved', 'Closed', 'Rejected')
                            );";


            //System.Diagnostics.Trace.WriteLine(sql);
            //System.Diagnostics.Trace.WriteLine(dateTime);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@testCasePathStart", testCasePathWithWildcard);
            parameters.Add("@dateTime", dateTime);

            HashSet<int> ids = new HashSet<int>();
            using (var conn = GetOpenConnection())
            {
                if (statusStringBuild != "")
                {
                    ids = conn.QueryAsync<int>(sql, parameters).Result.ToHashSet<int>();
                }

                if (notRun)
                {
                    ids.UnionWith(conn.QueryAsync<int>(notRunSql, parameters).Result.ToHashSet<int>());
                }

                if (blocked)
                {
                    ids.UnionWith(conn.QueryAsync<int>(blockedReadyForTestSql, parameters).Result.ToHashSet<int>());
                }
            }

            //System.Diagnostics.Trace.WriteLine(ids.ToList<int>().Count);

            IEnumerable<TestCase> res = GetTestCaseFromList(ids).Result;

            return res;
        }

        public async Task<IEnumerable<TestCase>> GetTestCaseTotalExecutedOnDate(string dateTime, string testCasePath)
        {
            List<int> ids = new List<int>();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@dateTime", dateTime);
            parameters.Add("@testCasePath", testCasePath);



            IEnumerable<TestCase> res = GetTestCaseFromList(ids).Result;

            return res;
        }

        public async Task<IEnumerable<TestCase>> GetReadyForTestTestCases(string[] severity, string[] testCaseStatuses)
        {
            string severityStringBuild = "'" + String.Join("','", severity) + "'";
            string testCaseStatusStringBuild = "'" + String.Join("','", testCaseStatuses) + "'";
            string sql = @"SELECT DISTINCT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                            LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                            LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                            LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                            LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                            JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                            JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                            WHERE Defect.DefectSeverity IN (" + severityStringBuild + @")
                            AND Defect.Status IN ('Resolved', 'Closed', 'Rejected')
                            AND NOT EXISTS(
                                SELECT * FROM TFS_TestCase TC
                                JOIN MP_TestCaseDefectMap TCDM ON TC.TestCaseId = TCDM.TestCaseId
                                JOIN TFS_Defect D ON TCDM.DefectId = D.DefectId
                                WHERE TC.TestCaseId = TestCase.TestCaseId
                                AND D.DefectId != Defect.DefectId
                                AND D.Status NOT IN ('Resolved', 'Closed', 'Rejected')
                            )
                            AND (
                                SELECT TCR.Result FROM TFS_TestCase TC
                                JOIN TFS_TestCaseResult TCR ON TC.TestCaseId = TCR.TestCaseId
                                WHERE TC.TestCaseId = TestCase.TestCaseId
                                ORDER BY TCR.ResultDT DESC
                                LIMIT 1
                            ) IN (" + testCaseStatusStringBuild + @")
                            ORDER BY TestCase.TestCaseId;";

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql);
            return testCaseDictionary.Values.ToList<TestCase>();
        }

        public async Task<IEnumerable<TestCase>> GetTestCasesPassedWithMinorDefects(string testCasePath)
        {
            string sql = @"SELECT DISTINCT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                            LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                            LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                            LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                            LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                            JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                            JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                            WHERE Defect.DefectSeverity NOT IN ('1 - Critical', '2 - High')
                            AND TestCase.TestCasePath = @testCasePath
                            AND NOT EXISTS(
                                SELECT * FROM TFS_TestCase TC
                                JOIN MP_TestCaseDefectMap TCDM ON TC.TestCaseId = TCDM.TestCaseId
                                JOIN TFS_Defect D ON TCDM.DefectId = D.DefectId
                                WHERE TC.TestCaseId = TestCase.TestCaseId
                                AND D.DefectSeverity IN('1 - Critical', '2 - High')
                                AND D.Status NOT IN ('Resolved', 'Closed', 'Rejected')
                            )
                            AND (
                                SELECT Result FROM TFS_TestCase TC
                                JOIN TFS_TestCaseResult ON TC.TestCaseId = TFS_TestCaseResult.TestCaseId
                                WHERE TC.TestCaseId = TestCase.TestCaseId
                                ORDER BY TFS_TestCaseResult.ResultDT DESC
                                LIMIT 1
                            ) = 'Failed'
                            ORDER BY TestCase.TestCaseId;";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@testCasePath", testCasePath);

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql, parameters);
            return testCaseDictionary.Values.ToList<TestCase>();
        }

        private async Task<IEnumerable<TestCase>> GetTestCaseFromList(IEnumerable<int> testCaseIds)
        {
            string testCaseIdString = String.Join(",", testCaseIds);
            string sql = @"SELECT DISTINCT TestCase.*, Url.*, TestCaseResult.*, TestScenario.*, Defect.* FROM TFS_TestCase TestCase
                            LEFT JOIN TFS_Url Url ON Url.TestCaseId = TestCase.TestCaseId 
                            LEFT JOIN TFS_TestCaseResult TestCaseResult ON TestCase.TestCaseId = TestCaseResult.TestCaseId
                            LEFT JOIN MP_TestScenarioTestCaseMap TestScenarioTestCaseMap ON TestCase.TestCaseId = TestScenarioTestCaseMap.TestCaseId
                            LEFT JOIN TFS_TestScenario TestScenario ON TestScenarioTestCaseMap.TestScenarioId = TestScenario.TestScenarioId
                            LEFT JOIN MP_TestCaseDefectMap TestCaseDefectMap ON TestCase.TestCaseId = TestCaseDefectMap.TestCaseId
                            LEFT JOIN TFS_Defect Defect ON TestCaseDefectMap.DefectId = Defect.DefectId
                            WHERE TestCase.TestCaseId IN (" + testCaseIdString + @")
                            ORDER BY TestCase.TestCaseId;";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@testCaseIds", testCaseIdString);

            Dictionary<int, TestCase> testCaseDictionary = await GetAsyncHelper(sql, parameters);

            return testCaseDictionary.Values.AsEnumerable<TestCase>();
        }

        private async Task<Dictionary<int, TestCase>> GetAsyncHelper(string sql, DynamicParameters parameters = null)
        {
            var testCaseDictionary = new Dictionary<int, TestCase>();

            using (var conn = GetOpenConnection())
            {
                var testCaseUrlDictionary = new Dictionary<int, List<int>>();
                var testCaseResultDictionary = new Dictionary<int, List<int>>();
                var testScenarioDictionary = new Dictionary<int, List<int>>();
                var testStepDictionary = new Dictionary<int, List<int>>();
                var defectDictionary = new Dictionary<int, List<int>>();

                await conn.QueryAsync<TestCase, Url, TestCaseResult, TestScenario, Defect, TestCase>(
                        sql,
                        (testCase, url, testCaseResult, testScenario, defect) =>
                        {
                            TestCase testCaseEntry;

                            if (!testCaseDictionary.TryGetValue(testCase.TestCaseId, out testCaseEntry))
                            {
                                testCaseEntry = testCase;
                                if (url != null && url.UrlId != 0)
                                {
                                    System.Diagnostics.Debug.WriteLine(url.UrlLink);
                                    testCaseEntry.Urls = new List<Url>();
                                    testCaseUrlDictionary.Add(testCase.TestCaseId, new List<int>());
                                }
                                if (testCaseResult != null && testCaseResult.TestCaseResultId != 0)
                                {
                                    testCaseEntry.TestCaseResults = new List<TestCaseResult>();
                                    testCaseResultDictionary.Add(testCase.TestCaseId, new List<int>());
                                    //System.Diagnostics.Debug.WriteLine(testCaseResult.TestCaseId);
                                }
                                if (testScenario != null && testScenario.TestScenarioId != 0)
                                {
                                    testCaseEntry.TestScenarios = new List<TestScenario>();
                                    testScenarioDictionary.Add(testCase.TestCaseId, new List<int>());
                                }
                                if (defect != null && defect.DefectId != 0)
                                {
                                    testCaseEntry.Defects = new List<Defect>();
                                    defectDictionary.Add(testCase.TestCaseId, new List<int>());
                                }
                                testCaseDictionary.Add(testCase.TestCaseId, testCase);
                            }

                            var testCaseId = testCase.TestCaseId;

                            if (testCaseUrlDictionary.ContainsKey(testCaseId)
                                    && !testCaseUrlDictionary[testCaseId].Contains(url.UrlId))
                            {
                                testCaseEntry.Urls.Add(url);
                                testCaseUrlDictionary[testCaseId].Add(url.UrlId);
                            }
                            if (testCaseResultDictionary.ContainsKey(testCaseId)
                                    && !testCaseResultDictionary[testCaseId].Contains(testCaseResult.TestCaseResultId))
                            {
                                testCaseEntry.TestCaseResults.Add(testCaseResult);
                                testCaseResultDictionary[testCaseId].Add(testCaseResult.TestCaseResultId);
                            }
                            if (testScenarioDictionary.ContainsKey(testCaseId)
                                    && !testScenarioDictionary[testCaseId].Contains(testScenario.TestScenarioId))
                            {
                                testCaseEntry.TestScenarios.Add(testScenario);
                                testScenarioDictionary[testCaseId].Add(testScenario.TestScenarioId);
                            }
                            if (defectDictionary.ContainsKey(testCaseId)
                                    && !defectDictionary[testCaseId].Contains(defect.DefectId))
                            {
                                testCaseEntry.Defects.Add(defect);
                                defectDictionary[testCaseId].Add(defect.DefectId);
                            }

                            return testCaseEntry;
                        },
                        parameters,
                        splitOn: "TestCaseId,TestCaseResultId,TestScenarioId,DefectId"
                    );
            }

            Dictionary<int, TestCase> testCaseWithLatestResult = new Dictionary<int, TestCase>();
            
            foreach (TestCase currTestCase in testCaseDictionary.Values)
            {
                TestCase copyTestCase = currTestCase.CloneJson<TestCase>();
                copyTestCase.CurrentTestCaseResult = GetMostRecentTestCaseResult(copyTestCase.TestCaseId).Result;

                testCaseWithLatestResult[copyTestCase.TestCaseId] = copyTestCase;
            }

            return testCaseWithLatestResult;
        }

        private async Task<TestCaseResult> GetMostRecentTestCaseResult(int testCaseId)
        {
            var sql = @"SELECT * FROM TFS_TestCaseResult TestCaseResult 
                        WHERE TestCaseResult.TestCaseId = @id
                        ORDER BY ResultDt DESC LIMIT 1;";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", testCaseId);

            TestCaseResult res;

            using (var conn = GetOpenConnection())
            {
                res = await conn.QueryFirstOrDefaultAsync<TestCaseResult>(sql, parameters);
            }

            return res;
        }

        public override void InsertAsync(TestCase entity)
        {
            var sql = @"INSERT OR REPLACE INTO TFS_TestCase AS TestCase 
                        (TestCaseId, TestCaseName, TestObjective, TestDescription, PreCondition, Priority, PriorityString, Complexity, ScenarioType, Application, 
                        ApplicationArea, ApplicationProcess, ApplicationSubArea, TestCaseType, UserName, OriginalIteration, CurrentIteration, TestCasePath, 
                        PlannedStartDate, PlannedEndDate,BaselineStartDate, BaselineEndDate, ActualStartDate, WPTask, TesterName, ScriptLeadName, Weight,
                        TestPlanId, TestSuiteId)
                        VALUES
                        (@TestCaseId, @TestCaseName, @TestObjective, @TestDescription, @PreCondition, @Priority, @PriorityString, @Complexity, @ScenarioType, @Application, 
                        @ApplicationArea, @ApplicationProcess, @ApplicationSubArea, @TestCaseType, @UserName, @OriginalIteration, @CurrentIteration, @TestCasePath, 
                        @PlannedStartDate, @PlannedEndDate, @BaselineStartDate, @BaselineEndDate, @ActualStartDate, @WPTask, @TesterName, @ScriptLeadName, @Weight,
                        @TestPlanId, @TestSuiteId)";
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, entity);
            }

            //DeleteTestStepWithTestCaseId(entity.TestCaseId);

            foreach (TestStep currTestStep in entity.TestSteps)
            {
                TestStep newTestStep = currTestStep;
                //System.Diagnostics.Debug.WriteLine(Convert.ToInt32(entity.TestCaseId.ToString() + newTestStep.StepNumber.ToString()));
                newTestStep.TestStepId = Convert.ToInt32(entity.TestCaseId.ToString() + newTestStep.StepNumber.ToString());
                //System.Diagnostics.Debug.WriteLine(newTestStep.TestStepId);
                newTestStep.TestCaseId = entity.TestCaseId;

                _testStepRepository.InsertAsync(newTestStep);
            }

            foreach (TestCaseResult currTestCaseResult in entity.TestCaseResults)
            {
                if (currTestCaseResult.TestRunId != 0)
                {
                    var checkExistingTestResultSql = @"SELECT COUNT(*) FROM TFS_TestCaseResult TestCaseResult WHERE TestCaseId = @TestCaseId AND TestRunId = @TestRunId";
                    using (var conn = GetOpenConnection())
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@TestCaseId", currTestCaseResult.TestCaseId);
                        parameters.Add("@TestRunId", currTestCaseResult.TestRunId);
                        int countTestCaseResult = conn.ExecuteScalar<int>(checkExistingTestResultSql, parameters);

                        if (countTestCaseResult == 0)
                        {
                            _testCaseResultRepository.InsertAsync(currTestCaseResult);
                        }
                        else
                        {
                            _testCaseResultRepository.UpdateAsync(currTestCaseResult);
                        }
                    }
                }
            }
        }

        //private void DeleteTestStepWithTestCaseId(int testCaseId)
        //{
        //    var sql = @"DELETE FROM TFS_TestStep AS TestStep WHERE TestCaseId = @TestCaseId";
        //    using (var conn = GetOpenConnection())
        //    {
        //        conn.Execute(sql, new { TestCaseId = testCaseId });
        //    }
        //}

        //private void InsertTestStepAsync(TestStep testStep)
        //{
        //    var sql = @"INSERT OR REPLACE INTO TFS_TestStep AS TestStep 
        //                (TestStepId, StepNumber, Action, Expected, TestCaseId)
        //                VALUES
        //                (@TestStepId, @StepNumber, @Action, @Expected, @TestCaseId)";
        //    using (var conn = GetOpenConnection())
        //    {
        //        conn.ExecuteAsync(sql, testStep);
        //    }
        //}

        //private void InsertTestCaseResultAsync(TestCaseResult testCaseResult)
        //{
        //    var sql = @"INSERT INTO TFS_TestCaseResult AS TestCaseResult 
        //                (TestRunId, RunByName, Result, ResultDT, TestCaseId) 
        //                VALES
        //                (@TestRunId, @RunByName, @Result, @ResultDT, @TestCaseId)";
        //    using (var conn = GetOpenConnection())
        //    {
        //        conn.ExecuteAsync(sql, testCaseResult);
        //    }
        //}


        public override void UpdateAsync(TestCase entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
