using System.Threading;
using System.Threading.Tasks;

namespace CUM.Choco
{
    public sealed class ChocoInstallerAsync : ChocoInstallerBase
    {
        /// <summary>
        /// Initializes an instance inherited from ChocoBaseInstaller
        /// </summary>
        public ChocoInstallerAsync() : base() { }

        /// <summary>
        /// Asynchronously installs Chocolatey if it is not yet installed
        /// </summary>
        /// <param name="auth"></param>
        /// <returns> Stdout process message if chocolatey is not installed; otherwise null</returns>
        public async Task<string> InstallChocoAsync()
        {
            if (!base.ChocoExists)
            {
                return await Task.Run(() => base.InstallChoco());
            }

            return null;
        }

        /// <summary>
        /// Asynchronously installs a package using Chocolatey<br/>
        /// Uses the instance token to abort the installation
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <returns> Stdout process message if chocolatey is installed; otherwise null </returns>
        public async Task<string> InstallPackageAsync(string packageLinkName, CancellationToken? cancellationToken = null)
        {
            if (base.ChocoExists)
            {
                if (cancellationToken?.IsCancellationRequested ?? false)
                    cancellationToken?.ThrowIfCancellationRequested();

                return await Task.Run(() => base.InstallPackage(packageLinkName), cancellationToken.Value);
            }

            return null;
        }

        /// <summary>
        /// Asynchronously updates the package using Chocolatey<br/>
        /// Uses the instance token to abort the update
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <returns> Stdout process message if chocolatey is installed; otherwise null </returns>
        public async Task<string> UpdatePackageAsync(string packageLinkName, CancellationToken? cancellationToken = null)
        {
            if (base.ChocoExists)
            {
                if (cancellationToken?.IsCancellationRequested ?? false)
                    cancellationToken?.ThrowIfCancellationRequested();

                return await Task.Run(() => base.UpdatePackage(packageLinkName), cancellationToken.Value);
            }

            return null;
        }

        /// <summary>
        /// Asynchronously deletes a package using Chocolatey<br/>
        /// Uses the instance token to abort the deletion
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <returns> Stdout process message if chocolatey is installed; otherwise null </returns>
        public async Task<string> UninstallPackageAsync(string packageLinkName, CancellationToken? cancellationToken = null)
        {
            if (base.ChocoExists)
            {
                if (cancellationToken?.IsCancellationRequested ?? false)
                    cancellationToken?.ThrowIfCancellationRequested();

                return await Task.Run(() => base.UninstallPackage(packageLinkName), cancellationToken.Value);
            }

            return null;
        }
    }
}
