namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetBeaconAdvertisementResponse")]
public readonly record struct WlanConfigurationGetBeaconAdvertisementResponse(
    [property: MessageBodyMember(Name = "NewBeaconAdvertisementEnabled")] bool BeaconAdvertisementEnabled);