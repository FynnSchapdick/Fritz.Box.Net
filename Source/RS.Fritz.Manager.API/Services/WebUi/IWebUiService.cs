using RS.Fritz.Manager.API.Entities;
using RS.Fritz.Manager.API.Services.WebUi.Entities;

namespace RS.Fritz.Manager.API.Services.WebUi;

public interface IWebUiService
{
    Task<WebUiSessionInfo> GetUsersAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);

    Task<WebUiSessionInfo> LogonAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);

    Task<WebUiSessionInfo> LogoffAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default);

    Task<WebUiSessionInfo> ValidateSessionAsync(InternetGatewayDevice internetGatewayDevice, string sessionId, CancellationToken cancellationToken = default);
}