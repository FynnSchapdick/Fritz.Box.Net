using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;
using RS.Fritz.Manager.API.Services.TR_064.SoapClient;

namespace FritzBoxPrometheusExporter.Collectors;

public sealed class HostCollector : ICollector
{
    private readonly IServiceScopeFactory _factory;
    private readonly IMetricFamily<IGauge> _gauge;

    public HostCollector(IServiceScopeFactory factory, IMetricFactory metricFactory)
    {
        _factory = factory;
        _gauge = metricFactory.CreateGauge("gateway_host_active", "gateway_host_active is host currently active", "gateway", "hostname", "interfacetype", "ipaddress", "macaddress");
    }
    
    public async Task CollectFromDeviceAsync(InternetGatewayDevice device, CancellationToken cancellationToken)
    {
        await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
        IFritzServiceOperationHandler operationHandler = asyncScope.ServiceProvider.GetRequiredService<IFritzServiceOperationHandler>();
        HostsGetHostNumberOfEntriesResponse hostsCountResponse = await operationHandler.HostsGetHostNumberOfEntriesAsync(device);

        for (ushort i = 0; i < hostsCountResponse.HostNumberOfEntries; i++)
        {
            HostsGetGenericHostEntryResponse hostInfo = await operationHandler.HostsGetGenericHostEntryAsync(device, new HostsGetGenericHostEntryRequest(i));
            if (!hostInfo.Active)
            {
                continue;
            }

            _gauge.WithLabels(device.Locations.Single().Host, hostInfo.HostName, hostInfo.InterfaceType, hostInfo.IpAddress, hostInfo.MacAddress).Set(1);
        }
    }
}