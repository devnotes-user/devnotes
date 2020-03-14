using DevNotes.Core.Task;
using System.Collections.Generic;

namespace DevNotes.Core.Project
{
    /// <summary>
    /// Models a Project the user is working on.
    /// </summary>
    public interface IProjectEntity
    {
        /// <summary>
        /// 
        /// </summary>
        string ProjectID { get; }

        string ProjectName { get; }

        /// <summary>
        /// List of tasks in the project
        /// </summary>
        IEnumerable<ITaskEntity> Tasks { get; }
    }
}
