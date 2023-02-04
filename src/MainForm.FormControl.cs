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
            this.ActionSelectionGroupBox.Height -= this.StopButton.Height;
        }

        private void UnlockAndShowStopButton()
        {
            this.StopButton.Enabled = true;
            this.StopButton.Visible = true;
            this.ActionSelectionGroupBox.Height += this.StopButton.Height;
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
            var packagesCount = @event is null ? this.GetSelectedPackagesCount() : this.GetSelectedPackagesCountAfterItemCheckEvent(@event);
            if (packagesCount == 0)
            {
                this.PackageInfoLabel.Text = "No packages selected";
            }
            else
            {
                this.PackageInfoLabel.Text = $"{packagesCount} package(s) selected";
            }
        }

    }
}
