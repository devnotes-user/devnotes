using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.CommandLineParser
{
    [Verb("find-task", HelpText = "Find a task by its name")]
    class FindTaskOption
    {
        [Option(longName: "name", shortName: 'n', HelpText = "The name of the task")]
        public string Name { get; set; }
    }
}
