namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetBssIdResponse")]
public readonly record struct WlanConfigurationGetBssIdResponse(
    [property: MessageBodyMember(Name = "NewBSSID")] string BssId);