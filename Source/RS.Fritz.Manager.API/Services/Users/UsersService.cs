using System.Xml;
using System.Xml.Serialization;
using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.TR_064.Services.LanConfigSecurity.Entities;
using RS.Fritz.Manager.API.Services.TR_064.SoapClient;
using RS.Fritz.Manager.API.Services.Users.Entities;

namespace RS.Fritz.Manager.API.Services.Users;

internal sealed class UsersService : IUsersService
{
    private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;

    public UsersService(IFritzServiceOperationHandler fritzServiceOperationHandler)
    {
        this.fritzServiceOperationHandler = fritzServiceOperationHandler;
    }

    public async Task<IEnumerable<User>> GetUsersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        LanConfigSecurityGetUserListResponse lanConfigSecurityGetUserListResponse = await fritzServiceOperationHandler.LanConfigSecurityGetUserListAsync(internetGatewayDevice);
        using var stringReader = new StringReader(lanConfigSecurityGetUserListResponse.UserList);
        using var xmlTextReader = new XmlTextReader(stringReader);
        var userList = (UserList)new XmlSerializer(typeof(UserList)).Deserialize(xmlTextReader)!;

        return userList.Users;
    }
}