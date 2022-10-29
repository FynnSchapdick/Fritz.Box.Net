using System.Text.Json;
using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Extensions;
using RS.Fritz.Manager.API.Services.MeshHosts.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;

namespace RS.Fritz.Manager.API.Services.MeshHosts;

internal sealed class DeviceMeshService : IDeviceMeshService
{
    private readonly IHttpClientFactory httpClientFactory;

    public DeviceMeshService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<DeviceMeshInfo> GetDeviceMeshAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        HostsGetMeshListPathResponse hostsGetMeshListPathResponse = await internetGatewayDevice.HostsGetMeshListPathAsync();
        string meshListPath = hostsGetMeshListPathResponse.MeshListPath;
        var meshListPathUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}:{internetGatewayDevice.SecurityPort}{meshListPath}"));
        await using Stream deviceMeshJsonStream = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStreamAsync(meshListPathUri, cancellationToken);
        var deviceMesh = (DeviceMesh)(await JsonSerializer.DeserializeAsync(deviceMeshJsonStream, typeof(DeviceMesh), cancellationToken: cancellationToken))!;

        return new DeviceMeshInfo(meshListPath, meshListPathUri, deviceMesh);
    }
}