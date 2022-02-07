using System.Linq;
using System.Collections.Generic;

namespace CUM.Installer
{
    /// <summary>
    /// Static class containing extensions to work with the Installer class
    /// </summary>
    internal static class InstallerWorkExtensions
    {
        /// <summary>
        /// Returns the number of selected packages
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

        /// <summary>
        /// Returns the number of packets selected, given the event data ItemCheckEventArgs
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        internal static int GetSelectedPackagesCountAfterEvent(this Installer installer, System.Windows.Forms.ItemCheckEventArgs e)
        {
            int packageCount = 0;
            foreach (var listBox in installer.ProgramsCheckedListBoxCollection)
            {
                packageCount += listBox.CheckedItems.Count;
            }

            //Crutch:
            //Only works with this code,
            //due to a flaw CheckedListBox the number of packets would be displayed incorrectly, therefore if checked it increases by 1;
            //otherwise decreases by 1
            if (e.NewValue == System.Windows.Forms.CheckState.Checked)
                ++packageCount;
            if (e.NewValue == System.Windows.Forms.CheckState.Unchecked)
                --packageCount;

            return packageCount;
        }

        /// <summary>
        /// Returns all entities of the type selected for operation ProgramInfo
        /// </summary>
        /// <param name="installer"></param>
        /// <returns>List of marked entities ProgramInfo</returns>
        internal static List<EntityModels.ProgramInfo> GetSelectedPackagesItems(this Installer installer)
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
