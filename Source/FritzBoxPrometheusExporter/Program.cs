using FritzBoxPrometheusExporter.Services;
using RS.Fritz.Manager.API.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<CollectorConfig>(builder.Configuration.GetSection("CollectorConfig"));
builder.Services.AddFritzApiAspNet();
builder.Services.AddMetricFactory();
builder.Services.AddHealthChecks();
builder.Services.AddTransient<ICollector, WanCollector>();
builder.Services.AddTransient<ICollector, HostCollector>();
builder.Services.AddSingleton<CollectorService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<CollectorService>());

WebApplication app = builder.Build();
app.UsePrometheusServer();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();