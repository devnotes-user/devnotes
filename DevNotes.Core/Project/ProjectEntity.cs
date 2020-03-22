using DevNotes.Core.Task;
using System.Collections.Generic;

namespace DevNotes.Core.Project
{
    /// <summary>
    /// Models a project the user wants to store data about.
    /// Is the aggregate root for Task and Note entities.
    /// </summary>
    public class ProjectEntity : IProjectEntity
    {
        /// <summary>
        /// Ctor to inject aggregates
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="projectName"></param>
        /// <param name="taskEntity"></param>
        public ProjectEntity(string projectName, IEnumerable<ITaskEntity> taskEntity)
        {
            ProjectName = projectName;
            Tasks = taskEntity;
        }

        /// <summary>
        /// Acts as the ID for a project.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Stores a collection of TaskEntities associated with this project.
        /// </summary>
        public IEnumerable<ITaskEntity> Tasks { get; }

        /// <summary>
        /// Two projects are equal when their Names are equal.
        /// </summary>
        /// <param name="obj">The other object to compare the Project with.</param>
        /// <returns>True if obj has an equivalent project name, false if not or if other object is any other type except ProjectEntity.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
            {
                return (obj as ProjectEntity).ProjectName == ProjectName;
            }
            return false;
        }

        /// <summary>
        /// Hash based on the ProjectName since it is the ID for a project
        /// </summary>
        /// <returns>Unique hash for a Project if the ProjectName is unique.</returns>
        public override int GetHashCode()
        {
            return -1680903589 + EqualityComparer<string>.Default.GetHashCode(ProjectName);
        }
    }
}
