///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2020-2020 Visionable Limited, All Rights Reserved
// COMPANY CONFIDENTIAL
// This file may not be reproduced or transmitted without explicit permission
//
// Author:  Wendy Wasmuth
// $File: //iocommain/Meeting/Windows/MeetingRefApp/MeetingRefApp/MeetingState.cs $
//
// Perforce RCS keywords (add with -t text+k to use these)
// $Author: wwasmuth $
// $DateTime: 2020/11/18 00:00:00 $
// $Revision: # $
// $Change: $
///////////////////////////////////////////////////////////////////////////////

using MeetingSDKHigh; // Meeting SDK (High Level)

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MeetingRefApp
{
    //----------------------------------------------------------------------------------------------------
    // MeetingState Class
    //----------------------------------------------------------------------------------------------------

    class MeetingState
    {
        public string strAudioOutputName = "";
        public string strAudioOutputID = "";
        public string strAudioInputName = "";
        public string strAudioInputID = "";

        //----------------------------------------------------------------------------------------------------
        // Video Devices Used
        //----------------------------------------------------------------------------------------------------

        public List<VideoDevicesUsed> VideoDevicesUsed = new List<VideoDevicesUsed>();

        //----------------------------------------------------------------------------------------------------
        // Audio Streams and Volumes
        //----------------------------------------------------------------------------------------------------

        public ConcurrentDictionary<string, int> AudioStreamVolumes = new ConcurrentDictionary<string, int>();

        //----------------------------------------------------------------------------------------------------
        // Video View Windows
        //----------------------------------------------------------------------------------------------------

        public ConcurrentDictionary<string, FormVideoView> VideoViewWindows = new ConcurrentDictionary<string, FormVideoView>();

        //----------------------------------------------------------------------------------------------------
        // GetVideoDevicesUsedCount
        //----------------------------------------------------------------------------------------------------

        public int GetVideoDevicesUsedCount()
        {
            return VideoDevicesUsed.Count;
        }

        //----------------------------------------------------------------------------------------------------
        // AddVideoDeviceUsed
        //----------------------------------------------------------------------------------------------------

        public void AddVideoDeviceUsed(string DeviceName, string Codec)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - MeetingState - AddVideoDeviceUsed" + " " + "DeviceName = " + DeviceName + " " + "Codec = " + Codec);

            VideoDevicesUsed videoDevicesUsed = new MeetingRefApp.VideoDevicesUsed();
            videoDevicesUsed.DeviceName = DeviceName;
            videoDevicesUsed.Codec = Codec;

            VideoDevicesUsed.Add(videoDevicesUsed);
        }

        //----------------------------------------------------------------------------------------------------
        // UpdateVideoDeviceUsedCodec
        //----------------------------------------------------------------------------------------------------

        public void UpdateVideoDeviceUsedCodec(string DeviceName, string Codec)
        {
            RemoveVideoDeviceUsed(DeviceName);
            AddVideoDeviceUsed(DeviceName, Codec);
        }

        //----------------------------------------------------------------------------------------------------
        // GetVideoDeviceUsedCodec
        //----------------------------------------------------------------------------------------------------

        public string GetVideoDeviceUsedCodec(string DeviceName)
        {
            if (VideoDevicesUsed != null)
            {
                VideoDevicesUsed videoDeviceUsed = VideoDevicesUsed.Find(x => x.DeviceName.Contains(DeviceName));

                if (videoDeviceUsed != null)
                {
                    return videoDeviceUsed.Codec;
                }
                else
                {
                    return "Not Used";
                }
            }
            else
            {
                return "Not Used";
            }
        }

        //----------------------------------------------------------------------------------------------------
        // VideoDeviceUsedExists
        //----------------------------------------------------------------------------------------------------

        public bool VideoDeviceUsedExists(string DeviceName)
        {
            if (VideoDevicesUsed != null)
            {
                VideoDevicesUsed videoDeviceUsed = VideoDevicesUsed.Find(x => x.DeviceName.Contains(DeviceName));

                if (videoDeviceUsed != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        //----------------------------------------------------------------------------------------------------
        // RemoveVideoDeviceUsed
        //----------------------------------------------------------------------------------------------------

        public void RemoveVideoDeviceUsed(string DeviceName)
        {

            System.Diagnostics.Debug.WriteLine("MeetingRefApp - MeetingState - RemoveVideoDeviceUsed - " + "DeviceName = " + DeviceName);

            if (VideoDevicesUsed != null)
            {
                VideoDevicesUsed videoDeviceUsed = VideoDevicesUsed.Find(x => x.DeviceName.Contains(DeviceName));

                if (videoDeviceUsed != null)
                {
                    VideoDevicesUsed.Remove(videoDeviceUsed);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        // RemoveAllVideoDevicesUsed
        //----------------------------------------------------------------------------------------------------

        public void RemoveAllVideoDevicesUsed()
        {
            if (VideoDevicesUsed != null)
            {
                VideoDevicesUsed.Clear();
            }
        }

        //----------------------------------------------------------------------------------------------------
        // GetVideoDevicesUsed
        //----------------------------------------------------------------------------------------------------

        public List<VideoDevicesUsed> GetVideoDevicesUsed(string DeviceName)
        {
            return VideoDevicesUsed;
        }

        //----------------------------------------------------------------------------------------------------
        // AddAudioStreamVolume
        //----------------------------------------------------------------------------------------------------

        public void AddAudioStreamVolume(string streamID, int volume)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - MeetingState - AddAudioStreamVolume - " + "streamID = " + streamID);

            AudioStreamVolumes.TryAdd(streamID, volume);
        }

        //----------------------------------------------------------------------------------------------------
        // GetAudioStreamVolume
        //----------------------------------------------------------------------------------------------------

        public int GetAudioStreamVolume(string streamID)
        {
            int volume;

            AudioStreamVolumes.TryGetValue(streamID, out volume);

            return volume;
        }

        //----------------------------------------------------------------------------------------------------
        // SetAudioStreamVolume
        //----------------------------------------------------------------------------------------------------

        public void SetAudioStreamVolume(string streamID, int volume)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - MeetingState - SetAudioStreamVolume - " + "streamID = " + streamID + "volume = " + volume);

            int oldVolume;

            AudioStreamVolumes.TryGetValue(streamID, out oldVolume);
            AudioStreamVolumes.TryUpdate(streamID, volume, oldVolume);
        }

        //----------------------------------------------------------------------------------------------------
        // AddVideoViewWindow
        //----------------------------------------------------------------------------------------------------

        public void AddVideoViewWindow(string streamID, FormVideoView formVideoView)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - MeetingState - AddVideoViewWindow - " + "streamID = " + streamID);

            VideoViewWindows.TryAdd(streamID, formVideoView);
        }

        //----------------------------------------------------------------------------------------------------
        // RemoveVideoViewWindow
        //----------------------------------------------------------------------------------------------------

        public void RemoveVideoViewWindow(string streamID)
        {
            System.Diagnostics.Debug.WriteLine("MeetingRefApp - MeetingState - RemoveVideoViewWindow - " + "streamID = " + streamID);

            FormVideoView formVideoView = null;

            VideoViewWindows.TryRemove(streamID, out formVideoView);
        }

        //----------------------------------------------------------------------------------------------------
        // GetVideoViewWindow
        //----------------------------------------------------------------------------------------------------

        public void GetVideoViewWindow(string streamID, out FormVideoView formVideoView)
        {
            VideoViewWindows.TryGetValue(streamID, out formVideoView);
        }

        //----------------------------------------------------------------------------------------------------
        // DumpMeetingStateInfo
        //----------------------------------------------------------------------------------------------------

        public void DumpMeetingStateInfo()
        {
            string message = "";

            System.Diagnostics.Debug.WriteLine("---------- BEGIN DUMP MEETING STATE INFO ----------"); ;

            foreach (VideoDevicesUsed videoDeviceUsed in Program.meetingState.VideoDevicesUsed)
            {
                message += "Meeting State Info - Devices Used - " + videoDeviceUsed.DeviceName + " " + videoDeviceUsed.Codec + "\n";
            }

            foreach (KeyValuePair<string, int> AudioStreamVolumes in Program.meetingState.AudioStreamVolumes)
            {
                message += "Meeting State Info - AudioStreamVolumes - " + "streamID = " + AudioStreamVolumes.Key + " " + "Volume = " + AudioStreamVolumes.Value + "\n";
            }

            foreach (KeyValuePair<string, FormVideoView> formVideoView in Program.meetingState.VideoViewWindows)
            {
                message += "Meeting State Info - " + "FormVideoView Key = " + formVideoView.Key;
            }

            System.Diagnostics.Debug.WriteLine(message);

            System.Diagnostics.Debug.WriteLine("---------- END DUMP MEETING STATE INFO ----------"); ;
        }
    }

    //----------------------------------------------------------------------------------------------------
    // VideoDevicesUsed Class
    //----------------------------------------------------------------------------------------------------

    internal class VideoDevicesUsed
    {
        public string DeviceName { get; set; }
        public string Codec { get; set; }
    }
}
