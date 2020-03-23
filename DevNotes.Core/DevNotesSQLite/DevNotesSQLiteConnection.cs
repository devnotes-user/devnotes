using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.Core.DevNotesSQLite
{
    /// <summary>
    /// Wraps a SQLite connection.
    /// </summary>
    public class DevNotesSQLiteConnection : IDevNotesSQLiteConnection
    {
        /// <summary>
        /// The underlying <see cref="SQLiteConnection"/>
        /// </summary>
        private SQLiteConnection connection;

        /// <summary>
        /// Creates the underlying <see cref="SQLiteConnection"/> with the given connection string.
        /// </summary>
        /// <param name="connectionString"></param>
        public DevNotesSQLiteConnection(string connectionString)
        {
            connection = new SQLiteConnection(connectionString);
        }

        public DevNotesSQLiteConnection(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Closes the underlying <see cref="SQLiteConnection"/>
        /// </summary>
        public void Close()
        {
            connection.Close();
        }

        /// <summary>
        /// Opens the underlying <see cref="SQLiteConnection"/>
        /// </summary>
        public void Open()
        {
            connection.Open();
        }

        /// <summary>
        /// Creates the wrapped SQLite command
        /// </summary>
        /// <returns>A new SQLite command</returns>
        public IDevNotesSQLiteCommand CreateCommand()
        {
            return new DevNotesSQLiteCommand(connection.CreateCommand());
        }

        /// <summary>
        /// Creates a new database file using the <see cref="SQLiteConnection.CreateFile(string)"/> method.
        /// </summary>
        /// <param name="databaseFileName"></param>
        public void CreateFile(string databaseFileName)
        {
            SQLiteConnection.CreateFile(databaseFileName);
        }

        public SQLiteErrorCode ResultCode()
        {
            return connection.ResultCode();
        }
    }
}
