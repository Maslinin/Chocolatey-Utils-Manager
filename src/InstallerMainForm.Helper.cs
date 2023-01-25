using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using CUM.Models;

namespace CUM
{
    internal partial class InstallerMainForm
    {
        public int GetSelectedPackagesCount()
        {
            return this.PackagesCheckedListBox.CheckedItems.Count;
        }

        public int GetSelectedPackagesCountAfterItemCheckEvent(ItemCheckEventArgs e)
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

        public IEnumerable<PackageInfo> GetSelectedPackagesItems()
        {
            return new List<PackageInfo>(this.PackagesCheckedListBox.CheckedItems.Cast<PackageInfo>());
        }
    }
}
