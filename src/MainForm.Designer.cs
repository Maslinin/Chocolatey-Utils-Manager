﻿namespace ChocolateyUtilsManager
{
    internal partial class MainForm
    {
        /// <summary>
        /// Mandatory constructor variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Frees all resources in use.
        /// </summary>
        /// <param name="disposing">true if the managed resource is to be deleted otherwise false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code automatically generated by the Windows Form Designer

        /// <summary>
        /// Required method for constructor support - do not change
        /// contents of this method using the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            InstallerSplitContainer = new System.Windows.Forms.SplitContainer();
            PackageSplitContainer = new System.Windows.Forms.SplitContainer();
            PackagesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            PackageCategoriesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            SelectAllCategoriesCheckBox = new System.Windows.Forms.CheckBox();
            SelectAllPackagesCheckBox = new System.Windows.Forms.CheckBox();
            OptionSelectionGroupBox = new System.Windows.Forms.GroupBox();
            StartButton = new System.Windows.Forms.Button();
            StopButton = new System.Windows.Forms.Button();
            UninstallRadioButton = new System.Windows.Forms.RadioButton();
            InstallRadioButton = new System.Windows.Forms.RadioButton();
            UpgradeRadioButton = new System.Windows.Forms.RadioButton();
            ChocoLogoPictureBox = new System.Windows.Forms.PictureBox();
            PackageInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)InstallerSplitContainer).BeginInit();
            InstallerSplitContainer.Panel1.SuspendLayout();
            InstallerSplitContainer.Panel2.SuspendLayout();
            InstallerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PackageSplitContainer).BeginInit();
            PackageSplitContainer.Panel1.SuspendLayout();
            PackageSplitContainer.Panel2.SuspendLayout();
            PackageSplitContainer.SuspendLayout();
            OptionSelectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ChocoLogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // InstallerSplitContainer
            // 
            InstallerSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            InstallerSplitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            InstallerSplitContainer.Location = new System.Drawing.Point(12, 12);
            InstallerSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            InstallerSplitContainer.Name = "InstallerSplitContainer";
            // 
            // InstallerSplitContainer.Panel1
            // 
            InstallerSplitContainer.Panel1.Controls.Add(PackageSplitContainer);
            InstallerSplitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // InstallerSplitContainer.Panel2
            // 
            InstallerSplitContainer.Panel2.Controls.Add(SelectAllCategoriesCheckBox);
            InstallerSplitContainer.Panel2.Controls.Add(SelectAllPackagesCheckBox);
            InstallerSplitContainer.Panel2.Controls.Add(OptionSelectionGroupBox);
            InstallerSplitContainer.Panel2.Controls.Add(ChocoLogoPictureBox);
            InstallerSplitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            InstallerSplitContainer.Size = new System.Drawing.Size(775, 425);
            InstallerSplitContainer.SplitterDistance = 587;
            InstallerSplitContainer.SplitterWidth = 5;
            InstallerSplitContainer.TabIndex = 1;
            // 
            // PackageSplitContainer
            // 
            PackageSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PackageSplitContainer.Location = new System.Drawing.Point(3, 3);
            PackageSplitContainer.Name = "PackageSplitContainer";
            // 
            // PackageSplitContainer.Panel1
            // 
            PackageSplitContainer.Panel1.Controls.Add(PackagesCheckedListBox);
            // 
            // PackageSplitContainer.Panel2
            // 
            PackageSplitContainer.Panel2.Controls.Add(PackageCategoriesCheckedListBox);
            PackageSplitContainer.Size = new System.Drawing.Size(578, 415);
            PackageSplitContainer.SplitterDistance = 313;
            PackageSplitContainer.TabIndex = 2;
            // 
            // PackagesCheckedListBox
            // 
            PackagesCheckedListBox.BackColor = System.Drawing.Color.Sienna;
            PackagesCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            PackagesCheckedListBox.CheckOnClick = true;
            PackagesCheckedListBox.FormattingEnabled = true;
            PackagesCheckedListBox.IntegralHeight = false;
            PackagesCheckedListBox.Location = new System.Drawing.Point(3, 7);
            PackagesCheckedListBox.Name = "PackagesCheckedListBox";
            PackagesCheckedListBox.Size = new System.Drawing.Size(300, 398);
            PackagesCheckedListBox.Sorted = true;
            PackagesCheckedListBox.TabIndex = 0;
            // 
            // PackageCategoriesCheckedListBox
            // 
            PackageCategoriesCheckedListBox.BackColor = System.Drawing.Color.Sienna;
            PackageCategoriesCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            PackageCategoriesCheckedListBox.CheckOnClick = true;
            PackageCategoriesCheckedListBox.FormattingEnabled = true;
            PackageCategoriesCheckedListBox.IntegralHeight = false;
            PackageCategoriesCheckedListBox.Location = new System.Drawing.Point(3, 7);
            PackageCategoriesCheckedListBox.Name = "PackageCategoriesCheckedListBox";
            PackageCategoriesCheckedListBox.Size = new System.Drawing.Size(253, 399);
            PackageCategoriesCheckedListBox.TabIndex = 1;
            // 
            // SelectAllCategoriesCheckBox
            // 
            SelectAllCategoriesCheckBox.AutoSize = true;
            SelectAllCategoriesCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SelectAllCategoriesCheckBox.Font = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SelectAllCategoriesCheckBox.Location = new System.Drawing.Point(4, 391);
            SelectAllCategoriesCheckBox.Name = "SelectAllCategoriesCheckBox";
            SelectAllCategoriesCheckBox.Size = new System.Drawing.Size(182, 27);
            SelectAllCategoriesCheckBox.TabIndex = 3;
            SelectAllCategoriesCheckBox.Text = "Select all categories";
            SelectAllCategoriesCheckBox.UseVisualStyleBackColor = true;
            SelectAllCategoriesCheckBox.CheckedChanged += SelectAllCategoriesCheckBox_CheckedChanged;
            // 
            // SelectAllPackagesCheckBox
            // 
            SelectAllPackagesCheckBox.AutoSize = true;
            SelectAllPackagesCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            SelectAllPackagesCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SelectAllPackagesCheckBox.Font = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SelectAllPackagesCheckBox.Location = new System.Drawing.Point(4, 368);
            SelectAllPackagesCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            SelectAllPackagesCheckBox.Name = "SelectAllPackagesCheckBox";
            SelectAllPackagesCheckBox.Size = new System.Drawing.Size(172, 27);
            SelectAllPackagesCheckBox.TabIndex = 0;
            SelectAllPackagesCheckBox.Text = "Select all packages";
            SelectAllPackagesCheckBox.UseVisualStyleBackColor = true;
            SelectAllPackagesCheckBox.CheckedChanged += SelectAllPackagesCheckBox_CheckedChanged;
            // 
            // OptionSelectionGroupBox
            // 
            OptionSelectionGroupBox.BackColor = System.Drawing.Color.PeachPuff;
            OptionSelectionGroupBox.Controls.Add(StartButton);
            OptionSelectionGroupBox.Controls.Add(StopButton);
            OptionSelectionGroupBox.Controls.Add(UninstallRadioButton);
            OptionSelectionGroupBox.Controls.Add(InstallRadioButton);
            OptionSelectionGroupBox.Controls.Add(UpgradeRadioButton);
            OptionSelectionGroupBox.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OptionSelectionGroupBox.Location = new System.Drawing.Point(4, 76);
            OptionSelectionGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OptionSelectionGroupBox.Name = "OptionSelectionGroupBox";
            OptionSelectionGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OptionSelectionGroupBox.Size = new System.Drawing.Size(173, 202);
            OptionSelectionGroupBox.TabIndex = 0;
            OptionSelectionGroupBox.TabStop = false;
            OptionSelectionGroupBox.Text = "Option";
            // 
            // StartButton
            // 
            StartButton.BackColor = System.Drawing.Color.Aquamarine;
            StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            StartButton.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StartButton.Location = new System.Drawing.Point(7, 110);
            StartButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            StartButton.Name = "StartButton";
            StartButton.Size = new System.Drawing.Size(158, 40);
            StartButton.TabIndex = 3;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.BackColor = System.Drawing.Color.Red;
            StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            StopButton.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StopButton.Location = new System.Drawing.Point(7, 156);
            StopButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            StopButton.Name = "StopButton";
            StopButton.Size = new System.Drawing.Size(158, 40);
            StopButton.TabIndex = 3;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = false;
            StopButton.Click += StopButton_Click;
            // 
            // UninstallRadioButton
            // 
            UninstallRadioButton.AutoSize = true;
            UninstallRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UninstallRadioButton.Font = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UninstallRadioButton.Location = new System.Drawing.Point(7, 77);
            UninstallRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            UninstallRadioButton.Name = "UninstallRadioButton";
            UninstallRadioButton.Size = new System.Drawing.Size(95, 27);
            UninstallRadioButton.TabIndex = 2;
            UninstallRadioButton.Text = "Uninstall";
            UninstallRadioButton.UseVisualStyleBackColor = true;
            // 
            // InstallRadioButton
            // 
            InstallRadioButton.AutoSize = true;
            InstallRadioButton.Checked = true;
            InstallRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            InstallRadioButton.Font = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            InstallRadioButton.Location = new System.Drawing.Point(7, 29);
            InstallRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            InstallRadioButton.Name = "InstallRadioButton";
            InstallRadioButton.Size = new System.Drawing.Size(75, 27);
            InstallRadioButton.TabIndex = 0;
            InstallRadioButton.TabStop = true;
            InstallRadioButton.Text = "Install";
            InstallRadioButton.UseVisualStyleBackColor = true;
            // 
            // UpgradeRadioButton
            // 
            UpgradeRadioButton.AutoSize = true;
            UpgradeRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UpgradeRadioButton.Font = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UpgradeRadioButton.Location = new System.Drawing.Point(7, 53);
            UpgradeRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            UpgradeRadioButton.Name = "UpgradeRadioButton";
            UpgradeRadioButton.Size = new System.Drawing.Size(90, 27);
            UpgradeRadioButton.TabIndex = 1;
            UpgradeRadioButton.Text = "Upgrade";
            UpgradeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ChocoLogoPictureBox
            // 
            ChocoLogoPictureBox.Image = (System.Drawing.Image)resources.GetObject("ChocoLogoPictureBox.Image");
            ChocoLogoPictureBox.Location = new System.Drawing.Point(4, 3);
            ChocoLogoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ChocoLogoPictureBox.Name = "ChocoLogoPictureBox";
            ChocoLogoPictureBox.Size = new System.Drawing.Size(175, 73);
            ChocoLogoPictureBox.TabIndex = 2;
            ChocoLogoPictureBox.TabStop = false;
            // 
            // PackageInfoLabel
            // 
            PackageInfoLabel.AutoSize = true;
            PackageInfoLabel.Font = new System.Drawing.Font("Trebuchet MS", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PackageInfoLabel.ForeColor = System.Drawing.Color.LightYellow;
            PackageInfoLabel.Location = new System.Drawing.Point(12, 440);
            PackageInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            PackageInfoLabel.Name = "PackageInfoLabel";
            PackageInfoLabel.Size = new System.Drawing.Size(186, 23);
            PackageInfoLabel.TabIndex = 2;
            PackageInfoLabel.Text = "No package(s) selected";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Sienna;
            ClientSize = new System.Drawing.Size(799, 464);
            Controls.Add(PackageInfoLabel);
            Controls.Add(InstallerSplitContainer);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Chocolatey Utils Manager";
            FormClosed += InstallerClose;
            Load += Installer_Load;
            Shown += Installer_Shown;
            InstallerSplitContainer.Panel1.ResumeLayout(false);
            InstallerSplitContainer.Panel2.ResumeLayout(false);
            InstallerSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InstallerSplitContainer).EndInit();
            InstallerSplitContainer.ResumeLayout(false);
            PackageSplitContainer.Panel1.ResumeLayout(false);
            PackageSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PackageSplitContainer).EndInit();
            PackageSplitContainer.ResumeLayout(false);
            OptionSelectionGroupBox.ResumeLayout(false);
            OptionSelectionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ChocoLogoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.RadioButton InstallRadioButton;
        internal System.Windows.Forms.RadioButton UninstallRadioButton;
        internal System.Windows.Forms.RadioButton UpgradeRadioButton;
        internal System.Windows.Forms.GroupBox OptionSelectionGroupBox;
        internal System.Windows.Forms.Button StartButton;
        internal System.Windows.Forms.CheckBox SelectAllPackagesCheckBox;
        internal System.Windows.Forms.PictureBox ChocoLogoPictureBox;
        internal System.Windows.Forms.Label PackageInfoLabel;
        internal System.Windows.Forms.Button StopButton;
        internal System.Windows.Forms.SplitContainer InstallerSplitContainer;
        private System.Windows.Forms.CheckedListBox PackagesCheckedListBox;
        private System.Windows.Forms.CheckedListBox PackageCategoriesCheckedListBox;
        private System.Windows.Forms.SplitContainer PackageSplitContainer;
        private System.Windows.Forms.CheckBox SelectAllCategoriesCheckBox;
    }
}
