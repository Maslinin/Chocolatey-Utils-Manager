namespace CUM.Installer.EntityModels
{
    /// <summary>
    /// Contains a description of the Chocolatey software package
    /// </summary>
    public sealed class ProgramInfo
    {
        /// <summary>
        /// Gets the name of the program (package)
        /// </summary>
        public string ProgramName { get; }
        /// <summary>
        /// Gets the name of the Chocolatey installation package
        /// </summary>
        public string ChocolateyInstallName { get; }

        /// <summary>
        /// Initializes a new instance ProgramInfo
        /// </summary>
        /// <param name="ProgramName"></param>
        /// <param name="ChocolateyInstallName"></param>
        public ProgramInfo(string ProgramName, string ChocolateyInstallName)
        {
            this.ProgramName = ProgramName;
            this.ChocolateyInstallName = ChocolateyInstallName;
        }

        /// <summary>
        /// Returns the ProgramName of the current instance
        /// </summary>
        /// <returns>ProgramName for the current instance</returns>
        public override string ToString() => ProgramName;
    }
}