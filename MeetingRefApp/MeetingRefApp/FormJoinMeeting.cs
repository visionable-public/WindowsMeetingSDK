///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2020-2020 Visionable Limited, All Rights Reserved
// COMPANY CONFIDENTIAL
// This file may not be reproduced or transmitted without explicit permission
//
// Author:  Wendy Wasmuth
// $File: //iocommain/Meeting/Windows/MeetingRefApp/MeetingRefApp/FormJoinMeeting.cs $
//
// Perforce RCS keywords (add with -t text+k to use these)
// $Author: wwasmuth $
// $DateTime: 2020/11/18 00:00:00 $
// $Revision: # $
// $Change: $
///////////////////////////////////////////////////////////////////////////////

using MeetingSDKHigh; // Meeting SDK (High Level)

using System;
using System.Windows.Forms;

namespace MeetingRefApp
{
    //----------------------------------------------------------------------------------------------------
    // FormJoinMeeting Class
    //----------------------------------------------------------------------------------------------------

    public partial class FormJoinMeeting : Form
    {
        public bool UserClosedFlag = false;

        //----------------------------------------------------------------------------------------------------
        // Settings Form
        //----------------------------------------------------------------------------------------------------

        private FormSettings formSettings;

        //----------------------------------------------------------------------------------------------------
        // Join Meeting Constructor
        //----------------------------------------------------------------------------------------------------

        public FormJoinMeeting()
        {
            InitializeComponent();

            // Disable Join Meeting Button
            buttonJoinMeeting.Enabled = false;

            // Form Settings
            formSettings = new FormSettings();
        }
        
        //----------------------------------------------------------------------------------------------------
        // buttonSettings_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            // Display Settings Form
            DialogResult dr = formSettings.ShowDialog();

            // If User did not Close the Join Meeeting Form
            if (dr != DialogResult.Cancel)
            {
                // Enable Join Meeting Button
                buttonJoinMeeting.Enabled = true;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // buttonJoinMeeting_Click
        //----------------------------------------------------------------------------------------------------

        private void buttonJoinMeeting_Click(object sender, EventArgs e)
        {
            // Get Meeting Information
            Program.MeetingServer = textBoxServer.Text;
            Program.MeetingID = textBoxMeetingUUID.Text;
            Program.ParticipantName = textBoxParticipantName.Text;

            // If Invalid Meeting Server
            if (Program.MeetingServer == "")
            {
                MessageBox.Show("Please Enter a Valid Meeting Server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If Invalid Meeting UUID or User did not enter a Meeting UUID
            if (Program.MeetingID == "" || Program.MeetingID == "Meeting UUID")
            {
                MessageBox.Show("Please Enter a Valid Meeting UUID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If Invalid Meeting Participant Name or User did not enter a Meeting Participant Name
            if (Program.ParticipantName == "" || Program.ParticipantName == "Enter Your Name")
            {
                MessageBox.Show("Please Enter a Valid Meeting Participant Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserClosedFlag = true;

            // Close Join Meeting Form
            Close();
        }
    }
}
