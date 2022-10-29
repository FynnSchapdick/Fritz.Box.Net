namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig.Entities;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WanDslLinkConfigGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewLinkStatus")] string LinkStatus,
    [property: MessageBodyMember(Name = "NewLinkType")] string LinkType,
    [property: MessageBodyMember(Name = "NewDestinationAddress")] string DestinationAddress,
    [property: MessageBodyMember(Name = "NewATMEncapsulation")] string AtmEncapsulation,
    [property: MessageBodyMember(Name = "NewAutoConfig")] bool AutoConfig,
    [property: MessageBodyMember(Name = "NewATMQoS")] string AtmQos,
    [property: MessageBodyMember(Name = "NewATMPeakCellRate")] uint AtmPeakCellRate,
    [property: MessageBodyMember(Name = "NewATMSustainableCellRate")] uint AtmSustainableCellRate);