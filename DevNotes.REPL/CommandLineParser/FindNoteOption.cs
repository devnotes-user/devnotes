using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.CommandLineParser
{
    [Verb("find-note", HelpText = "Finds a particular note in the current task/project.")]
    class FindNoteOption
    {
        [Option("name", HelpText = "Name of the note to search for.")]
        public string Name { get; set; }
    }
}
