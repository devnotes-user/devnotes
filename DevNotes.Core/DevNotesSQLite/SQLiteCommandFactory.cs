﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DevNotes.Core.DevNotesSQLite
{
    /// <summary>
    /// Creates a new <see cref="IDevNotesSQLiteCommand" from a valid <see cref="IDevNotesSQLiteConnection"/>/>
    /// </summary>
    public class SQLiteCommandFactory : ISQLiteCommandFactory
    {
        private IDevNotesSQLiteConnection conn;

        public SQLiteCommandFactory(IDevNotesSQLiteConnection conn)
        {
            this.conn = conn;
        }

        /// <summary>
        /// Creates a new <see cref="IDevNotesSQLiteCommand" if and only if the given <see cref="IDevNotesSQLiteConnection" has a valid connection/>
        /// </summary>
        /// <returns>A new SQLite command tied to a valid SQLiteConnection</returns>
        public IDevNotesSQLiteCommand CreateSQLiteCommand()
        {
            if (conn.InErrorState())
            {
                throw new Exception("SQLiteConnection is in error state");
            }
            return conn.CreateCommand();
        }
    }
}
