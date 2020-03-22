using DevNotes.Core.Task;
using System.Collections.Generic;

namespace DevNotes.Core.Project
{
    /// <summary>
    /// Keeps track of tasks and notes for a given project.
    /// The database is encapsulated so clients can use the repository without interacting with the DB directly.
    /// </summary>
    public interface IProjectRepository
    {
        string ProjectName { get; }

        void AddTask(ITaskEntity task);

        void RemoveTask(ITaskEntity task);

        bool FindTaskByName(string taskName);
    }
}
