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

#if defined(_WINDLL)
#define DLLEXPORT __declspec (dllexport)
#else
#define DLLEXPORT
#endif

class DLLEXPORT ModeratorSDK {
private:
    // Singleton implementation
    static ModeratorSDK* instance;

    friend class MeetingSDK;
public:
    static ModeratorSDK* sharedInstance();

public:
    ModeratorSDK();
    ~ModeratorSDK();
    bool isLocalUser(std::string userUUID);
    void connectWebSocket(std::string meetingUUID, std::string generatedUUID, std::string msgServer, std::string userUUID, std::string mjwt);
    void setDelegate(ModeratorSDKDelegate* delegate) {
        std::cout << "ModeratorSDK::setDelegate called!" << std::endl;
        this->delegate = delegate;
    }

    void sendMessage(std::string destination, std::string message);
    bool sendPTZCommand(std::string user, std::string device, std::string command);
    void setRemotePTZAllowed(bool allowed);
    bool getRemotePTZAllowed();

    void sendDeviceListUpdate();
    void closeSession();

private:
    void webSocketListener();
    void processDirectMessage(void* parsed);
    void processIncomingWSMessage(std::string message);
    void send(std::string message);

private:
    void *impl;

    ModeratorSDKDelegate* delegate;

    bool wsListenerActive;
    std::string wsMyChannelName;
    std::string wsDeviceInfoChannel;
    std::string wsMeetingUUID;

    bool remotePTZAllowed;
};

#endif /* MODERATOR_SDK_H */
