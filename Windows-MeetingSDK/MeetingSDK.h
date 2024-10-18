//
//  MeetingSDK.h
//  MeetingSDK
//
//  Created by John Curley on 6/10/2024
//

#ifndef MEETING_SDK_H
#define MEETING_SDK_H

#include "MeetingSDKDelegate.h"

#include <list>

#ifdef _MEETING_SDK_EXPORTS_
#define MEETING_SDK_API __declspec(dllexport)
#else
#define MEETING_SDK_API __declspec(dllimport)
#endif

typedef void(*CompletionCallback)(bool, const char*);

/**
 * @brief MeetingSDK class provides various APIs to manage and control meetings.
 */
class MEETING_SDK_API MeetingSDK {
public:
    /**
     * @brief Get the shared instance of MeetingSDK.
     * @return Pointer to the shared instance of MeetingSDK.
     */
    static MeetingSDK* sharedInstance();

public:
    /**
     * @brief Constructor for MeetingSDK.
     */
    MeetingSDK();

    /**
     * @brief Destructor for MeetingSDK.
     */
    ~MeetingSDK();

    /**
     * @brief Set the delegate for MeetingSDK.
     * @param delegate Pointer to the delegate object.
     */
    void setDelegate(MeetingSDKDelegate* delegate);

public:
    // Meeting APIs

    /**
     * @brief Join a meeting.
     * @param server Server address.
     * @param uuid Meeting UUID.
     * @param key Meeting key.
     * @param userUUID User UUID.
     * @param name User name.
     * @param completion Callback function to be called upon completion.
     */
    void joinMeeting(const char * server, const char * uuid, const char * key, const char * userUUID, const char * name, CompletionCallback completion);

    /**
     * @brief Join a meeting with a token.
     * @param server Server address.
     * @param uuid Meeting UUID.
     * @param token Meeting token.
     * @param userUUID User UUID.
     * @param name User name.
     * @param completion Callback function to be called upon completion.
     */
    void joinMeetingWithToken(const char * server, const char * uuid, const char * token, const char * userUUID, const char * name, CompletionCallback completion);

    /**
     * @brief Join a meeting with a token and JWT.
     * @param server Server address.
     * @param uuid Meeting UUID.
     * @param token Meeting token.
     * @param jwt JSON Web Token.
     * @param name User name.
     * @param completion Callback function to be called upon completion.
     */
    void joinMeetingWithTokenAndJWT(const char * server, const char * uuid, const char * token, const char * jwt, const char * name, CompletionCallback completion);

    /**
     * @brief Enable audio input from a device.
     * @param device Device name.
     * @return True if successful, false otherwise.
     */
    bool enableAudioInput(const char * device);

    /**
     * @brief Disable audio input from a device.
     * @param device Device name.
     * @return True if successful, false otherwise.
     */
    bool disableAudioInput(const char * device);

    /**
     * @brief Enable audio output to a device.
     * @param device Device name.
     * @return True if successful, false otherwise.
     */
    bool enableAudioOutput(const char * device);

    /**
     * @brief Disable audio output to a device.
     * @param device Device name.
     * @return True if successful, false otherwise.
     */
    bool disableAudioOutput(const char * device);

    /**
     * @brief Enable audio input preview from a device.
     * @param device Device name.
     * @return True if successful, false otherwise.
     */
    bool enableAudioInputPreview(const char * device);

    /**
     * @brief Disable audio input preview from a device.
     * @param device Device name.
     * @return True if successful, false otherwise.
     */
    bool disableAudioInputPreview(const char * device);

    /**
     * @brief Enable audio output preview to a device.
     * @param device Device name.
     * @param soundURL URL of the sound to be played.
     * @return True if successful, false otherwise.
     */
    bool enableAudioOutputPreview(const char * device, const char * soundURL);

    /**
     * @brief Disable audio output preview to a device.
     * @param device Device name.
     * @return True if successful, false otherwise.
     */
    bool disableAudioOutputPreview(const char * device);

    /**
     * @brief Set the volume of an audio stream.
     * @param streamId Stream ID.
     * @param volume Volume level (0-255).
     * @return True if successful, false otherwise.
     */
    bool setAudioStreamVolume(const char * streamId, uint8_t volume);

    /**
     * @brief Set the volume of an audio input device.
     * @param device Device name.
     * @param volume Volume level (0-255).
     * @return True if successful, false otherwise.
     */
    bool setAudioInputVolume(const char * device, uint8_t volume);

    /**
     * @brief Set the volume of an audio output device.
     * @param device Device name.
     * @param volume Volume level (0-255).
     * @return True if successful, false otherwise.
     */
    bool setAudioOutputVolume(const char * device, uint8_t volume);

    /**
     * @brief Enable video capture from a camera.
     * @param camera Camera name.
     * @param mode Capture mode.
     * @param enableBlurring Enable or disable background blurring.
     * @return True if successful, false otherwise.
     */
    bool enableVideoCapture(const char * camera, const char * mode, bool enableBlurring = false);

    /**
     * @brief Disable video capture from a camera.
     * @param camera Camera name.
     * @return True if successful, false otherwise.
     */
    bool disableVideoCapture(const char * camera);

    /**
     * @brief Enable video preview from a camera.
     * @param camera Camera name.
     * @param mode Preview mode.
     * @param enableBlurring Enable or disable background blurring.
     * @return True if successful, false otherwise.
     */
    bool enableVideoPreview(const char * camera, const char * mode, bool enableBlurring = false);

    /**
     * @brief Disable video preview from a camera.
     * @param camera Camera name.
     * @return True if successful, false otherwise.
     */
    bool disableVideoPreview(const char * camera);

    /**
     * @brief Enable window sharing.
     * @param windowId Window ID.
     * @param mode Sharing mode.
     * @return True if successful, false otherwise.
     */
    bool enableWindowSharing(const char * windowId, const char * mode);

    /**
     * @brief Disable window sharing.
     * @param windowId Window ID.
     * @return True if successful, false otherwise.
     */
    bool disableWindowSharing(const char * windowId);

    /**
     * @brief Enable network video.
     * @param url Video URL.
     * @param mode Video mode.
     * @param name Video name.
     * @return True if successful, false otherwise.
     */
    bool enableNetworkVideo(const char * url, const char * mode, const char * name);

    /**
     * @brief Disable network video.
     * @param url Video URL.
     * @return True if successful, false otherwise.
     */
    bool disableNetworkVideo(const char * url);

    /**
     * @brief Enable image capture device.
     * @param displayName Display name of the device.
     * @param directory Directory for storing images.
     * @param mode Capture mode.
     * @return Device ID if successful, -1 otherwise.
     */
    int enableImageCaptureDevice(const char * displayName, const char * directory, const char * mode);

    /**
     * @brief Disable image capture device.
     * @param deviceId Device ID.
     * @return True if successful, false otherwise.
     */
    bool disableImageCaptureDevice(int deviceId);

    /**
     * @brief Put an image to the image capture device.
     * @param deviceId Device ID.
     * @param yuv420p_ptr Pointer to the YUV420P image data.
     * @param width Image width.
     * @param height Image height.
     * @param size Image size.
     * @return True if successful, false otherwise.
     */
    bool imageCaptureDevicePutImage(int deviceId, const uint8_t *yuv420p_ptr, int width, int height, int size);

    /**
     * @brief Disable a video stream.
     * @param streamId Stream ID.
     * @return True if successful, false otherwise.
     */
    bool disableVideoStream(const char * streamId);

    /**
     * @brief Enable a video stream.
     * @param streamId Stream ID.
     * @return True if successful, false otherwise.
     */
    bool enableVideoStream(const char * streamId);

    /**
     * @brief Enable a video stream with a specific colorspace.
     * @param streamId Stream ID.
     * @param colorspace Colorspace.
     * @return True if successful, false otherwise.
     */
    bool enableVideoStream(const char * streamId, const char * colorspace);

    /**
     * @brief Pause video frame processing.
     * @param streamId Stream ID.
     */
    void pauseVideoFrameProcessing(const char * streamId);

    /**
     * @brief Resume video frame processing.
     * @param streamId Stream ID.
     */
    void resumeVideoFrameProcessing(const char * streamId);

    /**
     * @brief Exit the meeting.
     */
    void exitMeeting();

    // Logging related

    /**
     * @brief Enable or disable combined logs.
     * @param enable True to enable, false to disable.
     */
    void enableCombinedLogs(bool enable);

    /**
     * @brief Enable or disable log forwarding.
     * @param enable True to enable, false to disable.
     */
    void enableLogForwarding(bool enable);

    /**
     * @brief Enable active logging to a file.
     * @param filename Log file name.
     */
    void enableActiveLogging(const char * filename);

    /**
     * @brief Set the trace level.
     * @param level Trace level.
     */
    void setTraceLevel(int level);

    /**
     * @brief Set the audio trace level.
     * @param level Trace level.
     */
    void audioTraceLevel(int level);

    /**
     * @brief Set the video trace level.
     * @param level Trace level.
     */
    void videoTraceLevel(int level);

    /**
     * @brief Output video trace history to a file.
     * @param filename File name.
     */
    void videoTraceOutputHistory(const char * filename);

    /**
     * @brief Output audio trace history to a file.
     * @param filename File name.
     */
    void audioTraceOutputHistory(const char * filename);

    /**
     * @brief Output core meeting trace history to a file.
     * @param filename File name.
     */
    void coreMeetingTraceOutputHistory(const char * filename);

    /**
     * @brief Get the list of video devices.
     * @param devices Reference to the array of device names
     * @param screens Reference to the array of screen names
     */
    void getVideoDevices(VisionableArray & devices, VisionableArray& screens);

    /**
     * @brief Get the list of audio input devices.
     * @param devices Reference to the array of device names.
     * @param preferred Reference to the preferred device name.
     */
    void getAudioInputDevices(VisionableArray& devices, VisionableString & preferred);

    /**
     * @brief Get the list of audio output devices.
     * @param devices Reference to the array of device names.
     * @param preferred Reference to the preferred device name.
     */
    void getAudioOutputDevices(VisionableArray& devices, VisionableString & preferred);

    /**
     * @brief Get the supported video send resolutions for a device.
     * @param device Device name.
     * @param resolutions Reference to the array of resolution names.
     */
    void getSupportedVideoSendResolutions(const char * device, VisionableArray& resolutions);

    /**
     * @brief Get the list of windows.
     * @param windowList Reference to the array of WindowsInfoArray object.
     * @return Number of windows.
     */
    int getWindowList(WindowsInfoArray& windowList);

    /**
     * @brief Get the thumbnail of a window.
     * @param id Window ID.
     * @param outputFormat Output format.
     * @param destPath Destination path.
     * @param width Thumbnail width.
     * @param height Thumbnail height.
     * @param pThumbBuffer Reference to the thumbnail buffer. Use releaseWindowThumbnail to release memory.
     * @param size Reference to the size of the thumbnail buffer.
     * @return True if successful, false otherwise.
     */
    bool getWindowThumbnail(const char * id, const char * outputFormat, const char * destPath, int width, int height, uint8_t*& pThumbBuffer, uint32_t& size);

    /**
     * @brief Release the thumbnail of a window.
     * @param id Window ID.
     * @param pThumbBuffer Reference to the thumbnail buffer.
     * @return True if successful, false otherwise.
     */
    bool releaseWindowThumbnail(const char * id, uint8_t*& pThumbBuffer);

    /**
     * @brief Play a sound.
     * @param soundData Pointer to the sound data.
     * @param size Size of the sound data.
     * @return Pointer to the sound object.
     */
    const void* playSound(const char* soundData, uint64_t size);

    /**
     * @brief Stop playing a sound.
     * @param soundData Pointer to the sound data.
     * @return True if successful, false otherwise.
     */
    bool stopSound(const char* soundData);

    /**
     * @brief Check if screen sharing is enabled.
     * @param codec Codec name.
     * @return True if screen sharing is enabled, false otherwise.
     */
    bool isScreenShare(const char * codec);

    /**
     * @brief Get the last error message.
     * @return Pointer to the error message.
     */
    VisionableString getLastError();

    /**
     * @brief Get the local participant information.
     * @param participant Reference to the Participant object.
     */
    void getLocalParticipant(Participant& participant);

    /**
     * @brief Get the list of participant IDs.
     * @param ids Reference to the array of participant IDs
     */
    void getParticipantIds(VisionableArray & ids);

    /**
     * @brief Find video information by stream ID.
     * @param streamId Stream ID.
     * @param videoInfo Reference to the VideoInfo object.
     * @return True if successful, false otherwise.
     */
    bool findVideoInfo(const char * streamId, VideoInfo& videoInfo);

    /**
     * @brief Find participant by video stream ID.
     * @param streamId Stream ID.
	 * @param participant Reference to the Participant object.
     * @return True if successful, false otherwise.
     */
    bool findParticipantByVideoStreamId(const char * streamId, Participant& participant);

    /**
     * @brief Find participant by audio stream ID.
     * @param streamId Stream ID.
     * @param participant Reference to the Participant object.
     * @return True if successful, false otherwise.
     */
    bool findParticipantByAudioStreamId(const char * streamId, Participant& participant);

    /**
     * @brief Find participant by UUID.
     * @param uuid Participant UUID.
     * @param participant Reference to the Participant object.
     * @return True if successful, false otherwise.
     */
    bool findParticipantByUUID(const char * uuid, Participant& participant);

    // Extended Logging APIs

    /**
     * @brief Set the log directory.
     * @param path Directory path.
     * @return True if successful, false otherwise.
     */
    bool setLogDirectory(const char * path);

    /**
     * @brief Delete a log file.
     * @param fileName Log file name.
     * @return True if successful, false otherwise.
     */
    bool deleteLogFile(const char * fileName);

    /**
     * @brief Delete all log files.
     * @return True if successful, false otherwise.
     */
    bool deleteAllLogFiles();

    /**
     * @brief Reset the current log file.
     * @return True if successful, false otherwise.
     */
    bool resetCurrentLogFile();

    /**
     * @brief Trim the current log file.
     * @param numBytes Number of bytes to trim.
     * @return True if successful, false otherwise.
     */
    bool trimCurrentLogFile(int numBytes);

    /**
     * @brief Get the list of log files.
     * @param fileNames Reference to the array of log file names.
     * @return True if successful, false otherwise.
     */
    bool getLogFiles(VisionableArray & fileNames);

    /**
     * @brief Flush the current log file.
     * @return True if successful, false otherwise.
     */
    bool flushCurrentLogFile();

    // Time Zone related -- right now only Windows VC++ implements the C++20 chrono::time_zone object

    /**
     * @brief Get the time zone.
     */
    VisionableString getTimeZone();
};



#endif /* MODERATOR_SDK_H */
