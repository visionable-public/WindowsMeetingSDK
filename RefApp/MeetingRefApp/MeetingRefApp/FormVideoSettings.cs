///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2020-2020 Visionable Limited, All Rights Reserved
// COMPANY CONFIDENTIAL
// This file may not be reproduced or transmitted without explicit permission
//
// Author:  Wendy Wasmuth
// $File: //iocommain/Meeting/Windows/MeetingRefApp/MeetingRefApp/FormVideoSettings.cs $
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
    // FormVideoSettings Class
    //----------------------------------------------------------------------------------------------------

    public partial class FormVideoSettings : Form
    {
        //----------------------------------------------------------------------------------------------------
        // Participant
        //----------------------------------------------------------------------------------------------------

        private Participant participant;

        //----------------------------------------------------------------------------------------------------
        // FormVideoSettings Constructor
        //----------------------------------------------------------------------------------------------------

        public FormVideoSettings()
        {
            InitializeComponent();

            // Load Device Settings
            LoadSettings();
        }

        //----------------------------------------------------------------------------------------------------
        // SetParticipant
        //----------------------------------------------------------------------------------------------------

        public void SetParticipant(Participant participant)
        {
            // Set participant
            this.participant = participant;

            // Set Dialog Title for Participant
            Text = "Configuration for " + participant.displayName + "(Local)";
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

                comboBox.Name = device;
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

                // Set Video Device Codec
                string Codec = Program.meetingState.GetVideoDeviceUsedCodec(device);

                comboBox.Text = Codec;

                flowLayoutPanelVideoDevices.Controls.Add(comboBox);

                // Add ComboBox Selected Index Changed Event Handler
                comboBox.SelectedIndexChanged += new EventHandler(comboBoxCodec_SelectionChanged);
            }
        }

        //----------------------------------------------------------------------------------------------------
        // comboBoxCodec_SelectionChanged
        //----------------------------------------------------------------------------------------------------

        private void comboBoxCodec_SelectionChanged(object sender, EventArgs e)
        {
            string Device = "";
            string Codec = "";

            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                Device = comboBox.Name;
                Codec = comboBox.Text;

                if (Codec == "Not Used")
                {
                    Meeting.Instance.DisableVideoCapture(Device);

                    Program.meetingState.RemoveVideoDeviceUsed(Device);
                }
                else
                {
                    if (!Program.meetingState.VideoDeviceUsedExists(Device))
                    {
                        Program.meetingState.AddVideoDeviceUsed(Device, Codec);
                    }
                    else
                    {
                        Program.meetingState.UpdateVideoDeviceUsedCodec(Device, Codec);
                    }

                    Meeting.Instance.DisableVideoCapture(Device);

                    Meeting.Instance.EnableVideoCapture(Device, Codec);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // buttonDone_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
