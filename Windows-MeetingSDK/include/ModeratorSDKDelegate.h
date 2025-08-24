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
	*  @param requestId is an Id of request that should be used to notify SDK that request is completed
	* 
	*  @return true if request was sent to processing, else false
	*/
	virtual bool onCurrentDeviceChangeRequested(ModeratorSDKDeviceType deviceType, const char* nextDeviceId, 
		const char* resolution, const int requestId) {
		return false;
	}

	/**
	 *  @brief Notification to a client when SDK requests enabling of device type
	 *
	 *  @param deviceType type of device
	 *  @param nextDeviceId device Id that shall be set
	 *  @param resolution resolution that shall be set, is null for types that are not video or desktop
	 *  @param requestId is an Id of request that should be used to notify SDK that request is completed
	 * 
	 *  @return true if request was sent to processing, else false
	 */
	virtual bool onDeviceEnableRequested(ModeratorSDKDeviceType deviceType, const char* nextDeviceId, 
			const char* resolution, const int requestId) {
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
	virtual bool onEReportSubmitRequested(const char* description, const int requestId) {
		return false;
	}

	/**
	 *  @brief Notification to a moderator about request status related to particular user
	 * NOTE: Can be due to rejected request, or failure during request processing
	 *
	 *  @param participantId ID of the participant
	 *  @param requestType request type
	 *  @param hasFailed status of request, success or failure
	 */
	virtual void onModeratorRequestResponse(const char * participantId, ModeratorSDKRequestType requestType, bool hasFailed) {};

	/**
	 *  @brief Notification to a user that device has been disabled by moderator
	 *
	 *  @param deviceType type of devvice
	 */
	virtual void onModeratorDisabledDevice(ModeratorSDKDeviceType deviceType) {};
};
#endif /* MODERATOR_SDK_DELEGATE_H */
