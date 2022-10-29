namespace RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;

[MessageContract(WrapperName = "GetMeshListPathResponse")]
public readonly record struct HostsGetMeshListPathResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_MeshListPath")] string MeshListPath);