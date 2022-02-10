using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using CUM.Installer.EntityModels;

namespace CUM.Installer
{
    internal partial class Installer : Form
    {
        /// <summary>
        /// Gets an object for asynchronous Chocolatey operations
        /// </summary>
        internal Choco.ChocoInstallerAsync Choco { get; private set; }
        /// <summary>
        /// Gets the asynchronous operation cancellation token
        /// </summary>
        internal CancellationTokenSource CancellationToken { get; private set; }
        /// <summary>
        /// Gets a list of programs from the json file available for installation in Chocolatey
        /// </summary>
        internal List<ProgramList> Programs { get; private set; }
        /// <summary>
        /// Gets a collection of displayed CheckedListBox containing packages to install
        /// </summary>
        internal List<CheckedListBox> ProgramsCheckedListBoxCollection { get; private set; }

        internal Installer()
        {
            InitializeComponent();
            Choco = new Choco.ChocoInstallerAsync();
            CancellationToken = new CancellationTokenSource();

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

            //Deserialization of json files into objects
            Programs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProgramList>>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProgramList.json")));
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            //ProgramsListBoxCollection.Count must be ProgramsListBoxLabels.Count
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

            var categories = Newtonsoft.Json.JsonConvert.DeserializeObject<InstallerCategories>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InstallerCategories.json")));

            //To create register and space independence
            for (int i = 0; i < categories.DisplayedCategories.Count; ++i)
            {
                categories.DisplayedCategories[i] = categories.DisplayedCategories[i].Replace(" ", "").ToLower();
            }

            //Get the number of listbox to process, ProgramsListBoxLabels.Count must be ProgramsListBoxCollection.Count
            int programsListBoxCount = (ProgramsCheckedListBoxCollection.Count >= Programs.Count) ? Programs.Count : ProgramsCheckedListBoxCollection.Count;

            //Set the names of CheckedListBox labels
            for (int i = 0; i < programsListBoxCount; ++i)
            {
                ProgramsListBoxLabels[i].Text = Programs[i].Category + ":";
            }

            //Drop Packages by Category:
            CheckedListBox temp;
            for (int i = 0; i < programsListBoxCount; ++i)
            {
                var categoryFromFile = Programs[i].Category.Replace(" ", "").ToLower(); //To create register and space independence
                var categoryPredicate = categories.DisplayedCategories.Find(c => c == categoryFromFile);

                //Get the listbox to which the program will be added
                temp = (categoryFromFile == categoryPredicate) ? ProgramsCheckedListBoxCollection[i] : OtherProgramsListBox;
                foreach (var program in Programs[i].Programs)
                    temp.Items.Add(program, CheckState.Unchecked);
            } 
            this.SelectAllCheckBox.Checked = false;

            //Customize Items CheckedListBox:
            foreach (var listBox in ProgramsCheckedListBoxCollection)
            {
                listBox.ItemCheck += this.CheckedListBoxEvent_ItemCheck;
                listBox.CheckOnClick = true;
                listBox.Sorted = true;
                listBox.IntegralHeight = false;
            }

            this.LockAndHidesStopButton();
            this.UpdatePackagesInfoLabel();
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
                MessageBox.Show("No packages selected for operation",
                    "No packages selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!this.CancellationToken.IsCancellationRequested)
            {
                this.CancellationToken = new CancellationTokenSource();
            }

            this.LockInstallerForm();
            this.UnLockAndShowStopButton();

            try
            {
                if (InstallRadioButton.Checked)
                {
                    await this.InstallPackages(this.GetSelectedPackagesItems(), this.CancellationToken);
                }
                else if (UpdateRadioButton.Checked)
                {
                    await this.UpdatePackages(this.GetSelectedPackagesItems(), this.CancellationToken);
                }
                else if(DeleteRadioButton.Checked)
                {
                    await this.UninstallPackages(this.GetSelectedPackagesItems(), this.CancellationToken);
                }
            }
            catch(OperationCanceledException)
            {
                this.CancellationToken.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    ex.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.UnLockInstallerForm();
                this.LockAndHidesStopButton();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if(!(this.CancellationToken is null))
            {
                this.CancellationToken.Cancel();
                this.InfoLabel.Text = "Installing cancelled... The action will be completed after the current package is completed.";
            }
        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Remove the handler method so that the handler is not called after each check box is selected/cleared
            foreach (var checkedBox in this.ProgramsCheckedListBoxCollection)
            {
                checkedBox.ItemCheck -= this.CheckedListBoxEvent_ItemCheck;
            }

            if (SelectAllCheckBox.Checked)
                this.SelectAllPackages();
            else
                this.UnselectAllPackages();

            this.UpdatePackagesInfoLabel();

            //Return his method to the handler
            foreach (var checkedBox in this.ProgramsCheckedListBoxCollection)
            {
                checkedBox.ItemCheck += this.CheckedListBoxEvent_ItemCheck;
            }
        }

        private void CheckedListBoxEvent_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.UpdatePackagesInfoLabel(e);
        }

        private void InstallerClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}
