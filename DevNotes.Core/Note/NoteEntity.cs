using System.Collections.Generic;

namespace DevNotes.Core.Note
{
    public class NoteEntity : INoteEntity
    {
        public NoteEntity(string noteID, string noteDescription)
        {
            NoteID = noteID;
            NoteDescription = noteDescription;
        }

        public string NoteID { get; }

        public string NoteDescription { get; }

        public string ProjectID { get; }

        public string TaskID { get; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
            {
                return NoteID == (obj as NoteEntity).NoteID;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return 353487976 + EqualityComparer<string>.Default.GetHashCode(NoteID);
        }
    }
}
