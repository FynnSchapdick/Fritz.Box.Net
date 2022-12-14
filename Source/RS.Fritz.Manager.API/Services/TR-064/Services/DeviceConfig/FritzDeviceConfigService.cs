using System.Net;
using RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig.Entities;

namespace RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig;

internal sealed class FritzDeviceConfigService : FritzServiceClient<IFritzDeviceConfigService>, IFritzDeviceConfigService
{
    public const string ControlUrl = "/upnp/control/deviceconfig";

    public FritzDeviceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<DeviceConfigGetPersistentDataResponse> GetPersistentDataAsync(DeviceConfigGetPersistentDataRequest deviceConfigGetPersistentDataRequest)
    {
        return Channel.GetPersistentDataAsync(deviceConfigGetPersistentDataRequest);
    }

    public Task<DeviceConfigGenerateUuIdResponse> GenerateUuIdAsync(DeviceConfigGenerateUuIdRequest deviceConfigGenerateUuIdRequest)
    {
        return Channel.GenerateUuIdAsync(deviceConfigGenerateUuIdRequest);
    }

    public Task<DeviceConfigCreateUrlSidResponse> CreateUrlSidAsync(DeviceConfigCreateUrlSidRequest deviceConfigCreateUrlSidRequest)
    {
        return Channel.CreateUrlSidAsync(deviceConfigCreateUrlSidRequest);
    }

    public Task<DeviceConfigGetSupportDataInfoResponse> GetSupportDataInfoAsync(DeviceConfigGetSupportDataInfoRequest deviceConfigGetSupportDataInfoRequest)
    {
        return Channel.GetSupportDataInfoAsync(deviceConfigGetSupportDataInfoRequest);
    }
}