namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanPppConnection.Entities;

[MessageContract(WrapperName = "GetLinkLayerMaxBitRatesResponse")]
public readonly record struct WanPppConnectionGetLinkLayerMaxBitRatesResponse(
    [property: MessageBodyMember(Name = "NewUpstreamMaxBitRate")] uint UpstreamMaxBitRate,
    [property: MessageBodyMember(Name = "NewDownstreamMaxBitRate")] uint DownstreamMaxBitRate);