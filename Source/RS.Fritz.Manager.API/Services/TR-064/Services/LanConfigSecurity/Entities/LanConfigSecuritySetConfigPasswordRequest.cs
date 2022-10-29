namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity.Entities;

[MessageContract(WrapperName = "SetConfigPassword")]
public readonly record struct LanConfigSecuritySetConfigPasswordRequest(
    [property: MessageBodyMember(Name = "NewPassword")] string Password);