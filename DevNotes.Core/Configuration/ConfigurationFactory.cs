using System.IO;
using System.Xml.XPath;

namespace DevNotes.Core.Configuration
{
    /// <summary>
    /// Creates new <see cref="Configuration" objects/>
    /// </summary>
    public class ConfigurationFactory : IConfigurationFactory
    {
        public ConfigurationFactory()
        {
           
        }

        public Configuration CreateFromXMLFile(string fileName)
        {
            Configuration projectConfiguration;
            if (File.Exists(fileName))
            {
                projectConfiguration = ReadConfigurationFromXMLFile(fileName);
            }
            else
            {
                projectConfiguration = DefaultConfiguration;
            }
            return projectConfiguration;
        }
        
        private Configuration ReadConfigurationFromXMLFile(string fileName)
        {
            var configData = new XPathDocument(fileName);
            var navigator = configData.CreateNavigator();
            navigator.MoveToChild("devnotes", "devnotes");
            navigator.MoveToChild("project-name", "devnotes");
            var projectName = navigator.Value;
            return new Configuration(projectName);
        }

        /// <summary>
        /// Configuration used if no configuration file is present
        /// </summary>
        private Configuration DefaultConfiguration => new Configuration(null);
    }
}
