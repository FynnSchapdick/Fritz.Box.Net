using System.Net;

namespace RS.Fritz.Manager.API.Services.TR_064.SoapClient;

internal interface IClientFactory<T>
{
    T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential);
}