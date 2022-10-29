namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanEthernetLinkConfig.Entities;

[MessageContract(WrapperName = "GetEthernetLinkStatusResponse")]
public readonly record struct WanEthernetLinkConfigGetEthernetLinkStatusResponse(
    [property: MessageBodyMember(Name = "NewEthernetLinkStatus")] string EthernetLinkStatus);