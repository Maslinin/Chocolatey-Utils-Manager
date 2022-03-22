using System.Collections.Generic;

namespace CUM.Installer.EntityModels
{
    /// <summary>
    /// Contains information about Chocolatey packages in a specific category
    /// </summary>
    public sealed class ProgramList
    {
        /// <summary>
        /// Gets the category which the list of Programs in this instance belongs to
        /// </summary>
        public string Category { get; private set; }
        /// <summary>
        /// Gets a list of ProgramInfo instances, where each contains information about a particular package
        /// </summary>
        public List<ProgramInfo> Programs { get; private set; }

        /// <summary>
        /// Initializes a new instance ProgramList
        /// </summary>
        /// <param name="Category"></param>
        /// <param name="Programs"></param>
        public ProgramList(string Category, List<ProgramInfo> Programs)
        {
            this.Category = Category;
            this.Programs = new List<ProgramInfo>();
            this.Programs.AddRange(Programs);
        }
    }
}