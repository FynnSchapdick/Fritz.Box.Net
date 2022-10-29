namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetWpsInfoResponse")]
public readonly record struct WlanConfigurationGetWpsInfoResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_WPSMode")] string WpsMode,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_WPSStatus")] string WpsStatus);