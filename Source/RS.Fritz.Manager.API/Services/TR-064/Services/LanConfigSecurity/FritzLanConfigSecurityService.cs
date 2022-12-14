using System.Net;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity;

internal sealed class FritzLanConfigSecurityService : FritzServiceClient<IFritzLanConfigSecurityService>, IFritzLanConfigSecurityService
{
    public const string ControlUrl = "/upnp/control/lanconfigsecurity";

    public FritzLanConfigSecurityService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<LanConfigSecurityGetAnonymousLoginResponse> GetAnonymousLoginAsync(LanConfigSecurityGetAnonymousLoginRequest lanConfigSecurityGetAnonymousLoginRequest)
    {
        return Channel.GetAnonymousLoginAsync(lanConfigSecurityGetAnonymousLoginRequest);
    }

    public Task<LanConfigSecurityGetCurrentUserResponse> GetCurrentUserAsync(LanConfigSecurityGetCurrentUserRequest lanConfigSecurityGetCurrentUserRequest)
    {
        return Channel.GetCurrentUserAsync(lanConfigSecurityGetCurrentUserRequest);
    }

    public Task<LanConfigSecurityGetInfoResponse> GetInfoAsync(LanConfigSecurityGetInfoRequest lanConfigSecurityGetInfoRequest)
    {
        return Channel.GetInfoAsync(lanConfigSecurityGetInfoRequest);
    }

    public Task<LanConfigSecurityGetUserListResponse> GetUserListAsync(LanConfigSecurityGetUserListRequest lanConfigSecurityGetUserListRequest)
    {
        return Channel.GetUserListAsync(lanConfigSecurityGetUserListRequest);
    }

    public Task<LanConfigSecuritySetConfigPasswordResponse> SetConfigPasswordAsync(LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest)
    {
        return Channel.SetConfigPasswordAsync(lanConfigSecuritySetConfigPasswordRequest);
    }
}