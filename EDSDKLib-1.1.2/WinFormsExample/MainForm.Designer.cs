namespace WinFormsExample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.SavePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SaveToGroupBox = new System.Windows.Forms.GroupBox();
            this.STBothRdButton = new System.Windows.Forms.RadioButton();
            this.STComputerRdButton = new System.Windows.Forms.RadioButton();
            this.STCameraRdButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RecordVideoButton = new System.Windows.Forms.Button();
            this.TakePhotoButton = new System.Windows.Forms.Button();
            this.BulbUpDo = new System.Windows.Forms.NumericUpDown();
            this.ISOCoBox = new System.Windows.Forms.ComboBox();
            this.TvCoBox = new System.Windows.Forms.ComboBox();
            this.AvCoBox = new System.Windows.Forms.ComboBox();
            this.LiveViewGroupBox = new System.Windows.Forms.GroupBox();
            this.FocusFar3Button = new System.Windows.Forms.Button();
            this.FocusFar2Button = new System.Windows.Forms.Button();
            this.FocusFar1Button = new System.Windows.Forms.Button();
            this.FocusNear1Button = new System.Windows.Forms.Button();
            this.FocusNear2Button = new System.Windows.Forms.Button();
            this.FocusNear3Button = new System.Windows.Forms.Button();
            this.LiveViewPicBox = new System.Windows.Forms.PictureBox();
            this.LiveViewButton = new System.Windows.Forms.Button();
            this.InitGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.SessionLabel = new System.Windows.Forms.Label();
            this.SessionButton = new System.Windows.Forms.Button();
            this.SaveFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SettingsGroupBox.SuspendLayout();
            this.SaveToGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BulbUpDo)).BeginInit();
            this.LiveViewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LiveViewPicBox)).BeginInit();
            this.InitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.MainProgressBar);
            this.SettingsGroupBox.Controls.Add(this.SavePathTextBox);
            this.SettingsGroupBox.Controls.Add(this.BrowseButton);
            this.SettingsGroupBox.Controls.Add(this.SaveToGroupBox);
            this.SettingsGroupBox.Controls.Add(this.label4);
            this.SettingsGroupBox.Controls.Add(this.label3);
            this.SettingsGroupBox.Controls.Add(this.label2);
            this.SettingsGroupBox.Controls.Add(this.label1);
            this.SettingsGroupBox.Controls.Add(this.RecordVideoButton);
            this.SettingsGroupBox.Controls.Add(this.TakePhotoButton);
            this.SettingsGroupBox.Controls.Add(this.BulbUpDo);
            this.SettingsGroupBox.Controls.Add(this.ISOCoBox);
            this.SettingsGroupBox.Controls.Add(this.TvCoBox);
            this.SettingsGroupBox.Controls.Add(this.AvCoBox);
            this.SettingsGroupBox.Enabled = false;
            this.SettingsGroupBox.Location = new System.Drawing.Point(153, 13);
            this.SettingsGroupBox.MinimumSize = new System.Drawing.Size(407, 158);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(407, 158);
            this.SettingsGroupBox.TabIndex = 14;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Settings";
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Location = new System.Drawing.Point(6, 100);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(130, 20);
            this.MainProgressBar.TabIndex = 8;
            // 
            // SavePathTextBox
            // 
            this.SavePathTextBox.Enabled = false;
            this.SavePathTextBox.Location = new System.Drawing.Point(6, 126);
            this.SavePathTextBox.Name = "SavePathTextBox";
            this.SavePathTextBox.Size = new System.Drawing.Size(282, 20);
            this.SavePathTextBox.TabIndex = 6;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Enabled = false;
            this.BrowseButton.Location = new System.Drawing.Point(294, 123);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(99, 23);
            this.BrowseButton.TabIndex = 5;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // SaveToGroupBox
            // 
            this.SaveToGroupBox.Controls.Add(this.STBothRdButton);
            this.SaveToGroupBox.Controls.Add(this.STComputerRdButton);
            this.SaveToGroupBox.Controls.Add(this.STCameraRdButton);
            this.SaveToGroupBox.Location = new System.Drawing.Point(297, 20);
            this.SaveToGroupBox.Name = "SaveToGroupBox";
            this.SaveToGroupBox.Size = new System.Drawing.Size(96, 100);
            this.SaveToGroupBox.TabIndex = 4;
            this.SaveToGroupBox.TabStop = false;
            this.SaveToGroupBox.Text = "Save To";
            // 
            // STBothRdButton
            // 
            this.STBothRdButton.AutoSize = true;
            this.STBothRdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STBothRdButton.Location = new System.Drawing.Point(6, 71);
            this.STBothRdButton.Name = "STBothRdButton";
            this.STBothRdButton.Size = new System.Drawing.Size(53, 20);
            this.STBothRdButton.TabIndex = 0;
            this.STBothRdButton.Text = "Both";
            this.STBothRdButton.UseVisualStyleBackColor = true;
            this.STBothRdButton.CheckedChanged += new System.EventHandler(this.SaveToRdButton_CheckedChanged);
            // 
            // STComputerRdButton
            // 
            this.STComputerRdButton.AutoSize = true;
            this.STComputerRdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STComputerRdButton.Location = new System.Drawing.Point(6, 45);
            this.STComputerRdButton.Name = "STComputerRdButton";
            this.STComputerRdButton.Size = new System.Drawing.Size(84, 20);
            this.STComputerRdButton.TabIndex = 0;
            this.STComputerRdButton.Text = "Computer";
            this.STComputerRdButton.UseVisualStyleBackColor = true;
            this.STComputerRdButton.CheckedChanged += new System.EventHandler(this.SaveToRdButton_CheckedChanged);
            // 
            // STCameraRdButton
            // 
            this.STCameraRdButton.AutoSize = true;
            this.STCameraRdButton.Checked = true;
            this.STCameraRdButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STCameraRdButton.Location = new System.Drawing.Point(6, 19);
            this.STCameraRdButton.Name = "STCameraRdButton";
            this.STCameraRdButton.Size = new System.Drawing.Size(74, 20);
            this.STCameraRdButton.TabIndex = 0;
            this.STCameraRdButton.TabStop = true;
            this.STCameraRdButton.Text = "Camera";
            this.STCameraRdButton.UseVisualStyleBackColor = true;
            this.STCameraRdButton.CheckedChanged += new System.EventHandler(this.SaveToRdButton_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bulb (s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "ISO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Av";
            // 
            // RecordVideoButton
            // 
            this.RecordVideoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordVideoButton.Location = new System.Drawing.Point(217, 72);
            this.RecordVideoButton.Name = "RecordVideoButton";
            this.RecordVideoButton.Size = new System.Drawing.Size(71, 48);
            this.RecordVideoButton.TabIndex = 2;
            this.RecordVideoButton.Text = "Record Video";
            this.RecordVideoButton.UseVisualStyleBackColor = true;
            this.RecordVideoButton.Click += new System.EventHandler(this.RecordVideoButton_Click);
            // 
            // TakePhotoButton
            // 
            this.TakePhotoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TakePhotoButton.Location = new System.Drawing.Point(142, 72);
            this.TakePhotoButton.Name = "TakePhotoButton";
            this.TakePhotoButton.Size = new System.Drawing.Size(71, 48);
            this.TakePhotoButton.TabIndex = 2;
            this.TakePhotoButton.Text = "Take Photo";
            this.TakePhotoButton.UseVisualStyleBackColor = true;
            this.TakePhotoButton.Click += new System.EventHandler(this.TakePhotoButton_Click);
            // 
            // BulbUpDo
            // 
            this.BulbUpDo.Location = new System.Drawing.Point(142, 46);
            this.BulbUpDo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BulbUpDo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BulbUpDo.Name = "BulbUpDo";
            this.BulbUpDo.Size = new System.Drawing.Size(94, 20);
            this.BulbUpDo.TabIndex = 1;
            this.BulbUpDo.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ISOCoBox
            // 
            this.ISOCoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ISOCoBox.FormattingEnabled = true;
            this.ISOCoBox.Location = new System.Drawing.Point(6, 73);
            this.ISOCoBox.Name = "ISOCoBox";
            this.ISOCoBox.Size = new System.Drawing.Size(94, 21);
            this.ISOCoBox.TabIndex = 0;
            this.ISOCoBox.SelectedIndexChanged += new System.EventHandler(this.ISOCoBox_SelectedIndexChanged);
            // 
            // TvCoBox
            // 
            this.TvCoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TvCoBox.FormattingEnabled = true;
            this.TvCoBox.Location = new System.Drawing.Point(6, 46);
            this.TvCoBox.Name = "TvCoBox";
            this.TvCoBox.Size = new System.Drawing.Size(94, 21);
            this.TvCoBox.TabIndex = 0;
            this.TvCoBox.SelectedIndexChanged += new System.EventHandler(this.TvCoBox_SelectedIndexChanged);
            // 
            // AvCoBox
            // 
            this.AvCoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AvCoBox.FormattingEnabled = true;
            this.AvCoBox.Location = new System.Drawing.Point(6, 19);
            this.AvCoBox.Name = "AvCoBox";
            this.AvCoBox.Size = new System.Drawing.Size(94, 21);
            this.AvCoBox.TabIndex = 0;
            this.AvCoBox.SelectedIndexChanged += new System.EventHandler(this.AvCoBox_SelectedIndexChanged);
            // 
            // LiveViewGroupBox
            // 
            this.LiveViewGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LiveViewGroupBox.Controls.Add(this.FocusFar3Button);
            this.LiveViewGroupBox.Controls.Add(this.FocusFar2Button);
            this.LiveViewGroupBox.Controls.Add(this.FocusFar1Button);
            this.LiveViewGroupBox.Controls.Add(this.FocusNear1Button);
            this.LiveViewGroupBox.Controls.Add(this.FocusNear2Button);
            this.LiveViewGroupBox.Controls.Add(this.FocusNear3Button);
            this.LiveViewGroupBox.Controls.Add(this.LiveViewPicBox);
            this.LiveViewGroupBox.Controls.Add(this.LiveViewButton);
            this.LiveViewGroupBox.Enabled = false;
            this.LiveViewGroupBox.Location = new System.Drawing.Point(12, 177);
            this.LiveViewGroupBox.Name = "LiveViewGroupBox";
            this.LiveViewGroupBox.Size = new System.Drawing.Size(548, 411);
            this.LiveViewGroupBox.TabIndex = 13;
            this.LiveViewGroupBox.TabStop = false;
            this.LiveViewGroupBox.Text = "LiveView";
            // 
            // FocusFar3Button
            // 
            this.FocusFar3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FocusFar3Button.Location = new System.Drawing.Point(345, 20);
            this.FocusFar3Button.Name = "FocusFar3Button";
            this.FocusFar3Button.Size = new System.Drawing.Size(28, 23);
            this.FocusFar3Button.TabIndex = 6;
            this.FocusFar3Button.Text = ">>>";
            this.FocusFar3Button.UseVisualStyleBackColor = true;
            this.FocusFar3Button.Click += new System.EventHandler(this.FocusFar3Button_Click);
            // 
            // FocusFar2Button
            // 
            this.FocusFar2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FocusFar2Button.Location = new System.Drawing.Point(311, 20);
            this.FocusFar2Button.Name = "FocusFar2Button";
            this.FocusFar2Button.Size = new System.Drawing.Size(28, 23);
            this.FocusFar2Button.TabIndex = 6;
            this.FocusFar2Button.Text = ">>";
            this.FocusFar2Button.UseVisualStyleBackColor = true;
            this.FocusFar2Button.Click += new System.EventHandler(this.FocusFar2Button_Click);
            // 
            // FocusFar1Button
            // 
            this.FocusFar1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FocusFar1Button.Location = new System.Drawing.Point(277, 20);
            this.FocusFar1Button.Name = "FocusFar1Button";
            this.FocusFar1Button.Size = new System.Drawing.Size(28, 23);
            this.FocusFar1Button.TabIndex = 6;
            this.FocusFar1Button.Text = ">";
            this.FocusFar1Button.UseVisualStyleBackColor = true;
            this.FocusFar1Button.Click += new System.EventHandler(this.FocusFar1Button_Click);
            // 
            // FocusNear1Button
            // 
            this.FocusNear1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FocusNear1Button.Location = new System.Drawing.Point(243, 20);
            this.FocusNear1Button.Name = "FocusNear1Button";
            this.FocusNear1Button.Size = new System.Drawing.Size(28, 23);
            this.FocusNear1Button.TabIndex = 6;
            this.FocusNear1Button.Text = "<";
            this.FocusNear1Button.UseVisualStyleBackColor = true;
            this.FocusNear1Button.Click += new System.EventHandler(this.FocusNear1Button_Click);
            // 
            // FocusNear2Button
            // 
            this.FocusNear2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FocusNear2Button.Location = new System.Drawing.Point(209, 20);
            this.FocusNear2Button.Name = "FocusNear2Button";
            this.FocusNear2Button.Size = new System.Drawing.Size(28, 23);
            this.FocusNear2Button.TabIndex = 6;
            this.FocusNear2Button.Text = "<<";
            this.FocusNear2Button.UseVisualStyleBackColor = true;
            this.FocusNear2Button.Click += new System.EventHandler(this.FocusNear2Button_Click);
            // 
            // FocusNear3Button
            // 
            this.FocusNear3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FocusNear3Button.Location = new System.Drawing.Point(175, 20);
            this.FocusNear3Button.Name = "FocusNear3Button";
            this.FocusNear3Button.Size = new System.Drawing.Size(28, 23);
            this.FocusNear3Button.TabIndex = 6;
            this.FocusNear3Button.Text = "<<<";
            this.FocusNear3Button.UseVisualStyleBackColor = true;
            this.FocusNear3Button.Click += new System.EventHandler(this.FocusNear3Button_Click);
            // 
            // LiveViewPicBox
            // 
            this.LiveViewPicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LiveViewPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LiveViewPicBox.Location = new System.Drawing.Point(10, 51);
            this.LiveViewPicBox.Name = "LiveViewPicBox";
            this.LiveViewPicBox.Size = new System.Drawing.Size(524, 349);
            this.LiveViewPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LiveViewPicBox.TabIndex = 1;
            this.LiveViewPicBox.TabStop = false;
            this.LiveViewPicBox.SizeChanged += new System.EventHandler(this.LiveViewPicBox_SizeChanged);
            // 
            // LiveViewButton
            // 
            this.LiveViewButton.Location = new System.Drawing.Point(8, 20);
            this.LiveViewButton.Name = "LiveViewButton";
            this.LiveViewButton.Size = new System.Drawing.Size(70, 22);
            this.LiveViewButton.TabIndex = 2;
            this.LiveViewButton.Text = "Start LV";
            this.LiveViewButton.UseVisualStyleBackColor = true;
            this.LiveViewButton.Click += new System.EventHandler(this.LiveViewButton_Click);
            // 
            // InitGroupBox
            // 
            this.InitGroupBox.Controls.Add(this.RefreshButton);
            this.InitGroupBox.Controls.Add(this.CameraListBox);
            this.InitGroupBox.Controls.Add(this.SessionLabel);
            this.InitGroupBox.Controls.Add(this.SessionButton);
            this.InitGroupBox.Location = new System.Drawing.Point(12, 13);
            this.InitGroupBox.Name = "InitGroupBox";
            this.InitGroupBox.Size = new System.Drawing.Size(135, 158);
            this.InitGroupBox.TabIndex = 12;
            this.InitGroupBox.TabStop = false;
            this.InitGroupBox.Text = "Init";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(96, 127);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(31, 23);
            this.RefreshButton.TabIndex = 9;
            this.RefreshButton.Text = "↻";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // CameraListBox
            // 
            this.CameraListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.Location = new System.Drawing.Point(8, 35);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(121, 82);
            this.CameraListBox.TabIndex = 6;
            // 
            // SessionLabel
            // 
            this.SessionLabel.AutoSize = true;
            this.SessionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SessionLabel.Location = new System.Drawing.Point(6, 16);
            this.SessionLabel.Name = "SessionLabel";
            this.SessionLabel.Size = new System.Drawing.Size(110, 16);
            this.SessionLabel.TabIndex = 8;
            this.SessionLabel.Text = "No open session";
            // 
            // SessionButton
            // 
            this.SessionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SessionButton.Location = new System.Drawing.Point(6, 127);
            this.SessionButton.Name = "SessionButton";
            this.SessionButton.Size = new System.Drawing.Size(84, 23);
            this.SessionButton.TabIndex = 7;
            this.SessionButton.Text = "Open Session";
            this.SessionButton.UseVisualStyleBackColor = true;
            this.SessionButton.Click += new System.EventHandler(this.SessionButton_Click);
            // 
            // SaveFolderBrowser
            // 
            this.SaveFolderBrowser.Description = "Save Images To...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 600);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.LiveViewGroupBox);
            this.Controls.Add(this.InitGroupBox);
            this.Name = "MainForm";
            this.Text = "Canon SDK Tutorial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.SaveToGroupBox.ResumeLayout(false);
            this.SaveToGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BulbUpDo)).EndInit();
            this.LiveViewGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LiveViewPicBox)).EndInit();
            this.InitGroupBox.ResumeLayout(false);
            this.InitGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.ProgressBar MainProgressBar;
        private System.Windows.Forms.TextBox SavePathTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.GroupBox SaveToGroupBox;
        private System.Windows.Forms.RadioButton STBothRdButton;
        private System.Windows.Forms.RadioButton STComputerRdButton;
        private System.Windows.Forms.RadioButton STCameraRdButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RecordVideoButton;
        private System.Windows.Forms.Button TakePhotoButton;
        private System.Windows.Forms.NumericUpDown BulbUpDo;
        private System.Windows.Forms.ComboBox ISOCoBox;
        private System.Windows.Forms.ComboBox TvCoBox;
        private System.Windows.Forms.ComboBox AvCoBox;
        private System.Windows.Forms.GroupBox LiveViewGroupBox;
        private System.Windows.Forms.Button FocusFar3Button;
        private System.Windows.Forms.Button FocusFar2Button;
        private System.Windows.Forms.Button FocusFar1Button;
        private System.Windows.Forms.Button FocusNear1Button;
        private System.Windows.Forms.Button FocusNear2Button;
        private System.Windows.Forms.Button FocusNear3Button;
        private System.Windows.Forms.PictureBox LiveViewPicBox;
        private System.Windows.Forms.Button LiveViewButton;
        private System.Windows.Forms.GroupBox InitGroupBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.Label SessionLabel;
        private System.Windows.Forms.Button SessionButton;
        private System.Windows.Forms.FolderBrowserDialog SaveFolderBrowser;
    }
}

