namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement.Entities;

[MessageContract(WrapperName = "GetSubnetMaskResponse")]
public readonly record struct LanHostConfigManagementGetSubnetMaskResponse(
    [property: MessageBodyMember(Name = "NewSubnetMask")] string SubnetMask);