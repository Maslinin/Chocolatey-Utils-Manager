namespace CUM.ProgramInstaller
{
    internal static class InstallerFormExtensions
    {
        /// <summary>
        /// Locks the form so that only the STOP button becomes available and remains
        /// </summary>
        /// <param name="installer"></param>
        internal static void LockForm(this Installer installer)
        {
            installer.StartButton.Enabled = false;
            installer.StopButton.Enabled = true;
            installer.InstallButton.Enabled = false;
            installer.UpdateButton.Enabled = false;
            installer.DeleteButton.Enabled = false;
            installer.InstallerSplitContainer.Panel1.Enabled = false;
        }

        /// <summary>
        /// Locks the STOP button, making other form elements available for use
        /// </summary>
        /// <param name="installer"></param>
        internal static void UnLockForm(this Installer installer)
        {
            installer.StartButton.Enabled = true;
            installer.StopButton.Enabled = false;
            installer.InstallButton.Enabled = true;
            installer.UpdateButton.Enabled = true;
            installer.DeleteButton.Enabled = true;
            installer.InstallerSplitContainer.Panel1.Enabled = true;
        }
    }
}
