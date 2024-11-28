//
//  ModeratorSDKDelegate.h
//  MeetingSDK
//
//  Created by John Curley on 6/10/2024
//

#ifndef MODERATOR_SDK_DELEGATE_H
#define MODERATOR_SDK_DELEGATE_H

#include <string>

/**
 * @brief The ModeratorSDKDelegate class is an interface for receiving different events from the ModeratorSDK.
 */
class ModeratorSDKDelegate {
public:
	/**
  * @brief This method is called when the device list is updated.
  * 
  * @param deviceJSON The JSON string containing the updated device list.
  */
	virtual void deviceListUpdated(const char * deviceJSON) {};
};
#endif /* MODERATOR_SDK_DELEGATE_H */
