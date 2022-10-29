namespace RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;

[MessageContract(WrapperName = "GetChangeCounterResponse")]
public readonly record struct HostsGetChangeCounterResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_ChangeCounter")] uint ChangeCounter);