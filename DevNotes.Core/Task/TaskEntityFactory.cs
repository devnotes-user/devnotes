using DevNotes.Core.DevNotesSQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevNotes.Core.Task
{
    /// <summary>
    /// Factory to create new <see cref="ITaskEntity"/>
    /// </summary>
    public class TaskEntityFactory : ITaskEntityFactory
    {
        public ITaskEntity CreateFromDatabase(IDevNotesSQLiteConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
