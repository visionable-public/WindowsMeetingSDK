#ifndef MODERATOR_SDK_DATASTRUCTURES_H
#define MODERATOR_SDK_DATASTRUCTURES_H

#include <iostream>
#include <map>

#include "MeetingSDKDataStructures.h"
#include "ModeratorSDKEnums.h"

/**
* @brief Moderator response base object
*/
struct DATASTRUCTURE_EXPORT ModeratorResponse
{
	ModeratorResponse() = default;
	virtual ~ModeratorResponse() = default;

	bool granted = false;
};

/**
* @brief Moderator response to device enable response
*/
struct DATASTRUCTURE_EXPORT DeviceControlResponse : public ModeratorResponse
{
	DeviceControlResponse() = default;

	VisionableString prevDeviceId;
	VisionableString prevResolution;

	DeviceControlResponse(const DeviceControlResponse&) = delete;
	DeviceControlResponse& operator=(DeviceControlResponse&) = delete;

	DeviceControlResponse(DeviceControlResponse&&) noexcept;
	DeviceControlResponse& operator=(DeviceControlResponse&&) noexcept;
};

/**
* @brief Moderator response to device selection response
*/
struct DATASTRUCTURE_EXPORT DeviceSelectionResponse : public ModeratorResponse
{
	DeviceSelectionResponse() = default;

	VisionableString prevDeviceId;

	DeviceSelectionResponse(const DeviceSelectionResponse&) = delete;
	DeviceSelectionResponse& operator=(DeviceSelectionResponse&) = delete;

	DeviceSelectionResponse(DeviceSelectionResponse&&) noexcept;
	DeviceSelectionResponse& operator=(DeviceSelectionResponse&&) noexcept;
};

struct DATASTRUCTURE_EXPORT ModeratorPTZCommand
{
	ModeratorPTZCommand() = default;
	~ModeratorPTZCommand() = default;

	VisionableString deviceId;
	ModeratorSDKPTZCommandType commandType = ModeratorSDKPTZCommandType::UnknownPTZType;
	// Abs - step, Relative - PTZ action time ms
	int32_t moveTime = 0;
	int32_t step = 0;

	bool fastAction = false;
};

#endif //MODERATOR_SDK_DATASTRUCTURES_H
