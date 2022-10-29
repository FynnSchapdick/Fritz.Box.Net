namespace RS.Fritz.Manager.API.Services.TR_064.WanConnectionSharedEntities;

[MessageContract(WrapperName = "GetExternalIpAddress")]
public readonly record struct WanConnectionGetExternalIpAddressRequest;