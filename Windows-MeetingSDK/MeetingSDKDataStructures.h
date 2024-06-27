#pragma once
#include <iostream>
#include <map>

#define DLLEXPORT __declspec (dllexport)

// Exposed Data Structures.


class DLLEXPORT VideoInfo {
public:
    VideoInfo();
    VideoInfo(std::string streamId);
    std::string site();
    std::string name();
    std::string codecName();
    bool local();
    bool active();
    bool ptzStatus();
    uint8_t layout();
    uint32_t width();
    uint32_t height();
public:
    std::string streamId;
};

class DLLEXPORT AudioInfo {
public: 
    AudioInfo(std::string streamId);

    std::string site();
public:
    std::string streamId;
};


class DLLEXPORT Participant {
public:
    Participant(std::string userUUID);
    AudioInfo audioInfo();
    std::map<std::string, VideoInfo> videoInfo();
    std::string displayName();
    bool isLocal();

public:
    std::string userUUID;
};


class DLLEXPORT VideoView {
public:
    VideoView(std::string streamId);

private:
    std::string streamId;
};


