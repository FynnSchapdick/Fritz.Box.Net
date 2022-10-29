namespace RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;

[MessageContract(WrapperName = "SetInternationalConfig")]
public readonly record struct UserInterfaceSetInternationalConfigRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Language")] string Language,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Country")] string Country,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Annex")] string Annex);