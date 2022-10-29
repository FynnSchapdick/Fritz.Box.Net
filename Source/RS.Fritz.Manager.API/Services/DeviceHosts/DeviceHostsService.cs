using System.Runtime.Serialization;
using System.Xml;
using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Extensions;
using RS.Fritz.Manager.API.Services.DeviceHosts.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.Hosts.Entities;

namespace RS.Fritz.Manager.API.Services.DeviceHosts;

internal sealed class DeviceHostsService : IDeviceHostsService
{
    private readonly IHttpClientFactory httpClientFactory;

    public DeviceHostsService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<DeviceHostInfo> GetDeviceHostsAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        HostsGetHostListPathResponse hostsGetHostListPathResponse = await internetGatewayDevice.HostsGetHostListPathAsync();
        string hostListPath = hostsGetHostListPathResponse.HostListPath;
        var hostListPathUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}:{internetGatewayDevice.SecurityPort}{hostListPath}"));
        string deviceHostsListXml = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStringAsync(hostListPathUri, cancellationToken);
        using var stringReader = new StringReader(deviceHostsListXml);
        using var xmlTextReader = new XmlTextReader(stringReader);
        var deviceHostsList = (DeviceHostsList)new DataContractSerializer(typeof(DeviceHostsList)).ReadObject(xmlTextReader)!;

        return new DeviceHostInfo(hostListPath, hostListPathUri, deviceHostsList);
    }
}