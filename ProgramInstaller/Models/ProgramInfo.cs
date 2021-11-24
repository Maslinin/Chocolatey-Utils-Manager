namespace CUM.ProgramInstaller.Models
{
    sealed class ProgramInfo
    {
        public string ProgramName { get; set; }
        public string ChocolateyInstallName { get; set; }

        public ProgramInfo(string ProgramName, string ChocolateyInstallName)
        {
            this.ProgramName = ProgramName;
            this.ChocolateyInstallName = ChocolateyInstallName;
        }
        public override string ToString() => ProgramName;
    }
}