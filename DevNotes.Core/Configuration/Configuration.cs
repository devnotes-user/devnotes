using System;
using System.Collections.Generic;
using System.Text;

namespace DevNotes.Core.Configuration
{
    /// <summary>
    /// Configuration objects represent the current configuration of the DevNotes system.
    /// Configuration objects are immutable.
    /// </summary>
    public struct Configuration : IEquatable<Configuration>
    {
        /// <summary>
        /// Constructor for a new <see cref="Configuration"/> object.
        /// </summary>
        /// <param name="projectName"></param>
        public Configuration(string projectName)
        {
            ProjectName = projectName;
        }

        /// <summary>
        /// The name of the current project.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Overloaded equality from <see cref="IEquatable{T}"/>
        /// This overload is to ensure stable performance when comparing configurations.
        /// If this method did not exist, the clr would use a default reflection based equality for this struct, which would be extremly slow.
        /// </summary>
        /// <param name="other">Configuration to compare against.</param>
        /// <returns>True if this configuration equals the other configuration, false otherwise</returns>
        public bool Equals(Configuration other)
        {
            return ProjectName == other.ProjectName;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ProjectName.GetHashCode();
        }
    }
}
