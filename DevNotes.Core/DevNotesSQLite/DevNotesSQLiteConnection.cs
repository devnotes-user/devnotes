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
        public DevNotesSQLiteConnection(SQLiteConnection connection)
        {
            Connection = connection;
        }

        public SQLiteConnection Connection { get; }

        public void Close()
        {
            Connection.Close();
        }

        public void Open()
        {
            Connection.Open();
        }

        /// <summary>
        /// Creates the wrapped SQLite command
        /// </summary>
        /// <returns>A new SQLite command</returns>
        public IDevNotesSQLiteCommand CreateCommand()
        {
            return new DevNotesSQLiteCommand(Connection.CreateCommand());
        }
    }
}
