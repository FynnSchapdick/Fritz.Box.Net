using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.Users.Entities;

namespace RS.Fritz.Manager.API.Services.Users;

public interface IUsersService
{
    Task<IEnumerable<User>> GetUsersAsync(InternetGatewayDevice internetGatewayDevice);
}