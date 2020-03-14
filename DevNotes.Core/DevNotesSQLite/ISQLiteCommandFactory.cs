using System;
using System.Collections.Generic;
using System.Text;

namespace DevNotes.Core.DevNotesSQLite
{
    /// <summary>
    /// Creates a new SQLite command from a valid SQLiteConnection/>
    /// </summary>
    public interface ISQLiteCommandFactory
    {
        /// <summary>
        /// Creates a new <see cref="IDevNotesSQLiteCommand" if and only if a given connection is valid/>
        /// </summary>
        /// <returns></returns>
        IDevNotesSQLiteCommand CreateSQLiteCommand();
    }
}
