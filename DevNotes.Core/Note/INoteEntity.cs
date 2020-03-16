namespace DevNotes.Core.Note
{
    /// <summary>
    /// Represents a note for some task in a project.
    /// Two notes are equivalent if their NoteID is the same.
    /// </summary>
    public interface INoteEntity
    {
        /// <summary>
        /// 
        /// </summary>
        string NoteID { get; }

        string ProjectID { get; }

        /// <summary>
        /// ID of owner
        /// </summary>
        string TaskID { get; }

        string NoteDescription { get; }
    }
}
