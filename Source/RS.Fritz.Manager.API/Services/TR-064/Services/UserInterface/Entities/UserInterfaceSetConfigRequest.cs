namespace RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;

[MessageContract(WrapperName = "SetConfig")]
public readonly record struct UserInterfaceSetConfigRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AutoUpdateMode")] string AutoUpdateMode);