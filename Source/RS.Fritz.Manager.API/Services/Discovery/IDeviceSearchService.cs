using RS.Fritz.Manager.API.Entities;

namespace RS.Fritz.Manager.API.Services.Discovery;

public interface IDeviceSearchService
{
    Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null, int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default);

    Task<InternetGatewayDevice> GetDeviceAsync(int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default);
}