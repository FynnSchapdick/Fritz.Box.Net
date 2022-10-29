namespace RS.Fritz.Manager.API.Services.WlanDevice.Entities;

public readonly record struct WlanDeviceInfo(string WlanDeviceListPath, Uri WlanDeviceListPathLink, WlanDeviceList WlanDeviceList);