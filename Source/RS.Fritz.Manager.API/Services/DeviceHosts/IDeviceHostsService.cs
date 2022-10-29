using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.DeviceHosts.Entities;

namespace RS.Fritz.Manager.API.Services.DeviceHosts;

public interface IDeviceHostsService
{
    Task<DeviceHostInfo> GetDeviceHostsAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}