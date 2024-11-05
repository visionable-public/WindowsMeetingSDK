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

#ifdef _MEETING_SDK_EXPORTS_
#define VISIONABLE_API __declspec(dllexport)
#else
#define VISIONABLE_API __declspec(dllimport)
#endif

typedef void(*IntializeMeetingCallback)(bool, const char*);
typedef void(*AuthenticateCallback)(const char*);

/**
 * @class VisionableAPI
 * @brief The VisionableAPI class provides functionality for interacting with the Visionable API.
 * 
 * The VisionableAPI class provides methods for authentication and initializing meetings.
 */
class VISIONABLE_API VisionableAPI {
public:
    /**
     * @brief Get the shared instance of the VisionableAPI class.
     * @return The shared instance of the VisionableAPI class.
     */
    static VisionableAPI* sharedInstance();

public:
    /**
     * @brief Authenticate with the Visionable API.
     * @param server The server URL.
     * @param id The user ID.
     * @param password The user password.
     * @param completion The callback function to be called after authentication.
     */
    void authenticate(const char* server, const char* id, const char* password, AuthenticateCallback completion);

    /**
     * @brief Initialize a meeting with the Visionable API.
     * @param server The server URL.
     * @param meetingUUID The meeting UUID.
     * @param completion The callback function to be called after meeting initialization.
     * @return True if the meeting is successfully initialized, false otherwise.
     */
    bool initializeMeeting(const char* server, const char* meetingUUID, IntializeMeetingCallback completion);

    /**
     * @brief Initialize a meeting with the Visionable API using a token.
     * @param server The server URL.
     * @param meetingUUID The meeting UUID.
     * @param token The authentication token.
     * @param completion The callback function to be called after meeting initialization.
     * @return True if the meeting is successfully initialized, false otherwise.
     */
    bool initializeMeeting(const char* server, const char* meetingUUID, const char* token, IntializeMeetingCallback completion);
};

#endif /* VISIONABLE_API_H */
