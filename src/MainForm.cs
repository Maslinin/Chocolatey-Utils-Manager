using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using ChocolateyUtilsManager.Choco;
using ChocolateyUtilsManager.Models;
using static ChocolateyUtilsManager.Constants;

namespace ChocolateyUtilsManager
{
    internal partial class MainForm : Form
    {
        private delegate Task ChocoOption(string packageRefName);

        private readonly IChocoManager _choco;
        private readonly IEnumerable<PackageList> _packageList;
        private CancellationTokenSource _cancellationToken;

        internal MainForm()
        {
            InitializeComponent();
            this._choco = new ChocoManager();
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
            if (!this._choco.ChocoExists)
            {
                this.LockInstallerForm();
                this.PackageInfoLabel.Text = "Chocolatey isn't found on your computer. Installing it...";

                await this._choco.InstallChoco();

                this.UnlockInstallerForm();
                this.PackageInfoLabel.Text = "Chocolatey has been successfully installed";
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            if (this.GetSelectedPackagesCount() == 0)
            {
                PackageInfoLabel.Text = "No packages selected for operation";
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
                var packages = this.GetSelectedPackages();
                string option = this.GetCurrentSelectedOption();
                int counter = 0, packagesCount = this.GetSelectedPackagesCount();

                foreach (var package in packages)
                {
                    this.PackageInfoLabel.Text = $"{counter++} out of {packagesCount} packages {option}ed: {option}ing {package.PackageName}";

                    await this.GetChocoOptionMethodByCurrentSelectedOption()
                        .Invoke(package.PackageRefName);

                    this._cancellationToken.Token.ThrowIfCancellationRequested();
                }

                this.PackageInfoLabel.Text = $"Action completed";
            }
            catch (OperationCanceledException)
            {
                this.PackageInfoLabel.Text = "Action canceled";
                this._cancellationToken.Dispose();
            }
            finally
            {
                this.UnlockInstallerForm();
                this.LockAndHideStopButton();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this._cancellationToken.Cancel();

            string option = this.GetCurrentSelectedOption();
            this.PackageInfoLabel.Text = $"Cancelling action... The process will be completed after the current package is {option}ed";
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