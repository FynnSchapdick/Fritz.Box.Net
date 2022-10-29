namespace RS.Fritz.Manager.API.Services.TR_064.WanConnectionSharedEntities;

[MessageContract(WrapperName = "GetDnsServersResponse")]
public readonly record struct WanConnectionGetDnsServersResponse(
    [property: MessageBodyMember(Name = "NewDNSServers")] string DnsServers);