namespace CUM.Choco
{
    public interface IChoco
    {
        /// <summary>
        /// Gets true if Chocolatey is set; otherwise false
        /// </summary>
        bool ChocoExists { get; }
        /// <summary>
        /// Installs Chocolatey if it is not installed
        /// </summary>
        /// <returns> Message written by process from stdout </returns>
        string InstallChoco();
        /// <summary>
        /// Installs a package using Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <returns> Message written by process from stdout </returns>
        string InstallPackage(string packageLinkName);
        /// <summary>
        /// Updates the package using Chocolatey
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <returns> Message written by process from stdout </returns>
        string UpdatePackage(string packageLinkName);
        /// <summary>
        /// Deletes a package using Chocolatey<br/>
        /// </summary>
        /// <param name="packageLinkName"></param>
        /// <returns> Message written by process from stdout </returns>
        string UninstallPackage(string packageLinkName);
    }
}
