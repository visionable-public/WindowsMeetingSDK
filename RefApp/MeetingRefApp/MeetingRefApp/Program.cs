///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2020-2020 Visionable Limited, All Rights Reserved
// COMPANY CONFIDENTIAL
// This file may not be reproduced or transmitted without explicit permission
//
// Author:  Wendy Wasmuth
// $File: //iocommain/Meeting/Windows/MeetingRefApp/MeetingRefApp/Program.cs $
//
// Perforce RCS keywords (add with -t text+k to use these)
// $Author: wwasmuth $
// $DateTime: 2020/11/18 00:00:00 $
// $Revision: # $
// $Change: $
///////////////////////////////////////////////////////////////////////////////

using MeetingSDKHigh; // Meeting SDK (High Level)

using System;
using System.Collections.Concurrent;
using System.Windows.Forms;

namespace MeetingRefApp
{
    //----------------------------------------------------------------------------------------------------
    // Program Class
    //----------------------------------------------------------------------------------------------------
    
    static class Program
    {
        //----------------------------------------------------------------------------------------------------
        // Meeting Information
        //----------------------------------------------------------------------------------------------------

        public static string MeetingServer;
        public static string MeetingID;
        public static string ParticipantName;

        //----------------------------------------------------------------------------------------------------
        // Meeting Participants
        //----------------------------------------------------------------------------------------------------
        
        public static ConcurrentDictionary<string, Participant> participants = new ConcurrentDictionary<string, Participant>();

        //----------------------------------------------------------------------------------------------------
        // Meeting State
        //----------------------------------------------------------------------------------------------------

        public static MeetingState meetingState = new MeetingState();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]

        //----------------------------------------------------------------------------------------------------
        // Main
        //----------------------------------------------------------------------------------------------------
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create Join Meeting Form
            FormJoinMeeting formJoinMeeting = new FormJoinMeeting();
            formJoinMeeting.UserClosedFlag = false;

            // Display Join Meeting Form
            Application.Run(formJoinMeeting);

            // If User did not Close the Join Meeeting Form
            if (formJoinMeeting.UserClosedFlag)
            {
                // Display Meeting Form
                FormMeeting formMeeting = new FormMeeting();
                formMeeting.ShowDialog();
            }
        }
    }
}
