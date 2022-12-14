using System.Net;
using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.AvmSpeedtest;
using RS.Fritz.Manager.API.Services.TR_064.Services.AvmSpeedtest.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.DeviceConfig.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.DeviceInfo;
using RS.Fritz.Manager.API.Services.TR_064.Services.DeviceInfo.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.Hosts;
using RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanEthernetInterfaceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanEthernetInterfaceConfig.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanHostConfigManagement.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.Layer3Forwarding;
using RS.Fritz.Manager.API.Services.TR_064.Services.Layer3Forwarding.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer;
using RS.Fritz.Manager.API.Services.TR_064.Services.ManagementServer.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.Time;
using RS.Fritz.Manager.API.Services.TR_064.Services.Time.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface;
using RS.Fritz.Manager.API.Services.TR_064.Services.UserInterface.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanCommonInterfaceConfig.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanDslInterfaceConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanDslInterfaceConfig.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanDslLinkConfig.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanEthernetLinkConfig;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanEthernetLinkConfig.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanIpConnection;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanIpConnection.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanPppConnection;
using RS.Fritz.Manager.API.Services.TR_064.Services.WanPppConnection.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration;
using RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;
using RS.Fritz.Manager.API.Services.TR_064.WanConnectionSharedEntities;

namespace RS.Fritz.Manager.API.Services.TR_064.SoapClient;

internal sealed class FritzServiceOperationHandler : ServiceOperationHandler, IFritzServiceOperationHandler, IDisposable
{
    private readonly IClientFactory<IFritzHostsService> _fritzHostsServiceClientFactory;
    private readonly IClientFactory<IFritzWanCommonInterfaceConfigService> _fritzWanCommonInterfaceConfigServiceClientFactory;
    private readonly IClientFactory<IFritzDeviceInfoService> _fritzDeviceInfoServiceClientFactory;
    private readonly IClientFactory<IFritzLanConfigSecurityService> _fritzLanConfigSecurityServiceClientFactory;
    private readonly IClientFactory<IFritzLayer3ForwardingService> _fritzLayer3ForwardingServiceClientFactory;
    private readonly IClientFactory<IFritzWanDslInterfaceConfigService> _fritzWanDslInterfaceConfigServiceClientFactory;
    private readonly IClientFactory<IFritzWanPppConnectionService> _fritzWanPppConnectionServiceClientFactory;
    private readonly IClientFactory<IFritzWanIpConnectionService> _fritzWanIpConnectionServiceClientFactory;
    private readonly IClientFactory<IFritzWanEthernetLinkConfigService> _fritzWanEthernetLinkConfigServiceClientFactory;
    private readonly IClientFactory<IFritzWanDslLinkConfigService> _fritzWanDslLinkConfigServiceClientFactory;
    private readonly IClientFactory<IFritzAvmSpeedtestService> _fritzAvmSpeedtestServiceClientFactory;
    private readonly IClientFactory<IFritzLanEthernetInterfaceConfigService> _fritzLanEthernetInterfaceConfigServiceClientFactory;
    private readonly IClientFactory<IFritzLanHostConfigManagementService> _fritzLanHostConfigManagementServiceClientFactory;
    private readonly IClientFactory<IFritzWlanConfiguration1Service> _fritzWlanConfiguration1ServiceClientFactory;
    private readonly IClientFactory<IFritzWlanConfiguration2Service> _fritzWlanConfiguration2ServiceClientFactory;
    private readonly IClientFactory<IFritzWlanConfiguration3Service> _fritzWlanConfiguration3ServiceClientFactory;
    private readonly IClientFactory<IFritzWlanConfiguration4Service> _fritzWlanConfiguration4ServiceClientFactory;
    private readonly IClientFactory<IFritzManagementServerService> _fritzManagementServerServiceClientFactory;
    private readonly IClientFactory<IFritzTimeService> _fritzTimeServiceClientFactory;
    private readonly IClientFactory<IFritzUserInterfaceService> _fritzUserInterfaceServiceClientFactory;
    private readonly IClientFactory<IFritzDeviceConfigService> _fritzDeviceConfigServiceClientFactory;

    public FritzServiceOperationHandler(
        IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory,
        IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory,
        IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory,
        IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory,
        IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory,
        IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory,
        IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory,
        IClientFactory<IFritzWanIpConnectionService> fritzWanIpConnectionServiceClientFactory,
        IClientFactory<IFritzWanEthernetLinkConfigService> fritzWanEthernetLinkConfigServiceClientFactory,
        IClientFactory<IFritzWanDslLinkConfigService> fritzWanDslLinkConfigServiceClientFactory,
        IClientFactory<IFritzAvmSpeedtestService> fritzAvmSpeedtestServiceClientFactory,
        IClientFactory<IFritzLanEthernetInterfaceConfigService> fritzLanEthernetInterfaceConfigServiceClientFactory,
        IClientFactory<IFritzLanHostConfigManagementService> fritzLanHostConfigManagementServiceClientFactory,
        IClientFactory<IFritzWlanConfiguration1Service> fritzWlanConfiguration1ServiceClientFactory,
        IClientFactory<IFritzWlanConfiguration2Service> fritzWlanConfiguration2ServiceClientFactory,
        IClientFactory<IFritzWlanConfiguration3Service> fritzWlanConfiguration3ServiceClientFactory,
        IClientFactory<IFritzWlanConfiguration4Service> fritzWlanConfiguration4ServiceClientFactory,
        IClientFactory<IFritzManagementServerService> fritzManagementServerServiceClientFactory,
        IClientFactory<IFritzTimeService> fritzTimeServiceClientFactory,
        IClientFactory<IFritzUserInterfaceService> fritzUserInterfaceServiceClientFactory,
        IClientFactory<IFritzDeviceConfigService> fritzDeviceConfigServiceClientFactory)
    {
        _fritzHostsServiceClientFactory = fritzHostsServiceClientFactory;
        _fritzWanCommonInterfaceConfigServiceClientFactory = fritzWanCommonInterfaceConfigServiceClientFactory;
        _fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
        _fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
        _fritzLayer3ForwardingServiceClientFactory = fritzLayer3ForwardingServiceClientFactory;
        _fritzWanDslInterfaceConfigServiceClientFactory = fritzWanDslInterfaceConfigServiceClientFactory;
        _fritzWanPppConnectionServiceClientFactory = fritzWanPppConnectionServiceClientFactory;
        _fritzWanIpConnectionServiceClientFactory = fritzWanIpConnectionServiceClientFactory;
        _fritzWanEthernetLinkConfigServiceClientFactory = fritzWanEthernetLinkConfigServiceClientFactory;
        _fritzWanDslLinkConfigServiceClientFactory = fritzWanDslLinkConfigServiceClientFactory;
        _fritzAvmSpeedtestServiceClientFactory = fritzAvmSpeedtestServiceClientFactory;
        _fritzLanEthernetInterfaceConfigServiceClientFactory = fritzLanEthernetInterfaceConfigServiceClientFactory;
        _fritzLanHostConfigManagementServiceClientFactory = fritzLanHostConfigManagementServiceClientFactory;
        _fritzWlanConfiguration1ServiceClientFactory = fritzWlanConfiguration1ServiceClientFactory;
        _fritzWlanConfiguration2ServiceClientFactory = fritzWlanConfiguration2ServiceClientFactory;
        _fritzWlanConfiguration3ServiceClientFactory = fritzWlanConfiguration3ServiceClientFactory;
        _fritzWlanConfiguration4ServiceClientFactory = fritzWlanConfiguration4ServiceClientFactory;
        _fritzManagementServerServiceClientFactory = fritzManagementServerServiceClientFactory;
        _fritzTimeServiceClientFactory = fritzTimeServiceClientFactory;
        _fritzUserInterfaceServiceClientFactory = fritzUserInterfaceServiceClientFactory;
        _fritzDeviceConfigServiceClientFactory = fritzDeviceConfigServiceClientFactory;
    }

    public Task<HostsGetHostNumberOfEntriesResponse> HostsGetHostNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostNumberOfEntriesAsync(default));
    }

    public Task<HostsGetHostListPathResponse> HostsGetHostListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetHostListPathAsync(default));
    }

    public Task<HostsGetGenericHostEntryResponse> HostsGetGenericHostEntryAsync(InternetGatewayDevice internetGatewayDevice, HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetGenericHostEntryAsync(hostsGetGenericHostEntryRequest));
    }

    public Task<HostsGetChangeCounterResponse> HostsGetChangeCounterAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetChangeCounterAsync(default));
    }

    public Task<HostsGetMeshListPathResponse> HostsGetMeshListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzHostsServiceClientFactory, (q, r, t) => new FritzHostsService(q, r, t!), FritzHostsService.ControlUrl), q => q.GetMeshListPathAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetCommonLinkPropertiesAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> WanCommonInterfaceConfigGetTotalBytesReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesReceivedAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> WanCommonInterfaceConfigGetTotalBytesSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalBytesSentAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsReceivedAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> WanCommonInterfaceConfigGetTotalPacketsSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetTotalPacketsSentAsync(default));
    }

    public Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> WanCommonInterfaceConfigGetOnlineMonitorAsync(InternetGatewayDevice internetGatewayDevice, WanCommonInterfaceConfigGetOnlineMonitorRequest wanCommonInterfaceConfigGetOnlineMonitorRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.GetOnlineMonitorAsync(wanCommonInterfaceConfigGetOnlineMonitorRequest));
    }

    public Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> WanCommonInterfaceConfigSetWanAccessTypeAsync(InternetGatewayDevice internetGatewayDevice, WanCommonInterfaceConfigSetWanAccessTypeRequest wanCommonInterfaceConfigSetWanAccessTypeRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanCommonInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), FritzWanCommonInterfaceConfigService.ControlUrl), q => q.SetWanAccessTypeAsync(wanCommonInterfaceConfigSetWanAccessTypeRequest));
    }

    public Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.GetDeviceLogAsync(default));
    }

    public Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl, false), q => q.GetSecurityPortAsync(default));
    }

    public Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(InternetGatewayDevice internetGatewayDevice, DeviceInfoSetProvisioningCodeRequest deviceInfoSetProvisioningCodeRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceInfoServiceClientFactory, (q, r, t) => new FritzDeviceInfoService(q, r, t), FritzDeviceInfoService.ControlUrl), q => q.SetProvisioningCodeAsync(deviceInfoSetProvisioningCodeRequest));
    }

    public Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl, false), q => q.GetAnonymousLoginAsync(default));
    }

    public Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetCurrentUserAsync(default));
    }

    public Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.GetUserListAsync(default));
    }

    public Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(InternetGatewayDevice internetGatewayDevice, LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanConfigSecurityServiceClientFactory, (q, r, t) => new FritzLanConfigSecurityService(q, r, t), FritzLanConfigSecurityService.ControlUrl), q => q.SetConfigPasswordAsync(lanConfigSecuritySetConfigPasswordRequest));
    }

    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetDefaultConnectionServiceAsync(default));
    }

    public Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> Layer3ForwardingGetForwardNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetForwardNumberOfEntriesAsync(default));
    }

    public Task<Layer3ForwardingGetGenericForwardingEntryResponse> Layer3ForwardingGetGenericForwardingEntryAsync(InternetGatewayDevice internetGatewayDevice, Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLayer3ForwardingServiceClientFactory, (q, r, t) => new FritzLayer3ForwardingService(q, r, t!), FritzLayer3ForwardingService.ControlUrl), q => q.GetGenericForwardingEntryAsync(layer3ForwardingGetGenericForwardingEntryRequest));
    }

    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> WanDslInterfaceConfigGetDslDiagnoseInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslDiagnoseInfoAsync(default));
    }

    public Task<WanDslInterfaceConfigGetDslInfoResponse> WanDslInterfaceConfigGetDslInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetDslInfoAsync(default));
    }

    public Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslInterfaceConfigServiceClientFactory, (q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), FritzWanDslInterfaceConfigService.ControlUrl), q => q.GetStatisticsTotalAsync(default));
    }

    public Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanConnectionGetConnectionTypeInfoResponse> WanIpConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(default));
    }

    public Task<WanConnectionGetStatusInfoResponse> WanIpConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetStatusInfoAsync(default));
    }

    public Task<WanConnectionGetNatRsipStatusResponse> WanIpConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(default));
    }

    public Task<WanConnectionGetDnsServersResponse> WanIpConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetDnsServersAsync(default));
    }

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanIpConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(default));
    }

    public Task<WanConnectionGetExternalIpAddressResponse> WanIpConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(default));
    }

    public Task<WanConnectionGetGenericPortMappingEntryResponse> WanIpConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanIpConnectionServiceClientFactory, (q, r, t) => new FritzWanIpConnectionService(q, r, t!), FritzWanIpConnectionService.ControlUrl), q => q.GetGenericPortMappingEntryAsync(wanConnectionGetGenericPortMappingEntryRequest));
    }

    public Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanConnectionGetConnectionTypeInfoResponse> WanPppConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetConnectionTypeInfoAsync(default));
    }

    public Task<WanConnectionGetStatusInfoResponse> WanPppConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetStatusInfoAsync(default));
    }

    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> WanPppConnectionGetLinkLayerMaxBitRatesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetLinkLayerMaxBitRatesAsync(default));
    }

    public Task<WanPppConnectionGetUserNameResponse> WanPppConnectionGetUserNameAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetUserNameAsync(default));
    }

    public Task<WanConnectionGetNatRsipStatusResponse> WanPppConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetNatRsipStatusAsync(default));
    }

    public Task<WanConnectionGetDnsServersResponse> WanPppConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetDnsServersAsync(default));
    }

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanPppConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetPortMappingNumberOfEntriesAsync(default));
    }

    public Task<WanConnectionGetExternalIpAddressResponse> WanPppConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetExternalIpAddressAsync(default));
    }

    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> WanPppConnectionGetAutoDisconnectTimeSpanAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetAutoDisconnectTimeSpanAsync(default));
    }

    public Task<WanConnectionGetGenericPortMappingEntryResponse> WanPppConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanPppConnectionServiceClientFactory, (q, r, t) => new FritzWanPppConnectionService(q, r, t!), FritzWanPppConnectionService.ControlUrl), q => q.GetGenericPortMappingEntryAsync(wanConnectionGetGenericPortMappingEntryRequest));
    }

    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> WanEthernetLinkConfigGetEthernetLinkStatusAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanEthernetLinkConfigServiceClientFactory, (q, r, t) => new FritzWanEthernetLinkConfigService(q, r, t!), FritzWanEthernetLinkConfigService.ControlUrl), q => q.GetEthernetLinkStatusAsync(default));
    }

    public Task<WanDslLinkConfigGetInfoResponse> WanDslLinkConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WanDslLinkConfigGetDslLinkInfoResponse> WanDslLinkConfigGetDslLinkInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetDslLinkInfoAsync(default));
    }

    public Task<WanDslLinkConfigGetDestinationAddressResponse> WanDslLinkConfigGetDestinationAddressAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetDestinationAddressAsync(default));
    }

    public Task<WanDslLinkConfigGetAtmEncapsulationResponse> WanDslLinkConfigGetAtmEncapsulationAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetAtmEncapsulationAsync(default));
    }

    public Task<WanDslLinkConfigGetAutoConfigResponse> WanDslLinkConfigGetAutoConfigAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetAutoConfigAsync(default));
    }

    public Task<WanDslLinkConfigGetStatisticsResponse> WanDslLinkConfigGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWanDslLinkConfigServiceClientFactory, (q, r, t) => new FritzWanDslLinkConfigService(q, r, t!), FritzWanDslLinkConfigService.ControlUrl), q => q.GetStatisticsAsync(default));
    }

    public Task<AvmSpeedtestGetInfoResponse> AvmSpeedtestGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzAvmSpeedtestServiceClientFactory, (q, r, t) => new FritzAvmSpeedtestService(q, r, t!), FritzAvmSpeedtestService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<LanEthernetInterfaceConfigGetInfoResponse> LanEthernetInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanEthernetInterfaceConfigServiceClientFactory, (q, r, t) => new FritzLanEthernetInterfaceConfigService(q, r, t!), FritzLanEthernetInterfaceConfigService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<LanEthernetInterfaceConfigGetStatisticsResponse> LanEthernetInterfaceConfigGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanEthernetInterfaceConfigServiceClientFactory, (q, r, t) => new FritzLanEthernetInterfaceConfigService(q, r, t!), FritzLanEthernetInterfaceConfigService.ControlUrl), q => q.GetStatisticsAsync(default));
    }

    public Task<LanHostConfigManagementGetInfoResponse> LanHostConfigManagementGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<LanHostConfigManagementGetAddressRangeResponse> LanHostConfigManagementGetAddressRangeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetAddressRangeAsync(default));
    }

    public Task<LanHostConfigManagementGetDnsServersResponse> LanHostConfigManagementGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetDnsServersAsync(default));
    }

    public Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetIpInterfaceNumberOfEntriesAsync(default));
    }

    public Task<LanHostConfigManagementGetIpRoutersListResponse> LanHostConfigManagementGetIpRoutersListAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetIpRoutersListAsync(default));
    }

    public Task<LanHostConfigManagementGetSubnetMaskResponse> LanHostConfigManagementGetSubnetMaskAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzLanHostConfigManagementServiceClientFactory, (q, r, t) => new FritzLanHostConfigManagementService(q, r, t!), FritzLanHostConfigManagementService.ControlUrl), q => q.GetSubnetMaskAsync(default));
    }

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration1GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration2GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration3GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WlanConfigurationGetInfoResponse> WlanConfiguration4GetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration1GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));
    }

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration2GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));
    }

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration3GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));
    }

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration4GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanDeviceListPathAsync(default));
    }

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration1GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));
    }

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration2GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));
    }

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration3GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));
    }

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration4GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBasBeaconSecurityPropertiesAsync(default));
    }

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration1GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBssIdAsync(default));
    }

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration2GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBssIdAsync(default));
    }

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration3GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBssIdAsync(default));
    }

    public Task<WlanConfigurationGetBssIdResponse> WlanConfiguration4GetBssIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBssIdAsync(default));
    }

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration1GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetSsIdAsync(default));
    }

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration2GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetSsIdAsync(default));
    }

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration3GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetSsIdAsync(default));
    }

    public Task<WlanConfigurationGetSsIdResponse> WlanConfiguration4GetSsIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetSsIdAsync(default));
    }

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration1GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBeaconTypeAsync(default));
    }

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration2GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBeaconTypeAsync(default));
    }

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration3GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBeaconTypeAsync(default));
    }

    public Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration4GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBeaconTypeAsync(default));
    }

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration1GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetChannelInfoAsync(default));
    }

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration2GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetChannelInfoAsync(default));
    }

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration3GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetChannelInfoAsync(default));
    }

    public Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration4GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetChannelInfoAsync(default));
    }

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration1GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));
    }

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration2GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));
    }

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration3GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));
    }

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration4GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetBeaconAdvertisementAsync(default));
    }

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration1GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));
    }

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration2GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));
    }

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration3GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));
    }

    public Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration4GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetTotalAssociationsAsync(default));
    }

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration1GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));
    }

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration2GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));
    }

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration3GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));
    }

    public Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration4GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetIpTvOptimizedAsync(default));
    }

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration1GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration2GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration3GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration4GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration1GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration2GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration3GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration4GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetPacketStatisticsAsync(default));
    }

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration1GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetNightControlAsync(default));
    }

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration2GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetNightControlAsync(default));
    }

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration3GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetNightControlAsync(default));
    }

    public Task<WlanConfigurationGetNightControlResponse> WlanConfiguration4GetNightControlAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetNightControlAsync(default));
    }

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration1GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));
    }

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration2GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));
    }

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration3GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));
    }

    public Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration4GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanHybridModeAsync(default));
    }

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration1GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration2GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration3GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration4GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanExtInfoAsync(default));
    }

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration1GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWpsInfoAsync(default));
    }

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration2GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWpsInfoAsync(default));
    }

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration3GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWpsInfoAsync(default));
    }

    public Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration4GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWpsInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration1GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration1ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration1Service(q, r, t!), FritzWlanConfiguration1Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration2GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration2ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration2Service(q, r, t!), FritzWlanConfiguration2Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration3GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration3ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration3Service(q, r, t!), FritzWlanConfiguration3Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));
    }

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration4GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzWlanConfiguration4ServiceClientFactory, (q, r, t) => new FritzWlanConfiguration4Service(q, r, t!), FritzWlanConfiguration4Service.ControlUrl), q => q.GetWlanConnectionInfoAsync(default));
    }

    public Task<ManagementServerGetInfoResponse> ManagementServerGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<ManagementServerGetTr069FirmwareDownloadEnabledResponse> ManagementServerGetTr069FirmwareDownloadEnabledAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.GetTr069FirmwareDownloadEnabledAsync(default));
    }

    public Task<ManagementServerSetManagementServerUrlResponse> ManagementServerSetManagementServerUrlAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerUrlRequest managementServerSetManagementServerUrlRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetManagementServerUrlAsync(managementServerSetManagementServerUrlRequest));
    }

    public Task<ManagementServerSetManagementServerUsernameResponse> ManagementServerSetManagementServerUsernameAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerUsernameRequest managementServerSetManagementServerUsernameRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetManagementServerUsernameAsync(managementServerSetManagementServerUsernameRequest));
    }

    public Task<ManagementServerSetManagementServerPasswordResponse> ManagementServerSetManagementServerPasswordAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerPasswordRequest managementServerSetManagementServerPasswordRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetManagementServerPasswordAsync(managementServerSetManagementServerPasswordRequest));
    }

    public Task<ManagementServerSetPeriodicInformResponse> ManagementServerSetPeriodicInformAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetPeriodicInformRequest managementServerSetPeriodicInformRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetPeriodicInformAsync(managementServerSetPeriodicInformRequest));
    }

    public Task<ManagementServerSetConnectionRequestAuthenticationResponse> ManagementServerSetConnectionRequestAuthenticationAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetConnectionRequestAuthenticationRequest managementServerSetConnectionRequestAuthenticationRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetConnectionRequestAuthenticationAsync(managementServerSetConnectionRequestAuthenticationRequest));
    }

    public Task<ManagementServerSetUpgradeManagementResponse> ManagementServerSetUpgradeManagementAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetUpgradeManagementRequest managementServerSetUpgradeManagementRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetUpgradeManagementAsync(managementServerSetUpgradeManagementRequest));
    }

    public Task<ManagementServerSetTr069EnableResponse> ManagementServerSetTr069EnableAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetTr069EnableRequest managementServerSetTr069EnableRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetTr069EnableAsync(managementServerSetTr069EnableRequest));
    }

    public Task<ManagementServerSetTr069FirmwareDownloadEnabledResponse> ManagementServerSetTr069FirmwareDownloadEnabledAsync(InternetGatewayDevice internetGatewayDevice, ManagementServerSetTr069FirmwareDownloadEnabledRequest managementServerSetTr069FirmwareDownloadEnabledRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzManagementServerServiceClientFactory, (q, r, t) => new FritzManagementServerService(q, r, t!), FritzManagementServerService.ControlUrl), q => q.SetTr069FirmwareDownloadEnabledAsync(managementServerSetTr069FirmwareDownloadEnabledRequest));
    }

    public Task<TimeGetInfoResponse> TimeGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzTimeServiceClientFactory, (q, r, t) => new FritzTimeService(q, r, t!), FritzTimeService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<TimeSetNtpServersResponse> TimeSetNtpServersAsync(InternetGatewayDevice internetGatewayDevice, TimeSetNtpServersRequest timeSetNtpServersRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzTimeServiceClientFactory, (q, r, t) => new FritzTimeService(q, r, t!), FritzTimeService.ControlUrl), q => q.SetNtpServersAsync(timeSetNtpServersRequest));
    }

    public Task<UserInterfaceGetInfoResponse> UserInterfaceGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.GetInfoAsync(default));
    }

    public Task<UserInterfaceCheckUpdateResponse> UserInterfaceCheckUpdateAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceCheckUpdateRequest userInterfaceCheckUpdateRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.CheckUpdateAsync(userInterfaceCheckUpdateRequest));
    }

    public Task<UserInterfaceDoPrepareCgiResponse> UserInterfaceDoPrepareCgiAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.DoPrepareCgiAsync(default));
    }

    public Task<UserInterfaceDoUpdateResponse> UserInterfaceDoUpdateAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.DoUpdateAsync(default));
    }

    public Task<UserInterfaceDoManualUpdateResponse> UserInterfaceDoManualUpdateAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceDoManualUpdateRequest userInterfaceDoManualUpdateRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.DoManualUpdateAsync(userInterfaceDoManualUpdateRequest));
    }

    public Task<UserInterfaceGetInternationalConfigResponse> UserInterfaceGetInternationalConfigAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.GetInternationalConfigAsync(default));
    }

    public Task<UserInterfaceSetInternationalConfigResponse> UserInterfaceSetInternationalConfigAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceSetInternationalConfigRequest userInterfaceSetInternationalConfigRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.SetInternationalConfigAsync(userInterfaceSetInternationalConfigRequest));
    }

    public Task<UserInterfaceAvmGetInfoResponse> UserInterfaceAvmGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.AvmGetInfoAsync(default));
    }

    public Task<UserInterfaceSetConfigResponse> UserInterfaceSetConfigAsync(InternetGatewayDevice internetGatewayDevice, UserInterfaceSetConfigRequest userInterfaceSetConfigRequest)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzUserInterfaceServiceClientFactory, (q, r, t) => new FritzUserInterfaceService(q, r, t!), FritzUserInterfaceService.ControlUrl), q => q.SetConfigAsync(userInterfaceSetConfigRequest));
    }

    public Task<DeviceConfigGetPersistentDataResponse> DeviceConfigGetPersistentDataAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.GetPersistentDataAsync(default));
    }

    public Task<DeviceConfigGenerateUuIdResponse> DeviceConfigGenerateUuIdAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.GenerateUuIdAsync(default));
    }

    public Task<DeviceConfigCreateUrlSidResponse> DeviceConfigCreateUrlSidAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.CreateUrlSidAsync(default));
    }

    public Task<DeviceConfigGetSupportDataInfoResponse> DeviceConfigGetSupportDataInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzServiceClient(internetGatewayDevice, _fritzDeviceConfigServiceClientFactory, (q, r, t) => new FritzDeviceConfigService(q, r, t!), FritzDeviceConfigService.ControlUrl), q => q.GetSupportDataInfoAsync(default));
    }

    private static T GetFritzServiceClient<T>(InternetGatewayDevice internetGatewayDevice, IClientFactory<T> clientFactory, Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createService, string controlUrl, bool secure = true)
    {
        return clientFactory.Build(createService, internetGatewayDevice.PreferredLocation, secure, controlUrl, secure ? internetGatewayDevice.SecurityPort : null, internetGatewayDevice.NetworkCredential);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}