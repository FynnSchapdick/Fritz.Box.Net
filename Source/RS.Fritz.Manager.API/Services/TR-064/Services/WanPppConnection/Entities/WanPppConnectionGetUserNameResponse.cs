namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanPppConnection.Entities;

[MessageContract(WrapperName = "GetUserNameResponse")]
public readonly record struct WanPppConnectionGetUserNameResponse(
    [property: MessageBodyMember(Name = "NewUserName")] string UserName);