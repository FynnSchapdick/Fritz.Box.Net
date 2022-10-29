namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity.Entities;

[MessageContract(WrapperName = "GetAnonymousLoginResponse")]
public readonly record struct LanConfigSecurityGetAnonymousLoginResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AnonymousLoginEnabled")] bool AnonymousLoginEnabled,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_ButtonLoginEnabled")] bool ButtonLoginEnabled);