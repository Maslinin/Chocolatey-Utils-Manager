namespace CUM.ProgramInstaller
{
    /// <summary>
    /// Static class that contains extensions for working with Installer visual display
    /// </summary>
    internal static class InstallerFormExtensions
    {
        /// <summary>
        /// Updates the package information label
        /// </summary>
        /// <param name="installer"></param>
        internal static void UpdatePackagesInfoLabel(this Installer installer)
        {
            int packagesCount = installer.GetSelectedPackagesCount();
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
            installer.StopButton.Enabled = false;
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
    }
}
