using System.Threading.Tasks;

namespace CUM.Choco
{
    internal sealed class ChocoAsyncInstaller : ChocoBaseInstaller
    {
        /// <summary>
        /// Gets or sets the cancellation token for asynchronous operations
        /// </summary>
        internal System.Threading.CancellationTokenSource CancellationToken { get; set; }

        /// <summary>
        /// Initializes an instance inherited from ChocoBaseInstaller ChocoAsyncInstaller
        /// </summary>
        internal ChocoAsyncInstaller() : base()
        {
            CancellationToken = new System.Threading.CancellationTokenSource();
        }

        /// <summary>
        /// Asynchronously installs Chocolatey if it is not yet installed
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
        /// Asynchronously installs a package using Chocolatey<br/>
        /// Uses the instance token to abort the installation
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
        /// Asynchronously updates the package using Chocolatey<br/>
        /// Uses the instance token to abort the update
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
        /// Asynchronously deletes a package using Chocolatey<br/>
        /// Uses the instance token to abort the deletion
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
