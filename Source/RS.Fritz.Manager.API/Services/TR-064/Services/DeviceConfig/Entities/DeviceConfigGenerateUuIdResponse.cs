namespace RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig.Entities;

[MessageContract(WrapperName = "GenerateUuIdResponse")]
public readonly record struct DeviceConfigGenerateUuIdResponse(
    [property: MessageBodyMember(Name = "NewUUID")] string UuId);