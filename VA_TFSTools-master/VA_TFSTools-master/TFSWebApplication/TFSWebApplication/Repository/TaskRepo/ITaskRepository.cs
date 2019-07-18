using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFSTask = TFSCommon.Data.Task;

namespace TFSWebApplication.Repository.TaskRepo
{
    interface ITaskRepository : IGenericRepository<TFSTask>
    {
    }
}
