using RS.Fritz.Manager.API.Entities;

namespace RS.Fritz.Manager.API.Services.WlanDevice;

using Entities;

public interface IWlanDeviceService
{
    Task<WlanDeviceInfo> GetWlanDevicesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}