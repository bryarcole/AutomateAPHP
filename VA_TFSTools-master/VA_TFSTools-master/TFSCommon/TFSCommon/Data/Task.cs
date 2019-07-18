using Dapper.Contrib.Extensions;
using System;

namespace TFSCommon.Data
{
    public class Task
    {
        public Task() { }

        [ExplicitKey]
        public int TaskId { get; set; }

        public string TaskCategory { get; set; }

        public string TaskOwningTeam { get; set; }

        public string TaskPrimaryImpactArea { get; set; }

        public DateTime TargetCompletionDate { get; set; }

        public string Discipline { get; set; }

        public int Priority { get; set; }

        public string AssignedTo { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }
    }
}
