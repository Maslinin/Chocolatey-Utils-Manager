using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using CUM.ProgramInstaller.Models;

namespace CUM.ProgramInstaller
{
    internal partial class Installer : Form
    {
        internal List<ProgramList> Programs { get; private set; }
        internal Chocolatey.ChocoAsyncInstaller Choco { get; private set; }
        internal List<CheckedListBox> ProgramsCheckedListBoxCollection { get; private set; }

        internal Installer()
        {
            InitializeComponent();
            Choco = new Chocolatey.ChocoAsyncInstaller();
            //ProgramsListBoxCollection.Count must be ProgramsListBoxLabels.Count
            ProgramsCheckedListBoxCollection = new List<CheckedListBox>
            {
                this.BrowsersListBox,
                this.WorkWithFilesListBox,
                this.DotNetListBox,
                this.ProgrammingListBox,
                this.DataBasesListBox,
                this.AntivirusesListBox,
                this.MessengersListBox,
                this.GraphicAppsListBox,
                this.OtherListBox
            };

            foreach(var checkedBox in ProgramsCheckedListBoxCollection)
            {
                checkedBox.ItemCheck += this.CheckedListBoxEvent_ItemCheck;
            }

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
                this.BrowsersLabel,
                this.WorkWithFilesLabel,
                this.DotNetLabel,
                this.ProgrammingLabel,
                this.DataBasesLabel,
                this.AntivirusesLabel,
                this.MessengersLabel,
                this.GraphicAppsLabel,
                this.OtherLabel
            };
            for (int i = 0; i < (ProgramsCheckedListBoxCollection.Count >= Programs.Count ? Programs.Count : ProgramsCheckedListBoxCollection.Count); ++i)
            {
                ProgramsListBoxLabels[i].Text = Programs[i].Category + ":";
            }

            this.UpdatePackagesInfoLabel();

            this.StopButton.Enabled = false;
            this.StopButton.Visible = false;
        }

        //Immediately after opening the window, it is checked whether the chocolate package manager is installed on the computer
        private async void Installer_Shown(object sender, EventArgs e)
        {
            await this.InstallChoco();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            //If no packages are selected:
            if (this.GetSelectedPackagesCount() == 0)
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
                if (InstallRadioButton.Checked)
                {
                    await this.InstallPackages(this.GetSelectedPackagesItems());
                }
                else if (UpdateRadioButton.Checked)
                {
                    await this.UpdatePackages(this.GetSelectedPackagesItems());
                }
                else
                {
                    await this.UninstallPackages(this.GetSelectedPackagesItems());
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

            this.PackagesInfoLabel.Text = "Installing canceled";
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllCheckBox.Checked)
                this.SelectAllPackages();
            else
                this.UnselectAllPackages();
        }

        private void CheckedListBoxEvent_ItemCheck(object sender, EventArgs e)
        {
            this.UpdatePackagesInfoLabel();
        }

        private void InstallerClosed(object sender, FormClosedEventArgs e) => Application.Exit();

    }
}
