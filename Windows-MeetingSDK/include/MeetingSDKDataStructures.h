#ifndef MEETING_SDK_DATASTRUCTURES_H
#define MEETING_SDK_DATASTRUCTURES_H

#include <iostream>
#include <map>

#ifdef _MEETING_SDK_EXPORTS_
#define DATASTRUCTURE_EXPORT __declspec(dllexport)
#else
#define DATASTRUCTURE_EXPORT __declspec(dllimport)
#endif

// Data encapsulation classes for allocated by SDK objects
class DATASTRUCTURE_EXPORT VisionableString {
private:
    char* m_value;

public:
    VisionableString();
    /**
	* @brief Constructor for VisionableString. Passed string is copied into the object.
	* This class should not be used by the caller for automatic memory management, only for communication with the SDK.
    */
    VisionableString(const char* value);

    /**
	 * @brief Destructor for VisionableString. Frees the memory allocated for the string.
     */
    ~VisionableString();

    VisionableString(const VisionableString&) = delete;
    VisionableString& operator=(VisionableString&) = delete;

    VisionableString(VisionableString&&) noexcept;
    VisionableString& operator=(VisionableString&&) noexcept;

    void setValue(const char* value) noexcept;

    /**
     * @brief Get the value of the VisionableString.
     * @return const char* The value of the string.
     */
    const char* getValue() const;
};

class DATASTRUCTURE_EXPORT VisionableArray {
private:
    char** m_value;
    uint64_t m_size;

public:
    /**
	* @brief Constructor for VisionableArray that is storing dynamic array of strings. Passed array is not copied, only the pointer is stored. From moment of passing data into constructor
	* it is owned by this object and will be freed in destructor.
    * This class should not be used by the caller for automatic memory management, only for communication with the SDK.
    * 
    */
    VisionableArray();
    VisionableArray(char** value, uint64_t size);

    /**
	 * @brief Destructor for VisionableArray. Frees the memory allocated for the array of strings.
     */
    ~VisionableArray();

    VisionableArray(const VisionableArray&) = delete;
    VisionableArray& operator=(VisionableArray&) = delete;

    VisionableArray(VisionableArray&&) noexcept;
    VisionableArray& operator=(VisionableArray&&) noexcept;

    /**
     * @brief Get the value of the VisionableArray.
     * @return const char** The array of strings.
     */
    const char** getValue() const;

    /**
     * @brief Get the size of the VisionableArray.
     * @return uint64_t The size of the array.
     */
    uint64_t getSize() const;
};


template<typename T>
class DATASTRUCTURE_EXPORT ObjectsArray {
public:
    ObjectsArray();
    /**
    * @brief Constructor for ObjectsArray. Passed array is not copied, only the pointer is stored.
    * This class should be used for automatic memory management of the array of T.
    */
    ObjectsArray(T* infoArray, uint64_t size);

    /**
     * @brief Destructor for ObjectsArray. Frees the memory allocated for the array of T.
     */
    ~ObjectsArray();

    ObjectsArray(const ObjectsArray&) = delete;
    ObjectsArray& operator=(ObjectsArray&) = delete;

    ObjectsArray(ObjectsArray&&) noexcept;
    ObjectsArray& operator=(ObjectsArray&&) noexcept;

    T* getObjectsArray() const;
    uint64_t getSize() const;

private:
    T* m_infoArray;
    uint64_t m_size;
};

// Exposed Data Structures.
class DATASTRUCTURE_EXPORT WindowInfo {
public:
    WindowInfo();
    WindowInfo(const char * windowName, uint64_t windowId);
    WindowInfo(const WindowInfo&) = delete;
    WindowInfo& operator=(WindowInfo&) = delete;

    WindowInfo(WindowInfo&&) noexcept;
    WindowInfo& operator=(WindowInfo&&) noexcept;

    ~WindowInfo();

    /**
     * @brief Get the window ID.
     * @return uint64_t The window ID.
     */
    uint64_t getWindowId() const;

    /**
     * @brief Get the window name.
     * @return const char* The window name.
     */
    const char* getWindowName() const;

private:
    uint64_t windowId;
    char* windowName;
};

class DATASTRUCTURE_EXPORT VideoInfo {
public:
    VideoInfo();
    VideoInfo(const char * streamId);

    VideoInfo(const VideoInfo&) = delete;
    VideoInfo& operator=(VideoInfo&) = delete;

    VideoInfo(VideoInfo&&) noexcept;
    VideoInfo& operator=(VideoInfo&&) noexcept;

    ~VideoInfo();

    /**
     * @brief Get the site name.
     * @note The returned object supports only move semantics,
        internal data should not be freed by a caller. It is automatically freed when the object is destroyed.
     * @return char* The site name.
     */
    VisionableString site() const;

    /**
     * @brief Get the name.
     * @note The returned object supports only move semantics,
        internal data should not be freed by a caller. It is automatically freed when the object is destroyed.
     * @return char* The name.
     */
    VisionableString name() const;

    /**
     * @brief Get the stream ID.
     * @return const char* The stream ID.
     */
    const char * getStreamId() const;

    /**
     * @brief Get the codec name.
     * @note The returned object supports only move semantics,
        internal data should not be freed by a caller. It is automatically freed when the object is destroyed.
     * @return char* The codec name.
     */
    VisionableString codecName() const;

    /**
     * @brief Check if the video is local.
     * @return bool True if local, false otherwise.
     */
    bool local() const;

    /**
     * @brief Check if the video is active.
     * @return bool True if active, false otherwise.
     */
    bool active() const;

    /**
     * @brief Get the PTZ (Pan-Tilt-Zoom) status.
     * @return bool True if PTZ is enabled, false otherwise.
     */
    bool ptzStatus() const;

    /**
     * @brief Get the layout type.
     * @return uint8_t The layout type.
     */
    uint8_t layout() const;

    /**
     * @brief Get the video width.
     * @return uint32_t The video width.
     */
    uint32_t width() const;

    /**
     * @brief Get the video height.
     * @return uint32_t The video height.
     */
    uint32_t height() const;

private:
    char * streamId;
};

class DATASTRUCTURE_EXPORT AudioInfo {
public: 
    AudioInfo();
    AudioInfo(const char * streamId);

    AudioInfo(AudioInfo&) = delete;
    AudioInfo& operator=(AudioInfo&) = delete;

    AudioInfo(AudioInfo&&) noexcept;
    AudioInfo& operator=(AudioInfo&&) noexcept;

    ~AudioInfo();

    /**
     * @brief Get the site name.
     * @note The returned object supports only move semantics,
        internal data should not be freed by a caller. It is automatically freed when the object is destroyed.
     * @return char* The site name.
     */
    VisionableString site() const;

    /**
     * @brief Get the stream ID.
     * @return const char* The stream ID.
     */
    const char* getStreamId() const;

private:
    char * streamId;
};

class DATASTRUCTURE_EXPORT VideoInfoArray {
public:
    VideoInfoArray();
    VideoInfoArray(VideoInfo* infoArray, uint64_t size);
    ~VideoInfoArray();

    VideoInfoArray(const VideoInfoArray&) = delete;
    VideoInfoArray& operator=(VideoInfoArray&) = delete;

    VideoInfoArray(VideoInfoArray&&) noexcept;
    VideoInfoArray& operator=(VideoInfoArray&&) noexcept;

	VideoInfo* getInfoArray() const;
	uint64_t getSize() const;

private:
	VideoInfo* m_infoArray;
	uint64_t m_size;
};

class DATASTRUCTURE_EXPORT Participant {
public:
    Participant();
    Participant(const char * userUUID);

    ~Participant();

    Participant(const Participant&) = delete;
    Participant& operator=(Participant&) = delete;

    Participant(Participant&&) noexcept;
    Participant& operator=(Participant&&) noexcept;

    /**
     * @brief Get participant audio info.
     * @note The returned object supports only move semantics,
        internal data should not be freed by a caller. It is automatically freed when the object is destroyed.
     * @return AudioInfo The audio info.
     */
    AudioInfo audioInfo() const;

    /**
     * @brief Get participant video info array.
	 * @note The returned object supports only move semantics, 
        internal data should not be freed by a caller. It is automatically freed when the object is destroyed.
     * @param unsigned int& count The count of video info.
     * @return VideoInfoArray Video info array.
     */
    VideoInfoArray videoInfo() const;

    /**
     * @brief Get the display name.
     * @note The returned object supports only move semantics,
        internal data should not be freed by a caller. It is automatically freed when the object is destroyed.
     * @return char* The display name.
     */
    VisionableString displayName() const;

    /**
     * @brief Check if the participant is local.
     * @return bool True if local, false otherwise.
     */
    bool isLocal() const;

    /**
     * @brief Get the user UUID.
     * @return const char* The user UUID.
     */
    const char* getUserUUID() const;

private:
    char * userUUID;
};

class DATASTRUCTURE_EXPORT VideoView {
public:
    VideoView(const char * streamId);
    ~VideoView();

    VideoView(const VideoView&) = delete;
    VideoView& operator=(VideoView&) = delete;

private:
    char* streamId;
};

class DATASTRUCTURE_EXPORT VideoStreamStatistics {
public:
    VideoStreamStatistics() = default;

    VideoStreamStatistics(const VideoStreamStatistics&) = delete;
    VideoStreamStatistics& operator=(VideoStreamStatistics&) = delete;

    VideoStreamStatistics(VideoStreamStatistics&&) noexcept;
    VideoStreamStatistics& operator=(VideoStreamStatistics&&) noexcept;

    VisionableString streamId;
    VisionableString siteName;
    VisionableString streamName;
    VisionableString userUUID;
    VisionableString protocol;
    VisionableString codec;
    uint64_t droppedCtrl;
    uint64_t droppedData;
    int32_t framerate;
    int32_t kbps;
    int32_t upstreamLatency;
    int32_t upstreamLoss;
    int32_t upstreamJitter;
    int32_t downstreamLatency;
    int32_t downstreamLoss;
    int32_t downstreamJitter;
    int32_t bars;
};

class DATASTRUCTURE_EXPORT VideoStatistics {
public:
    VideoStatistics() = default;

    VideoStatistics(const VideoStatistics&) = delete;
    VideoStatistics& operator=(VideoStatistics&) = delete;

    VideoStatistics(VideoStatistics&&) noexcept;
    VideoStatistics& operator=(VideoStatistics&&) noexcept;

    ObjectsArray<VideoStreamStatistics> streamConditions;
    uint64_t kBytesReceived;
    uint64_t kBytesSent;
    uint64_t dataBytesDropped;
    uint64_t ctrlBytesDropped;
    int32_t cpuUsage;
    int32_t bars;
    int32_t lastNatArrival;
    int32_t connectionStatus;
};


class DATASTRUCTURE_EXPORT AudioStreamStatistic {
public:
    AudioStreamStatistic() = default;

    AudioStreamStatistic(const AudioStreamStatistic&) = delete;
    AudioStreamStatistic& operator=(AudioStreamStatistic&) = delete;

    AudioStreamStatistic(AudioStreamStatistic&&) noexcept;
    AudioStreamStatistic& operator=(AudioStreamStatistic&&) noexcept;

    VisionableString streamId;
    VisionableString name;
    VisionableString userUUID;
    VisionableString codec;
    VisionableString protocol;
    uint64_t droppedCtrl;
    uint64_t droppedData;
    int32_t upstreamLatency;
    int32_t upstreamLoss;
    int32_t upstreamJitter;
    int32_t downstreamLatency;
    int32_t downstreamLoss;
    int32_t downstreamJitter;
    int32_t bars;
};

class DATASTRUCTURE_EXPORT AudioStatistic {
public:
    AudioStatistic() = default;

    AudioStatistic(const AudioStatistic&) = delete;
    AudioStatistic& operator=(AudioStatistic&) = delete;

    AudioStatistic(AudioStatistic&&) noexcept;
    AudioStatistic& operator=(AudioStatistic&&) noexcept;

    ObjectsArray<AudioStreamStatistic> audioConditions;
    VisionableString upstreamCodec;
    VisionableString downstreamCodec;
    uint64_t kBytesReceived;
    uint64_t kBytesSent;
    uint64_t dataBytesDropped;
    uint64_t ctrlBytesDropped;
    int32_t lastNatArrival;
    int32_t bars;
    int32_t connectionStatus;
    int32_t upstreamFps;
    int32_t upstreamKbps;
    int32_t upstreamLoss;
    int32_t upstreamLatency;
    int32_t upstreamJitter;
    int32_t downstreamFps;
    int32_t downstreamKbps;
    int32_t downstreamLoss;
    int32_t downstreamLatency;
    int32_t downstreamJitter;
};

#endif //MEETING_SDK_DATASTRUCTURES_H