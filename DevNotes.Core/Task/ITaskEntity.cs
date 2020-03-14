namespace DevNotes.Core.Task
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskEntity
    {
        string TaskID { get; }

        string ProjectID { get; }

        string TaskName { get; }
    }
}
