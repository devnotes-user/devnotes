using DevNotes.Core.Project;
using DevNotes.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.Note
{
    /// <summary>
    /// Represents a note for some task in a project.
    /// Two notes are equivalent if their NoteID is the same.
    /// </summary>
    public interface INoteEntity
    {
        string NoteID { get; }

        string ProjectID { get; }

        string TaskID { get; }

        string NoteDescription { get; }
    }
}
