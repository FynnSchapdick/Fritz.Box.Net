namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetWlanDeviceListPathResponse")]
public readonly record struct WlanConfigurationGetWlanDeviceListPathResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_WLANDeviceListPath")] string WlanDeviceListPath);