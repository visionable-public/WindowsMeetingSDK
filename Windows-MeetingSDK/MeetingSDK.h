//
//  MeetingSDK.h
//  MeetingSDK
//
//  Created by John Curley on 6/10/2024
//

#ifndef MEETING_SDK_H
#define MEETING_SDK_H

#include "MeetingSDKDelegate.h"

#include <functional>
#include <list>

#define DLLEXPORT __declspec (dllexport)

class InternalMeetingDelegate;

class DLLEXPORT MeetingSDK {
private:
    // Singleton implementation
    static MeetingSDK* instance;

public:
    static MeetingSDK* sharedInstance();

    friend class InternalMeetingDelegate;
    friend void joinMeetingCallback(bool success, std::string generatedUUID);
public:
    MeetingSDK();
    ~MeetingSDK();

    void setDelegate(MeetingSDKDelegate* delegate);

public:
    // Meeting APIs

    void joinMeeting(const std::string& server, const std::string& uuid, const std::string& key, const std::string& userUUID, const std::string& name, std::function<void(bool, std::string)> completion);
    void joinMeetingWithToken(const std::string& server, const std::string& uuid, const std::string& token, const std::string& userUUID, const std::string& name, std::function<void(bool, std::string)> completion);
    void joinMeetingWithTokenAndJWT(const std::string& server, const std::string& uuid, const std::string& token, const std::string& jwt, const std::string& name, std::function<void(bool, std::string)> completion);


    bool enableAudioInput(const std::string& device);
    bool disableAudioInput(const std::string& device);
    bool enableAudioOutput(const std::string& device);
    bool disableAudioOutput(const std::string& device);
    bool enableAudioInputPreview(const std::string& device);
    bool disableAudioInputPreview(const std::string& device);
    bool enableAudioOutputPreview(const std::string& device, const std::string& soundURL);
    bool disableAudioOutputPreview(const std::string& device);

    bool setAudioStreamVolume(const std::string& streamId, uint8_t volume);
    bool setAudioInputVolume(const std::string& device, uint8_t volume);
    bool setAudioOutputVolume(const std::string& device, uint8_t volume);

    bool enableVideoCapture(const std::string& camera, const std::string& mode, bool enableBlurring = false);
    bool disableVideoCapture(const std::string& camera);
    bool enableVideoPreview(const std::string& camera, const std::string& mode, bool enableBlurring = false);
    bool disableVideoPreview(const std::string& camera);
    bool enableWindowSharing(const std::string& windowId, const std::string& mode);
    bool disableWindowSharing(const std::string& windowId);

    bool enableNetworkVideo(const std::string& url, const std::string& mode, const std::string& name);
    bool disableNetworkVideo(const std::string& url);

    int enableImageCaptureDevice(std::string& displayName, std::string& directory, std::string& mode);
    bool disableImageCaptureDevice(int deviceId);
    bool imageCaptureDevicePutImage(int deviceId, const uint8_t *yuv420p_ptr, int width, int height, int size);

    bool disableVideoStream(const std::string& streamId);
    bool enableVideoStream(const std::string& streamId);
    bool enableVideoStream(const std::string& streamId, const std::string& colorspace);
    void pauseVideoFrameProcessing(const std::string& streamId);
    void resumeVideoFrameProcessing(const std::string& streamId);

    void exitMeeting();

    // Logging related
    void enableCombinedLogs(bool enable);
    void enableLogForwarding(bool enable);
    void enableActiveLogging(const std::string& filename);
    void setTraceLevel(int level);
    void audioTraceLevel(int level);
    void videoTraceLevel(int level);
    void videoTraceOutputHistory(const std::string& filename);
    void audioTraceOutputHistory(const std::string& filename);
    void coreMeetingTraceOutputHistory(const std::string& filename);

    void getVideoDevices(std::vector<std::string>& devices, std::vector<std::string>& screens);
    void getAudioInputDevices(std::vector<std::string>& devices, std::string& preferred);
    void getAudioOutputDevices(std::vector<std::string>& devices, std::string& preferred);
    void getSupportedVideoSendResolutions(const std::string& device, std::vector<std::string>& resolutions);

    int getWindowList(std::list<std::pair<uint64_t, std::string>>& windowList);

    bool getWindowThumbnail(const std::string& id, const std::string& outputFormat, const std::string& destPath, int width, int height, uint8_t*& pThumbBuffer, uint32_t& size);
    bool releaseWindowThumbnail(const std::string& id, uint8_t*& pThumbBuffer);

    const void* playSound(const char* soundData, size_t size);
    bool stopSound(const char* soundData);

    bool isScreenShare(const std::string& codec);
    std::string getLastError();

    void getLocalParticipant(Participant& participant);
    void getParticipantIds(std::vector<std::string>& ids);
    bool findVideoInfo(const std::string& streamId, VideoInfo& videoInfo);
    bool findParticipantByVideoStreamId(const std::string& streamId, Participant& participant);
    bool findParticipantByAudioStreamId(const std::string& streamId, Participant& participant);
    bool findParticipantByUUID(const std::string& uuid, Participant& participant);

    // Extended Logging APIs
    bool setLogDirectory(const std::string& path);
    bool deleteLogFile(const std::string& fileName);
    bool deleteAllLogFiles();
    bool resetCurrentLogFile();
    bool trimCurrentLogFile(int numBytes);
    bool getLogFiles(std::vector<std::string>& fileNames);
    bool flushCurrentLogFile();

    // Time Zone related -- right now only Windows VC++ implements the C++20 chrono::time_zone object
    void getTimeZone(std::string& timeZone);


private:
    MeetingSDKDelegate* delegate;
    InternalMeetingDelegate* imdPtr;

    // flag to let us know if last joinMeeting call for a V2/V3 server
    bool isV2Meeting;

    // Keep track of server name of msg (RTN) server
    std::string msgServer;
};



#endif /* MODERATOR_SDK_H */
