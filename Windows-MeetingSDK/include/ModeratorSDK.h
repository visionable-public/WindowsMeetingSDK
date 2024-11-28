//
//  ModeratorSDK.h
//  MeetingSDK
//
//  Created by John Curley on 5/17/2024
//

#ifndef MODERATOR_SDK_H
#define MODERATOR_SDK_H

#include <iostream>
#include <string>

#include "ModeratorSDKDelegate.h"

#ifdef _MEETING_SDK_EXPORTS_
#define MODERATOR_SDK_API __declspec(dllexport)
#else
#define MODERATOR_SDK_API __declspec(dllimport)
#endif

/**
 * @brief The ModeratorSDK class provides the functionality to interact with RTN using websockets.
 * 
 * This class allows to perform various actions such as connecting to a websocket, sending messages,
 * controlling PTZ (Pan-Tilt-Zoom) devices, and managing the session.
 */
class MODERATOR_SDK_API ModeratorSDK {
public:
    /**
     * @brief Get the shared instance of the ModeratorSDK.
     * 
     * @return The shared instance of the ModeratorSDK.
     */
    static ModeratorSDK* sharedInstance();

public:
    /**
     * @brief Check if the specified user is the local user.
     * 
     * @param userUUID The UUID of the user to check.
     * @return true if the specified user is the local user, false otherwise.
     */
    bool isLocalUser(const char* userUUID);

    /**
     * @brief Connect to the WebSocket server for the specified meeting.
     * 
     * This method establishes a WebSocket connection with the specified meeting using the provided parameters.
     * 
     * @param meetingUUID The UUID of the meeting to connect to.
     * @param generatedUUID The generated UUID for the connection.
     * @param msgServer The message server URL.
     * @param userUUID The UUID of the user connecting to the meeting.
     * @param mjwt The JWT (JSON Web Token) for authentication.
     */
    void connectWebSocket(const char* meetingUUID, const char* generatedUUID, const char* msgServer, const char* userUUID, const char* mjwt);

    /**
     * @brief Set the delegate for receiving callbacks from the ModeratorSDK.
     * 
     * @param delegate The delegate object that implements the ModeratorSDKDelegate interface.
     */
    void setDelegate(ModeratorSDKDelegate* delegate);

    /**
     * @brief Send a message to the specified destination.
     * 
     * This method sends a message to the specified destination using the WebSocket connection.
     * 
     * @param destination The destination of the message.
     * @param message The message to send.
     */
    void sendMessage(const char* destination, const char* message);

    /**
     * @brief Send a PTZ (Pan-Tilt-Zoom) command to the specified user and device.
     * 
     * This method sends a PTZ command to the specified user and device using the WebSocket connection.
     * 
     * @param user The UUID of the user to send the command to.
     * @param device The UUID of the device to send the command to.
     * @param command The PTZ command to send.
     * @return true if the command was sent successfully, false otherwise.
     */
    bool sendPTZCommand(const char* user, const char* device, const char* command);

    /**
     * @brief Set whether remote PTZ control is allowed.
     * 
     * @param allowed true to allow remote PTZ control, false to disallow.
     */
    void setRemotePTZAllowed(bool allowed);

    /**
     * @brief Get whether remote PTZ control is allowed.
     * 
     * @return true if remote PTZ control is allowed, false otherwise.
     */
    bool getRemotePTZAllowed();

    /**
     * @brief Send an update for the device list.
     * 
     * This method sends an update for the device list using the WebSocket connection.
     */
    void sendDeviceListUpdate();

    /**
     * @brief Close the session.
     * 
     * This method closes the session and disconnects from the WebSocket server.
     */
    void closeSession();
};

#endif /* MODERATOR_SDK_H */
