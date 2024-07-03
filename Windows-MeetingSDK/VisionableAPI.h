//
//  VisionableAPI.h
//  MeetingSDK
//
//  Created by John Curley on 5/17/2024
//

#ifndef VISIONABLE_API_H
#define VISIONABLE_API_H

#include <string>
#include <functional>
#include <vector>

#if defined(_WINDLL)
#define DLLEXPORT __declspec (dllexport)
#else
#define DLLEXPORT
#endif

class DLLEXPORT VisionableAPI {
private:
    // Singleton implementation
    static VisionableAPI* instance;

public:
    static VisionableAPI* sharedInstance();
    friend class MeetingSDK;

public:
    VisionableAPI();
    void authenticate(std::string server, std::string id, std::string password, std::function<void(std::string)> completion);
    bool initializeMeeting(std::string server, std::string meetingUUID, std::function<void(bool, std::string)> completion);
    bool initializeMeeting(std::string server, std::string meetingUUID, std::string token, std::function<void(bool, std::string)> completion);

private:
    // Utility functions
    std::vector<std::string> splitString(const std::string& source);
    std::string joinString(std::vector<std::string>components);

};

#endif /* VISIONABLE_API_H */
