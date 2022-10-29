using RS.Fritz.Manager.API.Entities;

namespace FritzBoxPrometheusExporter.Collectors.Abstractions;

public interface ICollector
{
    Task CollectFromDeviceAsync(InternetGatewayDevice device, CancellationToken cancellationToken);
}