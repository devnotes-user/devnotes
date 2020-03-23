using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace DevNotes.Core.Configuration
{
    /// <summary>
    /// Creates new <see cref="IConfiguration" objects/>
    /// </summary>
    public interface IConfigurationFactory
    {
        /// <summary>
        /// Populated population configuration from a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Configuration loaded from XML file if it exists, otherwise the default configuration</returns>
        Configuration CreateFromXMLFile(string fileName);
    }
}
