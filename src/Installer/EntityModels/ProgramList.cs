using System.Collections.Generic;

namespace CUM.Installer.EntityModels
{
    /// <summary>
    /// Contains information about Chocolatey packages in a specific category
    /// </summary>
    public sealed class ProgramList
    {
        /// <summary>
        /// Returns the category to which the list of Programs in this instance belongs
        /// </summary>
        public string Category { get; }
        /// <summary>
        /// Returns a list of ProgramInfo instances, each containing information about a particular package
        /// </summary>
        public List<ProgramInfo> Programs { get; } = new List<ProgramInfo>();

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