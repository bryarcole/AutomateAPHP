//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
using SQLite;
using System;

namespace TFSWebApplication.Migrations
{
    public class SQLiteDb
    {
        string _path;
        public SQLiteDb(string path)
        {
            _path = path;
        }
        
         public void Create()
        {
            using (SQLiteConnection db = new SQLiteConnection(_path))
            {
                db.CreateTable<MP_ContractRequirementMectRequirementMap>();
                db.CreateTable<MP_ContractRequirementTaskMap>();
                db.CreateTable<MP_TestCaseDefectMap>();
                db.CreateTable<MP_TestCaseTestCaseResultMap>();
                db.CreateTable<MP_TestCaseTestRunMap>();
                db.CreateTable<MP_TestScenarioTestCaseMap>();
                db.CreateTable<MP_TestSuiteTestSuiteMap>();
                db.CreateTable<RD_ApplicationArea>();
                db.CreateTable<RD_ApplicationProcess>();
                db.CreateTable<RD_Iteration>();
                db.CreateTable<TFS_ContractRequirement>();
                db.CreateTable<TFS_Defect>();
                db.CreateTable<TFS_DefectHistory>();
                db.CreateTable<TFS_ExternalTestScenario>();
                db.CreateTable<TFS_MectRequirement>();
                db.CreateTable<TFS_Task>();
                db.CreateTable<TFS_TestCase>();
                db.CreateTable<TFS_TestCaseResult>();
                db.CreateTable<TFS_TestPlan>();
                db.CreateTable<TFS_TestRun>();
                db.CreateTable<TFS_TestScenario>();
                db.CreateTable<TFS_TestStep>();
                db.CreateTable<TFS_TestSuite>();
                db.CreateTable<TFS_Url>();
            }
        }
    }
    public partial class MP_ContractRequirementMectRequirementMap
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ContractRequirementContractRequirementId { get; set; }
        
        [NotNull]
        public Int64 ParentContractRequirementId { get; set; }
        
        [NotNull]
        public Int64 ChildContractRequirementId { get; set; }
        
    }
    
    public partial class MP_ContractRequirementTaskMap
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ContractRequirementTaskId { get; set; }
        
        [NotNull]
        public Int64 ContractRequirementId { get; set; }
        
        [NotNull]
        public Int64 TaskId { get; set; }
        
    }
    
    public partial class MP_TestCaseDefectMap
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestCaseDefectId { get; set; }
        
        [NotNull]
        public Int64 TestCaseId { get; set; }
        
        [NotNull]
        public Int64 DefectId { get; set; }
        
    }
    
    public partial class MP_TestCaseTestCaseResultMap
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestCaseTestResultId { get; set; }
        
        [NotNull]
        public Int64 TestCaseId { get; set; }
        
        [NotNull]
        public Int64 TestResultId { get; set; }
        
    }
    
    public partial class MP_TestCaseTestRunMap
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestCaseTestRunId { get; set; }
        
        [NotNull]
        public Int64 TestCaseId { get; set; }
        
        [NotNull]
        public Int64 TestRunId { get; set; }
        
    }
    
    public partial class MP_TestScenarioTestCaseMap
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestCaseTestScenarioId { get; set; }
        
        [NotNull]
        public Int64 TestCaseId { get; set; }
        
        [NotNull]
        public Int64 TestScenarioId { get; set; }
        
    }
    
    public partial class MP_TestSuiteTestSuiteMap
    {
        [PrimaryKey, AutoIncrement]
        public Int64 SuiteSuiteMapId { get; set; }
        
        [NotNull]
        public Int64 ParentTestSuiteId { get; set; }
        
        [NotNull]
        public Int64 ChildTestSuiteId { get; set; }
        
    }
    
    public partial class RD_ApplicationArea
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ApplicationAreaId { get; set; }
        
        [NotNull]
        public Int64 AreaName { get; set; }
        
    }
    
    public partial class RD_ApplicationProcess
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ApplicationProcessId { get; set; }
        
        [NotNull]
        public String ProcessName { get; set; }
        
    }
    
    public partial class RD_Iteration
    {
        [PrimaryKey, AutoIncrement]
        public Int64 IterationId { get; set; }
        
        [NotNull]
        public String IterationName { get; set; }
        
    }
    
    public partial class TFS_ContractRequirement
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ContractRequirementId { get; set; }
        
        [NotNull]
        public Int64 RequirementTitle { get; set; }
        
        public String ProposedLanguage { get; set; }
        
        public Int64? Priority { get; set; }
        
        public String Description { get; set; }
        
        public String AssignedTo { get; set; }
        
        public String State { get; set; }
        
        public String PrimaryArea { get; set; }
        
        public String Validated { get; set; }
        
        public String DeScopeDetails { get; set; }
        
        public String ValidationActionItem { get; set; }
        
        public String ValidationActionItemStatus { get; set; }
        
        public String ValidationAssumptions { get; set; }
        
        public String Deliverable { get; set; }
        
        public String CoveredInCrp { get; set; }
        
        public String CrpSession { get; set; }
        
        public String SolutionUnderstanding { get; set; }
        
        public String VendorIntegration { get; set; }
        
        public String Coverage { get; set; }
        
    }
    
    public partial class TFS_Defect
    {
        [PrimaryKey, AutoIncrement]
        public Int64 DefectId { get; set; }
        
        [NotNull]
        public String DefectName { get; set; }
        
        public String DefectSeverity { get; set; }
        
        public String DefectHistory { get; set; }
        
        public String Status { get; set; }
        
        public String AssignedTo { get; set; }
        
        public String DefectCreateDate { get; set; }
        
        public String DiscussionDate { get; set; }
        
        public String Iteration { get; set; }
        
        public String DefectType { get; set; }
        
        public String TfsVersion { get; set; }

        public String ApplicationArea { get; set; }

        public String ApplicationProcess { get; set; }

        public String FoundInEnvironment { get; set; }

    }
    
    public partial class TFS_DefectHistory
    {
        [PrimaryKey, AutoIncrement]
        public Int64 DefectHistoryId { get; set; }
        
        [NotNull]
        public Int64 DefectId { get; set; }
        
        public String History { get; set; }
        
        public String Timestamp { get; set; }
        
    }
    
    public partial class TFS_ExternalTestScenario
    {
        [PrimaryKey, AutoIncrement]
        public Int64 ExternalTestScenarioId { get; set; }
        
        [NotNull]
        public Int64 IterationId { get; set; }
        
        public String Name { get; set; }
        
    }
    
    public partial class TFS_MectRequirement
    {
        [PrimaryKey, AutoIncrement]
        public Int64 MectRequirementId { get; set; }
        
        public String Description { get; set; }
        
        public String MectName { get; set; }
        
        public String MectCriteria { get; set; }
        
        public String MectSource { get; set; }
        
        public String Scope { get; set; }
        
        public String MectTitle { get; set; }
        
    }
    
    public partial class TFS_Task
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TaskId { get; set; }
        
        public String TaskCategory { get; set; }
        
        public String TaskOwningTeam { get; set; }
        
        public String TaskPrimaryImpactArea { get; set; }
        
        public String TargetCompletionDate { get; set; }
        
        public String Discipline { get; set; }
        
        public Int64? Priority { get; set; }
        
        public String AssignedTo { get; set; }
        
        public String Description { get; set; }
        
        public String Title { get; set; }
        
    }
    
    public partial class TFS_TestCase
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestCaseId { get; set; }
        
        [NotNull]
        public String TestCaseName { get; set; }
        
        [NotNull]
        public String TestObjective { get; set; }
        
        public String TestDescription { get; set; }
        
        public String PreCondition { get; set; }
        
        [NotNull]
        public Int64 Priority { get; set; }
        
        [NotNull]
        public String PriorityString { get; set; }
        
        public String Complexity { get; set; }
        
        public String Application { get; set; }
        
        public String ApplicationSubArea { get; set; }
        
        public String UserName { get; set; }
        
        public Int64? CurrentTestCaseResultId { get; set; }
        
        public Int64? OriginalIteration { get; set; }
        
        public Int64? CurrentIteration { get; set; }
        
        public String Weight { get; set; }
        
        public String ScriptLeadName { get; set; }
        
        public String TesterName { get; set; }
        
        public String WPTask { get; set; }
        
        public String BaselineStartDate { get; set; }
        
        public String BaselineEndDate { get; set; }
        
        public String PlannedStartDate { get; set; }
        
        public String PlannedEndDate { get; set; }
        
        public String ActualStartDate { get; set; }
        
        [NotNull]
        public Int64 TestPlanId { get; set; }
        
        [NotNull]
        public Int64 TestSuiteId { get; set; }
        
        [NotNull]
        public String ApplicationArea { get; set; }
        
        [NotNull]
        public String ApplicationProcess { get; set; }
        
        [NotNull]
        public String TestCaseType { get; set; }
        
        public String TestCasePath { get; set; }
        
        public String ScenarioType { get; set; }
        
    }
    
    public partial class TFS_TestCaseResult
    {
        [PrimaryKey, AutoIncrement]
        [Unique(Name = "sqlite_autoindex_TFS_TestCaseResult_1", Order = 0)]
        public Int64 TestCaseResultId { get; set; }
        
        [NotNull]
        public Int64 TestRunId { get; set; }
        
        [NotNull]
        public String Result { get; set; }
        
        public String RunByName { get; set; }
        
        public String ResultDT { get; set; }
        
        [NotNull]
        public Int64 TestCaseId { get; set; }
        
    }
    
    public partial class TFS_TestPlan
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestPlanId { get; set; }
        
        public String TestPlanName { get; set; }
        
    }
    
    public partial class TFS_TestRun
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestRunId { get; set; }
        
        [NotNull]
        public String TestRunName { get; set; }
        
        public Int64? PassedTests { get; set; }
        
        [NotNull]
        public String State { get; set; }
        
        public Int64? TotalTests { get; set; }
        
        public String LastUpdatedBy { get; set; }
        
        public String LastUpdatedDate { get; set; }
        
        public String Owner { get; set; }
        
        public Int64? TestPlanId { get; set; }
        
        public Int64? TestSuiteId { get; set; }
        
        public Int64? IncompleteTests { get; set; }
        
        public Int64? NotApplicableTests { get; set; }
        
        public Int64? UnanalyzedTests { get; set; }
        
    }
    
    public partial class TFS_TestScenario
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestScenarioId { get; set; }
        
        public Int64? ContractRequirementId { get; set; }
        
        [NotNull]
        public String ApplicationArea { get; set; }
        
        [NotNull]
        public String ApplicationProcess { get; set; }
        
        public String ScenarioDescription { get; set; }
        
        [NotNull]
        public String ScenarioName { get; set; }
        
    }
    
    public partial class TFS_TestStep
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestStepId { get; set; }
        
        [NotNull]
        public Int64 StepNumber { get; set; }
        
        [NotNull]
        public String Action { get; set; }
        
        [NotNull]
        public String Expected { get; set; }
        
        public Int64? TestCaseId { get; set; }
        
    }
    
    public partial class TFS_TestSuite
    {
        [PrimaryKey, AutoIncrement]
        public Int64 TestSuiteId { get; set; }
        
        [NotNull]
        public String TestSuiteName { get; set; }
        
        [NotNull]
        public String TestPath { get; set; }
        
    }
    
    public partial class TFS_Url
    {
        [NotNull]
        public Int64 TestCaseId { get; set; }
        
        [PrimaryKey, AutoIncrement]
        public Int64 UrlId { get; set; }
        
        [NotNull]
        public String UrlName { get; set; }
        
        [NotNull]
        public String UrlLink { get; set; }
        
    }
    
}
