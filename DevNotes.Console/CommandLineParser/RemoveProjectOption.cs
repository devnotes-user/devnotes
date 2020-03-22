using CommandLine;

namespace DevNotes.CommandLineParser
{
    [Verb("remove-project", HelpText = "Remove a project")]
    class RemoveProjectOption
    {
        [Option("name", HelpText = "Name of project to remove")]
        public string Name { get; set; }
    }
}
