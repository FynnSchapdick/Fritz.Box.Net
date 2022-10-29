using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;
using RS.Fritz.Manager.API.Services.TR_064.SoapClient;

namespace FritzBoxPrometheusExporter.Collectors;

public sealed class WanCollector : ICollector
{
    private readonly IServiceScopeFactory _factory;
    private readonly IMetricFamily<ICounter> _counter;

    public WanCollector(IServiceScopeFactory factory, IMetricFactory metricFactory)
    {
        _factory = factory;
        _counter = metricFactory.CreateCounter("gateway_traffic", "traffic on gateway interface", "direction", "unit", "interface", "gateway");
    }
    
    public async Task CollectFromDeviceAsync(InternetGatewayDevice device, CancellationToken cancellationToken)
    {
        await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
        IFritzServiceOperationHandler operationHandler = asyncScope.ServiceProvider.GetRequiredService<IFritzServiceOperationHandler>();
        WanCommonInterfaceConfigGetTotalBytesSentResponse totalBytesSent = await operationHandler.WanCommonInterfaceConfigGetTotalBytesSentAsync(device);
        WanCommonInterfaceConfigGetTotalBytesReceivedResponse totalBytesReceived = await operationHandler.WanCommonInterfaceConfigGetTotalBytesReceivedAsync(device);
        WanCommonInterfaceConfigGetTotalPacketsReceivedResponse totalPacketsReceived = await operationHandler.WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(device);
        WanCommonInterfaceConfigGetTotalPacketsSentResponse totalPacketsSent = await operationHandler.WanCommonInterfaceConfigGetTotalPacketsSentAsync(device);
        _counter.WithLabels("Sent", "Bytes", "WAN", device.Locations.Single().Host).Inc(totalBytesSent.TotalBytesSent);
        _counter.WithLabels("Received", "Bytes", "WAN", device.Locations.Single().Host).Inc(totalBytesReceived.TotalBytesReceived);
        _counter.WithLabels("Received", "Packets", "WAN", device.Locations.Single().Host).Inc(totalPacketsReceived.TotalPacketsReceived);
        _counter.WithLabels("Sent", "Packets", "WAN", device.Locations.Single().Host).Inc(totalPacketsSent.TotalPacketsSent);
    }
}