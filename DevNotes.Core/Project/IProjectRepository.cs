using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.Core.Project
{
    /// <summary>
    /// Interface for Project repositories.
    /// </summary>
    public interface IProjectRepository
    {
        IEnumerable<IProjectEntity> Items { get; }

        /// <summary>
        /// Adds a project to the repository if it doesn't already exist
        /// </summary>
        /// <param name="project">Project to add to the repository</param>
        void Add(IProjectEntity project);

        /// <summary>
        /// Predicate to determine if a project exists in the repository
        /// </summary>
        /// <param name="project">Which project to check for existance in repo.</param>
        /// <returns>True if project exists, false if project does not.</returns>
        bool Exists(IProjectEntity project);

        /// <summary>
        /// Discovers a project in the repo if it exists by its name.
        /// </summary>
        /// <param name="projectName">Project name to search for.</param>
        /// <returns>The entity associated with the project name.</returns>
        IProjectEntity FindByKey(string projectName);

        /// <summary>
        /// Removes a project from the repository
        /// </summary>
        /// <param name="projectName">The project to remove if it exists</param>
        void RemoveProject(string projectName);

        /// <summary>
        /// Update data associated with the project if it exists
        /// </summary>
        /// <param name="project">Project to update</param>
        void Update(IProjectEntity project);
    }
}
