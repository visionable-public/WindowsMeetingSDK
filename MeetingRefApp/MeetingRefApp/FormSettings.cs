///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2020-2020 Visionable Limited, All Rights Reserved
// COMPANY CONFIDENTIAL
// This file may not be reproduced or transmitted without explicit permission
//
// Author:  Wendy Wasmuth
// $File: //iocommain/Meeting/Windows/MeetingRefApp/MeetingRefApp/FormSettings.cs $
//
// Perforce RCS keywords (add with -t text+k to use these)
// $Author: wwasmuth $
// $DateTime: 2020/11/18 00:00:00 $
// $Revision: # $
// $Change: $
///////////////////////////////////////////////////////////////////////////////

using MeetingSDKHigh; // Meeting SDK (High Level)

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MeetingRefApp
{
    //----------------------------------------------------------------------------------------------------
    // FormSettings Class
    //----------------------------------------------------------------------------------------------------

    public partial class FormSettings : Form
    {
        //----------------------------------------------------------------------------------------------------
        // FormSettings Constructor
        //----------------------------------------------------------------------------------------------------

        public FormSettings()
        {
            InitializeComponent();

            // Load Device Settings
            LoadSettings();
        }

        //----------------------------------------------------------------------------------------------------
        // OnHandleCreated Override
        //----------------------------------------------------------------------------------------------------

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        //----------------------------------------------------------------------------------------------------
        // LoadSettings
        //----------------------------------------------------------------------------------------------------

        public void LoadSettings()
        {
            flowLayoutPanelVideoDevices.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelVideoDevices.WrapContents = false;
            flowLayoutPanelVideoDevices.AutoScroll = true;

            flowLayoutPanelVideoDevices.Controls.Clear();

            // Initialize Video Devices
            List<string> videoDevices = Meeting.Instance.GetVideoDevices();

            foreach (string device in videoDevices)
            {
                Label label = new Label();
                label.Name = "Device";
                label.Text = device;
                label.Width = flowLayoutPanelVideoDevices.Width - 30;

                flowLayoutPanelVideoDevices.Controls.Add(label);

                ComboBox comboBox = new ComboBox();
                ComboboxItem comboBoxItem = new ComboboxItem();

                comboBox.Name = "Codec";
                comboBox.Size = new Size(433, 21);
                comboBoxItem.Text = "Not Used";
                comboBoxItem.Value = 0;
                comboBox.Items.Add(comboBoxItem);

                int i = 1;

                // Set Video Input Codec Default
                List<string> Codecs = Meeting.Instance.GetSupportedVideoSendResolutions(device);

                foreach (string codec in Codecs)
                {
                    comboBoxItem = new ComboboxItem();
                    comboBoxItem.Text = codec;
                    comboBoxItem.Value = i;
                    comboBox.Items.Add(comboBoxItem);
                    i++;
                }

                comboBox.SelectedIndex = 0;

                flowLayoutPanelVideoDevices.Controls.Add(comboBox);
            }

            // Initialize Audio Inputs
            List<string> AudioInputDevices = Meeting.Instance.GetAudioInputDevices();

            foreach (string audioInputDevice in AudioInputDevices)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = audioInputDevice;
                item.Value = audioInputDevice;

                comboBoxAudioInputs.Items.Add(item);
            }

            int idx = comboBoxAudioInputs.FindString(Meeting.Instance.GetDefaultAudioInputDevice());
            comboBoxAudioInputs.SelectedIndex = idx;

            // Initialize Audio Outputs
            List<string> AudioOutputDevices = Meeting.Instance.GetAudioOutputDevices();

            foreach (string audioOutputDevice in AudioOutputDevices)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = audioOutputDevice;
                item.Value = audioOutputDevice;

                comboBoxAudioOutputs.Items.Add(item);
            }

            idx = comboBoxAudioOutputs.FindString(Meeting.Instance.GetDefaultAudioOutputDevice());
            comboBoxAudioOutputs.SelectedIndex = idx;
        }

        //----------------------------------------------------------------------------------------------------
        // buttonCancel_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //----------------------------------------------------------------------------------------------------
        // buttonSave_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Remove Video Devices and Codecs
            Program.meetingState.RemoveAllVideoDevicesUsed();

            // Get Device and Codec Control Arrays
            Control[] cDeviceArray = flowLayoutPanelVideoDevices.Controls.Find("Device", true);
            Control[] cCodecArray = flowLayoutPanelVideoDevices.Controls.Find("Codec", true);

            // Initialize Video Devices and Codecs
            for (int i=0; i<cCodecArray.Length; i++)
            {
                if (cCodecArray[i].Text != "Not Used")
                {
                    Program.meetingState.AddVideoDeviceUsed(cDeviceArray[i].Text, cCodecArray[i].Text);
                }
            }

            // Initialize Audio Inputs
            ComboboxItem item = comboBoxAudioInputs.SelectedItem as ComboboxItem;
            Program.meetingState.strAudioInputName = item.Text;

            // Initialize Audio Outputs
            item = comboBoxAudioOutputs.SelectedItem as ComboboxItem;
            Program.meetingState.strAudioOutputName = item.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
