namespace RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;

[MessageContract(WrapperName = "CheckUpdate")]
public readonly record struct UserInterfaceCheckUpdateRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_LaborVersion")] string LaborVersion);