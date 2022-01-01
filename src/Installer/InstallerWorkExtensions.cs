using System.Linq;
using System.Collections.Generic;

namespace CUM.Installer
{
    /// <summary>
    /// Static class containing extensions to work with the Installer class
    /// </summary>
    static class InstallerWorkExtensions
    {
        /// <summary>
        /// Gets the number of selected packages
        /// </summary>
        /// <param name="installer"></param>
        /// <returns>Packages selected count</returns>
        internal static int GetSelectedPackagesCount(this Installer installer)
        {
            int packageCount = 0;
            foreach (var listBox in installer.ProgramsCheckedListBoxCollection)
            {
                packageCount += listBox.CheckedItems.Count;
            }
            return packageCount;
        }

        internal static int GetSelectedPackagesCountAfterEvent(this Installer installer, System.Windows.Forms.ItemCheckEventArgs e)
        {
            int packageCount = 0;
            foreach (var listBox in installer.ProgramsCheckedListBoxCollection)
            {
                packageCount += listBox.CheckedItems.Count;
            }

            //crutch:
            if (e.NewValue == System.Windows.Forms.CheckState.Checked)
                ++packageCount;
            if (e.NewValue == System.Windows.Forms.CheckState.Unchecked)
                --packageCount;
            return packageCount;
        }

        /// <summary>
        /// Gets all entities of the type selected for operation ProgramInfo
        /// </summary>
        /// <param name="installer"></param>
        /// <returns>List of marked entities ProgramInfo</returns>
        internal static List<EntityModels.ProgramInfo> GetSelectedPackagesListItems(this Installer installer)
        {
            var programs = new List<EntityModels.ProgramInfo>();

            foreach (var listBox in installer.ProgramsCheckedListBoxCollection)
            {
                programs.AddRange(listBox.CheckedItems.Cast<EntityModels.ProgramInfo>());
            }
            return programs;
        }
    }
}
