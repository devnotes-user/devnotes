using CommandLine;

namespace DevNotes.CommandLineParser
{
    [Verb("set-project", HelpText = "Work within the selected project")]
    class SetProjectOption
    {
        [Option("id", Required = true)]
        public string ID { get; set; }
    }
}
