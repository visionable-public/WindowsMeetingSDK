
namespace MeetingRefApp
{
    partial class FormVideoSettings
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
            this.labelSettings = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            this.labelVideoDevices = new System.Windows.Forms.Label();
            this.flowLayoutPanelVideoDevices = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVideoCodecs1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVideoCodecs2 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelVideoDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F);
            this.labelSettings.Location = new System.Drawing.Point(128, 15);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(229, 36);
            this.labelSettings.TabIndex = 0;
            this.labelSettings.Text = "Video Settings";
            this.labelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(20, 195);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(450, 25);
            this.buttonDone.TabIndex = 4;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // labelVideoDevices
            // 
            this.labelVideoDevices.AutoSize = true;
            this.labelVideoDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVideoDevices.Location = new System.Drawing.Point(20, 57);
            this.labelVideoDevices.Name = "labelVideoDevices";
            this.labelVideoDevices.Size = new System.Drawing.Size(93, 13);
            this.labelVideoDevices.TabIndex = 1;
            this.labelVideoDevices.Text = "Video Devices:";
            // 
            // flowLayoutPanelVideoDevices
            // 
            this.flowLayoutPanelVideoDevices.AutoScroll = true;
            this.flowLayoutPanelVideoDevices.Controls.Add(this.label1);
            this.flowLayoutPanelVideoDevices.Controls.Add(this.comboBoxVideoCodecs1);
            this.flowLayoutPanelVideoDevices.Controls.Add(this.label2);
            this.flowLayoutPanelVideoDevices.Controls.Add(this.comboBoxVideoCodecs2);
            this.flowLayoutPanelVideoDevices.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelVideoDevices.Location = new System.Drawing.Point(17, 73);
            this.flowLayoutPanelVideoDevices.Name = "flowLayoutPanelVideoDevices";
            this.flowLayoutPanelVideoDevices.Size = new System.Drawing.Size(450, 100);
            this.flowLayoutPanelVideoDevices.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "labelVideo1";
            // 
            // comboBoxVideoCodecs1
            // 
            this.comboBoxVideoCodecs1.DropDownWidth = 425;
            this.comboBoxVideoCodecs1.FormattingEnabled = true;
            this.comboBoxVideoCodecs1.Location = new System.Drawing.Point(3, 16);
            this.comboBoxVideoCodecs1.Name = "comboBoxVideoCodecs1";
            this.comboBoxVideoCodecs1.Size = new System.Drawing.Size(433, 21);
            this.comboBoxVideoCodecs1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "labelVideo2";
            // 
            // comboBoxVideoCodecs2
            // 
            this.comboBoxVideoCodecs2.DropDownWidth = 425;
            this.comboBoxVideoCodecs2.FormattingEnabled = true;
            this.comboBoxVideoCodecs2.Location = new System.Drawing.Point(3, 56);
            this.comboBoxVideoCodecs2.Name = "comboBoxVideoCodecs2";
            this.comboBoxVideoCodecs2.Size = new System.Drawing.Size(433, 21);
            this.comboBoxVideoCodecs2.TabIndex = 3;
            // 
            // FormVideoSettings
            // 
            this.AcceptButton = this.buttonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 236);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanelVideoDevices);
            this.Controls.Add(this.labelVideoDevices);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.labelSettings);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 275);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 275);
            this.Name = "FormVideoSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configuration for Participant (Local)";
            this.TopMost = true;
            this.flowLayoutPanelVideoDevices.ResumeLayout(false);
            this.flowLayoutPanelVideoDevices.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Label labelVideoDevices;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVideoDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVideoCodecs1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVideoCodecs2;
    }
}