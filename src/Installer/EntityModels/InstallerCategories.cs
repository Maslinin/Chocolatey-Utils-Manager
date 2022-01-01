using System.Collections.Generic;

namespace CUM.Installer.EntityModels
{
    sealed class InstallerCategories
    {
        public List<string> DisplayedCategories { get; set; } = new List<string>();

        public InstallerCategories() { }
    }
}
