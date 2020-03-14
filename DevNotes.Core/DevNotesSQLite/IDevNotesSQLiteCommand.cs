using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.Core.DevNotesSQLite
{
    /// <summary>
    /// Wraps the SQLiteCommand class
    /// </summary>
    public interface IDevNotesSQLiteCommand
    {
        string CommandText { get; set; }

        int ExecuteNonQuery();

        IDevNotesSQLiteDataReader ExecuteReader();
    }
}
