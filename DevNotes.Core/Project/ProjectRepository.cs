using DevNotes.Core.DevNotesSQLite;
using DevNotes.Core.Task;
using System.Collections.Generic;

namespace DevNotes.Core.Project
{
    /// <summary>
    /// Keeps track of projects in a SQLite database.
    /// The database is encapsulated so clients can use the repository without interacting with the DB directly.
    /// </summary>
    /// TODO: change all direct creations of sqlite commands to use factory
    public class ProjectRepository : IProjectRepository
    {
        private IDevNotesSQLiteConnection sqliteConnection;
        private ISQLiteCommandFactory sqliteCommandFactory;

        /// <summary>
        /// Create a new project repository
        /// </summary>
        public ProjectRepository(IDevNotesSQLiteConnection sqliteConnection)
        {
            this.sqliteConnection = sqliteConnection;
            sqliteCommandFactory = new SQLiteCommandFactory(sqliteConnection);
        }

        public IEnumerable<IProjectEntity> Items
        {
            get
            {
                var projects = new List<IProjectEntity>();
                var cmd = sqliteCommandFactory.CreateSQLiteCommand();
                cmd.CommandText = "select * from Projects";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projects.Add(CreateProjectEntityFromRow(reader));
                }
                return projects;
            }
        }

        public void Add(IProjectEntity project)
        {
            var cmd = sqliteConnection.CreateCommand();
            cmd.CommandText = $"insert into Projects (ProjectName) values('{project.ProjectName}')";
            cmd.ExecuteNonQuery();
        }

        public bool Exists(IProjectEntity project)
        {
            var command = sqliteConnection.CreateCommand();
            command.CommandText = $"select * from Projects where ProjectName='{project.ProjectName}'";
            var projectReader = command.ExecuteReader();
            return projectReader.HasRows;
        }

        public IProjectEntity FindByKey(string projectName)
        {
            IProjectEntity result;
            var command = sqliteConnection.CreateCommand();
            command.CommandText = $"select * from Projects where ProjectName={projectName}";
            var projectReader = command.ExecuteReader();
            if (projectReader.HasRows)
            {
                result = CreateProjectEntityFromRow(projectReader);
            }
            else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Removes a project from the repository.
        /// TODO: Remove all related tasks and notes from their respective tables.
        /// </summary>
        /// <param name="projectName"></param>
        public void RemoveProject(string projectName)
        {
            var cmd = sqliteConnection.CreateCommand();
            cmd.CommandText = $"delete from Projects where ProjectName='{projectName}'";
            cmd.ExecuteNonQuery();
        }

        public void Update(IProjectEntity project)
        {
            var cmd = sqliteConnection.CreateCommand();
            cmd.CommandText = "alter table Projects (ProjectName) where ";
            cmd.ExecuteNonQuery();
        }

        private IProjectEntity CreateProjectEntityFromRow(IDevNotesSQLiteDataReader dataReader)
        {
            string projectName = dataReader.GetString(1);
            short taskEntitiesForeignKey = 0;
            var taskEntities = CreateTaskEntitiesFromFK(taskEntitiesForeignKey);
            IProjectEntity result = new ProjectEntity(projectName, projectName, taskEntities);
            return result;
        }

        private IEnumerable<ITaskEntity> CreateTaskEntitiesFromFK(short foreignKey)
        {
            var cmd = sqliteConnection.CreateCommand();
            var tasks = new List<ITaskEntity>();
            cmd.CommandText = $"select * from Tasks where ProjectID={foreignKey}";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tasks.Add(CreateTaskEntityFromReader(reader));
            }
            return new List<ITaskEntity>();
        }

        private ITaskEntity CreateTaskEntityFromReader(IDevNotesSQLiteDataReader reader)
        {
            var taskName = reader.GetString(1);
            var task = new TaskEntity("", "", taskName);
            return task;
        }
    }
}
