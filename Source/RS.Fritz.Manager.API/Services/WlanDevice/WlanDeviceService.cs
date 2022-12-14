using System.Xml;
using System.Xml.Serialization;
using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Extensions;
using RS.Fritz.Manager.API.Services.TR_064.Services.WlanConfiguration.Entities;

namespace RS.Fritz.Manager.API.Services.WlanDevice;

using Entities;

internal sealed class WlanDeviceService : IWlanDeviceService
{
    private readonly IHttpClientFactory httpClientFactory;

    public WlanDeviceService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<WlanDeviceInfo> GetWlanDevicesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        WlanConfigurationGetWlanDeviceListPathResponse wlanConfigurationGetWlanDeviceListPathResponse = await internetGatewayDevice.WlanConfigurationGetWlanDeviceListPathAsync(1);
        string wlanDeviceListPath = wlanConfigurationGetWlanDeviceListPathResponse.WlanDeviceListPath;
        var wlanDeviceListPathUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}:{internetGatewayDevice.SecurityPort}{wlanDeviceListPath}"));
        string wlanDeviceListXml = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStringAsync(wlanDeviceListPathUri, cancellationToken);
        using var stringReader = new StringReader(wlanDeviceListXml);
        using var xmlTextReader = new XmlTextReader(stringReader);
        var wlanDeviceList = (WlanDeviceList)new XmlSerializer(typeof(WlanDeviceList)).Deserialize(xmlTextReader)!;

        return new WlanDeviceInfo(wlanDeviceListPath, wlanDeviceListPathUri, wlanDeviceList);
    }
}