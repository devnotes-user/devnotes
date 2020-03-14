﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevNotes.CommandLineParser
{
    [Verb("find-project", HelpText = "Find a specific project by searching by id.")]
    class FindProjectOption
    {
        [Option("name", HelpText = "Id of project to search for")]
        public string Name { get; set; }
    }
}
