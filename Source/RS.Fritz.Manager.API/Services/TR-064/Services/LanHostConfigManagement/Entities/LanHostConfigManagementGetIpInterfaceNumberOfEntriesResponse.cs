namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement.Entities;

[MessageContract(WrapperName = "GetIpInterfaceNumberOfEntriesResponse")]
public readonly record struct LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewIPInterfaceNumberOfEntries")] ushort IpInterfaceNumberOfEntries);