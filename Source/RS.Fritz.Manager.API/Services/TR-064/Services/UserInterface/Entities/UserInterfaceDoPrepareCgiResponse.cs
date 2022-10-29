namespace RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;

[MessageContract(WrapperName = "DoPrepareCgiResponse")]
public readonly record struct UserInterfaceDoPrepareCgiResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_CGI")] string Cgi,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SessionID")] string SessionId);