using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using CUM.Models;

namespace CUM
{
    internal partial class InstallerMainForm
    {
        public async Task InstallChoco()
        {
            if (!this._сhoco.ChocoExists)
            {
                this.LockInstallerForm();
                this.StopButton.Enabled = false;
                this.PackageInfoLabel.Text = "Chocolatey isn't found on your computer. Installing it...";

                await this._сhoco.InstallChoco();

                this.UnlockInstallerForm();
                this.PackageInfoLabel.Text = "Chocolatey was installed";
            }
        }

        public async Task Process(IEnumerable<PackageInfo> packages, CancellationToken cancellationToken)
        {
            int counter = 0, packagesCount = this.GetSelectedPackagesCount();

            this.PackageInfoLabel.Text = $"{counter} out of {packagesCount} packages installed";
            foreach (var package in packages)
            {
                this.PackageInfoLabel.Text = $"{counter++} out of {packagesCount} packages installed: installing {package.PackageName}";

                if (this.InstallRadioButton.Checked) 
                    await this._сhoco.InstallPackage(package.PackageRefName);
                else if (this.UpgradeRadioButton.Checked) 
                    await this._сhoco.UpgradePackage(package.PackageRefName);
                else if (this.UninstallRadioButton.Checked) 
                    await this._сhoco.UninstallPackage(package.PackageRefName);

                cancellationToken.ThrowIfCancellationRequested();
            }

            this.PackageInfoLabel.Text = "Action completed";
        }

        private void UpdatePackageInfoLabel(ItemCheckEventArgs @event = null)
        {
            var packagesCount = @event is null ? this.GetSelectedPackagesCount() : this.GetSelectedPackagesCountAfterItemCheckEvent(@event);
            if (packagesCount == 0)
            {
                this.PackageInfoLabel.Text = "No package(s) selected";
            }
            else
            {
                this.PackageInfoLabel.Text = $"Select(ed) {packagesCount} package(s)";
            }
        }

    }
}
