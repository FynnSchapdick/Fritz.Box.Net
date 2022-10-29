namespace RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;

[MessageContract(WrapperName = "DoUpdateResponse")]
public readonly record struct UserInterfaceDoUpdateResponse(
    [property: MessageBodyMember(Name = "NewUpgradeAvailable")] bool UpgradeAvailable,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UpdateState")] string UpdateState);