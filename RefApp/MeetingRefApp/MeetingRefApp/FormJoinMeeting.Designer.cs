
namespace MeetingRefApp
{
    partial class FormJoinMeeting
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
            this.labelJoinAMeeting = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxMeetingUUID = new System.Windows.Forms.TextBox();
            this.textBoxParticipantName = new System.Windows.Forms.TextBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonJoinMeeting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelJoinAMeeting
            // 
            this.labelJoinAMeeting.AutoSize = true;
            this.labelJoinAMeeting.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F);
            this.labelJoinAMeeting.Location = new System.Drawing.Point(66, 15);
            this.labelJoinAMeeting.Name = "labelJoinAMeeting";
            this.labelJoinAMeeting.Size = new System.Drawing.Size(243, 36);
            this.labelJoinAMeeting.TabIndex = 0;
            this.labelJoinAMeeting.Text = "Join a Meeting";
            this.labelJoinAMeeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(37, 62);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(301, 20);
            this.textBoxServer.TabIndex = 1;
            this.textBoxServer.Text = "v2.visionable.com";
            // 
            // textBoxMeetingUUID
            // 
            this.textBoxMeetingUUID.Location = new System.Drawing.Point(37, 94);
            this.textBoxMeetingUUID.Name = "textBoxMeetingUUID";
            this.textBoxMeetingUUID.Size = new System.Drawing.Size(301, 20);
            this.textBoxMeetingUUID.TabIndex = 2;
            this.textBoxMeetingUUID.Text = "Meeting UUID";
            // 
            // textBoxParticipantName
            // 
            this.textBoxParticipantName.Location = new System.Drawing.Point(37, 126);
            this.textBoxParticipantName.Name = "textBoxParticipantName";
            this.textBoxParticipantName.Size = new System.Drawing.Size(301, 20);
            this.textBoxParticipantName.TabIndex = 3;
            this.textBoxParticipantName.Text = "Enter Your Name";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(36, 179);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(130, 25);
            this.buttonSettings.TabIndex = 0;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonJoinMeeting
            // 
            this.buttonJoinMeeting.Location = new System.Drawing.Point(207, 179);
            this.buttonJoinMeeting.Name = "buttonJoinMeeting";
            this.buttonJoinMeeting.Size = new System.Drawing.Size(130, 25);
            this.buttonJoinMeeting.TabIndex = 5;
            this.buttonJoinMeeting.Text = "Join Meeting";
            this.buttonJoinMeeting.UseVisualStyleBackColor = true;
            this.buttonJoinMeeting.Click += new System.EventHandler(this.buttonJoinMeeting_Click);
            // 
            // FormJoinMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 226);
            this.Controls.Add(this.buttonJoinMeeting);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.textBoxParticipantName);
            this.Controls.Add(this.textBoxMeetingUUID);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.labelJoinAMeeting);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 265);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 265);
            this.Name = "FormJoinMeeting";
            this.Text = "Meeting SDK Reference App";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelJoinAMeeting;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxMeetingUUID;
        private System.Windows.Forms.TextBox textBoxParticipantName;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonJoinMeeting;
    }
}