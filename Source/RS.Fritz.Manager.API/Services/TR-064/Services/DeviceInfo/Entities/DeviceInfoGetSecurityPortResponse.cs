namespace RS.Fritz.Manager.API.Services.TR_064.Services.DeviceInfo.Entities;

[MessageContract(WrapperName = "GetSecurityPortResponse")]
public readonly record struct DeviceInfoGetSecurityPortResponse(
    [property: MessageBodyMember(Name = "NewSecurityPort")] ushort SecurityPort);