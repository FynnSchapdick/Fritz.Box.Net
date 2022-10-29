namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetSsIdResponse")]
public readonly record struct WlanConfigurationGetSsIdResponse(
    [property: MessageBodyMember(Name = "NewSSID")] string SsId);