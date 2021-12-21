///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2020-2020 Visionable Limited, All Rights Reserved
// COMPANY CONFIDENTIAL
// This file may not be reproduced or transmitted without explicit permission
//
// Author:  Wendy Wasmuth
// $File: //iocommain/Meeting/Windows/MeetingRefApp/MeetingRefApp/FormMeeting.cs $
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
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MeetingRefApp
{
    //----------------------------------------------------------------------------------------------------
    // FormMeeting Class
    //----------------------------------------------------------------------------------------------------

    public partial class FormMeeting : Form
    {
        //----------------------------------------------------------------------------------------------------
        // Form Meeting Constructor
        //----------------------------------------------------------------------------------------------------

        public FormMeeting()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------
        // OnHandleCreated Override
        //----------------------------------------------------------------------------------------------------
        
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Setup Data Grid View
            SetupDataGridView();

            // Join Meeting
            if (Join())
            {
                // Set Video Off/On Button
                if (Program.meetingState.GetVideoDevicesUsedCount() == 0)
                {
                    buttonVideoOff.Text = "Video On";
                    buttonVideoOff.Enabled = false;
                }
                else
                {
                    buttonVideoOff.Text = "Video Off";
                    buttonVideoOff.Enabled = true;
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // SetupDataGridView
        //----------------------------------------------------------------------------------------------------

        private void SetupDataGridView()
        {
            dataGridViewParticipants.ColumnCount = 3;
            dataGridViewParticipants.RowCount = 0;

            dataGridViewParticipants.Columns[0].Name = "Participant";
            dataGridViewParticipants.Columns[1].Name = "Config";
            dataGridViewParticipants.Columns[2].Name = "userIdString";

            dataGridViewParticipants.MultiSelect = false;
        }

        //----------------------------------------------------------------------------------------------------
        // PopulateDataGridView
        //----------------------------------------------------------------------------------------------------

        private void PopulateDataGridView()
        {
            Program.participants = Meeting.Instance.participants;

            if (IsHandleCreated)
            {
                dataGridViewParticipants.Invoke((MethodInvoker)delegate
                {
                    dataGridViewParticipants.Rows.Clear();
                });

                foreach (var rparticipant in Program.participants)
                {
                    if (rparticipant.Value.isLocal == false)
                    {
                        dataGridViewParticipants.Invoke((MethodInvoker)delegate
                        {
                            int rowIndex = dataGridViewParticipants.Rows.Add(rparticipant.Value.displayName);
                            dataGridViewParticipants[2, rowIndex].Value = rparticipant.Value.userIdString;
                        });
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // Join
        //----------------------------------------------------------------------------------------------------

        private bool Join()
        {
            // Set High Level SDK Callbacks
            Meeting.ParticipantAdded(ParticipantAdded);
            Meeting.ParticipantVideoAdded(ParticipantVideoAdded);
            Meeting.ParticipantVideoUpdated(ParticipantVideoUpdated);
            Meeting.ParticipantVideoRemoteLayoutChanged(ParticipantVideoRemoteLayoutChanged);
            Meeting.ParticipantVideoViewCreated(ParticipantVideoViewCreated);
            Meeting.ParticipantVideoViewRetrieved(ParticipantVideoViewRetrieved);
            Meeting.ParticipantVideoRemoved(ParticipantVideoRemoved);
            Meeting.ParticipantRemoved(ParticipantRemoved);
            Meeting.InputMeterChanged(InputMeterChanged);
            Meeting.OutputMeterChanged(OutMeterChanged);
            Meeting.Amplitude(Amplitude);
            Meeting.ParticipantVideoStreamSizeChanged(ParticipantVideoStreamSizeChanged);

            // Initialize Meeting
            bool ret = Meeting.Instance.InitializeMeeting(Program.MeetingID, Program.MeetingServer, Meeting.Instance.OnInitDone);

            if (ret)
            {
                // Join Meeting, Enable Audio, and Enable Video Capture
                ret = Meeting.Instance.JoinMeeting(Program.ParticipantName);

                if (ret)
                {
                    // Enable Audio Output
                    ret = Meeting.Instance.EnableAudioOutput(Program.meetingState.strAudioOutputName);

                    if (!ret)
                    {
                        // Get Last Error
                        string lastError = Meeting.Instance.GetLastError();

                        MessageBox.Show("Enable Audio Output Failed." + "\n" + lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Enable Audio Input
                    ret = Meeting.Instance.EnableAudioInput(Program.meetingState.strAudioInputName);

                    if (!ret)
                    {
                        // Get Last Error
                        string lastError = Meeting.Instance.GetLastError();

                        MessageBox.Show("Enable Audio Input Failed." + "\n" + lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    foreach (VideoDevicesUsed videoDeviceUsed in Program.meetingState.VideoDevicesUsed)
                    {
                        // Enable Video Capture
                        ret = Meeting.Instance.EnableVideoCapture(videoDeviceUsed.DeviceName, videoDeviceUsed.Codec);

                        if (!ret)
                        {
                            // Get Last Error
                            string lastError = Meeting.Instance.GetLastError();

                            MessageBox.Show("Enable Video Capture Failed." + "\n" + lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        }
                    }
                }
                else
                {
                    // Get Last Error
                    string lastError = Meeting.Instance.GetLastError();

                    MessageBox.Show("Join Meeting Failed." + "\n" + lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Meeting.Instance.ExitMeeting();

                    // Exit Application Program
                    Application.Exit();

                    return false;
                }
            }
            else
            {
                // Get Last Error
                string lastError = Meeting.Instance.GetLastError();

                MessageBox.Show("Initialize Meeting Failed." + "\n" + lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Meeting.Instance.ExitMeeting();

                // Exit Application Program
                Application.Exit();

                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------------------------------------
        // ParticipantAdded
        // Called when a participant gets added to the meeting
        // - Parameter participant: Current information of the corresponding participant
        //----------------------------------------------------------------------------------------------------

        public void ParticipantAdded(Participant participant)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantAdded - " + participant.displayName + " " + participant.userIdString);

            // Make sure we have an Audio Stream
            if (participant.audioInfo.streamId != null)
            {
                // Add Audio Stream and Volume to Meeting State
                Program.meetingState.AddAudioStreamVolume(participant.audioInfo.streamId, 50);
            }

            // Repopulate Meeting Participants
            PopulateDataGridView();
        }

        //----------------------------------------------------------------------------------------------------
        // ParticipantVideoAdded
        // Called when a participant gets added with a video stream, on the video_site_changed callback
        // - Parameters:
        //   - participant: Current information of the corresponding participant
        //   - streamId: Unique stream id
        //----------------------------------------------------------------------------------------------------

        public void ParticipantVideoAdded(Participant participant, string streamID)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantVideoAdded - " + participant.displayName + " " + participant.userIdString + " " + "StreamID = " + streamID);

            // Enable Participant Video Stream
            Meeting.Instance.EnableVideoStream(participant, streamID);
        }

        //----------------------------------------------------------------------------------------------------
        // ParticipantVideoUpdated
        // Called when a participant video stream is updated with a new size
        // - Parameters:
        //   - participant: Current information of the corresponding participant
        //   - streamId: Unique stream id
        //   - videoView: The VideoView for the corresponding participant
        //----------------------------------------------------------------------------------------------------

        public void ParticipantVideoUpdated(Participant participant, string streamID, VideoView videoView)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantVideoUpdated - " + participant.displayName + " " + participant.userIdString + " " + "StreamID = " + streamID);
        }

        //----------------------------------------------------------------------------------------------------
        // Called when the remote layout of a participant's video is changed
        // - Parameters:
        //   - participant: Current information of the corresponding participant
        //   - streamId: Unique stream id
        //----------------------------------------------------------------------------------------------------

        public void ParticipantVideoRemoteLayoutChanged(Participant participant, string streamID)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantVideoRemoteLayoutChanged - " + participant.displayName + " " + participant.userIdString + " " + "StreamID = " + streamID);
        }

        //----------------------------------------------------------------------------------------------------
        // ParticipantVideoViewCreated
        // Called when a video stream is enabled
        // - Parameters:
        //   - partipant: Current information of the corresponding participant
        //   - videoView: The VideoView for the corresponding participant
        //   - local: Boolean to know if this participant is the local video stream
        //----------------------------------------------------------------------------------------------------

        public void ParticipantVideoViewCreated(Participant participant, VideoView videoView, bool local)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantVideoViewCreated - " + participant.displayName + " " + participant.userIdString);

            // Update Video View Window
            if (participant.videoInfoDic != null)
            {
                foreach (KeyValuePair<string, VideoInfo> videoInfo in participant.videoInfoDic)
                {
                    if (videoInfo.Value.videoView == videoView)
                    {
                        if (videoView != null)
                        {
                            Thread t = new Thread(new ThreadStart(() =>
                            {
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    FormVideoView formVideoView = new FormVideoView();

                                    formVideoView.Controls.Add(videoView);

                                    formVideoView.Text = videoInfo.Value.site + "-" + videoInfo.Value.name;

                                    formVideoView.Show();

                                    Program.meetingState.AddVideoViewWindow(videoInfo.Value.streamId, formVideoView);
                                });
                            }));

                            t.Start();
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // ParticipantVideoViewRetrieved
        // This delegate method is received when enableVideoStream is called on a VideoView that already
        // exists. This can happen if an existing video stream is disabled and then re-enabled
        // - Parameters:
        //   - partipant: Current information of the corresponding participant
        //   - streamId: Unique stream id
        //   - videoView: The VideoView for the corresponding participant
        //----------------------------------------------------------------------------------------------------

        public void ParticipantVideoViewRetrieved(Participant participant, string streamID, VideoView videoView)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantVideoViewRetrieved - " + participant.displayName + " " + participant.userIdString + " " + "StreamID = " + streamID);

            // If this window was put in the background/hidden because the stream was disabled,
            // we need to bring it back to the foreground

            FormVideoView formVideoView;

            Program.meetingState.GetVideoViewWindow(streamID, out formVideoView);

            formVideoView.Invoke((MethodInvoker)delegate
            {
                if (formVideoView.Visible == false)
                {
                    formVideoView.Visible = true;
                }
            });
       }

        //----------------------------------------------------------------------------------------------------
        // ParticipantVideoRemoved
        // Called when a participant's video is removed, on the video_stream_removed callback
        // - Parameters:
        //   - participant: Current information of the corresponding participant
        //   - streamId: Unique stream id
        //   - videoView: The VideoView for the corresponding participant
        //----------------------------------------------------------------------------------------------------

        public void ParticipantVideoRemoved(Participant participant, string streamID, VideoView videoView)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantVideoRemoved - " + participant.displayName + " " + participant.userIdString + " " + "StreamID = " + streamID);

            // Make sure we have a Video Info
            if (participant.videoInfoDic != null)
            {
                if (participant.videoInfoDic.ContainsKey(streamID))
                {
                    // Remove Participant Video Window
                    RemoveWindow(streamID);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // ParticipantVideoStreamSizeChanged
        // Called when a participant video stream size changed.
        // - Parameters:
        //   - participant: Current information of the corresponding participant
        //   - streamId: Unique stream id
        //----------------------------------------------------------------------------------------------------

        public void ParticipantVideoStreamSizeChanged(Participant participant, string streamID)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantVideoStreamSizeChanged - " + participant.displayName + " " + participant.userIdString + " " + "StreamID = " + streamID);

            VideoInfo videoInfo;

            participant.videoInfoDic.TryGetValue(streamID, out videoInfo);

            if (videoInfo.active == "true")
            {
                RemoveWindow(streamID);

                // Enable Participant Video Stream
                Meeting.Instance.EnableVideoStream(participant, streamID);
            }
        }

        //----------------------------------------------------------------------------------------------------
        // ParticipantRemoved
        // Called when a participant leaves or is removed from the meeting
        // - Parameter participant: Current information of the corresponding participant
        //----------------------------------------------------------------------------------------------------

        public void ParticipantRemoved(Participant participant)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - ParticipantRemoved - " + participant.displayName + " " + participant.userIdString);

            // Repopulate Meeting Participants
            PopulateDataGridView();

            if (participant.videoInfoDic != null)
            {
                // Remove Participant Video Views
                foreach (KeyValuePair<string, VideoInfo> videoInfo in participant.videoInfoDic)
                {
                    RemoveWindow(videoInfo.Value.streamId);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // InputMeterChanged
        //----------------------------------------------------------------------------------------------------

        public void InputMeterChanged(string meter)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - InputMeterChanged - " + meter);
        }

        //----------------------------------------------------------------------------------------------------
        // OutputMeterChanged
        //----------------------------------------------------------------------------------------------------

        public void OutMeterChanged(string meter)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - OutputMeterChanged - " + meter);
        }

        //----------------------------------------------------------------------------------------------------
        // Amplitude
        //----------------------------------------------------------------------------------------------------

        public void Amplitude(Participant participant, string amplitude, bool muted)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - Amplitude - " + participant.displayName + " " + participant.userIdString + " " + "amplitude = " + amplitude + " " + "muted = " + muted.ToString());
        }

        //----------------------------------------------------------------------------------------------------
        // dataGridViewParticipants_CellContentClick
        //----------------------------------------------------------------------------------------------------

        private void dataGridViewParticipants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            Participant participant;

            // Get Participant by User ID
            participant = Meeting.Instance.GetParticipantByUserID(dataGridViewParticipants[2, rowIndex].Value.ToString());


            FormConfigurationRemote formConfigurationRemote = new FormConfigurationRemote();

            formConfigurationRemote.SetParticipant(participant);

            formConfigurationRemote.ShowDialog();
        }

        //----------------------------------------------------------------------------------------------------
        // buttonMuteMe_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonMuteMe_Click(object sender, EventArgs e)
        {
            if (buttonMuteMe.Text == "Mute Me")
            {
                Meeting.Instance.DisableAudioInput(Program.meetingState.strAudioInputName);
                buttonMuteMe.Text = "Unmute Me";
            }
            else
            {
                Meeting.Instance.EnableAudioInput(Program.meetingState.strAudioInputName);
                trackBarInputVolume.Value = 50;
                buttonMuteMe.Text = "Mute Me";
            }
        }

        //----------------------------------------------------------------------------------------------------
        // buttonVideoOff_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonVideoOff_Click(object sender, EventArgs e)
        {
            if (buttonVideoOff.Text == "Video Off")
            {
                foreach (VideoDevicesUsed videoDeviceUsed in Program.meetingState.VideoDevicesUsed)
                {
                    Meeting.Instance.DisableVideoCapture(videoDeviceUsed.DeviceName);
                }

                buttonVideoOff.Text = "Video On";
            }
            else
            {
                foreach (VideoDevicesUsed videoDeviceUsed in Program.meetingState.VideoDevicesUsed)
                {
                    Meeting.Instance.EnableVideoCapture(videoDeviceUsed.DeviceName, videoDeviceUsed.Codec);
                }

                buttonVideoOff.Text = "Video Off";
            }
        }

        //----------------------------------------------------------------------------------------------------
        // buttonSettings_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonVideoSettings_Click(object sender, EventArgs e)
        {
            // Display Video Settings Form
            FormVideoSettings formVideoSettings = new FormVideoSettings();

            // Set Participant to Local Participant
            formVideoSettings.SetParticipant(Meeting.Instance.GetLocalParcipitant());

            formVideoSettings.ShowDialog();

            // Set Video Off/On Button
            if (Program.meetingState.GetVideoDevicesUsedCount() == 0)
            {
                buttonVideoOff.Text = "Video On";
                buttonVideoOff.Enabled = false;
            }
            else
            {
                buttonVideoOff.Text = "Video Off";
                buttonVideoOff.Enabled = true;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // trackBarInputVolume_Scroll
        //----------------------------------------------------------------------------------------------------

        private void trackBarInputVolume_Scroll(object sender, EventArgs e)
        {
            bool bRet = Meeting.Instance.SetAudioInputVolume(GetTrackerInputValue());
        }

        //----------------------------------------------------------------------------------------------------
        // GetTrackerInputValueCallback (Thread-Safe)
        //----------------------------------------------------------------------------------------------------

        delegate int GetTrackerInputValueCallback();

        private int GetTrackerInputValue()
        {
            if (trackBarInputVolume.InvokeRequired)
            {
                GetTrackerInputValueCallback cb = new GetTrackerInputValueCallback(GetTrackerInputValue);

                return (int)trackBarInputVolume.Invoke(cb);
            }
            else
            {
                return (int)trackBarInputVolume.Value;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // trackBarOutputVolume_Scroll
        //----------------------------------------------------------------------------------------------------

        private void trackBarOutputVolume_Scroll(object sender, EventArgs e)
        {
            bool bRet = Meeting.Instance.SetAudioOutputVolume(GetTrackerOutputValue());
        }

        //----------------------------------------------------------------------------------------------------
        // GetTrackerOutputValueCallback (Thread-Safe)
        //----------------------------------------------------------------------------------------------------

        delegate int GetTrackerOutputValueCallback();

        private int GetTrackerOutputValue()
        {
            if (trackBarOutputVolume.InvokeRequired)
            {
                GetTrackerOutputValueCallback cb = new GetTrackerOutputValueCallback(GetTrackerOutputValue);

                return (int)trackBarOutputVolume.Invoke(cb);
            }
            else
            {
                return (int)trackBarOutputVolume.Value;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // buttonExitMeeting_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonExitMeeting_Click(object sender, EventArgs e)
        {
            // Close All Video Views
            CloseVideoViews();

            // Exit Meeting
            Meeting.Instance.ExitMeeting();

            // Exit Application Program
            Application.Exit();
        }

        //----------------------------------------------------------------------------------------------------
        // RemoveWindow
        //----------------------------------------------------------------------------------------------------

        private void RemoveWindow(string streamID)
        {
            FormVideoView formVideoView = null;

            Program.meetingState.GetVideoViewWindow(streamID, out formVideoView);

            if (formVideoView != null)
            {
                formVideoView.Invoke((MethodInvoker)delegate
                {
                    formVideoView.Close();
                });

                Program.meetingState.RemoveVideoViewWindow(streamID);
            }
        }

        //----------------------------------------------------------------------------------------------------
        // CloseVideoViews
        //----------------------------------------------------------------------------------------------------

        private void CloseVideoViews()
        {
            // Close Video Views
            foreach (KeyValuePair<string, FormVideoView> formVideoView in Program.meetingState.VideoViewWindows)
            {
                formVideoView.Value.Close();
            }
        }

        //----------------------------------------------------------------------------------------------------
        // FormMeeting Destructor
        //----------------------------------------------------------------------------------------------------

        ~FormMeeting()
        {

        }
    }
}
