using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUM.ProgramInstaller.Models;

namespace CUM.ProgramInstaller
{
    internal partial class Installer : Form
    {
        internal List<CheckedListBox> ProgramsListBoxCollection { get; private set; }
        internal List<ProgramList> Programs { get; private set; }
        internal Chocolatey.ChocoInstaller Choco { get; private set; }

        public Installer()
        {
            InitializeComponent();
            Choco = new Chocolatey.ChocoInstaller();
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

        private async void Installer_Shown(object sender, EventArgs e)
        {
            if (!Choco.ChocoChild.ChocoExists)
            {
                PackagesInfoLabel.Text = "Chocolate isn't found on your computer. Installing it...";
                await Choco.ChocoInstallAsync();
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

        private void StartButton_Click(object sender, EventArgs e)
        {
            int packagesCount = ProgramsListBoxCollection.Select(l => l.CheckedItems.Count != 0).ToList().Where(p => p != false).Count();
            //If no packages are selected:
            if (packagesCount == 0)
            {
                MessageBox.Show("No package selected for installation",
                    "No packages selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.LockForm();

            try
            {
                int i = 0;
                if (InstallButton.Checked)
                {
                    PackagesInfoLabel.Text = $"0 out of {packagesCount} packages installed";
                    foreach (var listBox in ProgramsListBoxCollection)
                        foreach (ProgramInfo program in listBox.CheckedItems)
                        {
                            Task.Run(async() => await Choco.InstallPackageAsync(program.ChocolateyInstallName));
                            PackagesInfoLabel.Text = $"{++i} out of {packagesCount} packages installed";
                        }
                }
                else if (UpdateButton.Checked)
                {
                    PackagesInfoLabel.Text = $"0 out of {packagesCount} packages updated";
                    foreach (var listBox in ProgramsListBoxCollection)
                        foreach (ProgramInfo program in listBox.CheckedItems)
                        {
                            Task.Run(async () => await Choco.UpdatePackageAsync(program.ChocolateyInstallName));
                            PackagesInfoLabel.Text = $"{++i} out of {packagesCount} packages updated";
                        }
                }
                else
                {
                    PackagesInfoLabel.Text = $"0 out of {packagesCount} packages deleted";
                    foreach (var listBox in ProgramsListBoxCollection)
                        foreach (ProgramInfo program in listBox.CheckedItems)
                        {
                            Task.Run(async () => await Choco.UpdatePackageAsync(program.ChocolateyInstallName));
                            PackagesInfoLabel.Text = $"{++i} out of {packagesCount} packages deleted";
                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    ex.GetType().Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            this.UnLockForm();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.UnLockForm();
        }

        private void InstallerClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}
