using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using CUM.Models;

namespace CUM
{
    internal partial class MainForm
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
                this.PackageInfoLabel.Text = "Chocolatey has been successfully installed";
            }
        }

        public async Task CreateProcess(IEnumerable<PackageInfo> packages, CancellationToken cancellationToken)
        {
            string action = this.GetCurrentAction();
            int counter = 0, packagesCount = this.GetSelectedPackagesCount();

            foreach (var package in packages)
            {
                this.PackageInfoLabel.Text = $"{counter++} out of {packagesCount} packages {action}ed: {action}ing {package.PackageName}";

                await this.GetCurrentChocoMethod()
                    .Invoke(package.PackageRefName);

                cancellationToken.ThrowIfCancellationRequested();
            }

            this.PackageInfoLabel.Text = $"Action completed";
        }

        private void UpdatePackageInfoLabel(ItemCheckEventArgs @event = null)
        {
            var packagesCount = @event is null ? this.GetSelectedPackagesCount() : this.GetSelectedPackagesCountAfterItemCheckEvent(@event);
            if (packagesCount == 0)
            {
                this.PackageInfoLabel.Text = "No packages selected";
            }
            else
            {
                this.PackageInfoLabel.Text = $"{packagesCount} package(s) selected";
            }
        }

    }
}
