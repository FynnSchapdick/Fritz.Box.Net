using System.Net.Sockets;
using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.Discovery;

namespace FritzBoxPrometheusExporter.Services;

public sealed record CollectorConfig
{
    // Required for OptionPattern -GetSection("CollectorConfig") needs a default parameterless costructor
    public CollectorConfig() { }
    public string UserName { get; init; } 
    public string Password { get; init; }
    public int IntervalSeconds { get; init; }
}

public sealed class CollectorService : BackgroundService
{
    private readonly IOptions<CollectorConfig> _config;
    private readonly ILogger<CollectorService> _logger;
    private readonly IServiceScopeFactory _factory;
    private readonly IDeviceSearchService _deviceSearch;
    private IEnumerable<ICollector> _collectors;

    public CollectorService(ILogger<CollectorService> logger, IServiceScopeFactory factory, IOptions<CollectorConfig> config, IDeviceSearchService deviceSearch)
    {
        _logger = logger;
        _factory = factory;
        _config = config;
        _deviceSearch = deviceSearch;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        InternetGatewayDevice device = await _deviceSearch.GetDeviceAsync(cancellationToken: cancellationToken);
        await device.InitializeAsync();
        device.NetworkCredential = new NetworkCredential(_config.Value.UserName, _config.Value.Password);
        using PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(_config.Value.IntervalSeconds));
        ulong executionCount = 0;
        
        while (!cancellationToken.IsCancellationRequested
               && await timer.WaitForNextTickAsync(cancellationToken))
        {
            try
            {
                await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                _collectors = asyncScope.ServiceProvider.GetRequiredService<IEnumerable<ICollector>>();

                foreach (ICollector collector in _collectors)
                {
                    await collector.CollectFromDeviceAsync(device, cancellationToken);
                }

                executionCount++;
                _logger.LogInformation("Executed CollectorService - Count: {ExecutionCount}", executionCount);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Failed to execute CollectorService with exception message {ExMessage}. Good luck next round!", ex.Message);
            }
        }
    }
}