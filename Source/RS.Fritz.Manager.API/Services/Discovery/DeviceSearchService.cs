using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.Discovery.Entities;
using RS.Fritz.Manager.API.Services.TR_064.SoapClient;
using RS.Fritz.Manager.API.Services.Users;

namespace RS.Fritz.Manager.API.Services.Discovery;

internal sealed class DeviceSearchService : IDeviceSearchService
{
    private const string InternetGatewayDeviceDeviceType = "urn:dslforum-org:device:InternetGatewayDevice:1";
    private const int UPnPMultiCastPort = 1900;
    private const int DefaultReceiveTimeout = 500;
    private const int DefaultSendCount = 3;

    private readonly IHttpClientFactory httpClientFactory;
    private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;
    private readonly IUsersService usersService;

    private readonly AddressFamily[] supportedAddressFamilies =
    {
        AddressFamily.InterNetwork, AddressFamily.InterNetworkV6
    };

    public DeviceSearchService(IHttpClientFactory httpClientFactory, IFritzServiceOperationHandler fritzServiceOperationHandler, IUsersService usersService)
    {
        this.httpClientFactory = httpClientFactory;
        this.fritzServiceOperationHandler = fritzServiceOperationHandler;
        this.usersService = usersService;
    }

    private static IDictionary<AddressType, IPAddress> SsdpMultiCastAddresses => new Dictionary<AddressType, IPAddress>
    {
        [AddressType.IpV4SiteLocal] = IPAddress.Parse("239.255.255.250"),
        [AddressType.IpV6LinkLocal] = IPAddress.Parse("[FF02::C]"),
        [AddressType.IpV6SiteLocal] = IPAddress.Parse("[FF05::C]")
    };

    public async Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null,
        int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default)
    {
        deviceType ??= InternetGatewayDeviceDeviceType;
        timeout ??= DefaultReceiveTimeout;
        sendCount ??= DefaultSendCount;

        IEnumerable<string> rawDeviceResponses = await GetRawDeviceResponses(deviceType, sendCount.Value, timeout.Value, cancellationToken);
        IEnumerable<Dictionary<string, string>> formattedDeviceResponses = GetFormattedDeviceResponses(rawDeviceResponses.ToArray());
        IEnumerable<IGrouping<string, InternetGatewayDeviceResponse>> groupedInternetGatewayDeviceResponses = GetGroupedInternetGatewayDeviceResponses(formattedDeviceResponses);

        return await Extensions.TaskExtensions.WhenAllSafe(groupedInternetGatewayDeviceResponses.Select(q => GetInternetGatewayDeviceAsync(q, cancellationToken)));
    }

    public async Task<InternetGatewayDevice> GetDeviceAsync(int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default)
    {
        var names = await Dns.GetHostEntryAsync(Dns.GetHostName(), cancellationToken);

        foreach (var VARIABLE in names.AddressList)
        {
            Console.WriteLine(VARIABLE);
        }
        
        Console.WriteLine("---------------------------------------");
        
        foreach (var VARIABLE2 in names.Aliases)
        {
            Console.WriteLine(VARIABLE2);
        }
        
        Console.WriteLine("---------------------------------------");

        Console.WriteLine(names.HostName);
        throw new NotImplementedException();
        // if (ip is null)
        // {
        //     throw new Exception("No Host Found.");
        // }



        // string? rawDeviceResponse = await GetRawDeviceResponse(ip, InternetGatewayDeviceDeviceType, sendCount ?? DefaultSendCount, timeout ?? DefaultReceiveTimeout, cancellationToken);
        // IEnumerable<Dictionary<string, string>> formattedDeviceResponse = GetFormattedDeviceResponses(new[] { rawDeviceResponse });
        // IGrouping<string, InternetGatewayDeviceResponse>? gatewayDevice = GetGroupedInternetGatewayDeviceResponses(formattedDeviceResponse).FirstOrDefault();
        // if (gatewayDevice is null)
        // {
        //     throw new Exception("No gateway device found.");
        // }
        //
        // return await GetInternetGatewayDeviceAsync(gatewayDevice, cancellationToken);
    }

    private static IEnumerable<IGrouping<string, InternetGatewayDeviceResponse>> GetGroupedInternetGatewayDeviceResponses(IEnumerable<Dictionary<string, string>> formattedDeviceResponses)
    {
        return formattedDeviceResponses
            .Select(q => new InternetGatewayDeviceResponse(new Uri(q["LOCATION"]), q["SERVER"], q["CACHE-CONTROL"],
                q["EXT"], q["ST"], q["USN"]))
            .GroupBy(q => q.Usn);
    }

    private static Uri GetPreferredLocation(IReadOnlyCollection<Uri> locations)
    {
        return locations.SingleOrDefault(q => q.HostNameType is UriHostNameType.IPv6) ??
               locations.Single(q => q.HostNameType is UriHostNameType.IPv4);
    }

    private static IEnumerable<Dictionary<string, string>> GetFormattedDeviceResponses(string?[] responses)
    {
        if (!responses.Any() || string.IsNullOrEmpty(responses[0]))
        {
            throw new ArgumentException("null or contains no value", nameof(responses));
        }

        IEnumerable<IEnumerable<string>> responseLines = responses.Select(q => q?.Split(Environment.NewLine)).Select(p => p.Where(r => r.Contains(':', StringComparison.OrdinalIgnoreCase)));

        return responses.Select(q => q?.Split(Environment.NewLine)).Select(q => q.Where(r => r.Contains(':', StringComparison.OrdinalIgnoreCase)).ToDictionary(
                s => s[..s.IndexOf(':', StringComparison.OrdinalIgnoreCase)],
                s =>
                {
                    string value = s[s.IndexOf(':', StringComparison.OrdinalIgnoreCase)..];

                    if (value.EndsWith(":", StringComparison.OrdinalIgnoreCase))
                    {
                        return value.Replace(":", null, StringComparison.OrdinalIgnoreCase);
                    }

                    return value.Replace(": ", null, StringComparison.OrdinalIgnoreCase);
                }));
    }

    private static async Task<IEnumerable<string>> SearchDevicesAsync(IPAddress localAddress, string deviceType,
        int sendCount, int receiveTimeout, CancellationToken cancellationToken)
    {
        List<string> responses = new List<string>();
        AddressType addressType = GetAddressType(localAddress);

        if (addressType is AddressType.Unknown)
        {
            throw new NotImplementedException();
        }

        using Socket socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        {
            ExclusiveAddressUse = true
        };

        socket.Bind(new IPEndPoint(localAddress, 0));

        IPEndPoint multiCastIpEndPoint = new IPEndPoint(SsdpMultiCastAddresses[addressType], UPnPMultiCastPort);
        string request = FormattableString.Invariant(
            $"M-SEARCH * HTTP/1.1\r\nHOST: {multiCastIpEndPoint}\r\nST: {deviceType}\r\nMAN: \"ssdp:discover\"\r\nMX: 3\r\n\r\n");
        var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(request));

        for (int i = 0; i < sendCount; i++)
        {
            _ = await socket.SendToAsync(buffer, SocketFlags.None, multiCastIpEndPoint);
        }

        await ReceiveAsync(socket, new ArraySegment<byte>(new byte[4096]), responses, receiveTimeout,
            cancellationToken);

        return responses;
    }

    private static AddressType GetAddressType(IPAddress localAddress) =>
        localAddress switch
        {
            { AddressFamily: AddressFamily.InterNetwork } => AddressType.IpV4SiteLocal,
            { IsIPv6LinkLocal: true } => AddressType.IpV6LinkLocal,
            { IsIPv6SiteLocal: true } => AddressType.IpV6SiteLocal,
            _ => AddressType.Unknown
        };

    private static async Task ReceiveAsync(Socket socket, ArraySegment<byte> buffer, ICollection<string> responses,
        int receiveTimeout, CancellationToken cancellationToken)
    {
        using var timeoutCancellationTokenSource = new CancellationTokenSource(receiveTimeout);
        using var linkedCancellationTokenSource =
            CancellationTokenSource.CreateLinkedTokenSource(timeoutCancellationTokenSource.Token, cancellationToken);

        while (!linkedCancellationTokenSource.IsCancellationRequested)
        {
            try
            {
                int bytesReceived =
                    await socket.ReceiveAsync(buffer, SocketFlags.None, linkedCancellationTokenSource.Token);

                if (bytesReceived > 0)
                    responses.Add(Encoding.UTF8.GetString(buffer.Take(bytesReceived).ToArray()));
            }
            catch (OperationCanceledException)
            {
                // Ignore Task cancellation
            }
        }
    }

    private async Task<IEnumerable<string>> GetRawDeviceResponses(string deviceType, int sendCount, int timeout, CancellationToken cancellationToken)
    {
        IEnumerable<IPAddress> localAddresses = GetLocalAddresses();
        IEnumerable<string>[] localAddressesDeviceResponses = await Extensions.TaskExtensions.WhenAllSafe(
            localAddresses.Select(q => SearchDevicesAsync(q, deviceType, sendCount, timeout, cancellationToken)));

        return localAddressesDeviceResponses.Where(q => q.Any()).SelectMany(q => q).Distinct();
    }

    private async Task<string?> GetRawDeviceResponse(IPAddress address, string deviceType, int sendCount, int timeout, CancellationToken cancellationToken)
    {
        IEnumerable<string> localAddressesDeviceResponses = await SearchDevicesAsync(address, deviceType, sendCount, timeout, cancellationToken);
        return localAddressesDeviceResponses.FirstOrDefault(q => !string.IsNullOrEmpty(q));
    }

    private IEnumerable<IPAddress> GetLocalAddresses()
    {
        return NetworkInterface.GetAllNetworkInterfaces()
            .Where(q => q.OperationalStatus is OperationalStatus.Up)
            .Select(q => q.GetIPProperties())
            .Where(q => q.GatewayAddresses.Any())
            .SelectMany(q => q.UnicastAddresses)
            .Select(q => q.Address)
            .Where(q => supportedAddressFamilies.Contains(q.AddressFamily));
    }

    private async Task<UPnPDescription> GetUPnPDescription(Uri uri, CancellationToken cancellationToken)
    {
        string uPnPDescription = await httpClientFactory.CreateClient(Constants.HttpClientName)
            .GetStringAsync(uri, cancellationToken);
        using var stringReader = new StringReader(uPnPDescription);
        using var xmlTextReader = new XmlTextReader(stringReader);

        return (UPnPDescription)new DataContractSerializer(typeof(UPnPDescription)).ReadObject(xmlTextReader)!;
    }

    private async Task<InternetGatewayDevice> GetInternetGatewayDeviceAsync(
        IGrouping<string, InternetGatewayDeviceResponse> internetGatewayDeviceResponses,
        CancellationToken cancellationToken)
    {
        Uri preferredLocation = GetPreferredLocation(internetGatewayDeviceResponses.Select(r => r.Location).ToArray());

        return new InternetGatewayDevice(
            fritzServiceOperationHandler,
            usersService,
            internetGatewayDeviceResponses.Select(r => r.Location).Distinct(),
            internetGatewayDeviceResponses.Select(r => r.Server).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.CacheControl).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.Ext).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.SearchTarget).Distinct().Single(),
            internetGatewayDeviceResponses.Key,
            await GetUPnPDescription(preferredLocation, cancellationToken),
            preferredLocation);
    }
}