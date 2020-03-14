using DevNotes.Note;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.Task
{
    public class TaskEntity : ITaskEntity
    {
        public TaskEntity()
        {
            TaskID = null;
        }

        public TaskEntity(string taskID, string projectID, string taskName)
        {
            TaskID = taskID;
            ProjectID = projectID;
            TaskName = taskName;
        }

        public string TaskID { get; }

        public string ProjectID { get; }

        public string TaskName { get; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
            {
                return TaskID == (obj as TaskEntity).TaskID;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -1716862765;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TaskID);
            return hashCode;
        }
    }
}
