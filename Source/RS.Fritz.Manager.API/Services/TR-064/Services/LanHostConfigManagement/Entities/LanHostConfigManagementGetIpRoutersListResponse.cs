namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement.Entities;

[MessageContract(WrapperName = "GetIpRoutersListResponse")]
public readonly record struct LanHostConfigManagementGetIpRoutersListResponse(
    [property: MessageBodyMember(Name = "NewIPRouters")] string IpRouters);