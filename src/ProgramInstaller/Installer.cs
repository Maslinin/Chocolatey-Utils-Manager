using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using CUM.ProgramInstaller.Models;

namespace CUM.ProgramInstaller
{
    internal partial class Installer : Form
    {
        internal List<CheckedListBox> ProgramsListBoxCollection { get; private set; }
        internal List<ProgramList> Programs { get; private set; }
        internal Chocolatey.ChocoAsyncInstaller Choco { get; private set; }
        internal int SelectedPackagesCount { get; private set; }

        internal Installer()
        {
            InitializeComponent();
            Choco = new Chocolatey.ChocoAsyncInstaller();
            //ProgramsListBoxCollection.Count must be ProgramsListBoxLabels.Count
            ProgramsListBoxCollection = new List<CheckedListBox>
            {
                BrowsersListBox,
                WorkWithFilesListBox,
                DotNetListBox,
                ProgrammingListBox,
                DataBasesListBox,
                AntivirusesListBox,
                MessengersListBox,
                GraphicAppsListBox,
                OtherListBox
            };

            Programs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProgramList>>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProgramList.json")));

            CheckedListBox temp;
            foreach (var list in Programs)
            {
                var category = list.Category.Replace(" ", "").ToLower();

                if (category == "browsers")
                    temp = BrowsersListBox;
                else if (category == "workingwithfiles")
                    temp = WorkWithFilesListBox;
                else if (category == "dotnet")
                    temp = DotNetListBox;
                else if (category == "programming")
                    temp = ProgrammingListBox;
                else if (category == "databases")
                    temp = DataBasesListBox;
                else if (category == "antiviruses")
                    temp = AntivirusesListBox;
                else if (category == "messengers")
                    temp = MessengersListBox;
                else if (category == "graphic")
                    temp = GraphicAppsListBox;
                else
                    temp = OtherListBox;

                foreach (var program in list.Programs)
                    temp.Items.Add(program, CheckState.Checked);
            }

            //ProgramsListBoxLabels.Count must be ProgramsListBoxCollection.Count
            var ProgramsListBoxLabels = new List<Label>
            {
                BrowsersLabel,
                WorkWithFilesLabel,
                DotNetLabel,
                ProgrammingLabel,
                DataBasesLabel,
                AntivirusesLabel,
                MessengersLabel,
                GraphicAppsLabel,
                OtherLabel
            };
            for (int i = 0; i < (ProgramsListBoxCollection.Count >= Programs.Count ? Programs.Count : ProgramsListBoxCollection.Count); ++i)
            {
                ProgramsListBoxLabels[i].Text = Programs[i].Category + ":";
            }

            PackagesInfoLabel.Text = "No package(s) selected";

            StopButton.Enabled = false;
        }

        //Immediately after opening the window, it is checked whether the chocolate package manager is installed on the computer
        private async void Installer_Shown(object sender, EventArgs e)
        {
            if (!Choco.ChocoChild.ChocoExists)
            {
                PackagesInfoLabel.Text = "Chocolate isn't found on your computer. Installing it...";
                await Choco.InstallChocoAsync();
                PackagesInfoLabel.Text = "Chocolate was installed";
            }
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllCheckBox.Checked)
                foreach (var listBox in ProgramsListBoxCollection)
                    for (int i = 0; i < listBox.Items.Count; ++i)
                    {
                        listBox.SetItemCheckState(i, CheckState.Checked);
                    }
            else
                foreach (var listBox in ProgramsListBoxCollection)
                    for (int i = 0; i < listBox.Items.Count; ++i)
                    {
                        listBox.SetItemCheckState(i, CheckState.Unchecked);
                    }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            int packagesCount = this.GetSelectedPackagesCount();
            //If no packages are selected:
            if (packagesCount == 0)
            {
                MessageBox.Show("No package selected for installation",
                    "No packages selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.LockInstallerForm();

            try
            {
                int i = 0;
                if (InstallButton.Checked)
                {
                    PackagesInfoLabel.Text = $"0 out of {packagesCount} packages installed";
                    foreach (var listBox in ProgramsListBoxCollection)
                        foreach (ProgramInfo program in listBox.CheckedItems)
                        {
                            PackagesInfoLabel.Text = $"{i++} out of {packagesCount} packages installed: installing {program.ChocolateyInstallName}";
                            await Choco.InstallPackageAsync(program.ChocolateyInstallName);
                        }
                    PackagesInfoLabel.Text = "Installing completed";
                }
                else if (UpdateButton.Checked)
                {
                    PackagesInfoLabel.Text = $"0 out of {packagesCount} packages updated";
                    foreach (var listBox in ProgramsListBoxCollection)
                        foreach (ProgramInfo program in listBox.CheckedItems)
                        {
                            PackagesInfoLabel.Text = $"{i++} out of {packagesCount} packages updated: updating {program.ChocolateyInstallName}";
                            await Choco.UpdatePackageAsync(program.ChocolateyInstallName);
                        }
                    PackagesInfoLabel.Text = "Updating completed";
                }
                else
                {
                    PackagesInfoLabel.Text = $"0 out of {packagesCount} packages deleted";
                    foreach (var listBox in ProgramsListBoxCollection)
                        foreach (ProgramInfo program in listBox.CheckedItems)
                        {
                            PackagesInfoLabel.Text = $"{i++} out of {packagesCount} packages uninstalled: uninstalling {program.ChocolateyInstallName}";
                            await Choco.UpdatePackageAsync(program.ChocolateyInstallName);
                        }
                    PackagesInfoLabel.Text = "Uninstallation completed";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    ex.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            this.UnLockInstallerForm();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.UnLockInstallerForm();

            PackagesInfoLabel.Text = "Installing canceled";
        }

        private void InstallerClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}
