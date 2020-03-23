using DevNotes.Core.DevNotesSQLite;

namespace DevNotes.Core.Project
{
    public interface IProjectFactory
    {
        IProjectEntity CreateProject(string projectName, IDevNotesSQLiteConnection connection);
    }
}
