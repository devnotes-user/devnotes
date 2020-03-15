using CommandLine;
using DevNotes.CommandLineParser;
using DevNotes.Core.DevNotesSQLite;
using DevNotes.Core.Note;
using DevNotes.Core.Project;
using DevNotes.Core.Task;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using DevNotesConsole.CommandLineParser;
using System.Linq;

namespace DevNotes
{
    class Program
    {
        static IProjectRepository projects;

        static string currentProjectID;

        static string currentTaskID;

        static int noteNum = 0;

        const string DATABASE_NAME = "database.db";

        const string NEW_SQLITE_ARGUMENTS = "Data Source = database.db;Version=3;New=True;Compress=True";

        const string EXISTING_CONNECTION_ARGUMENTS = "Data Source = database.db;Version=3;New=False;Compress=True";

        /// <summary>
        /// Entry point to the DevNotes console program.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            var sqlConn = OpenDatabase();
            AddTablesIfNeeded(sqlConn);
            projects = new ProjectRepository(new DevNotesSQLiteConnection(sqlConn));
            ReadEvalPrintLoop();
            sqlConn.Close();
        }

        /// <summary>
        /// Opens the database connection, creating it if it doesn't exist
        /// </summary>
        /// <returns>An opened SQLiteConnection</returns>
        static SQLiteConnection OpenDatabase()
        {
            SQLiteConnection conn;
            if (File.Exists(DATABASE_NAME))
            {
                conn = new SQLiteConnection(EXISTING_CONNECTION_ARGUMENTS);
            }
            else
            {
                conn = new SQLiteConnection(NEW_SQLITE_ARGUMENTS);
            }
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Adds the Projects, Tasks, and Notes tables if they don't exist.
        /// </summary>
        /// <param name="connection"></param>
        static void AddTablesIfNeeded(SQLiteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "select name from sqlite_master where type='table' AND name='Projects'";
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                AddTable(connection, "Projects", "(ID INT PRIMARY KEY, ProjectName Text)");
            }
            reader.Close();
            cmd.CommandText = "select name from sqlite_master where type='table' AND name='Tasks'";
            reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                AddTable(connection, "Tasks", "(ID INT PRIMARY KEY, TaskName, TaskDescription, ProjectID Text)");
            }
            
        }

        static void AddTable(SQLiteConnection conn, string tableName, string columns)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"create table {tableName} {columns}";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// The core Read-Eval-Print-Loop (REPL) functionality
        /// Read: reads input from user
        /// Eval: evaluates input from user
        /// Print: Displays result of evaluation
        /// Loop: Performs the above three steps until user wishes to quit.
        /// </summary>
        static void ReadEvalPrintLoop()
        {
            string input;
            do
            {
                Console.Write(CreatePrompt());
                input = Console.ReadLine();
                var output = Eval(input);
                Console.WriteLine(output);
            } while (input != "q");
        }

        /// <summary>
        /// Displays the DevNotes command prompt and adds current project ID to it.
        /// </summary>
        /// <returns></returns>
        static string CreatePrompt()
        {
            var prompt = "Devnotes";
            if (currentProjectID != null)
            {
                prompt += $" {currentProjectID}";
            }
            return prompt + "> ";
        }

        /// <summary>
        /// Evaluates input given from the user, performs the desired operation on the system, and gives the output of that operation. 
        /// </summary>
        /// <param name="input">The user's unparsed, unevaluated command</param>
        /// <returns>Output of the evaluated command</returns>
        static string Eval(string input)
        {
            var result = Parser.Default.ParseArguments
                        <AddNoteOption, AddProjectOption, AddTaskOption, ListProjectsOption, FindProjectOption, FindTaskOption, FindNoteOption, RemoveProjectOption, SetProjectOption, SetTaskOption, ErrorOptions>
                        (input.Split(' '));
            return result.MapResult(
                (AddNoteOption opt) => AddNote(opt),
                (AddProjectOption opt) => AddProject(opt),
                (AddTaskOption opt) => AddTask(opt),
                (ListProjectsOption opt) => ListProjects(opt),
                (FindProjectOption opt) => FindProject(opt),
                (FindTaskOption opt) => FindTask(opt),
                (FindNoteOption opt) => FindNote(opt),
                (RemoveProjectOption opt) => RemoveProject(opt),
                (SetProjectOption opt) => SetProject(opt),
                (SetTaskOption opt) => SetTask(opt),
                (ErrorOptions opt) => "error parsing command",
                errs => "Error parsing command"
            );
        }

        #region VerbProcessing

        static string AddNote(AddNoteOption opt)
        {
            var note = new NoteEntity((++noteNum).ToString(), opt.Desc);
            string output;
            output = $"Note: {note.NoteDescription} added";
            return output;
        }

        static string AddProject(AddProjectOption opt)
        {
            IProjectEntity project = new ProjectEntity(opt.Name, opt.Name, new List<ITaskEntity>());
            string output;
            projects.Add(project);
            output = $"Added {project.ProjectName} to projects\n";
            output += SetProject(new SetProjectOption() { ID = project.ProjectName });
            return output;
        }

        static string ListProjects(ListProjectsOption opt)
        {
            return projects.Items.Select(o => o.ProjectName).Aggregate("", (name1, name2) => name1 + Environment.NewLine + name2);
        }

        static string FindProject(FindProjectOption opt)
        {
            return projects.FindByKey(opt.Name).ProjectName;
        }

        static string FindTask(FindTaskOption opt)
        {
            return "Find tasks not currently implemented";
        }

        static string FindNote(FindNoteOption opt)
        {
            return "Find notes not currently implemented";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        /// TODO: Implement add task
        static string AddTask(AddTaskOption opt)
        {
            var task = new TaskEntity(opt.ID, currentProjectID, opt.Name);
            string output;

            return "Add task currently not implemented.";
        }

        /// <summary>
        /// Sets current project id.
        /// TODO: Check if project exists
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        static string SetProject(SetProjectOption opt)
        {
            var id = opt.ID;
            string output;
            currentProjectID = id;
            output = $"Setting current project";
            return output;
        }

        static string SetTask(SetTaskOption opt)
        {
            var key = opt.ID;
            string output;
            return "Set task not implemented";
        }

        /// <summary>
        /// Removes a project from the list of projects
        /// </summary>
        /// <param name="opt">The command line options for this project</param>
        /// <returns>Message indicating the project has been removed.</returns>
        static string RemoveProject(RemoveProjectOption opt)
        {
            projects.RemoveProject(opt.Name);
            currentProjectID = "";
            return $"Project {opt.Name} has been removed";
        }

        #endregion // VerbProcessing
    }
}
