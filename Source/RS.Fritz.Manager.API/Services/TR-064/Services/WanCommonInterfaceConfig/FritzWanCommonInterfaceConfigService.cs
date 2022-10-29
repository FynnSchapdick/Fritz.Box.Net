using System.Net;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig;

internal sealed class FritzWanCommonInterfaceConfigService : FritzServiceClient<IFritzWanCommonInterfaceConfigService>, IFritzWanCommonInterfaceConfigService
{
    public const string ControlUrl = "/upnp/control/wancommonifconfig1";

    public FritzWanCommonInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetCommonLinkPropertiesAsync(WanCommonInterfaceConfigGetCommonLinkPropertiesRequest wanCommonInterfaceConfigGetCommonLinkPropertiesRequest)
    {
        return Channel.GetCommonLinkPropertiesAsync(wanCommonInterfaceConfigGetCommonLinkPropertiesRequest);
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetTotalBytesReceivedAsync(WanCommonInterfaceConfigGetTotalBytesReceivedRequest wanCommonInterfaceConfigGetTotalBytesReceivedRequest)
    {
        return Channel.GetTotalBytesReceivedAsync(wanCommonInterfaceConfigGetTotalBytesReceivedRequest);
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetTotalBytesSentAsync(WanCommonInterfaceConfigGetTotalBytesSentRequest wanCommonInterfaceConfigGetTotalBytesSentRequest)
    {
        return Channel.GetTotalBytesSentAsync(wanCommonInterfaceConfigGetTotalBytesSentRequest);
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> GetTotalPacketsReceivedAsync(WanCommonInterfaceConfigGetTotalPacketsReceivedRequest wanCommonInterfaceConfigGetTotalPacketsReceivedRequest)
    {
        return Channel.GetTotalPacketsReceivedAsync(wanCommonInterfaceConfigGetTotalPacketsReceivedRequest);
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> GetTotalPacketsSentAsync(WanCommonInterfaceConfigGetTotalPacketsSentRequest wanCommonInterfaceConfigGetTotalPacketsSentRequest)
    {
        return Channel.GetTotalPacketsSentAsync(wanCommonInterfaceConfigGetTotalPacketsSentRequest);
    }

    public Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> SetWanAccessTypeAsync(WanCommonInterfaceConfigSetWanAccessTypeRequest wanCommonInterfaceConfigSetWanAccessTypeRequest)
    {
        return Channel.SetWanAccessTypeAsync(wanCommonInterfaceConfigSetWanAccessTypeRequest);
    }

    public Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> GetOnlineMonitorAsync(WanCommonInterfaceConfigGetOnlineMonitorRequest wanCommonInterfaceConfigGetOnlineMonitorRequest)
    {
        return Channel.GetOnlineMonitorAsync(wanCommonInterfaceConfigGetOnlineMonitorRequest);
    }
}