using System.Windows.Forms;

namespace CUM
{
    internal partial class MainForm
    {
        private void LockInstallerForm()
        {
            this.StartButton.Enabled = false;
            this.StopButton.Enabled = false;
            this.InstallRadioButton.Enabled = false;
            this.UpgradeRadioButton.Enabled = false;
            this.UninstallRadioButton.Enabled = false;
            this.InstallerSplitContainer.Panel1.Enabled = false;
            this.SelectAllPackagesCheckBox.Enabled = false;
        }

        private void UnlockInstallerForm()
        {
            this.StartButton.Enabled = true;
            this.StopButton.Enabled = true;
            this.InstallRadioButton.Enabled = true;
            this.UpgradeRadioButton.Enabled = true;
            this.UninstallRadioButton.Enabled = true;
            this.InstallerSplitContainer.Panel1.Enabled = true;
            this.SelectAllPackagesCheckBox.Enabled = true;
        }

        private void LockAndHideStopButton()
        {
            this.StopButton.Enabled = false;
            this.StopButton.Visible = false;
            this.OptionSelectionGroupBox.Height -= this.StopButton.Height;
        }

        private void UnlockAndShowStopButton()
        {
            this.StopButton.Enabled = true;
            this.StopButton.Visible = true;
            this.OptionSelectionGroupBox.Height += this.StopButton.Height;
        }

        private void SelectAllPackages()
        {
            var listBox = this.PackagesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void UnselectAllPackages()
        {
            var listBox = this.PackagesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void SelectAllCategories()
        {
            var listBox = this.PackageCategoriesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void UnselectAllCategories() 
        {
            var listBox = this.PackageCategoriesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void UpdatePackageInfoLabel(ItemCheckEventArgs @event = null)
        {
            var packagesCount = this.GetSelectedPackagesCount();

            if (@event is null)
            {
                //Crutch:
                //Only works with this code,
                //due to a flaw CheckedListBox the number of packets would be displayed incorrectly, therefore if checked it increases by 1;
                //otherwise decreases by 1
                if (@event.NewValue == CheckState.Checked)
                    ++packagesCount;
                else if (@event.NewValue == CheckState.Unchecked)
                    --packagesCount;
            }

            this.PackageInfoLabel.Text = packagesCount == 0 ? "No packages selected" : $"{packagesCount} package(s) selected";
        }

    }
}
