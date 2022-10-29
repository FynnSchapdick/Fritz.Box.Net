namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement.Entities;

[MessageContract(WrapperName = "GetDnsServersResponse")]
public readonly record struct LanHostConfigManagementGetDnsServersResponse(
    [property: MessageBodyMember(Name = "NewDNSServers")] string DnsServers);