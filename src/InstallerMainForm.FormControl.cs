using System.Windows.Forms;

namespace CUM
{
    internal partial class InstallerMainForm
    {
        public void LockInstallerForm()
        {
            this.StartButton.Enabled = false;
            this.StopButton.Enabled = false;
            this.InstallRadioButton.Enabled = false;
            this.UpgradeRadioButton.Enabled = false;
            this.UninstallRadioButton.Enabled = false;
            this.InstallerSplitContainer.Panel1.Enabled = false;
            this.SelectAllPackagesCheckBox.Enabled = false;
        }

        public void UnlockInstallerForm()
        {
            this.StartButton.Enabled = true;
            this.StopButton.Enabled = true;
            this.InstallRadioButton.Enabled = true;
            this.UpgradeRadioButton.Enabled = true;
            this.UninstallRadioButton.Enabled = true;
            this.InstallerSplitContainer.Panel1.Enabled = true;
            this.SelectAllPackagesCheckBox.Enabled = true;
        }

        public void LockAndHideStopButton()
        {
            this.StopButton.Enabled = false;
            this.StopButton.Visible = false;
            this.ActionSelectionGroupBox.Height -= this.StopButton.Height;
        }

        public void UnlockAndShowStopButton()
        {
            this.StopButton.Enabled = true;
            this.StopButton.Visible = true;
            this.ActionSelectionGroupBox.Height += this.StopButton.Height;
        }

        public void SelectAllPackages()
        {
            var listBox = this.PackagesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        public void UnselectAllPackages()
        {
            var listBox = this.PackagesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        public void SelectAllCategories()
        {
            var listBox = this.PackageCategoriesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        public void UnselectAllCategories() 
        {
            var listBox = this.PackageCategoriesCheckedListBox;
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                listBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

    }
}
