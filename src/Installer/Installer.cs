using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using CUM.Installer.EntityModels;

namespace CUM.Installer
{
    internal partial class Installer : Form
    {
        /// <summary>
        /// Gets a collection of displayed CheckedListBox containing packages to install
        /// </summary>
        internal List<CheckedListBox> ProgramsCheckedListBoxCollection { get; private set; }

        /// <summary>
        /// Gets an object for asynchronous Chocolatey operations
        /// </summary>
        private readonly Choco.ChocoInstallerAsync _сhoco;
        /// <summary>
        /// Gets the choco asynchronous operation cancellation token
        /// </summary>
        private CancellationTokenSource _сancellationToken;
        /// <summary>
        /// Gets a list of programs from the json file available for installation in Chocolatey
        /// </summary>
        private readonly List<ProgramList> _programs;

        internal Installer()
        {
            InitializeComponent();
            _сhoco = new Choco.ChocoInstallerAsync();
            _сancellationToken = new CancellationTokenSource();

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
            _programs = JsonConvert.DeserializeObject<List<ProgramList>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProgramList.json")));
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

            var categories = JsonConvert.DeserializeObject<InstallerCategories>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InstallerCategories.json")));

            //To create register and space independence
            for (int i = 0; i < categories.DisplayedCategories.Count; ++i)
            {
                categories.DisplayedCategories[i] = categories.DisplayedCategories[i].Replace(" ", "").ToLower();
            }

            //Get the number of listbox to process, ProgramsListBoxLabels.Count must be ProgramsListBoxCollection.Count
            int programsListBoxCount = (ProgramsCheckedListBoxCollection.Count >= _programs.Count) ? _programs.Count : ProgramsCheckedListBoxCollection.Count;

            //Set the names of CheckedListBox labels
            for (int i = 0; i < programsListBoxCount; ++i)
            {
                ProgramsListBoxLabels[i].Text = _programs[i].Category + ":";
            }

            //Drop Packages by Category:
            CheckedListBox temp;
            for (int i = 0; i < programsListBoxCount; ++i)
            {
                var categoryFromFile = _programs[i].Category.Replace(" ", "").ToLower(); //To create register and space independence
                var categoryPredicate = categories.DisplayedCategories.Find(c => c == categoryFromFile);

                //Get the listbox to which the program will be added
                temp = (categoryFromFile == categoryPredicate) ? ProgramsCheckedListBoxCollection[i] : OtherProgramsListBox;
                foreach (var program in _programs[i].Programs)
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

            this.InfoLabel.ForeColor = System.Drawing.Color.LightYellow;

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
                InfoLabel.Text = "No packages selected for operation";
                return;
            }

            if (!this._сancellationToken.IsCancellationRequested)
            {
                this._сancellationToken = new CancellationTokenSource();
            }

            this.LockInstallerForm();
            this.UnLockAndShowStopButton();

            try
            {
                if (InstallRadioButton.Checked)
                {
                    await this.InstallPackages(this.GetSelectedPackagesItems(), this._сancellationToken);
                }
                else if (UpdateRadioButton.Checked)
                {
                    await this.UpdatePackages(this.GetSelectedPackagesItems(), this._сancellationToken);
                }
                else if (DeleteRadioButton.Checked)
                {
                    await this.UninstallPackages(this.GetSelectedPackagesItems(), this._сancellationToken);
                }
            }
            catch(OperationCanceledException)
            {
                this._сancellationToken.Dispose();
            }
            catch(Exception ex)
            {
                Logger.NLogger.Log(ex.ToString());
                MessageBox.Show($"{ex.Message}.\nCheck out the full version of the log on the path {Logger.NLogger.LogDirPath}",
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
            if(this._сancellationToken is not null)
            {
                this._сancellationToken.Cancel();

                if (InstallRadioButton.Checked)
                {
                    this.InfoLabel.Text = $"Canceling the installation... The process will be terminated after the current package is installed.";
                }
                else if (UpdateRadioButton.Checked)
                {
                    this.InfoLabel.Text = $"Canceling update... The process will be completed after the current package is updated.";
                }
                else if (DeleteRadioButton.Checked)
                {
                    this.InfoLabel.Text = $"Canceling the uninstallation... The process will be completed after uninstallation the current package.";
                }
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

        private void InstallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.UnselectAllPackages();
        }

        private void UpdateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.UnselectAllPackages();
        }

        private void DeleteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.UnselectAllPackages();
        }

        private void CheckedListBoxEvent_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.UpdatePackagesInfoLabel(e);
        }

        private void InstallerClosed(object sender, FormClosedEventArgs e) => Application.Exit();

    }
}
