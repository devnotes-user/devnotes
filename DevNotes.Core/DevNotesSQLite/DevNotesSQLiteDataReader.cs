using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.Core.DevNotesSQLite
{
    public class DevNotesSQLiteDataReader : IDevNotesSQLiteDataReader
    {
        private SQLiteDataReader dataReader;

        public DevNotesSQLiteDataReader(SQLiteDataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        /// <summary>
        /// Returns true if the result set has rows that can be fetched.
        /// </summary>
        public bool HasRows => dataReader.HasRows;

        public short GetInt16(int i)
        {
            return dataReader.GetInt16(i);
        }

        public string GetString(int i)
        {
            return dataReader.GetString(i);
        }

        public bool Read()
        {
            return dataReader.Read();
        }
    }
}
