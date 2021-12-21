namespace CUM.ProgramInstaller
{
    internal partial class Installer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.ProgramsCheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.InstallerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ProgramsCheckedListBoxLabel8 = new System.Windows.Forms.Label();
            this.ProgramsCheckedListBox6 = new System.Windows.Forms.CheckedListBox();
            this.ProgramsCheckedListBoxLabel5 = new System.Windows.Forms.Label();
            this.ProgramsCheckedListBoxLabel7 = new System.Windows.Forms.Label();
            this.ProgramsCheckedListBoxLabel4 = new System.Windows.Forms.Label();
            this.ProgramsCheckedListBox8 = new System.Windows.Forms.CheckedListBox();
            this.ProgramsCheckedListBox5 = new System.Windows.Forms.CheckedListBox();
            this.ProgramsCheckedListBox7 = new System.Windows.Forms.CheckedListBox();
            this.ProgramsCheckedListBox4 = new System.Windows.Forms.CheckedListBox();
            this.ProgramsCheckedListBoxLabel6 = new System.Windows.Forms.Label();
            this.OtherProgramsListBox = new System.Windows.Forms.CheckedListBox();
            this.OtherProgramsLabel = new System.Windows.Forms.Label();
            this.ProgramsCheckedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.ProgramsCheckedListBoxLabel3 = new System.Windows.Forms.Label();
            this.ProgramsCheckedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.ProgramsCheckedListBoxLabel2 = new System.Windows.Forms.Label();
            this.ProgramsCheckedListBoxLabel1 = new System.Windows.Forms.Label();
            this.SelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.ModeSelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.DeleteRadioButton = new System.Windows.Forms.RadioButton();
            this.InstallRadioButton = new System.Windows.Forms.RadioButton();
            this.UpdateRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PackagesInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InstallerSplitContainer)).BeginInit();
            this.InstallerSplitContainer.Panel1.SuspendLayout();
            this.InstallerSplitContainer.Panel2.SuspendLayout();
            this.InstallerSplitContainer.SuspendLayout();
            this.ModeSelectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgramsCheckedListBox1
            // 
            this.ProgramsCheckedListBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox1.FormattingEnabled = true;
            this.ProgramsCheckedListBox1.Location = new System.Drawing.Point(7, 28);
            this.ProgramsCheckedListBox1.Name = "ProgramsCheckedListBox1";
            this.ProgramsCheckedListBox1.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox1.TabIndex = 0;
            // 
            // InstallerSplitContainer
            // 
            this.InstallerSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstallerSplitContainer.IsSplitterFixed = true;
            this.InstallerSplitContainer.Location = new System.Drawing.Point(12, 12);
            this.InstallerSplitContainer.Name = "InstallerSplitContainer";
            // 
            // InstallerSplitContainer.Panel1
            // 
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel8);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox6);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel5);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel7);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel4);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox8);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox5);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox7);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox4);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel6);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.OtherProgramsListBox);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.OtherProgramsLabel);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox3);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel3);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox2);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel2);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBoxLabel1);
            this.InstallerSplitContainer.Panel1.Controls.Add(this.ProgramsCheckedListBox1);
            // 
            // InstallerSplitContainer.Panel2
            // 
            this.InstallerSplitContainer.Panel2.Controls.Add(this.SelectAllCheckBox);
            this.InstallerSplitContainer.Panel2.Controls.Add(this.ModeSelectionGroupBox);
            this.InstallerSplitContainer.Panel2.Controls.Add(this.pictureBox1);
            this.InstallerSplitContainer.Size = new System.Drawing.Size(907, 419);
            this.InstallerSplitContainer.SplitterDistance = 719;
            this.InstallerSplitContainer.TabIndex = 1;
            // 
            // ProgramsCheckedListBoxLabel8
            // 
            this.ProgramsCheckedListBoxLabel8.AutoSize = true;
            this.ProgramsCheckedListBoxLabel8.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.ProgramsCheckedListBoxLabel8.Location = new System.Drawing.Point(479, 142);
            this.ProgramsCheckedListBoxLabel8.Name = "ProgramsCheckedListBoxLabel8";
            this.ProgramsCheckedListBoxLabel8.Size = new System.Drawing.Size(84, 22);
            this.ProgramsCheckedListBoxLabel8.TabIndex = 17;
            this.ProgramsCheckedListBoxLabel8.Text = "Graphical:";
            // 
            // ProgramsCheckedListBox6
            // 
            this.ProgramsCheckedListBox6.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox6.FormattingEnabled = true;
            this.ProgramsCheckedListBox6.Location = new System.Drawing.Point(246, 302);
            this.ProgramsCheckedListBox6.Name = "ProgramsCheckedListBox6";
            this.ProgramsCheckedListBox6.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox6.TabIndex = 9;
            // 
            // ProgramsCheckedListBoxLabel5
            // 
            this.ProgramsCheckedListBoxLabel5.AutoSize = true;
            this.ProgramsCheckedListBoxLabel5.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.ProgramsCheckedListBoxLabel5.Location = new System.Drawing.Point(242, 142);
            this.ProgramsCheckedListBoxLabel5.Name = "ProgramsCheckedListBoxLabel5";
            this.ProgramsCheckedListBoxLabel5.Size = new System.Drawing.Size(86, 22);
            this.ProgramsCheckedListBoxLabel5.TabIndex = 16;
            this.ProgramsCheckedListBoxLabel5.Text = "Databases:";
            // 
            // ProgramsCheckedListBoxLabel7
            // 
            this.ProgramsCheckedListBoxLabel7.AutoSize = true;
            this.ProgramsCheckedListBoxLabel7.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.ProgramsCheckedListBoxLabel7.Location = new System.Drawing.Point(479, 6);
            this.ProgramsCheckedListBoxLabel7.Name = "ProgramsCheckedListBoxLabel7";
            this.ProgramsCheckedListBoxLabel7.Size = new System.Drawing.Size(94, 22);
            this.ProgramsCheckedListBoxLabel7.TabIndex = 15;
            this.ProgramsCheckedListBoxLabel7.Text = "Messengers:";
            // 
            // ProgramsCheckedListBoxLabel4
            // 
            this.ProgramsCheckedListBoxLabel4.AutoSize = true;
            this.ProgramsCheckedListBoxLabel4.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.ProgramsCheckedListBoxLabel4.Location = new System.Drawing.Point(242, 6);
            this.ProgramsCheckedListBoxLabel4.Name = "ProgramsCheckedListBoxLabel4";
            this.ProgramsCheckedListBoxLabel4.Size = new System.Drawing.Size(108, 22);
            this.ProgramsCheckedListBoxLabel4.TabIndex = 14;
            this.ProgramsCheckedListBoxLabel4.Text = "Programming:";
            // 
            // ProgramsCheckedListBox8
            // 
            this.ProgramsCheckedListBox8.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox8.FormattingEnabled = true;
            this.ProgramsCheckedListBox8.Location = new System.Drawing.Point(483, 165);
            this.ProgramsCheckedListBox8.Name = "ProgramsCheckedListBox8";
            this.ProgramsCheckedListBox8.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox8.TabIndex = 13;
            // 
            // ProgramsCheckedListBox5
            // 
            this.ProgramsCheckedListBox5.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox5.FormattingEnabled = true;
            this.ProgramsCheckedListBox5.Location = new System.Drawing.Point(246, 165);
            this.ProgramsCheckedListBox5.Name = "ProgramsCheckedListBox5";
            this.ProgramsCheckedListBox5.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox5.TabIndex = 12;
            // 
            // ProgramsCheckedListBox7
            // 
            this.ProgramsCheckedListBox7.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox7.FormattingEnabled = true;
            this.ProgramsCheckedListBox7.Location = new System.Drawing.Point(483, 28);
            this.ProgramsCheckedListBox7.Name = "ProgramsCheckedListBox7";
            this.ProgramsCheckedListBox7.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox7.TabIndex = 11;
            // 
            // ProgramsCheckedListBox4
            // 
            this.ProgramsCheckedListBox4.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox4.FormattingEnabled = true;
            this.ProgramsCheckedListBox4.Location = new System.Drawing.Point(246, 28);
            this.ProgramsCheckedListBox4.Name = "ProgramsCheckedListBox4";
            this.ProgramsCheckedListBox4.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox4.TabIndex = 10;
            // 
            // ProgramsCheckedListBoxLabel6
            // 
            this.ProgramsCheckedListBoxLabel6.AutoSize = true;
            this.ProgramsCheckedListBoxLabel6.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.ProgramsCheckedListBoxLabel6.Location = new System.Drawing.Point(242, 277);
            this.ProgramsCheckedListBoxLabel6.Name = "ProgramsCheckedListBoxLabel6";
            this.ProgramsCheckedListBoxLabel6.Size = new System.Drawing.Size(93, 22);
            this.ProgramsCheckedListBoxLabel6.TabIndex = 8;
            this.ProgramsCheckedListBoxLabel6.Text = "Antiviruses:";
            // 
            // OtherProgramsListBox
            // 
            this.OtherProgramsListBox.BackColor = System.Drawing.Color.PeachPuff;
            this.OtherProgramsListBox.FormattingEnabled = true;
            this.OtherProgramsListBox.Location = new System.Drawing.Point(483, 302);
            this.OtherProgramsListBox.Name = "OtherProgramsListBox";
            this.OtherProgramsListBox.Size = new System.Drawing.Size(231, 109);
            this.OtherProgramsListBox.TabIndex = 7;
            // 
            // OtherProgramsLabel
            // 
            this.OtherProgramsLabel.AutoSize = true;
            this.OtherProgramsLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OtherProgramsLabel.Location = new System.Drawing.Point(479, 277);
            this.OtherProgramsLabel.Name = "OtherProgramsLabel";
            this.OtherProgramsLabel.Size = new System.Drawing.Size(63, 22);
            this.OtherProgramsLabel.TabIndex = 6;
            this.OtherProgramsLabel.Text = "Others:";
            // 
            // ProgramsCheckedListBox3
            // 
            this.ProgramsCheckedListBox3.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox3.FormattingEnabled = true;
            this.ProgramsCheckedListBox3.Location = new System.Drawing.Point(9, 302);
            this.ProgramsCheckedListBox3.Name = "ProgramsCheckedListBox3";
            this.ProgramsCheckedListBox3.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox3.TabIndex = 5;
            // 
            // ProgramsCheckedListBoxLabel3
            // 
            this.ProgramsCheckedListBoxLabel3.AutoSize = true;
            this.ProgramsCheckedListBoxLabel3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.ProgramsCheckedListBoxLabel3.Location = new System.Drawing.Point(5, 277);
            this.ProgramsCheckedListBoxLabel3.Name = "ProgramsCheckedListBoxLabel3";
            this.ProgramsCheckedListBoxLabel3.Size = new System.Drawing.Size(48, 22);
            this.ProgramsCheckedListBoxLabel3.TabIndex = 4;
            this.ProgramsCheckedListBoxLabel3.Text = ".NET:";
            // 
            // ProgramsCheckedListBox2
            // 
            this.ProgramsCheckedListBox2.BackColor = System.Drawing.Color.PeachPuff;
            this.ProgramsCheckedListBox2.FormattingEnabled = true;
            this.ProgramsCheckedListBox2.Location = new System.Drawing.Point(9, 165);
            this.ProgramsCheckedListBox2.Name = "ProgramsCheckedListBox2";
            this.ProgramsCheckedListBox2.Size = new System.Drawing.Size(231, 109);
            this.ProgramsCheckedListBox2.TabIndex = 3;
            // 
            // ProgramsCheckedListBoxLabel2
            // 
            this.ProgramsCheckedListBoxLabel2.AutoSize = true;
            this.ProgramsCheckedListBoxLabel2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProgramsCheckedListBoxLabel2.Location = new System.Drawing.Point(5, 142);
            this.ProgramsCheckedListBoxLabel2.Name = "ProgramsCheckedListBoxLabel2";
            this.ProgramsCheckedListBoxLabel2.Size = new System.Drawing.Size(151, 22);
            this.ProgramsCheckedListBoxLabel2.TabIndex = 2;
            this.ProgramsCheckedListBoxLabel2.Text = "Working With Files:";
            // 
            // ProgramsCheckedListBoxLabel1
            // 
            this.ProgramsCheckedListBoxLabel1.AutoSize = true;
            this.ProgramsCheckedListBoxLabel1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProgramsCheckedListBoxLabel1.Location = new System.Drawing.Point(3, 6);
            this.ProgramsCheckedListBoxLabel1.Name = "ProgramsCheckedListBoxLabel1";
            this.ProgramsCheckedListBoxLabel1.Size = new System.Drawing.Size(80, 22);
            this.ProgramsCheckedListBoxLabel1.TabIndex = 1;
            this.ProgramsCheckedListBoxLabel1.Text = "Browsers:";
            // 
            // SelectAllCheckBox
            // 
            this.SelectAllCheckBox.AutoSize = true;
            this.SelectAllCheckBox.Checked = true;
            this.SelectAllCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectAllCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectAllCheckBox.Font = new System.Drawing.Font("Trebuchet MS", 11F);
            this.SelectAllCheckBox.Location = new System.Drawing.Point(3, 390);
            this.SelectAllCheckBox.Name = "SelectAllCheckBox";
            this.SelectAllCheckBox.Size = new System.Drawing.Size(86, 24);
            this.SelectAllCheckBox.TabIndex = 0;
            this.SelectAllCheckBox.Text = "Select all";
            this.SelectAllCheckBox.UseVisualStyleBackColor = true;
            this.SelectAllCheckBox.CheckedChanged += new System.EventHandler(this.SelectAllCheckBox_CheckedChanged);
            // 
            // ModeSelectionGroupBox
            // 
            this.ModeSelectionGroupBox.BackColor = System.Drawing.Color.PeachPuff;
            this.ModeSelectionGroupBox.Controls.Add(this.StartButton);
            this.ModeSelectionGroupBox.Controls.Add(this.StopButton);
            this.ModeSelectionGroupBox.Controls.Add(this.DeleteRadioButton);
            this.ModeSelectionGroupBox.Controls.Add(this.InstallRadioButton);
            this.ModeSelectionGroupBox.Controls.Add(this.UpdateRadioButton);
            this.ModeSelectionGroupBox.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.ModeSelectionGroupBox.Location = new System.Drawing.Point(3, 71);
            this.ModeSelectionGroupBox.Name = "ModeSelectionGroupBox";
            this.ModeSelectionGroupBox.Size = new System.Drawing.Size(175, 186);
            this.ModeSelectionGroupBox.TabIndex = 0;
            this.ModeSelectionGroupBox.TabStop = false;
            this.ModeSelectionGroupBox.Text = "Mode:";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Aquamarine;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartButton.Location = new System.Drawing.Point(6, 103);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(163, 35);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Red;
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Location = new System.Drawing.Point(6, 144);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(163, 35);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // DeleteRadioButton
            // 
            this.DeleteRadioButton.AutoSize = true;
            this.DeleteRadioButton.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.DeleteRadioButton.Location = new System.Drawing.Point(6, 67);
            this.DeleteRadioButton.Name = "DeleteRadioButton";
            this.DeleteRadioButton.Size = new System.Drawing.Size(87, 26);
            this.DeleteRadioButton.TabIndex = 2;
            this.DeleteRadioButton.Text = "Uninstall";
            this.DeleteRadioButton.UseVisualStyleBackColor = true;
            // 
            // InstallRadioButton
            // 
            this.InstallRadioButton.AutoSize = true;
            this.InstallRadioButton.Checked = true;
            this.InstallRadioButton.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.InstallRadioButton.Location = new System.Drawing.Point(6, 25);
            this.InstallRadioButton.Name = "InstallRadioButton";
            this.InstallRadioButton.Size = new System.Drawing.Size(68, 26);
            this.InstallRadioButton.TabIndex = 0;
            this.InstallRadioButton.TabStop = true;
            this.InstallRadioButton.Text = "Install";
            this.InstallRadioButton.UseVisualStyleBackColor = true;
            // 
            // UpdateRadioButton
            // 
            this.UpdateRadioButton.AutoSize = true;
            this.UpdateRadioButton.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.UpdateRadioButton.Location = new System.Drawing.Point(6, 46);
            this.UpdateRadioButton.Name = "UpdateRadioButton";
            this.UpdateRadioButton.Size = new System.Drawing.Size(79, 26);
            this.UpdateRadioButton.TabIndex = 1;
            this.UpdateRadioButton.Text = "Update";
            this.UpdateRadioButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 62);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PackagesInfoLabel
            // 
            this.PackagesInfoLabel.AutoSize = true;
            this.PackagesInfoLabel.Font = new System.Drawing.Font("Trebuchet MS", 12.25F);
            this.PackagesInfoLabel.Location = new System.Drawing.Point(8, 434);
            this.PackagesInfoLabel.Name = "PackagesInfoLabel";
            this.PackagesInfoLabel.Size = new System.Drawing.Size(186, 23);
            this.PackagesInfoLabel.TabIndex = 2;
            this.PackagesInfoLabel.Text = "No package(s) selected";
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(931, 459);
            this.Controls.Add(this.PackagesInfoLabel);
            this.Controls.Add(this.InstallerSplitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Installer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chocolatey Utils Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InstallerClosed);
            this.Shown += new System.EventHandler(this.Installer_Shown);
            this.InstallerSplitContainer.Panel1.ResumeLayout(false);
            this.InstallerSplitContainer.Panel1.PerformLayout();
            this.InstallerSplitContainer.Panel2.ResumeLayout(false);
            this.InstallerSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstallerSplitContainer)).EndInit();
            this.InstallerSplitContainer.ResumeLayout(false);
            this.ModeSelectionGroupBox.ResumeLayout(false);
            this.ModeSelectionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox1;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel1;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel2;
        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox2;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel3;
        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox3;
        internal System.Windows.Forms.Label OtherProgramsLabel;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel6;
        internal System.Windows.Forms.CheckedListBox OtherProgramsListBox;
        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox6;
        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox4;
        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox8;
        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox5;
        internal System.Windows.Forms.CheckedListBox ProgramsCheckedListBox7;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel4;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel7;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel5;
        internal System.Windows.Forms.Label ProgramsCheckedListBoxLabel8;
        internal System.Windows.Forms.RadioButton InstallRadioButton;
        internal System.Windows.Forms.RadioButton DeleteRadioButton;
        internal System.Windows.Forms.RadioButton UpdateRadioButton;
        internal System.Windows.Forms.GroupBox ModeSelectionGroupBox;
        internal System.Windows.Forms.Button StartButton;
        internal System.Windows.Forms.CheckBox SelectAllCheckBox;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label PackagesInfoLabel;
        internal System.Windows.Forms.Button StopButton;
        internal System.Windows.Forms.SplitContainer InstallerSplitContainer;
    }
}
