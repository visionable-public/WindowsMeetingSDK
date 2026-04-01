#ifndef MODERATOR_SDK_ENUMS_H
#define MODERATOR_SDK_ENUMS_H

/**
 * @brief The ModeratorSDKDeviceType enum that represents device type supported by ModeratorSDK requests
 *
 * NOTE: Not all requests support all types (e.g select supports only audio and mic)
 */
enum ModeratorSDKDeviceType
{
	audio,
	microphone,
	video,
	desktop
};

/**
 * @brief The ModeratorSDKRequestType enum that represents request type supported by SDK
 */
enum ModeratorSDKRequestType
{
	enable,
	disable,
	set,
	submitEReport
};

/**
* @brief The ModeratorSDKPTZCommandType enum that represents command type supported by ModeratorSDK
*/
enum ModeratorSDKPTZCommandType
{
	UnknownPTZType = -1,
	PanLeft,
	PanRight,
	TiltUp,
	TiltDown,
	ZoomIn,
	ZoomOut,
	StopMove,
	StopZoom
};


#endif // MODERATOR_SDK_ENUMS_H