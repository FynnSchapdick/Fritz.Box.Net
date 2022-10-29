namespace RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;

[MessageContract(WrapperName = "DoManualUpdate")]
public readonly record struct UserInterfaceDoManualUpdateRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DownloadURL")] string DownloadUrl,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AllowDowngrade")] bool AllowDowngrade);