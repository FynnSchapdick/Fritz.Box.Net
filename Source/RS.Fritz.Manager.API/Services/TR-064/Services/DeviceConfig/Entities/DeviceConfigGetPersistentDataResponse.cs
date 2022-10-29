namespace RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig.Entities;

[MessageContract(WrapperName = "GetPersistentDataResponse")]
public readonly record struct DeviceConfigGetPersistentDataResponse(
    [property: MessageBodyMember(Name = "NewPersistentData")] string PersistentData);