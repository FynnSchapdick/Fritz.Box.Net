namespace RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;

[MessageContract(WrapperName = "GetHostListPathResponse")]
public readonly record struct HostsGetHostListPathResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_HostListPath")] string HostListPath);