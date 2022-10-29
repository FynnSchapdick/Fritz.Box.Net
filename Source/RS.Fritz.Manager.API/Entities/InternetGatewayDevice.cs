using System.Net;
using RS.Fritz.Manager.API.Extensions;
using RS.Fritz.Manager.API.Services.Discovery.Entities;
using RS.Fritz.Manager.API.Services.TR_064.SoapClient;
using RS.Fritz.Manager.API.Services.Users;
using RS.Fritz.Manager.API.Services.Users.Entities;

namespace RS.Fritz.Manager.API.Entities;

public sealed record InternetGatewayDevice(IFritzServiceOperationHandler FritzServiceOperationHandler, IUsersService UsersService, IEnumerable<Uri> Locations, string Server, string CacheControl, string? Ext, string SearchTarget, string UniqueServiceName, UPnPDescription UPnPDescription, Uri PreferredLocation)
{
    private IReadOnlyCollection<ServiceListItem>? services;

    public ushort? SecurityPort { get; private set; }

    public User[]? Users { get; private set; }

    public NetworkCredential? NetworkCredential { get; set; }

    public IEnumerable<ServiceListItem> Services => services ??= UPnPDescription.Device.GetServices().ToArray();

    internal Task<TResult> ExecuteAsync<TResult>(Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<TResult>> operation)
    {
        return operation(FritzServiceOperationHandler, this);
    }

    public async Task InitializeAsync()
    {
        SecurityPort = (await this.DeviceInfoGetSecurityPortAsync()).SecurityPort;
        Users = (await UsersService.GetUsersAsync(this)).ToArray();
    }
}