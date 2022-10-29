namespace RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;

[MessageContract(WrapperName = "GetHostNumberOfEntriesResponse")]
public readonly record struct HostsGetHostNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewHostNumberOfEntries")] ushort HostNumberOfEntries);