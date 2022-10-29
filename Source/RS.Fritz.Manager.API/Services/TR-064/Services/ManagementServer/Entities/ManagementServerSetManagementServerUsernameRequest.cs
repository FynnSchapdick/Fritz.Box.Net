namespace RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer.Entities;

[MessageContract(WrapperName = "SetManagementServerUsername")]
public readonly record struct ManagementServerSetManagementServerUsernameRequest(
    [property: MessageBodyMember(Name = "NewUsername")] string Username);