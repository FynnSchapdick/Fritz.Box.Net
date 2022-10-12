using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using FritzBox.Net.FritzBox.Clients.Base;
using FritzBox.Net.FritzBox.Clients.DeviceInfo;

namespace FritzBox.Net.FritzBox
{
    /// <summary>
    /// class representing a fritz device
    /// </summary>
    public class FritzDevice
    {
        internal FritzDevice()
        {
        }

        internal FritzDevice(IPAddress address, Uri location)
        {
            if(address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            if(location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            Location = location;
            IPAddress = address;
        }

        /// <summary>
        /// Method to parse the udp response
        /// </summary>
        /// <param name="address"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static async Task<FritzDevice> ParseResponseAsync(IPAddress address, string response)
        {
            FritzDevice device = new FritzDevice();
            device.IPAddress = address;
            device.Location = device.ParseResponseAsync(response);

            var uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = address.ToString();
            uriBuilder.Port = device.Location.Port;

            uriBuilder.Port = await new DeviceInfoClient(uriBuilder.Uri.ToString(), 10000).GetSecurityPortAsync();
            uriBuilder.Scheme = "https";
            device.BaseUrl = uriBuilder.ToString();

            if (device.Location == null)
                return null;
            else
                return device;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="defaultPort"></param>
        /// <returns></returns>
        internal static async Task<FritzDevice> CreateDeviceAsync(IPAddress address, int defaultPort)
        {
            FritzDevice device = new FritzDevice();
            device.IPAddress = address;

            var uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = address.ToString();
            uriBuilder.Port = defaultPort;

            uriBuilder.Port = await new DeviceInfoClient(uriBuilder.Uri.ToString(), 10000).GetSecurityPortAsync();
            uriBuilder.Scheme = "https";
            device.BaseUrl = uriBuilder.ToString();

            if (device.Location == null)
                return null;
            else
                return device;
        }

        /// <summary>
        /// Method to parse the response
        /// </summary>
        /// <param name="response">the response</param>
        private Uri ParseResponseAsync(string response)
        {
            Dictionary<string, string> values = response.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                                 .Skip(1)
                                                 .Select(line => line.Split(new[] { ":" }, 2, StringSplitOptions.None))
                                                 .Where(parts => parts.Length == 2)
                .                                 ToDictionary(parts => parts[0].ToLowerInvariant().Trim(), parts => parts[1].Trim());

            if (values.ContainsKey("location"))
            {
                string location = values["location"];
                
                Uri uri = Uri.TryCreate(location, UriKind.Absolute, out Uri locationUri) ? locationUri : new UriBuilder() { Scheme = "unknown", Host = location }.Uri;
                Port = uri.Port;

                return uri;
            }
            else
                return null;
        }

        /// <summary>
        /// Gets the device type
        /// </summary>
        public string DeviceType { get; internal set; }

        /// <summary>
        /// Gets the friendly name
        /// </summary>
        public string FriendlyName { get; internal set; }

        /// <summary>
        /// Gets the manufacturer
        /// </summary>
        public string Manufacturer { get; internal set; }

        /// <summary>
        /// Gets the model name
        /// </summary>
        public string ModelName { get; internal set; }

        /// <summary>
        /// Gets the model description
        /// </summary>
        public string ModelDescription { get; internal set; }

        /// <summary>
        /// Gets the manufacturer url
        /// </summary>
        public string ManufacturerUrl { get; internal set; }

        /// <summary>
        /// Gets the ip address
        /// </summary>
        public IPAddress IPAddress { get; internal set; }

        /// <summary>
        /// Gets the port
        /// </summary>
        public int Port { get; internal set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        public Uri Location { get; set; }

        /// <summary>
        /// Gets the model number
        /// </summary>
        public string ModelNumber { get; internal set; }

        /// <summary>
        /// Gets the udn
        /// </summary>
        public string UDN { get; internal set; }

        /// <summary>
        /// Gets or sets the credentials
        /// </summary>
        public NetworkCredential Credentials { get; set; }

        /// <summary>
        /// timeout for service requests
        /// </summary>
        public int RequestTimeout { get; set; } = 10000;

        /// <summary>
        /// Gets the base url
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// Method to get service client
        /// </summary>
        /// <typeparam name="T">type param</typeparam>
        /// <param name="settings">connection settings</param>
        /// <returns>the service client</returns>
        [Obsolete("Creating service using connection settings is obsolete. Use GetServiceClient<T> without parameters. Username and password are used from FritzDevice")]
        public async Task<T> GetServiceClient<T>(ConnectionSettings settings)
        {
            if (String.IsNullOrEmpty(settings.BaseUrl))
            {
                var uriBuilder = new UriBuilder();
                uriBuilder.Scheme = "http";
                uriBuilder.Host = IPAddress.ToString();
                uriBuilder.Port = Port;

                settings.BaseUrl = uriBuilder.Uri.ToString();
                // get the security port
                int port = await new DeviceInfoClient(settings.BaseUrl, settings.Timeout).GetSecurityPortAsync();

                uriBuilder.Port = port;
                uriBuilder.Scheme = "https";
                settings.BaseUrl = uriBuilder.Uri.ToString();
            }
            
            return (T)Activator.CreateInstance(typeof(T), settings);
        }

        /// <summary>
        /// Method the get instance of service client
        /// </summary>
        /// <typeparam name="T">the type param</typeparam>
        /// <returns>the instance of the service client</returns>
        public  T GetServiceClient<T>()
        {               
            ConnectionSettings settings = new ConnectionSettings()
            {
                UserName = Credentials?.UserName,
                Password = Credentials?.Password,
                Timeout = RequestTimeout,
                BaseUrl = BaseUrl
            };

            return (T)Activator.CreateInstance(typeof(T), settings);
        }

        /// <summary>
        /// Method to parse the fritz tr64 description
        /// </summary>
        /// <param name="data">the description data</param>
        internal void ParseTR64Desc(string data)
        {
            XDocument document = XDocument.Parse(data);
            XElement deviceRoot = GetElement(document.Root, "device");
            
            if (deviceRoot != null)
            {
                // read device info
                DeviceType = GetElementValue(deviceRoot, "deviceType");
                FriendlyName = GetElementValue(deviceRoot, "friendlyName");
                Manufacturer = GetElementValue(deviceRoot, "manufacturer");
                ManufacturerUrl = GetElementValue(deviceRoot, "manufacturerURL");
                ModelName = GetElementValue(deviceRoot, "modelName");
                ModelDescription = GetElementValue(deviceRoot, "modelDescription");
                ModelNumber = GetElementValue(deviceRoot, "modelNumber");
                UDN = GetElementValue(deviceRoot, "UDN");
            }
        }

        /// <summary>
        /// Mehtod to get an element
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private XElement GetElement(XElement parent, string key)
        {
            return parent.Element(parent.Document.Root.Name.Namespace + key);
        }

        /// <summary>
        /// Method to get an element value
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetElementValue(XElement parent, string key)
        {
            return GetElement(parent, key).Value;
        }

        /// <summary>
        /// Method to get element collection
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private IEnumerable<XElement> GetElements(XElement parent, string key)
        {
            return parent.Elements(parent.Document.Root.Name.Namespace + key);
        }

        /// <summary>
        /// Method to locate devices
        /// </summary>
        /// <returns>a collection of all found devices</returns>
        public static async Task<ICollection<FritzDevice>> LocateDevicesAsync()
        {
            return await new DeviceLocator().DiscoverAsync();
        }
    }
}
