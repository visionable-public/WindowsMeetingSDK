#pragma once
#include <iostream>
#include <map>

#define DLLEXPORT __declspec (dllexport)

// Exposed Data Structures.


class DLLEXPORT VideoInfo {
public:
    VideoInfo();
    VideoInfo(std::string streamId);
    std::string site() const;
    std::string name() const;
    std::string codecName() const;
    bool local() const;
    bool active() const;
    bool ptzStatus() const;
    uint8_t layout() const;
    uint32_t width() const;
    uint32_t height() const;
public:
    std::string streamId;
};

class DLLEXPORT AudioInfo {
public: 
    AudioInfo() {}
    AudioInfo(std::string streamId);

    std::string site() const;
public:
    std::string streamId;
};


class DLLEXPORT Participant {
public:
    Participant() {}
    Participant(std::string userUUID);
    AudioInfo audioInfo() const;
    std::map<std::string, VideoInfo> videoInfo() const;
    std::string displayName() const;
    bool isLocal() const;

public:
    std::string userUUID;
};


class DLLEXPORT VideoView {
public:
    VideoView(std::string streamId);

private:
    std::string streamId;
};


