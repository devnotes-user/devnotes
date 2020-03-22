﻿using DevNotes.Core.DevNotesSQLite;
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

            ProjectName = projectName;
            this.sqliteConnection = sqliteConnection;
            sqliteCommandFactory = new SQLiteCommandFactory(sqliteConnection);
        }

        public string ProjectName { get; }

        public void AddTask(ITaskEntity task)
        {
            throw new NotImplementedException();
        }

        public bool FindTaskByName(string taskName)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(ITaskEntity task)
        {
            throw new NotImplementedException();
        }
    }
}
