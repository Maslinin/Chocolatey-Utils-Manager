using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using CUM.Models;
using static CUM.Constants;

namespace CUM
{
    internal partial class MainForm
    {
        private int GetSelectedPackagesCount()
        {
            return this.PackagesCheckedListBox.CheckedItems.Count;
        }

        private int GetSelectedPackagesCountAfterItemCheckEvent(ItemCheckEventArgs e)
        {
            int packageCount = this.PackagesCheckedListBox.CheckedItems.Count;

            //Crutch:
            //Only works with this code,
            //due to a flaw CheckedListBox the number of packets would be displayed incorrectly, therefore if checked it increases by 1;
            //otherwise decreases by 1
            if (e.NewValue == CheckState.Checked)
                ++packageCount;
            else if (e.NewValue == CheckState.Unchecked)
                --packageCount;

            return packageCount;
        }

        private IEnumerable<PackageInfo> GetSelectedPackagesItems()
        {
            return new List<PackageInfo>(this.PackagesCheckedListBox.CheckedItems.Cast<PackageInfo>());
        }

        private string GetCurrentAction()
        {
            if (this.InstallRadioButton.Checked)
                return Action.Install;
            else if (this.UpgradeRadioButton.Checked)
                return Action.Upgrade;
            else
                return Action.Uninstall;
        }

        private ChocoProcess GetCurrentChocoMethod()
        {
            if (this.InstallRadioButton.Checked)
                return this._сhoco.InstallPackage;
            else if (this.UpgradeRadioButton.Checked)
                return this._сhoco.UpgradePackage;
            else
                return this._сhoco.UninstallPackage;
        }
    }
}
