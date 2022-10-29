namespace RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer.Entities;

[MessageContract(WrapperName = "SetManagementServerUrl")]
public readonly record struct ManagementServerSetManagementServerUrlRequest(
    [property: MessageBodyMember(Name = "NewURL")] string Url);