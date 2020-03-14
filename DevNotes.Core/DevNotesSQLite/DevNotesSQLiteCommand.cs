using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.Core.DevNotesSQLite
{
    public class DevNotesSQLiteCommand : IDevNotesSQLiteCommand
    {
        public DevNotesSQLiteCommand(SQLiteCommand command)
        {
            Command = command;
        }

        public string CommandText 
        { 
            get => Command.CommandText;
            set
            {
                Command.CommandText = value;
            } 
        }

        private SQLiteCommand Command { get; }

        public int ExecuteNonQuery()
        {
            return Command.ExecuteNonQuery();
        }

        public IDevNotesSQLiteDataReader ExecuteReader()
        {
            return new DevNotesSQLiteDataReader(Command.ExecuteReader());
        }
    }
}
