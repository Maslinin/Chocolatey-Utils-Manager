using System.Threading.Tasks;

namespace CUM.Chocolatey
{
    sealed class ChocoAsyncInstaller : ChocoBaseInstaller
    {
        internal System.Threading.CancellationTokenSource CancellationToken { get; set; }

        internal ChocoAsyncInstaller() : base()
        {
            CancellationToken = new System.Threading.CancellationTokenSource();
        }

        /// <summary>
        /// Installs Chocolatey if it is not installed
        /// </summary>
        /// <param name="auth"></param>
        internal async Task InstallChocoAsync()
        {
            if (!base.ChocoExists)
            {
                await Task.Run(() => base.ChocoInstall());
            }
        }

        /// <summary>
        /// Installs the specified Chocolatey package
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async Task InstallPackageAsync(string packageLinkName)
        {
            if (base.ChocoExists)
            {
                await Task.Run(() => base.InstallPackage(packageLinkName, CancellationToken.Token), CancellationToken.Token);
            }
        }

        /// <summary>
        /// Updates the specified Chocolatey package
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async Task UpdatePackageAsync(string packageLinkName)
        {
            if (base.ChocoExists)
            {
                await Task.Run(() => base.UpdatePackage(packageLinkName, CancellationToken.Token), CancellationToken.Token);
            }
        }

        /// <summary>
        /// Deletes the specified Chocolatey package
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async Task UninstallPackageAsync(string packageLinkName)
        {
            if (base.ChocoExists)
            {
                await Task.Run(() => base.UninstallPackage(packageLinkName, CancellationToken.Token), CancellationToken.Token);
            }
        }
    }
}
