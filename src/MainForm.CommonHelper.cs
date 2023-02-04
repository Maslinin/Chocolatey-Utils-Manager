using System.Linq;
using System.Collections.Generic;
using CUM.Models;
using static CUM.Constants;

namespace CUM
{
    internal partial class MainForm
    {

        #region Helper methods for working with packages

        private int GetSelectedPackagesCount()
        {
            return this.PackagesCheckedListBox.CheckedItems.Count;
        }

        private IEnumerable<PackageInfo> GetSelectedPackages()
        {
            var packagesInfo = this.PackagesCheckedListBox.CheckedItems.Cast<PackageInfo>();
            return new List<PackageInfo>(packagesInfo);
        }

        #endregion

        #region Simple Factories to select an action depending on the selected option

        private string GetCurrentSelectedOption()
        {
            if (this.InstallRadioButton.Checked)
                return Option.Install;
            else if (this.UpgradeRadioButton.Checked)
                return Option.Upgrade;
            else
                return Option.Uninstall;
        }

        private ChocoProcess GetChocoMethodForCurrentOption()
        {
            if (this.InstallRadioButton.Checked)
                return this._choco.InstallPackage;
            else if (this.UpgradeRadioButton.Checked)
                return this._choco.UpgradePackage;
            else
                return this._choco.UninstallPackage;
        }

        #endregion

    }
}
