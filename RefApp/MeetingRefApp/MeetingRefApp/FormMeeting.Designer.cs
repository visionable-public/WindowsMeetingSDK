
namespace MeetingRefApp
{
    partial class FormMeeting
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMuteMe = new System.Windows.Forms.Button();
            this.buttonExitMeeting = new System.Windows.Forms.Button();
            this.buttonVideoOff = new System.Windows.Forms.Button();
            this.labelMeetingName = new System.Windows.Forms.Label();
            this.dataGridViewParticipants = new System.Windows.Forms.DataGridView();
            this.ColumnParticipant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnConfig = new System.Windows.Forms.DataGridViewButtonColumn();
            this.userIdString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelOutputVolume = new System.Windows.Forms.Label();
            this.labelInputVolume = new System.Windows.Forms.Label();
            this.trackBarOutputVolume = new System.Windows.Forms.TrackBar();
            this.trackBarInputVolume = new System.Windows.Forms.TrackBar();
            this.buttonSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipants)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOutputVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInputVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMuteMe
            // 
            this.buttonMuteMe.Location = new System.Drawing.Point(9, 492);
            this.buttonMuteMe.Name = "buttonMuteMe";
            this.buttonMuteMe.Size = new System.Drawing.Size(101, 25);
            this.buttonMuteMe.TabIndex = 2;
            this.buttonMuteMe.Text = "Mute Me";
            this.buttonMuteMe.UseVisualStyleBackColor = true;
            this.buttonMuteMe.Click += new System.EventHandler(this.buttonMuteMe_Click);
            // 
            // buttonExitMeeting
            // 
            this.buttonExitMeeting.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExitMeeting.Location = new System.Drawing.Point(6, 578);
            this.buttonExitMeeting.Name = "buttonExitMeeting";
            this.buttonExitMeeting.Size = new System.Drawing.Size(355, 25);
            this.buttonExitMeeting.TabIndex = 3;
            this.buttonExitMeeting.Text = "Exit Meeting";
            this.buttonExitMeeting.UseVisualStyleBackColor = true;
            this.buttonExitMeeting.Click += new System.EventHandler(this.buttonExitMeeting_Click);
            // 
            // buttonVideoOff
            // 
            this.buttonVideoOff.Location = new System.Drawing.Point(134, 492);
            this.buttonVideoOff.Name = "buttonVideoOff";
            this.buttonVideoOff.Size = new System.Drawing.Size(101, 25);
            this.buttonVideoOff.TabIndex = 4;
            this.buttonVideoOff.Text = "Video Off";
            this.buttonVideoOff.UseVisualStyleBackColor = true;
            this.buttonVideoOff.Click += new System.EventHandler(this.buttonVideoOff_Click);
            // 
            // labelMeetingName
            // 
            this.labelMeetingName.AutoSize = true;
            this.labelMeetingName.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F);
            this.labelMeetingName.Location = new System.Drawing.Point(69, 15);
            this.labelMeetingName.Name = "labelMeetingName";
            this.labelMeetingName.Size = new System.Drawing.Size(234, 36);
            this.labelMeetingName.TabIndex = 0;
            this.labelMeetingName.Text = "Meeting Name";
            this.labelMeetingName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewParticipants
            // 
            this.dataGridViewParticipants.AllowUserToAddRows = false;
            this.dataGridViewParticipants.AllowUserToDeleteRows = false;
            this.dataGridViewParticipants.AllowUserToResizeColumns = false;
            this.dataGridViewParticipants.AllowUserToResizeRows = false;
            this.dataGridViewParticipants.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParticipants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnParticipant,
            this.ColumnConfig,
            this.userIdString});
            this.dataGridViewParticipants.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewParticipants.Location = new System.Drawing.Point(10, 55);
            this.dataGridViewParticipants.Name = "dataGridViewParticipants";
            this.dataGridViewParticipants.ReadOnly = true;
            this.dataGridViewParticipants.RowHeadersWidth = 5;
            this.dataGridViewParticipants.RowTemplate.Height = 25;
            this.dataGridViewParticipants.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewParticipants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewParticipants.Size = new System.Drawing.Size(350, 420);
            this.dataGridViewParticipants.TabIndex = 1;
            this.dataGridViewParticipants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewParticipants_CellContentClick);
            // 
            // ColumnParticipant
            // 
            this.ColumnParticipant.HeaderText = "Participant";
            this.ColumnParticipant.Name = "ColumnParticipant";
            this.ColumnParticipant.ReadOnly = true;
            this.ColumnParticipant.Width = 250;
            // 
            // ColumnConfig
            // 
            this.ColumnConfig.HeaderText = "Config";
            this.ColumnConfig.Name = "ColumnConfig";
            this.ColumnConfig.ReadOnly = true;
            this.ColumnConfig.Text = "Config";
            this.ColumnConfig.UseColumnTextForButtonValue = true;
            // 
            // userIdString
            // 
            this.userIdString.HeaderText = "UserIdString";
            this.userIdString.Name = "userIdString";
            this.userIdString.ReadOnly = true;
            this.userIdString.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelOutputVolume);
            this.panel1.Controls.Add(this.labelInputVolume);
            this.panel1.Controls.Add(this.buttonExitMeeting);
            this.panel1.Controls.Add(this.dataGridViewParticipants);
            this.panel1.Controls.Add(this.trackBarOutputVolume);
            this.panel1.Controls.Add(this.trackBarInputVolume);
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Controls.Add(this.buttonVideoOff);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 612);
            this.panel1.TabIndex = 6;
            // 
            // labelOutputVolume
            // 
            this.labelOutputVolume.AutoSize = true;
            this.labelOutputVolume.Location = new System.Drawing.Point(322, 532);
            this.labelOutputVolume.Name = "labelOutputVolume";
            this.labelOutputVolume.Size = new System.Drawing.Size(39, 13);
            this.labelOutputVolume.TabIndex = 8;
            this.labelOutputVolume.Text = "Output";
            // 
            // labelInputVolume
            // 
            this.labelInputVolume.AutoSize = true;
            this.labelInputVolume.Location = new System.Drawing.Point(9, 532);
            this.labelInputVolume.Name = "labelInputVolume";
            this.labelInputVolume.Size = new System.Drawing.Size(31, 13);
            this.labelInputVolume.TabIndex = 7;
            this.labelInputVolume.Text = "Input";
            // 
            // trackBarOutputVolume
            // 
            this.trackBarOutputVolume.Location = new System.Drawing.Point(180, 529);
            this.trackBarOutputVolume.Maximum = 100;
            this.trackBarOutputVolume.Name = "trackBarOutputVolume";
            this.trackBarOutputVolume.Size = new System.Drawing.Size(140, 45);
            this.trackBarOutputVolume.TabIndex = 6;
            this.trackBarOutputVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarOutputVolume.Value = 50;
            this.trackBarOutputVolume.Scroll += new System.EventHandler(this.trackBarOutputVolume_Scroll);
            // 
            // trackBarInputVolume
            // 
            this.trackBarInputVolume.Location = new System.Drawing.Point(40, 529);
            this.trackBarInputVolume.Maximum = 100;
            this.trackBarInputVolume.Name = "trackBarInputVolume";
            this.trackBarInputVolume.Size = new System.Drawing.Size(140, 45);
            this.trackBarInputVolume.TabIndex = 5;
            this.trackBarInputVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarInputVolume.Value = 50;
            this.trackBarInputVolume.Scroll += new System.EventHandler(this.trackBarInputVolume_Scroll);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(260, 492);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(101, 25);
            this.buttonSettings.TabIndex = 0;
            this.buttonSettings.Text = "Video Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonVideoSettings_Click);
            // 
            // FormMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonExitMeeting;
            this.ClientSize = new System.Drawing.Size(372, 611);
            this.ControlBox = false;
            this.Controls.Add(this.labelMeetingName);
            this.Controls.Add(this.buttonMuteMe);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(388, 650);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(388, 650);
            this.Name = "FormMeeting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Meeting";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipants)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOutputVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarInputVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMuteMe;
        private System.Windows.Forms.Button buttonExitMeeting;
        private System.Windows.Forms.Button buttonVideoOff;
        private System.Windows.Forms.Label labelMeetingName;
        private System.Windows.Forms.DataGridView dataGridViewParticipants;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParticipant;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdString;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelOutputVolume;
        private System.Windows.Forms.Label labelInputVolume;
        private System.Windows.Forms.TrackBar trackBarOutputVolume;
        private System.Windows.Forms.TrackBar trackBarInputVolume;
    }
}

