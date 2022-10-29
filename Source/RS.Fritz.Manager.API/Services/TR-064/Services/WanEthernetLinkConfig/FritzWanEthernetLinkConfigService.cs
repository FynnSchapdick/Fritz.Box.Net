using System.Net;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanEthernetLinkConfig.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanEthernetLinkConfig;

internal sealed class FritzWanEthernetLinkConfigService : FritzServiceClient<IFritzWanEthernetLinkConfigService>, IFritzWanEthernetLinkConfigService
{
    public const string ControlUrl = "/upnp/control/wanethlinkconfig1";

    public FritzWanEthernetLinkConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> GetEthernetLinkStatusAsync(WanEthernetLinkConfigGetEthernetLinkStatusRequest wanEthernetLinkConfigGetEthernetLinkStatusRequest)
    {
        return Channel.GetEthernetLinkStatusAsync(wanEthernetLinkConfigGetEthernetLinkStatusRequest);
    }
}