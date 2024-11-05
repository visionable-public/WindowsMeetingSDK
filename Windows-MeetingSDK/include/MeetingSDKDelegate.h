//
//  MeetingSDKDelegate.h
//  MeetingSDK
//
//  Created by John Curley on 6/10/2024
//

#ifndef MEETING_SDK_DELEGATE_H
#define MEETING_SDK_DELEGATE_H

#include <iostream>

#include "MeetingSDKDataStructures.h"

/**
 * @class MeetingSDKDelegate
 * @brief Interface for handling various events and updates in the Meeting SDK.
 */
class MeetingSDKDelegate
{
public:
    /**
     * @brief Called when a decoded meeting token is available.
     * @param decodedToken The decoded meeting token.
     */
    virtual void meetingToken(const char * decodedToken) {}

    /**
     * @brief Called when a participant is added to the meeting.
     * @param participant The participant that was added.
     */
    virtual void participantAdded(const Participant& participant) = 0;

    /**
     * @brief Called when a participant is removed from the meeting.
     * @param participant The participant that was removed.
     */
    virtual void participantRemoved(const Participant& participant) = 0;

    /**
     * @brief Called when a participant's audio stream is added.
     * @param participant The participant whose audio stream was added.
     */
    virtual void participantAudioAdded(const Participant& participant) {}

    /**
     * @brief Called when a participant's audio stream is updated.
     * @param participant The participant whose audio stream was updated.
     */
    virtual void participantAudioUpdated(const Participant& participant) = 0;

    /**
     * @brief Called when a participant's video stream is added.
     * @param participant The participant whose video stream was added.
     * @param streamId The ID of the video stream.
     */
    virtual void participantVideoAdded(const Participant& participant, const char * streamId) {}

    /**
     * @brief Called when a participant's video stream is updated.
     * @param participant The participant whose video stream was updated.
     * @param streamId The ID of the video stream.
     */
    virtual void participantVideoUpdated(const Participant& participant, const char * streamId) {}

    /**
     * @brief Called when a participant's video stream is removed.
     * @param participant The participant whose video stream was removed.
     * @param streamId The ID of the video stream.
     */
    virtual void participantVideoRemoved(const Participant& participant, const char * streamId) {}

    /**
     * @brief Called when the remote layout of a participant's video stream changes.
     * @param participant The participant whose video stream layout changed.
     * @param streamId The ID of the video stream.
     */
    virtual void participantVideoRemoteLayoutChanged(const Participant& participant, const char * streamId) {}

    /**
     * @brief Called when a video stream buffer is ready.
     * @param streamId The ID of the video stream.
     * @param pixelBuffer The buffer containing the video stream pixels.
     */
    virtual void videoStreamBufferReady(const char * streamId, void* pixelBuffer) {}

    /**
     * @brief Called when a video frame is ready.
     * @param streamId The ID of the video stream.
     * @param pixelBuffer The buffer containing the video frame pixels.
     */
    virtual void videoFrameReady(const char * streamId, void* pixelBuffer) {}

    /**
     * @brief Called when a video preview is ready.
     * @param streamId The ID of the video stream.
     * @param name The name of the video preview.
     * @param width The width of the video preview.
     * @param height The height of the video preview.
     */
    virtual void videoPreviewReady(const char * streamId, const char * name, int width, int height) {}

    /**
     * @brief Called when a preview frame is ready.
     * @param streamId The ID of the video stream.
     * @param pixelBuffer The buffer containing the preview frame pixels.
     */
    virtual void previewFrameReady(const char * streamId, void* pixelBuffer) {}

    /**
     * @brief Called when a preview video is updated.
     * @param streamId The ID of the video stream.
     */
    virtual void previewVideoUpdated(const char * streamId) {}

    /**
     * @brief Called when a video error occurs.
     * @param errorName The name of the error.
     * @param errorDesc The description of the error.
     * @param isFatal Indicates if the error is fatal.
     */
    virtual void videoError(const char * errorName, const char * errorDesc, bool isFatal) {}

    /**
     * @brief Called when an audio error occurs.
     * @param errorName The name of the error.
     * @param errorDesc The description of the error.
     * @param isFatal Indicates if the error is fatal.
     */
    virtual void audioError(const char * errorName, const char * errorDesc, bool isFatal) {}

    /**
     * @brief Called when the input audio meter changes.
     * @param meter The new meter value.
     */
    virtual void inputMeterChanged(uint8_t meter) {}

    /**
     * @brief Called when the output audio meter changes.
     * @param meter The new meter value.
     */
    virtual void outputMeterChanged(uint8_t meter) {}

    /**
     * @brief Called when a participant's audio amplitude changes.
     * @param participant The participant whose audio amplitude changed.
     * @param amplitude The new amplitude value.
     * @param muted Indicates if the participant is muted.
     */
    virtual void participantAmplitudeChanged(const Participant& participant, uint8_t amplitude, bool muted) {}

    /**
     * @brief Called when a participant's audio amplitude changes with epoch time.
     * @param participant The participant whose audio amplitude changed.
     * @param amplitude The new amplitude value.
     * @param muted Indicates if the participant is muted.
     * @param epoch_time The epoch time of the change.
     */
    virtual void participantAmplitudeChanged(const Participant& participant, uint8_t amplitude, bool muted, uint32_t epoch_time) {
        // By default, will just cause the 3-argument version unless this is overridden
        participantAmplitudeChanged(participant, amplitude, muted);
    }

    /**
     * @brief Called when a log message is available.
     * @param level The log level.
     * @param message The log message.
     */
    virtual void logMessage(unsigned int level, const char * message) {}

    /**
     * @brief Called when binary playback ends.
     * @param id The ID of the binary playback.
     */
    virtual void binaryPlaybackEnded(uint64_t id) {}

    /**
     * @brief Called when binary playback fails.
     * @param id The ID of the binary playback.
     */
    virtual void binaryPlaybackFailed(uint64_t id) {}

    /**
	 * @brief Called when audio statistics are updated.
	 * @param id Reference to the audio statistics.
     */
    virtual void audioConditionUpdate(const AudioStatistic& ac) {}

    /**
     * @brief Called when video statistics are updated.
     * @param id Reference to the video statistics.
     */
    virtual void videoConditionUpdate(const VideoStatistics& vc) {}

    /**
     * @brief Called when the meeting is disconnected.
     */
    virtual void meetingDisconnected() {}

    /**
     * @brief Called when a participant's network quality changes.
     * @param participant The participant whose network quality changed.
     * @param streamId The ID of the video stream.
     * @param barValue The new network quality value.
     */
    virtual void participantNetworkQuality(const Participant& participant, const char * streamId, uint32_t barValue) {}

    /**
     * @brief Called when the network quality changes.
     * @param barValue The new network quality value.
     */
    virtual void networkQuality(uint32_t barValue) {}

    /**
     * @brief Called when the connection status changes.
     * @param status The new connection status.
     */
    virtual void connectionStatus(uint32_t status) {}

    //TODO: callback(s) related to screen sharing
};

#endif /* MEETING_SDK_DELEGATE_H */
