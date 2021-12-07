namespace CUM.ProgramInstaller
{
    /// <summary>
    /// Static class that contains extensions for working with Installer visual display
    /// </summary>
    internal static class InstallerFormExtensions
    {
        /// <summary>
        /// Locks the form so that only the STOP button becomes available and remains
        /// </summary>
        /// <param name="installer"></param>
        internal static void LockInstallerForm(this Installer installer)
        {
            installer.StartButton.Enabled = false;
            installer.StopButton.Enabled = true;
            installer.InstallRadioButton.Enabled = false;
            installer.UpdateRadioButton.Enabled = false;
            installer.DeleteRadioButton.Enabled = false;
            installer.InstallerSplitContainer.Panel1.Enabled = false;
            installer.SelectAllCheckBox.Enabled = false;
        }

        /// <summary>
        /// Locks the STOP button, making other form elements available for use
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
        /// Sets Cheсked to all items CheckedBox
        /// </summary>
        /// <param name="installer"></param>
        internal static void SelectAllPackages(this Installer installer)
        {
            foreach (var listBox in installer.ProgramsListBoxCollection)
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
            foreach (var listBox in installer.ProgramsListBoxCollection)
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    listBox.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
        }
    }
}
