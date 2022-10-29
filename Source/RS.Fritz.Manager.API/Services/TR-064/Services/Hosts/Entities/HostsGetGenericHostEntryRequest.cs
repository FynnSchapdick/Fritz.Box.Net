namespace RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;

[MessageContract(WrapperName = "GetGenericHostEntry")]
public readonly record struct HostsGetGenericHostEntryRequest(
    [property: MessageBodyMember(Name = "NewIndex")] ushort Index);