using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using CUM.ProgramInstaller.Models;

namespace CUM.ProgramInstaller
{
    internal partial class Installer : Form
    {
        /// <summary>
        /// List of programs from the json file available for installation in Chocolatey
        /// </summary>
        internal List<ProgramList> Programs { get; }
        internal List<CheckedListBox> ProgramsCheckedListBoxCollection { get; }
        internal Chocolatey.ChocoAsyncInstaller Choco { get; }

        internal Installer()
        {
            InitializeComponent();
            Choco = new Chocolatey.ChocoAsyncInstaller();

            //ProgramsListBoxCollection.Count must be ProgramsListBoxLabels.Count
            ProgramsCheckedListBoxCollection = new List<CheckedListBox>
            {
                this.ProgramsCheckedListBox1,
                this.ProgramsCheckedListBox2,
                this.ProgramsCheckedListBox3,
                this.ProgramsCheckedListBox4,
                this.ProgramsCheckedListBox5,
                this.ProgramsCheckedListBox6,
                this.ProgramsCheckedListBox7,
                this.ProgramsCheckedListBox8,
                this.OtherProgramsListBox
            };
            var ProgramsListBoxLabels = new List<Label>
            {
                this.ProgramsCheckedListBoxLabel1,
                this.ProgramsCheckedListBoxLabel2,
                this.ProgramsCheckedListBoxLabel3,
                this.ProgramsCheckedListBoxLabel4,
                this.ProgramsCheckedListBoxLabel5,
                this.ProgramsCheckedListBoxLabel6,
                this.ProgramsCheckedListBoxLabel7,
                this.ProgramsCheckedListBoxLabel8,
                this.OtherProgramsLabel
            };

            foreach (var checkedBox in ProgramsCheckedListBoxCollection)
            {
                checkedBox.ItemCheck += this.CheckedListBoxEvent_ItemCheck;
            }

            //Deserialization of json files into objects
            Programs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProgramList>>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProgramList.json")));
            var categories = Newtonsoft.Json.JsonConvert.DeserializeObject<Categories>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Categories.json")));

            //To create register and space independence
            for (int i = 0; i < categories.DisplayedCategories.Count; ++i)
            {
                categories.DisplayedCategories[i] = categories.DisplayedCategories[i].Replace(" ", "").ToLower();
            }

            //Get the number of listbox to process, ProgramsListBoxLabels.Count must be ProgramsListBoxCollection.Count
            int programsListBoxCount = (ProgramsCheckedListBoxCollection.Count >= Programs.Count ? Programs.Count : ProgramsCheckedListBoxCollection.Count);

            //Set the names of CheckedListBox labels
            for (int i = 0; i < programsListBoxCount; ++i)
            {
                ProgramsListBoxLabels[i].Text = Programs[i].Category + ":";
            }

            CheckedListBox temp;
            for (int i = 0; i < programsListBoxCount; ++i)
            {
                var categoryFromFile = Programs[i].Category.Replace(" ", "").ToLower(); //To create register and space independence
                var categoryPredicate = categories.DisplayedCategories.Find(c => c == categoryFromFile);

                temp = (categoryFromFile == categoryPredicate) ? ProgramsCheckedListBoxCollection[i] : OtherProgramsListBox;

                foreach (var program in Programs[i].Programs)
                    temp.Items.Add(program, CheckState.Checked);
            }

            this.UnLockInstallerForm();
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
                MessageBox.Show("No packages selected for operation",
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
                else if(DeleteRadioButton.Checked)
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
