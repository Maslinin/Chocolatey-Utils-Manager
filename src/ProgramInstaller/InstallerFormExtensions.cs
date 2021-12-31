using System.Collections.Generic;

namespace CUM.ProgramInstaller
{
    /// <summary>
    /// Static class that contains extensions for working with Installer visual display
    /// </summary>
    internal static class InstallerFormExtensions
    {
        /// <summary>
        /// UnLocks all form elements
        /// </summary>
        /// <param name="installer"></param>
        internal static void LockInstallerForm(this Installer installer)
        {
            installer.StartButton.Enabled = false;
            installer.StopButton.Enabled = false;
            installer.InstallRadioButton.Enabled = false;
            installer.UpdateRadioButton.Enabled = false;
            installer.DeleteRadioButton.Enabled = false;
            installer.InstallerSplitContainer.Panel1.Enabled = false;
            installer.SelectAllCheckBox.Enabled = false;
        }

        /// <summary>
        /// Locks all form elements
        /// </summary>
        /// <param name="installer"></param>
        internal static void UnLockInstallerForm(this Installer installer)
        {
            installer.StartButton.Enabled = true;
            installer.StopButton.Enabled = true;
            installer.InstallRadioButton.Enabled = true;
            installer.UpdateRadioButton.Enabled = true;
            installer.DeleteRadioButton.Enabled = true;
            installer.InstallerSplitContainer.Panel1.Enabled = true;
            installer.SelectAllCheckBox.Enabled = true;
        }

        /// <summary>
        /// Locks and hides the Stop button on the form
        /// </summary>
        /// <param name="installer"></param>
        internal static void LockStopButton(this Installer installer)
        {
            installer.StopButton.Enabled = false;
            installer.StopButton.Visible = false;
            installer.ModeSelectionGroupBox.Height -= installer.StopButton.Height;
        }

        /// <summary>
        /// Unlocks and displays the Stop button on the form
        /// </summary>
        /// <param name="installer"></param>
        internal static void UnLockStopButton(this Installer installer)
        {
            installer.StopButton.Enabled = true;
            installer.StopButton.Visible = true;
            installer.ModeSelectionGroupBox.Height += installer.StopButton.Height;
        }


        /// <summary>
        /// Sets Cheсked to all items CheckedBox
        /// </summary>
        /// <param name="installer"></param>
        internal static void SelectAllPackages(this Installer installer)
        {
            foreach (var listBox in installer.ProgramsCheckedListBoxCollection)
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    listBox.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
                }
        }

        /// <summary>
        /// Clears Cheсked to all items CheckedBox
        /// </summary>
        /// <param name="installer"></param>
        internal static void UnselectAllPackages(this Installer installer)
        {
            foreach (var listBox in installer.ProgramsCheckedListBoxCollection)
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    listBox.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
        }

        /// <summary>
        /// Updates the package information label
        /// </summary>
        /// <param name="installer"></param>
        internal static void UpdatePackagesInfoLabel(this Installer installer, System.Windows.Forms.ItemCheckEventArgs e = null)
        {
            var packagesCount = e is null ? installer.GetSelectedPackagesCount() : installer.GetSelectedPackagesCount(e);
            if (packagesCount == 0)
            {
                installer.PackagesInfoLabel.Text = "No package(s) selected";
            }
            else
            {
                installer.PackagesInfoLabel.Text = $"Select(ed) {packagesCount} package(s)";
            }
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
                installer.PackagesInfoLabel.Text = "Chocolatey isn't found on your computer. Installing it...";
                await installer.Choco.InstallChocoAsync();
                installer.PackagesInfoLabel.Text = "Chocolatey was installed";
                installer.UnLockInstallerForm();
                installer.LockStopButton();
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
