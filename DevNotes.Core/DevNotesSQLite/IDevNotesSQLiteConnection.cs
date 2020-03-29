using System.Data.SQLite;

namespace DevNotes.Core.DevNotesSQLite
{
    /// <summary>
    /// Interface for wrapper of a SQLite connection.
    /// </summary>
    public interface IDevNotesSQLiteConnection
    {
        /// <summary>
        /// Opens a database
        /// </summary>
        void Open();

        /// <summary>
        /// Closes a database
        /// </summary>
        void Close();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDevNotesSQLiteCommand CreateCommand();

        /// <summary>
        /// Creates a database from a file
        /// </summary>
        /// <param name="databaseFileName"></param>
        void CreateFile(string databaseFileName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SQLiteErrorCode ResultCode();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool InErrorState();
    }
}
