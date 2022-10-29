namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig.Entities;

[MessageContract(WrapperName = "GetDslLinkInfoResponse")]
public readonly record struct WanDslLinkConfigGetDslLinkInfoResponse(
    [property: MessageBodyMember(Name = "NewLinkType")] string LinkType,
    [property: MessageBodyMember(Name = "NewLinkStatus")] string LinkStatus);