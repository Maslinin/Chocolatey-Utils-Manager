using System.Collections.Generic;

namespace CUM.Installer.EntityModels
{
    /// <summary>
    /// Contains a description of the categories
    /// </summary>
    public sealed class InstallerCategories
    {
        /// <summary>
        /// Returns the list of categories displayed for the CheckedListBox
        /// </summary>
        public List<string> DisplayedCategories { get; } = new List<string>();

        public InstallerCategories() { }
    }
}
