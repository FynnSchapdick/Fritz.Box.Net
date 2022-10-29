namespace RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;

[MessageContract(WrapperName = "GetInternationalConfigResponse")]
public readonly record struct UserInterfaceGetInternationalConfigResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Language")] string Language,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Country")] string Country,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Annex")] string Annex,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_LanguageList")] string LanguageList,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_CountryList")] string CountryList,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AnnexList")] string AnnexList);