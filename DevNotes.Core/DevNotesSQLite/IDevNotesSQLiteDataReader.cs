using System.Data.SQLite;

namespace DevNotes.Core.DevNotesSQLite
{
    /// <summary>
    /// Encapsulates a <see cref="SQLiteDataReader"/>
    /// </summary>
    public interface IDevNotesSQLiteDataReader
    {
        /// <summary>
        /// Returns true if the result set has rows that can be fetched.
        /// </summary>
        bool HasRows { get; }

        bool Read();

        string GetString(int i);

        short GetInt16(int i);
    }
}
