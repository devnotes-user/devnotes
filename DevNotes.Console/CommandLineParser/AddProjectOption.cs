using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.CommandLineParser
{
    [Verb("add-project", HelpText = "Add a new project")]
    class AddProjectOption
    {
        [Option(longName: "name", shortName: 'n', Required = true)]
        public string Name { get; set; }
    }
}
