namespace RS.Fritz.Manager.API.Services.TR_064.Services.DeviceInfo.Entities;

[MessageContract(WrapperName = "SetProvisioningCode")]
public readonly record struct DeviceInfoSetProvisioningCodeRequest(
    [property: MessageBodyMember(Name = "NewProvisioningCode")] string ProvisioningCode);