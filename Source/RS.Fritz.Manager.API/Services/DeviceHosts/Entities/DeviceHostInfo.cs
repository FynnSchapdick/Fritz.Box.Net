namespace RS.Fritz.Manager.API.Services.DeviceHosts.Entities;

public readonly record struct DeviceHostInfo(string HostListPath, Uri HostListPathLink, IEnumerable<DeviceHost> DeviceHosts);