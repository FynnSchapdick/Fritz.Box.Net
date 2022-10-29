namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig.Entities;

[MessageContract(WrapperName = "GetDestinationAddressResponse")]
public readonly record struct WanDslLinkConfigGetDestinationAddressResponse(
    [property: MessageBodyMember(Name = "NewDestinationAddress")] string DestinationAddress);