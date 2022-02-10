using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CUM.Installer
{
    internal partial class Installer
    {
        /// <summary>
        /// UnLocks all form elements
        /// </summary>
        /// <param name="installer"></param>
        private void LockInstallerForm()
        {
            this.StartButton.Enabled = false;
            this.StopButton.Enabled = false;
            this.InstallRadioButton.Enabled = false;
            this.UpdateRadioButton.Enabled = false;
            this.DeleteRadioButton.Enabled = false;
            this.InstallerSplitContainer.Panel1.Enabled = false;
            this.SelectAllCheckBox.Enabled = false;
        }

        /// <summary>
        /// Locks all form elements
        /// </summary>
        /// <param name="installer"></param>
        private void UnLockInstallerForm()
        {
            this.StartButton.Enabled = true;
            this.StopButton.Enabled = true;
            this.InstallRadioButton.Enabled = true;
            this.UpdateRadioButton.Enabled = true;
            this.DeleteRadioButton.Enabled = true;
            this.InstallerSplitContainer.Panel1.Enabled = true;
            this.SelectAllCheckBox.Enabled = true;
        }

        /// <summary>
        /// Locks and hides the Stop button on the form
        /// </summary>
        /// <param name="installer"></param>
        private void LockAndHidesStopButton()
        {
            this.StopButton.Enabled = false;
            this.StopButton.Visible = false;
            this.ModeSelectionGroupBox.Height -= this.StopButton.Height;
        }

        /// <summary>
        /// Unlocks and displays the Stop button on the form
        /// </summary>
        /// <param name="installer"></param>
        private void UnLockAndShowStopButton()
        {
            this.StopButton.Enabled = true;
            this.StopButton.Visible = true;
            this.ModeSelectionGroupBox.Height += this.StopButton.Height;
        }


        /// <summary>
        /// Sets Cheсked to all items CheckedBox
        /// </summary>
        /// <param name="installer"></param>
        private void SelectAllPackages()
        {
            foreach (var listBox in this.ProgramsCheckedListBoxCollection)
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    listBox.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
                }
        }

        /// <summary>
        /// Clears Cheсked to all items CheckedBox
        /// </summary>
        /// <param name="installer"></param>
        private void UnselectAllPackages()
        {
            foreach (var listBox in this.ProgramsCheckedListBoxCollection)
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    listBox.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
        }

        /// <summary>
        /// Updates the package information label
        /// </summary>
        /// <param name="installer"></param>
        private void UpdatePackagesInfoLabel(System.Windows.Forms.ItemCheckEventArgs e = null)
        {
            var packagesCount = e is null ? this.GetSelectedPackagesCount() : this.GetSelectedPackagesCountAfterEvent(e);
            if (packagesCount == 0)
            {
                this.InfoLabel.Text = "No package(s) selected";
            }
            else
            {
                this.InfoLabel.Text = $"Select(ed) {packagesCount} package(s)";
            }
        }

        /// <summary>
        /// Installs Chocololatey if it is not installed
        /// </summary>
        /// <param name="installer"></param>
        private async Task InstallChoco()
        {
            if (!this.Choco.ChocoExists)
            {
                this.LockInstallerForm();
                this.InfoLabel.Text = "Chocolatey isn't found on your computer. Installing it...";
                await this.Choco.InstallChocoAsync();
                this.UnLockInstallerForm();
                this.StopButton.Enabled = false;
                this.InfoLabel.Text = "Chocolatey was installed";
            }
        }

        /// <summary>
        /// Installs the packages passed to the parameter as a collection<br/>
        /// cancellation Token parameter is required to cancel install and exit the asynchronous thread
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="programs"></param>
        private async Task InstallPackages(List<EntityModels.ProgramInfo> programs, CancellationTokenSource cancellationToken)
        {
            int i = 0, packagesCount = this.GetSelectedPackagesCount();

            this.InfoLabel.Text = $"0 out of {packagesCount} packages installed";
            foreach (var program in programs)
            {
                this.InfoLabel.Text = $"{i++} out of {packagesCount} packages installed: installing {program.ProgramName}";
                string psMesagge = await this.Choco.InstallPackageAsync(program.ChocolateyInstallName, cancellationToken.Token);
                Logger.NLogger.Log(psMesagge);

                if (cancellationToken?.IsCancellationRequested ?? false)
                {
                    this.UnLockInstallerForm();
                    this.LockAndHidesStopButton();
                    this.InfoLabel.Text = "Installing canceled";

                    throw new System.OperationCanceledException();
                }
            }
            this.InfoLabel.Text = "Installing completed";
        }

        /// <summary>
        /// Updates the packages passed to the parameter as a collection<br/>
        /// cancellationToken parameter is required to cancel update and exit the asynchronous thread
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="programs"></param>
        private async Task UpdatePackages(List<EntityModels.ProgramInfo> programs, CancellationTokenSource cancellationToken)
        {
            int i = 0, packagesCount = this.GetSelectedPackagesCount();

            this.InfoLabel.Text = $"0 out of {packagesCount} packages updated";
            foreach (var program in programs)
            {
                this.InfoLabel.Text = $"{i++} out of {packagesCount} packages updated: updating {program.ProgramName}";
                string psMesagge = await this.Choco.UpdatePackageAsync(program.ChocolateyInstallName, cancellationToken.Token);
                Logger.NLogger.Log(psMesagge);

                if (cancellationToken?.IsCancellationRequested ?? false)
                {
                    this.UnLockInstallerForm();
                    this.LockAndHidesStopButton();
                    this.InfoLabel.Text = "Updating canceled";

                    throw new System.OperationCanceledException();
                }
            }
            this.InfoLabel.Text = "Updating completed";
        }

        /// <summary>
        /// Uninstall the packages passed to the parameter as a collection<br/>
        /// cancellationToken parameter is required to cancel uninstall and exit the asynchronous thread
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="programs"></param>
        private async Task UninstallPackages(List<EntityModels.ProgramInfo> programs, CancellationTokenSource cancellationToken)
        {
            int i = 0, packagesCount = this.GetSelectedPackagesCount();

            this.InfoLabel.Text = $"0 out of {packagesCount} packages deleted";
            foreach (var program in programs)
            {
                this.InfoLabel.Text = $"{i++} out of {packagesCount} packages uninstalled: uninstalling {program.ProgramName}";
                string psMesagge = await this.Choco.UninstallPackageAsync(program.ChocolateyInstallName, cancellationToken.Token);
                Logger.NLogger.Log(psMesagge);

                if (cancellationToken?.IsCancellationRequested ?? false)
                {
                    this.UnLockInstallerForm();
                    this.LockAndHidesStopButton();
                    this.InfoLabel.Text = "Uninstalling canceled";

                    throw new System.OperationCanceledException();
                }
            }
            this.InfoLabel.Text = "Uninstallation complete";
        }
    }
}
