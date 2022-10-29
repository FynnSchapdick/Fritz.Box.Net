namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity.Entities;

[MessageContract(WrapperName = "GetUserListResponse")]
public readonly record struct LanConfigSecurityGetUserListResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UserList")] string UserList);