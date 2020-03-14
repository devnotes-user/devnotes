using System.Data.SQLite;

namespace DevNotes.Core.DevNotesSQLite
{
    /// <summary>
    /// Interface for wrapper of a SQLite connection.
    /// </summary>
    public interface IDevNotesSQLiteConnection
    {
        SQLiteConnection Connection { get; }

        void Open();

        void Close();

        IDevNotesSQLiteCommand CreateCommand();
    }
}
