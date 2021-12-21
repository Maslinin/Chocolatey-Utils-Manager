using System.Linq;
using System.Collections.Generic;

namespace CUM.ProgramInstaller
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

        /// <summary>
        /// Gets all entities of the type selected for operation ProgramInfo
        /// </summary>
        /// <param name="installer"></param>
        /// <returns>List of marked entities ProgramInfo</returns>
        internal static List<Models.ProgramInfo> GetSelectedPackagesListItems(this Installer installer)
        {
            List<Models.ProgramInfo> programs = new List<Models.ProgramInfo>();

            foreach (var listBox in installer.ProgramsCheckedListBoxCollection)
            {
                programs.AddRange(listBox.CheckedItems.Cast<Models.ProgramInfo>());
            }

            return programs;
        }

        /// <summary>
        /// Installs Chocololatey if it is not installed
        /// </summary>
        /// <param name="installer"></param>
        internal static async System.Threading.Tasks.Task InstallChoco(this Installer installer)
        {
            if (!installer.Choco.ChocoExists)
            {
                installer.LockInstallerForm();
                installer.PackagesInfoLabel.Text = "Chocolate isn't found on your computer. Installing it...";
                await installer.Choco.InstallChocoAsync();
                installer.PackagesInfoLabel.Text = "Chocolate was installed";
                installer.UnLockInstallerForm();
            }
        }

        /// <summary>
        /// Installs the packages passed to the parameter as a collection
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="programs"></param>
        internal static async System.Threading.Tasks.Task InstallPackages(this Installer installer, List<Models.ProgramInfo> programs)
        {
            int i = 0, packagesCount = installer.GetSelectedPackagesCount();

            installer.PackagesInfoLabel.Text = $"0 out of {packagesCount} packages installed";
            foreach (var program in programs)
            {
                installer.PackagesInfoLabel.Text = $"{i++} out of {packagesCount} packages installed: installing {program.ProgramName}";
                await installer.Choco.InstallPackageAsync(program.ChocolateyInstallName);
            }
            installer.PackagesInfoLabel.Text = "Installing completed";
        }

        /// <summary>
        /// Updates the packages passed to the parameter as a collection
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="programs"></param>
        internal static async System.Threading.Tasks.Task UpdatePackages(this Installer installer, List<Models.ProgramInfo> programs)
        {
            int i = 0, packagesCount = installer.GetSelectedPackagesCount();

            installer.PackagesInfoLabel.Text = $"0 out of {packagesCount} packages updated";
            foreach (var program in programs)
            {
                installer.PackagesInfoLabel.Text = $"{i++} out of {packagesCount} packages updated: updating {program.ProgramName}";
                await installer.Choco.UpdatePackageAsync(program.ChocolateyInstallName);
            }
            installer.PackagesInfoLabel.Text = "Updating completed";
        }

        /// <summary>
        /// Uninstall the packages passed to the parameter as a collection
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="programs"></param>
        internal static async System.Threading.Tasks.Task UninstallPackages(this Installer installer, List<Models.ProgramInfo> programs)
        {
            int i = 0, packagesCount = installer.GetSelectedPackagesCount();

            installer.PackagesInfoLabel.Text = $"0 out of {packagesCount} packages deleted";
            foreach (var program in programs)
            {
                installer.PackagesInfoLabel.Text = $"{i++} out of {packagesCount} packages uninstalled: uninstalling {program.ProgramName}";
                await installer.Choco.UninstallPackageAsync(program.ChocolateyInstallName);
            }
            installer.PackagesInfoLabel.Text = "Uninstallation completed";
        }
    }
}
