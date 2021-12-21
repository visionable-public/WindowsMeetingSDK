///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2020-2020 Visionable Limited, All Rights Reserved
// COMPANY CONFIDENTIAL
// This file may not be reproduced or transmitted without explicit permission
//
// Author:  Wendy Wasmuth
// $File: //iocommain/Meeting/Windows/MeetingRefApp/MeetingRefApp/FormConfigurationRemote.cs $
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
using System.Windows.Forms;

namespace MeetingRefApp
{
    //----------------------------------------------------------------------------------------------------
    // FormConfigurationRemote Class
    //----------------------------------------------------------------------------------------------------

    public partial class FormConfigurationRemote : Form
    {
        //----------------------------------------------------------------------------------------------------
        // Participant
        //----------------------------------------------------------------------------------------------------

        private Participant participant;

        //----------------------------------------------------------------------------------------------------
        // FormConfigurationRemote Constructor
        //----------------------------------------------------------------------------------------------------

        public FormConfigurationRemote()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------
        // SetParticipant
        //----------------------------------------------------------------------------------------------------

        public void SetParticipant(Participant participant)
        {
            // Set participant
            this.participant = participant;

            // Set Dialog Title for Participant
            Text = "Configuration for " + participant.displayName;
            labelParticipantName.Text = participant.displayName;
        }

        //----------------------------------------------------------------------------------------------------
        // OnHandleCreated Override
        //----------------------------------------------------------------------------------------------------
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Setup Data Grid View
            SetupDataGridView();

            // Populate Data Grid View
            PopulateDataGridView();
        }

        //----------------------------------------------------------------------------------------------------
        // SetupDataGridView
        //----------------------------------------------------------------------------------------------------

        private void SetupDataGridView()
        {
            dataGridViewVideoDevices.ColumnCount = 3;
            dataGridViewVideoDevices.RowCount = 0;

            dataGridViewVideoDevices.Columns[0].Name = "VideoDevice";
            dataGridViewVideoDevices.Columns[1].Name = "Disable";
            dataGridViewVideoDevices.Columns[2].Name = "StreamID";

            dataGridViewVideoDevices.MultiSelect = false;
        }

        //----------------------------------------------------------------------------------------------------
        // PopulateDataGridView
        //----------------------------------------------------------------------------------------------------

        private void PopulateDataGridView()
        {
            if (IsHandleCreated)
            {
                // Clear Video Devices Grid
                dataGridViewVideoDevices.Invoke((MethodInvoker)delegate
                {
                    dataGridViewVideoDevices.Rows.Clear();
                });

                // Display Video Devices
                if (participant.videoInfoDic != null)
                {
                    foreach (KeyValuePair<string, VideoInfo> videoInfo in participant.videoInfoDic)
                    {
                        dataGridViewVideoDevices.Invoke((MethodInvoker)delegate
                        {
                            int rowIndex = dataGridViewVideoDevices.Rows.Add(videoInfo.Value.name);

                            if (videoInfo.Value.active == "true")
                            {
                                dataGridViewVideoDevices[1, rowIndex].Value = "Disable";
                            }
                            else
                            {
                                dataGridViewVideoDevices[1, rowIndex].Value = "Enable";
                            }

                            dataGridViewVideoDevices[2, rowIndex].Value = videoInfo.Value.streamId;
                        });
                    }
                }

                // Set Audio Stream Volume
                if (participant.audioInfo.streamId != null)
                {
                    trackBarVolume.Value = Program.meetingState.GetAudioStreamVolume(participant.audioInfo.streamId);
                }
                else
                {
                    trackBarVolume.Value = 50;
                }
            }
            else
            {
                return;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // dataGridViewVideoDevices_CellContentClick
        //----------------------------------------------------------------------------------------------------

        private void dataGridViewVideoDevices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            FormVideoView formVideoView = null;

            string streamID = dataGridViewVideoDevices[2, rowIndex].Value.ToString();

            if ((string)dataGridViewVideoDevices[1, rowIndex].Value == "Disable")
            {
                Program.meetingState.GetVideoViewWindow(streamID, out formVideoView);

                if (formVideoView != null)
                {
                    dataGridViewVideoDevices[1, rowIndex].Value = "Enable";

                    formVideoView.Invoke((MethodInvoker)delegate
                    {
                        formVideoView.Visible = false;
                    });

                    Meeting.Instance.DisableVideoStream(streamID);
                }
                else
                {
                    MessageBox.Show("The remote participant may have disabled/enabled their video while this Configuration was open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Program.meetingState.GetVideoViewWindow(streamID, out formVideoView);

                if (formVideoView != null)
                {
                    dataGridViewVideoDevices[1, rowIndex].Value = "Disable";

                    Meeting.Instance.EnableVideoStream(participant, streamID);
                }
                else
                {
                    MessageBox.Show("The remote participant may have disabled/enabled their video while Configuration was open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // trackBarVolume_Scroll
        //----------------------------------------------------------------------------------------------------

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            string strStreamID = participant.audioInfo.streamId;

            if (strStreamID != null)
            {
                Program.meetingState.SetAudioStreamVolume(strStreamID, GetTrackerValue());

                Meeting.Instance.SetAudioStreamVolume(strStreamID, GetTrackerValue());
            }
        }

        //----------------------------------------------------------------------------------------------------
        // GetTrackerValueCallback (Thread-Safe)
        //----------------------------------------------------------------------------------------------------

        delegate int GetTrackerValueCallback();

        private int GetTrackerValue()
        {
            if (trackBarVolume.InvokeRequired)
            {
                GetTrackerValueCallback cb = new GetTrackerValueCallback(GetTrackerValue);

                return (int)trackBarVolume.Invoke(cb);
            }
            else
            {
                return (int)trackBarVolume.Value;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // buttonDone_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
