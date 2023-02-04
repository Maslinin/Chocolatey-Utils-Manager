namespace ChocolateyUtilsManager.Models
{
    internal sealed class PackageInfo
    {
        public string PackageName { get; set; }
        public string PackageRefName { get; set; }

        public override string ToString() => this.PackageName;
    }
}