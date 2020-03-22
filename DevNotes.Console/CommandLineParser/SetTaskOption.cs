using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.CommandLineParser
{
    [Verb("set-task", HelpText = "Sets the current task")]
    class SetTaskOption
    {
        [Option("id", Required = true)]
        public string ID { get; set; }
    }
}
