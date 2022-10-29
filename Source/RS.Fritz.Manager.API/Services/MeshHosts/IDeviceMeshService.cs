using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.MeshHosts.Entities;

namespace RS.Fritz.Manager.API.Services.MeshHosts;

public interface IDeviceMeshService
{
    Task<DeviceMeshInfo> GetDeviceMeshAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}