using System.Net;
using RS.Fritz.Manager.API.Services.TR_064.Services.AvmSpeedtest.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.AvmSpeedtest;

internal sealed class FritzAvmSpeedtestService : FritzServiceClient<IFritzAvmSpeedtestService>, IFritzAvmSpeedtestService
{
    public const string ControlUrl = "/upnp/control/x_speedtest";

    public FritzAvmSpeedtestService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest)
    {
        return Channel.GetInfoAsync(avmSpeedtestGetInfoRequest);
    }
}