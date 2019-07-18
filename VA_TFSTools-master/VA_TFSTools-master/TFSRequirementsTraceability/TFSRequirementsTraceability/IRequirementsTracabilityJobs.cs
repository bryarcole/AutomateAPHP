using System.Collections.Generic;
using TFSCommon.Data;

namespace RequirementsTraceability
{
    public interface IRequirementsTracabilityJobs
    {
        void GatherAndWriteMectRequirementToDb();

        void GatherAndWriteContractMectRequirementMappingToDb();

        void GatherAndWriteContractRequirementsToDb(List<ContractRequirement> requirements);

        void CreateAndUpdateTestScenarios();

        void UpdateTestsCasesInDB();

        List<TestCase> GetTestCasesInSuite();

        List<TestCase> GetTestCaseGivenPlanSuite(int planId, int suiteId);

        TestCase GetSingleTestCase(int testCaseId, int suiteId);

        void UpdateMectAndContractRequirementIdsToExcel();

        List<ContractRequirement> GatherAndWriteContractRequirementToDb();

        List<ContractRequirement> UpdateContractRequirementsAndAllLinks();

        List<int> DeleteNonExistingTestsCases(List<TestCase> allTestCases = null);
    }
}