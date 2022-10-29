namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetBeaconTypeResponse")]
public readonly record struct WlanConfigurationGetBeaconTypeResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_PossibleBeaconTypes")] string PossibleBeaconTypes);