
namespace MeetingRefApp
{
    partial class FormSettings
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelVideoDevices = new System.Windows.Forms.Label();
            this.labelAudioDevices = new System.Windows.Forms.Label();
            this.flowLayoutPanelVideoDevices = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVideoCodecs1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVideoCodecs2 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelAudioDevices = new System.Windows.Forms.FlowLayoutPanel();
            this.labelInput = new System.Windows.Forms.Label();
            this.comboBoxAudioInputs = new System.Windows.Forms.ComboBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.comboBoxAudioOutputs = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelVideoDevices.SuspendLayout();
            this.flowLayoutPanelAudioDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F);
            this.labelSettings.Location = new System.Drawing.Point(175, 15);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(135, 36);
            this.labelSettings.TabIndex = 0;
            this.labelSettings.Text = "Settings";
            this.labelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(263, 326);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(130, 25);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(92, 326);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 25);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
            // labelAudioDevices
            // 
            this.labelAudioDevices.AutoSize = true;
            this.labelAudioDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAudioDevices.Location = new System.Drawing.Point(20, 187);
            this.labelAudioDevices.Name = "labelAudioDevices";
            this.labelAudioDevices.Size = new System.Drawing.Size(93, 13);
            this.labelAudioDevices.TabIndex = 5;
            this.labelAudioDevices.Text = "Audio Devices:";
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
            this.flowLayoutPanelVideoDevices.TabIndex = 2;
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
            this.comboBoxVideoCodecs1.TabIndex = 3;
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
            this.comboBoxVideoCodecs2.TabIndex = 4;
            // 
            // flowLayoutPanelAudioDevices
            // 
            this.flowLayoutPanelAudioDevices.AutoScroll = true;
            this.flowLayoutPanelAudioDevices.Controls.Add(this.labelInput);
            this.flowLayoutPanelAudioDevices.Controls.Add(this.comboBoxAudioInputs);
            this.flowLayoutPanelAudioDevices.Controls.Add(this.labelOutput);
            this.flowLayoutPanelAudioDevices.Controls.Add(this.comboBoxAudioOutputs);
            this.flowLayoutPanelAudioDevices.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAudioDevices.Location = new System.Drawing.Point(17, 203);
            this.flowLayoutPanelAudioDevices.Name = "flowLayoutPanelAudioDevices";
            this.flowLayoutPanelAudioDevices.Size = new System.Drawing.Size(450, 100);
            this.flowLayoutPanelAudioDevices.TabIndex = 6;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(3, 0);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(34, 13);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "Input:";
            // 
            // comboBoxAudioInputs
            // 
            this.comboBoxAudioInputs.DropDownWidth = 425;
            this.comboBoxAudioInputs.FormattingEnabled = true;
            this.comboBoxAudioInputs.Location = new System.Drawing.Point(3, 16);
            this.comboBoxAudioInputs.Name = "comboBoxAudioInputs";
            this.comboBoxAudioInputs.Size = new System.Drawing.Size(433, 21);
            this.comboBoxAudioInputs.TabIndex = 7;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(3, 40);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(42, 13);
            this.labelOutput.TabIndex = 2;
            this.labelOutput.Text = "Output:";
            // 
            // comboBoxAudioOutputs
            // 
            this.comboBoxAudioOutputs.DropDownWidth = 425;
            this.comboBoxAudioOutputs.FormattingEnabled = true;
            this.comboBoxAudioOutputs.Location = new System.Drawing.Point(3, 56);
            this.comboBoxAudioOutputs.Name = "comboBoxAudioOutputs";
            this.comboBoxAudioOutputs.Size = new System.Drawing.Size(433, 21);
            this.comboBoxAudioOutputs.TabIndex = 8;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanelAudioDevices);
            this.Controls.Add(this.flowLayoutPanelVideoDevices);
            this.Controls.Add(this.labelAudioDevices);
            this.Controls.Add(this.labelVideoDevices);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelSettings);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Meeting SDK Reference App";
            this.TopMost = true;
            this.flowLayoutPanelVideoDevices.ResumeLayout(false);
            this.flowLayoutPanelVideoDevices.PerformLayout();
            this.flowLayoutPanelAudioDevices.ResumeLayout(false);
            this.flowLayoutPanelAudioDevices.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelVideoDevices;
        private System.Windows.Forms.Label labelAudioDevices;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVideoDevices;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAudioDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVideoCodecs1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVideoCodecs2;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.ComboBox comboBoxAudioInputs;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.ComboBox comboBoxAudioOutputs;
    }
}