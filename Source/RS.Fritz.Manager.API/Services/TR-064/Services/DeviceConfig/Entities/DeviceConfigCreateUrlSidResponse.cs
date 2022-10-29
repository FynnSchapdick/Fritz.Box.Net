namespace RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig.Entities;

[MessageContract(WrapperName = "CreateUrlSidResponse")]
public readonly record struct DeviceConfigCreateUrlSidResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UrlSID")] string UrlSid);