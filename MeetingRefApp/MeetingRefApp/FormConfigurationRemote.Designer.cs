
namespace MeetingRefApp
{
    partial class FormConfigurationRemote
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
            this.buttonDone = new System.Windows.Forms.Button();
            this.labelParticipantName = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.dataGridViewVideoDevices = new System.Windows.Forms.DataGridView();
            this.ColumnParticipant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisableEnable = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StreamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVideoDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(14, 230);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(425, 25);
            this.buttonDone.TabIndex = 3;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // labelParticipantName
            // 
            this.labelParticipantName.AutoSize = true;
            this.labelParticipantName.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F);
            this.labelParticipantName.Location = new System.Drawing.Point(82, 15);
            this.labelParticipantName.Name = "labelParticipantName";
            this.labelParticipantName.Size = new System.Drawing.Size(290, 36);
            this.labelParticipantName.TabIndex = 0;
            this.labelParticipantName.Text = "Participant Name";
            this.labelParticipantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(16, 194);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(425, 45);
            this.trackBarVolume.TabIndex = 2;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // dataGridViewVideoDevices
            // 
            this.dataGridViewVideoDevices.AllowUserToAddRows = false;
            this.dataGridViewVideoDevices.AllowUserToDeleteRows = false;
            this.dataGridViewVideoDevices.AllowUserToResizeColumns = false;
            this.dataGridViewVideoDevices.AllowUserToResizeRows = false;
            this.dataGridViewVideoDevices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewVideoDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVideoDevices.ColumnHeadersVisible = false;
            this.dataGridViewVideoDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnParticipant,
            this.DisableEnable,
            this.StreamID});
            this.dataGridViewVideoDevices.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewVideoDevices.Location = new System.Drawing.Point(12, 55);
            this.dataGridViewVideoDevices.Name = "dataGridViewVideoDevices";
            this.dataGridViewVideoDevices.ReadOnly = true;
            this.dataGridViewVideoDevices.RowHeadersWidth = 5;
            this.dataGridViewVideoDevices.RowTemplate.Height = 25;
            this.dataGridViewVideoDevices.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewVideoDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewVideoDevices.Size = new System.Drawing.Size(430, 135);
            this.dataGridViewVideoDevices.TabIndex = 1;
            this.dataGridViewVideoDevices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVideoDevices_CellContentClick);
            // 
            // ColumnParticipant
            // 
            this.ColumnParticipant.HeaderText = "VideoDevice";
            this.ColumnParticipant.Name = "ColumnParticipant";
            this.ColumnParticipant.ReadOnly = true;
            this.ColumnParticipant.Width = 325;
            // 
            // DisableEnable
            // 
            this.DisableEnable.HeaderText = "DisableEnable";
            this.DisableEnable.Name = "DisableEnable";
            this.DisableEnable.ReadOnly = true;
            this.DisableEnable.Text = "Disable";
            // 
            // StreamID
            // 
            this.StreamID.HeaderText = "StreamID";
            this.StreamID.Name = "StreamID";
            this.StreamID.ReadOnly = true;
            this.StreamID.Visible = false;
            // 
            // FormConfigurationRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 276);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewVideoDevices);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.labelParticipantName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 315);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 315);
            this.Name = "FormConfigurationRemote";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configuration for Participant (Remote)";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVideoDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.DataGridView dataGridViewVideoDevices;
        public System.Windows.Forms.Label labelParticipantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParticipant;
        private System.Windows.Forms.DataGridViewButtonColumn DisableEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreamID;
    }
}