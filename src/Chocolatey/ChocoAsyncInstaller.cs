using System.Threading.Tasks;

namespace CUM.Chocolatey
{
    sealed class ChocoAsyncInstaller
    {
        internal ChocoBaseInstaller ChocoChild { get; private set; }

        public ChocoAsyncInstaller() => ChocoChild = new ChocoBaseInstaller();

        /// <summary>
        /// Installs Chocolatey if it is not installed
        /// </summary>
        /// <param name="auth"></param>
        internal async Task InstallChocoAsync()
        {
            if (!ChocoChild.ChocoExists)
            {
                await Task.Run(() => ChocoChild.ChocoInstall());
            }
        }
        /// <summary>
        /// Installs the specified Chocolatey package
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async Task InstallPackageAsync(string packageLinkName)
        {
            if (ChocoChild.ChocoExists)
            {
                await Task.Run(() => ChocoChild.InstallPackage(packageLinkName));
            }
        }
        /// <summary>
        /// Updates the specified Chocolatey package
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async Task UpdatePackageAsync(string packageLinkName)
        {
            if (ChocoChild.ChocoExists)
            {
                await Task.Run(() => ChocoChild.UpdatePackage(packageLinkName));
            }
        }
        /// <summary>
        /// Deletes the specified Chocolatey package
        /// </summary>
        /// <param name="packageLinkName"></param>
        internal async Task UninstallPackageAsync(string packageLinkName)
        {
            if (ChocoChild.ChocoExists)
            {
                await Task.Run(() => ChocoChild.UninstallPackage(packageLinkName));
            }
        }
    }
}
