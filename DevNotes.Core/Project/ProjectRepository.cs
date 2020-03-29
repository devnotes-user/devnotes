using DevNotes.Core.DevNotesSQLite;
using DevNotes.Core.Task;
using System.Collections.Generic;
using System;

namespace DevNotes.Core.Project
{
    /// <summary>
    /// Keeps track of tasks and notes for a given project.
    /// The database is encapsulated so clients can use the repository without interacting with the DB directly.
    /// </summary>
    public class ProjectRepository : IProjectRepository
    {
        private IDevNotesSQLiteConnection sqliteConnection;
        private ISQLiteCommandFactory sqliteCommandFactory;
        private IProjectEntity currentProject;

        /// <summary>
        /// Create a new project repository
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        public ProjectRepository(string projectName, IDevNotesSQLiteConnection sqliteConnection)
        {
            // Check that connection is a valid object before proceeding.
            if (sqliteConnection is null)
            {
                throw new ArgumentNullException("sqliteConnection");
            }

            if (projectName is null)
            {
                throw new ArgumentNullException("projectName");
            }

            this.sqliteConnection = sqliteConnection;
            sqliteCommandFactory = new SQLiteCommandFactory(sqliteConnection);
            currentProject = new ProjectEntity(projectName, new List<ITaskEntity>());
        }

        /// <summary>
        /// Retreives the current name of the project.
        /// </summary>
        public string ProjectName => currentProject.ProjectName;

        /// <summary>
        /// Adds a new task to the project database.
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(ITaskEntity task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find a task in the project database.
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        public bool FindTaskByName(string taskName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a task from the project database.
        /// </summary>
        /// <param name="task"></param>
        public void RemoveTask(ITaskEntity task)
        {
            throw new NotImplementedException();
        }
    }
}
