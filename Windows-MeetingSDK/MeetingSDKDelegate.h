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

class MeetingSDKDelegate
{
public:
    // Return decoded MJWT
    virtual void meetingToken(std::string decodedToken) {}

    // Participant model object related; required
    virtual void participantAdded(const Participant participant) = 0;
    virtual void participantRemoved(const Participant participant) = 0;

    // Participant audio stream related; optional
    virtual void participantAudioAdded(const Participant participant) {}
    virtual void participantAudioUpdated(const Participant participant) = 0;

    // Participant video stream related; optional
    virtual void participantVideoAdded(const Participant participant, std::string streamId) {}
    virtual void participantVideoUpdated(const Participant participant, std::string streamId) {}
    virtual void participantVideoRemoved(const Participant participant, std::string streamId) {}
    virtual void participantVideoRemoteLayoutChanged(const Participant participant, std::string streamId) {}
    virtual void videoStreamBufferReady(std::string streamId, void* pixelBuffer) {}
    virtual void videoFrameReady(std::string streamId, void* pixelBuffer) {}
    virtual void videoPreviewReady(std::string streamId, std::string name, int width, int height) {}
    virtual void previewFrameReady(std::string streamId, void* pixelBuffer) {}
    virtual void previewVideoUpdated(std::string streamId) {}

    virtual void videoError(std::string errorName, std::string errorDesc, bool isFatal) {}
    virtual void audioError(std::string errorName, std::string errorDesc, bool isFatal) {}

    // Related to audio of local participant; optional
    virtual void inputMeterChanged(uint8_t meter) {}
    virtual void outputMeterChanged(uint8_t meter) {}

    // Related to audio of remote participants; optional
    virtual void participantAmplitudeChanged(const Participant participant, uint8_t amplitude, bool muted) {}
    virtual void participantAmplitudeChanged(const Participant participant, uint8_t amplitude, bool muted, uint32_t epoch_time) {
        // By default, will just cause the 3-argument version unless this is overridden
        participantAmplitudeChanged(participant, amplitude, muted);
    }

    // logging related; optional
    virtual void logMessage(unsigned int level, const std::string& message) {}

    // related to playing sounds
    virtual void binaryPlaybackEnded(uint64_t id) {}
    virtual void binaryPlaybackFailed(uint64_t id) {}

    // Related to statistics
    //virtual void audioConditionUpdate(Visionable::AudioCondition& ac) {}
    //virtual void videoConditionUpdate(Visionable::VideoCondition& vc) {}

    // Related to information coming from audio/video condition updates
    virtual void meetingDisconnected() {}

    // Network health/connection related
    virtual void participantNetworkQuality(const Participant participant, std::string streamId, uint32_t barValue) {}
    virtual void networkQuality(uint32_t barValue) {}
    virtual void connectionStatus(uint32_t status) {}

    //TODO: callback(s) related to screen sharing
};

#endif /* MEETING_SDK_DELEGATE_H */
