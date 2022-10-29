using RS.Fritz.Manager.API.Services.Discovery.Entities;

namespace RS.Fritz.Manager.API.Extensions;

public static class DeviceExtensions
{
    public static IEnumerable<ServiceListItem> GetServices(this Device device)
    {
        IEnumerable<ServiceListItem> serviceListItems = device.ServiceList;

        foreach (Device deviceListItem in device.DeviceList ?? Array.Empty<Device>())
        {
            serviceListItems = serviceListItems.Concat(GetServices(deviceListItem));
        }

        return serviceListItems;
    }
}