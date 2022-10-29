namespace RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer.Entities;

[MessageContract(WrapperName = "SetManagementServerPassword")]
public readonly record struct ManagementServerSetManagementServerPasswordRequest(
    [property: MessageBodyMember(Name = "NewPassword")] string Password);