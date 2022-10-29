namespace RS.Fritz.Manager.API.Services.Discovery.Entities;

internal sealed record InternetGatewayDeviceResponse(Uri Location, string Server, string CacheControl, string Ext, string SearchTarget, string Usn);