using CommandLine;

namespace DevNotes.CommandLineParser
{
    [Verb("add-task", HelpText = "Add a new task to a project")]
    class AddTaskOption
    {
        [Option("name", Required = true)]
        public string Name { get; set; }
    }
}
