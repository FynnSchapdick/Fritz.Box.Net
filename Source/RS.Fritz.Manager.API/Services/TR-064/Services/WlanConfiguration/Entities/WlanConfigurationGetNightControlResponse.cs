namespace RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

[MessageContract(WrapperName = "GetNightControlResponse")]
public readonly record struct WlanConfigurationGetNightControlResponse(
    [property: MessageBodyMember(Name = "NewNightControl")] string NightControl,
    [property: MessageBodyMember(Name = "NewNightTimeControlNoForcedOff")] bool NightTimeControlNoForcedOff);