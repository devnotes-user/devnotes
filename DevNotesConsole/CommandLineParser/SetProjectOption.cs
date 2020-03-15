using CommandLine;

namespace DevNotes.CommandLineParser
{
    [Verb("set-project", HelpText = "Work within the selected project")]
    class SetProjectOption
    {
        [Option("name", Required = true, HelpText = "Name of project to select.")]
        public string ID { get; set; }
    }
}
