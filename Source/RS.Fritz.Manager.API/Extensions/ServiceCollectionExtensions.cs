namespace RS.Fritz.Manager.API.Extensions;

using System.Net;
using System.Net.Security;
using Microsoft.Extensions.DependencyInjection;
using RS.Fritz.Manager.API.Services.Capture;
using RS.Fritz.Manager.API.Services.DeviceHosts;
using RS.Fritz.Manager.API.Services.Discovery;
using RS.Fritz.Manager.API.Services.MeshHosts;
using RS.Fritz.Manager.API.Services.TR_064.Services.AvmSpeedtest;
using RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.DeviceInfo;
using RS.Fritz.Manager.API.Services.TR_064.Services.Hosts;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanEthernetInterfaceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement;
using RS.Fritz.Manager.API.Services.TR_064.Services.Layer3Forwarding;
using RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer;
using RS.Fritz.Manager.API.Services.TR_064.Services.Time;
using RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanDslInterfaceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanEthernetLinkConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanIpConnection;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanPppConnection;
using RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration;
using RS.Fritz.Manager.API.Services.TR_064.SoapClient;
using RS.Fritz.Manager.API.Services.Users;
using RS.Fritz.Manager.API.Services.WebUi;
using RS.Fritz.Manager.API.Services.WlanDevice;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFritzApi(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<IDeviceSearchService, DeviceSearchService>()
            .AddSingleton<IDeviceHostsService, DeviceHostsService>()
            .AddSingleton<IDeviceMeshService, DeviceMeshService>()
            .AddSingleton<IWlanDeviceService, WlanDeviceService>()
            .AddSingleton<ICaptureControlService, CaptureControlService>()
            .AddSingleton<IFritzServiceOperationHandler, FritzServiceOperationHandler>()
            .AddSingleton<IUsersService, UsersService>()
            .AddSingleton<IWebUiService, WebUiService>()
            .AddSingleton<IClientFactory<IFritzLanConfigSecurityService>,
                ClientFactory<IFritzLanConfigSecurityService>>()
            .AddSingleton<IClientFactory<IFritzDeviceInfoService>, ClientFactory<IFritzDeviceInfoService>>()
            .AddSingleton<IClientFactory<IFritzWanDslInterfaceConfigService>,
                ClientFactory<IFritzWanDslInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzHostsService>, ClientFactory<IFritzHostsService>>()
            .AddSingleton<IClientFactory<IFritzWanCommonInterfaceConfigService>,
                ClientFactory<IFritzWanCommonInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzLayer3ForwardingService>, ClientFactory<IFritzLayer3ForwardingService>>()
            .AddSingleton<IClientFactory<IFritzWanPppConnectionService>, ClientFactory<IFritzWanPppConnectionService>>()
            .AddSingleton<IClientFactory<IFritzWanIpConnectionService>, ClientFactory<IFritzWanIpConnectionService>>()
            .AddSingleton<IClientFactory<IFritzWanEthernetLinkConfigService>,
                ClientFactory<IFritzWanEthernetLinkConfigService>>()
            .AddSingleton<IClientFactory<IFritzWanDslLinkConfigService>, ClientFactory<IFritzWanDslLinkConfigService>>()
            .AddSingleton<IClientFactory<IFritzAvmSpeedtestService>, ClientFactory<IFritzAvmSpeedtestService>>()
            .AddSingleton<IClientFactory<IFritzLanEthernetInterfaceConfigService>,
                ClientFactory<IFritzLanEthernetInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzLanHostConfigManagementService>,
                ClientFactory<IFritzLanHostConfigManagementService>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration1Service>,
                ClientFactory<IFritzWlanConfiguration1Service>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration2Service>,
                ClientFactory<IFritzWlanConfiguration2Service>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration3Service>,
                ClientFactory<IFritzWlanConfiguration3Service>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration4Service>,
                ClientFactory<IFritzWlanConfiguration4Service>>()
            .AddSingleton<IClientFactory<IFritzManagementServerService>, ClientFactory<IFritzManagementServerService>>()
            .AddSingleton<IClientFactory<IFritzTimeService>, ClientFactory<IFritzTimeService>>()
            .AddSingleton<IClientFactory<IFritzUserInterfaceService>, ClientFactory<IFritzUserInterfaceService>>()
            .AddSingleton<IClientFactory<IFritzDeviceConfigService>, ClientFactory<IFritzDeviceConfigService>>()
            .ConfigureHttpClients();
    }

    public static IServiceCollection AddFritzApiAspNet(this IServiceCollection serviceCollection) =>
        serviceCollection.AddTransient<IDeviceSearchService, DeviceSearchService>()
            .AddTransient<IDeviceHostsService, DeviceHostsService>()
            .AddTransient<IDeviceMeshService, DeviceMeshService>()
            .AddTransient<IWlanDeviceService, WlanDeviceService>()
            .AddTransient<ICaptureControlService, CaptureControlService>()
            .AddTransient<IFritzServiceOperationHandler, FritzServiceOperationHandler>()
            .AddTransient<IUsersService, UsersService>()
            .AddTransient<IWebUiService, WebUiService>()
            .AddTransient<IClientFactory<IFritzLanConfigSecurityService>,
                ClientFactory<IFritzLanConfigSecurityService>>()
            .AddTransient<IClientFactory<IFritzDeviceInfoService>, ClientFactory<IFritzDeviceInfoService>>()
            .AddTransient<IClientFactory<IFritzWanDslInterfaceConfigService>,
                ClientFactory<IFritzWanDslInterfaceConfigService>>()
            .AddTransient<IClientFactory<IFritzHostsService>, ClientFactory<IFritzHostsService>>()
            .AddTransient<IClientFactory<IFritzWanCommonInterfaceConfigService>,
                ClientFactory<IFritzWanCommonInterfaceConfigService>>()
            .AddTransient<IClientFactory<IFritzLayer3ForwardingService>, ClientFactory<IFritzLayer3ForwardingService>>()
            .AddTransient<IClientFactory<IFritzWanPppConnectionService>, ClientFactory<IFritzWanPppConnectionService>>()
            .AddTransient<IClientFactory<IFritzWanIpConnectionService>, ClientFactory<IFritzWanIpConnectionService>>()
            .AddTransient<IClientFactory<IFritzWanEthernetLinkConfigService>,
                ClientFactory<IFritzWanEthernetLinkConfigService>>()
            .AddTransient<IClientFactory<IFritzWanDslLinkConfigService>, ClientFactory<IFritzWanDslLinkConfigService>>()
            .AddTransient<IClientFactory<IFritzAvmSpeedtestService>, ClientFactory<IFritzAvmSpeedtestService>>()
            .AddTransient<IClientFactory<IFritzLanEthernetInterfaceConfigService>,
                ClientFactory<IFritzLanEthernetInterfaceConfigService>>()
            .AddTransient<IClientFactory<IFritzLanHostConfigManagementService>,
                ClientFactory<IFritzLanHostConfigManagementService>>()
            .AddTransient<IClientFactory<IFritzWlanConfiguration1Service>,
                ClientFactory<IFritzWlanConfiguration1Service>>()
            .AddTransient<IClientFactory<IFritzWlanConfiguration2Service>,
                ClientFactory<IFritzWlanConfiguration2Service>>()
            .AddTransient<IClientFactory<IFritzWlanConfiguration3Service>,
                ClientFactory<IFritzWlanConfiguration3Service>>()
            .AddTransient<IClientFactory<IFritzWlanConfiguration4Service>,
                ClientFactory<IFritzWlanConfiguration4Service>>()
            .AddTransient<IClientFactory<IFritzManagementServerService>, ClientFactory<IFritzManagementServerService>>()
            .AddTransient<IClientFactory<IFritzTimeService>, ClientFactory<IFritzTimeService>>()
            .AddTransient<IClientFactory<IFritzUserInterfaceService>, ClientFactory<IFritzUserInterfaceService>>()
            .AddTransient<IClientFactory<IFritzDeviceConfigService>, ClientFactory<IFritzDeviceConfigService>>()
            .ConfigureHttpClients();

    private static IServiceCollection ConfigureHttpClients(this IServiceCollection serviceCollection)
    {
        _ = serviceCollection.AddHttpClient(Constants.HttpClientName)
            .ConfigureHttpClient((_, httpClient) =>
            {
                httpClient.Timeout = TimeSpan.FromSeconds(60);
                httpClient.DefaultRequestVersion = Version.Parse("2.0");
            })
            .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.All
            });
        _ = serviceCollection.AddHttpClient(Constants.NonValidatingHttpsClientName)
            .ConfigureHttpClient((_, httpClient) =>
            {
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                httpClient.DefaultRequestVersion = Version.Parse("2.0");
            })
            .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (_, _, _, sslPolicyErrors) =>
                        (sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) == 0,
                AutomaticDecompression = DecompressionMethods.All
            });

        return serviceCollection;
    }
}