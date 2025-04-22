//
//  ModeratorSDKDelegate.h
//  MeetingSDK
//
//  Created by John Curley on 6/10/2024
//

#ifndef MODERATOR_SDK_DELEGATE_H
#define MODERATOR_SDK_DELEGATE_H

#include "MeetingSDKDataStructures.h"
#include "ModeratorSDKEnums.h"
#include <string>


typedef void(*enableDeviceRequestCallback)(const char* prevDeviceId, const char* prevResolution, bool granted, void* userData);
typedef void(*changeDeviceRequestCallback)(const char* prevDeviceId, bool granted, void* userData);
typedef void(*reportSubmitCallback)(bool granted, void* userData);

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

	/**
	*  @brief Notification to a client when SDK requests change of current device type
	*
	*  @param deviceType type of device
	*  @param nextDeviceId device Id that shall be set
	*  @param resolution resolution that shall be set, is null for types that are not video or desktop
	*  @param callback function that accepts prev device id (NOTE: This device shall be disabled during switch)
	*  @param userData a data from SDK that should be forwared to callback, when client completes processing request
	* 
	*  @return true if request was sent to processing, else false
	*/
	virtual bool onCurrentDeviceChangeRequested(ModeratorSDKDeviceType deviceType, const char* nextDeviceId, 
		const char* resolution, changeDeviceRequestCallback callback, void * userData) {
		return false;
	}

	/**
	 *  @brief Notification to a client when SDK requests enabling of device type
	 *
	 *  @param deviceType type of device
	 *  @param nextDeviceId device Id that shall be set
	 *  @param resolution resolution that shall be set, is null for types that are not video or desktop
	 *	@param callback function that accepts prev device id and resolution (NOTE: If nextDeviceId is empty, client should consider that currently selected device is target)
	 *	@param userData a data from SDK that should be forwared to callback, when client completes processing request
	 * 
	 *  @return true if request was sent to processing, else false
	 */
	virtual bool onDeviceEnableRequested(ModeratorSDKDeviceType deviceType, const char* nextDeviceId, 
			const char* resolution, enableDeviceRequestCallback callback, void* userData) {
		return false;
	}

	/**
	 *  @brief Notification to a client when SDK request submit of eReport
	 *
	 *  @param description a description of eReport
	 *  @param callback function that is returning if request submitted or rejected
	 *	@param userData a data from SDK that should be forwared to callback, when client completes processing request
	 *
	 *  @return true if request was sent to processing, else false
	 */
	virtual bool onEReportSubmitRequested(const char* description, reportSubmitCallback callback, void* userData) {
		return false;
	}

	/**
	 *  @brief Notification to a moderator that request execution failed
	 * NOTE: Can be due to rejected request, or failure during request processing
	 *
	 *  @param participantId ID of the participant
	 *  @param requestType request type
	 */
	virtual void onModeratorRequestFailed(const char * participantId, ModeratorSDKRequestType requestType) {};
};
#endif /* MODERATOR_SDK_DELEGATE_H */
