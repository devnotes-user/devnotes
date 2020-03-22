using CommandLine;

namespace DevNotes.CommandLineParser
{
    [Verb("add-note", HelpText = "Add a new note to a task in a project")]
    class AddNoteOption
    {
        [Option("name", HelpText = "Name of the note")]
        public string Name { get; set; }

        [Option("desc", HelpText = "Description of the note")]
        public string Desc { get; set; }
    }
}
