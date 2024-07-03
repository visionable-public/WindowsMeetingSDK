//
//  ModeratorSDKDelegate.h
//  MeetingSDK
//
//  Created by John Curley on 6/10/2024
//

#ifndef MODERATOR_SDK_DELEGATE_H
#define MODERATOR_SDK_DELEGATE_H

#include <string>

class ModeratorSDKDelegate {
public:
	virtual void deviceListUpdated(const std::string& deviceJSON) {};
};
#endif /* MODERATOR_SDK_DELEGATE_H */
