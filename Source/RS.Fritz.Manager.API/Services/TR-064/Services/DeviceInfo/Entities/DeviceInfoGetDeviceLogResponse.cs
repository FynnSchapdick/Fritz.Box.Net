namespace RS.Fritz.Manager.API.Services.TR_064.Services.DeviceInfo.Entities;

[MessageContract(WrapperName = "GetDeviceLogResponse")]
public readonly record struct DeviceInfoGetDeviceLogResponse(
    [property: MessageBodyMember(Name = "NewDeviceLog")] string DeviceLog);