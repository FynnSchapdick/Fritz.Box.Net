namespace RS.Fritz.Manager.API.Services.TR_064.WanConnectionSharedEntities;

[MessageContract(WrapperName = "GetExternalIpAddressResponse")]
public readonly record struct WanConnectionGetExternalIpAddressResponse(
    [property: MessageBodyMember(Name = "NewExternalIPAddress")] string ExternalIpAddress);