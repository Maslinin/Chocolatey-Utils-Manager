using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using CUM.Choco;
using CUM.Models;
using static CUM.Constants;

namespace CUM
{
    internal partial class MainForm : Form
    {
        private delegate Task ChocoProcess(string packageRefName);
        private readonly IChoco _сhoco;
        private readonly IEnumerable<PackageList> _packageList;
        private CancellationTokenSource _cancellationToken;

        internal MainForm()
        {
            InitializeComponent();
            this._сhoco = new ChocoManager();
            this._cancellationToken = new CancellationTokenSource();

            this.InstallerSplitContainer.IsSplitterFixed = true;

            this.PackagesCheckedListBox.ItemCheck += this.PackageCheckedListBox_ItemCheck;
            this.PackageCategoriesCheckedListBox.ItemCheck += this.PackageCategoriesCheckedListBox_ItemCheck;

            this._packageList = JsonConvert.DeserializeObject<IEnumerable<PackageList>>(
                File.ReadAllText(IO.PackageListPath));
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            this.SelectAllPackagesCheckBox.Checked = false;
            this.SelectAllCategoriesCheckBox.Checked = true;

            this.LockAndHideStopButton();
            this.GetSelectedPackagesCount();

            foreach (var category in this._packageList)
            {
                this.PackageCategoriesCheckedListBox.Items.Add(category, CheckState.Checked);
            }
        }

        //Immediately after opening the window, it is checked whether the chocolate package manager is installed on the computer
        private async void Installer_Shown(object sender, EventArgs e)
        {
            await this.InstallChoco();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (this.GetSelectedPackagesCount() == 0)
            {
                PackageInfoLabel.Text = "No packages selected for operation.";
                return;
            }

            if (!this._cancellationToken.IsCancellationRequested)
            {
                this._cancellationToken = new CancellationTokenSource();
            }

            this.LockInstallerForm();
            this.UnlockAndShowStopButton();

            try
            {
                await this.CreateProcess(this.GetSelectedPackagesItems(), this._cancellationToken.Token);
            }
            catch (OperationCanceledException)
            {
                this.PackageInfoLabel.Text = "Action canceled.";
                this._cancellationToken.Dispose();
            }
            catch (Exception ex)
            {
                PackageInfoLabel.Text = ex.Message;
            }
            finally
            {
                this.UnlockInstallerForm();
                this.LockAndHideStopButton();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            string action = this.GetCurrentAction();

            this._cancellationToken.Cancel();
            this.PackageInfoLabel.Text = $"Canceling action... The process will be completed after the current package is {action}ed.";
        }

        private void SelectAllPackagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SelectAllPackagesCheckBox.Checked)
                this.SelectAllPackages();
            else
                this.UnselectAllPackages();

            this.UpdatePackageInfoLabel();
        }

        private void SelectAllCategoriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SelectAllCategoriesCheckBox.Checked)
                this.SelectAllCategories();
            else
                this.UnselectAllCategories();
        }

        private void PackageCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.UpdatePackageInfoLabel(e);
        }

        private void PackageCategoriesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var packages = ((sender as CheckedListBox)
                .Items[e.Index] as PackageList)
                .Packages;

            if (e.NewValue == CheckState.Checked)
                foreach (var package in packages)
                {
                    this.PackagesCheckedListBox.Items.Add(package, this.SelectAllPackagesCheckBox.Checked);
                }
            else if (e.NewValue == CheckState.Unchecked)
                foreach (var package in packages)
                {
                    this.PackagesCheckedListBox.Items.Remove(package);
                }

            this.UpdatePackageInfoLabel();
        }

        private void InstallerClose(object sender, FormClosedEventArgs e) => Application.Exit();

    }
}
