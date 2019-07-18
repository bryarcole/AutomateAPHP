using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSTask = TFSCommon.Data.Task;

namespace TFSWebApplication.Repository.TaskRepo
{
    public class TaskRepository : SqlRepository<TFSTask>, ITaskRepository
    {
        public TaskRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<TFSTask>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<TFSTask> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(TFSTask entity)
        {
            string sql = @"INSERT OR REPLACE INTO TFS_Task AS Task
                            (TaskId, TaskCategory, TaskOwningTeam, TaskPrimaryImpactArea, TargetCompletionDate,
                            Discipline, Priority, AssignedTo, Description, Title)
                            VALUES
                            (@TaskId, @TaskCategory, @TaskOwningTeam, @TaskPrimaryImpactArea, @TargetCompletionDate,
                            @Discipline, @Priority, @AssignedTo, @Description, @Title)";
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql, entity);
            }
        }

        public override void UpdateAsync(TFSTask entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
