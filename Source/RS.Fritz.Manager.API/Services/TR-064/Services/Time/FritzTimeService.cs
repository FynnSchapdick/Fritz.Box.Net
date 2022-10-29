using System.Net;
using RS.Fritz.Manager.API.Services.TR_064.Services.Time.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.Time;

internal sealed class FritzTimeService : FritzServiceClient<IFritzTimeService>, IFritzTimeService
{
    public const string ControlUrl = "/upnp/control/time";

    public FritzTimeService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<TimeGetInfoResponse> GetInfoAsync(TimeGetInfoRequest timeGetInfoRequest)
    {
        return Channel.GetInfoAsync(timeGetInfoRequest);
    }

    public Task<TimeSetNtpServersResponse> SetNtpServersAsync(TimeSetNtpServersRequest timeSetNtpServersRequest)
    {
        return Channel.SetNtpServersAsync(timeSetNtpServersRequest);
    }
}