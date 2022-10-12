using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using FritzBox.Net.FritzBox.Clients.Base;
using FritzBox.Net.FritzBox.Clients.Base.Soap;

namespace FritzBox.Net.FritzBox.Clients.RemoteAccess
{
    /// <summary>
    /// client for Remote Access service
    /// </summary>
    public class RemoteAccessClient : FritzTr64Client
    {
        public RemoteAccessClient(string url, int timeout) : base(url, timeout)
        {
        }

        public RemoteAccessClient(string url, int timeout, string username) : base(url, timeout, username)
        {
        }

        public RemoteAccessClient(string url, int timeout, string username, string password) : base(url, timeout, username, password)
        {
        }

        public RemoteAccessClient(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
        }

        /// <summary>
        /// Gets the control url
        /// </summary>
        protected override string ControlUrl => "/upnp/control/x_remote";

        /// <summary>
        /// Gets the request namespace
        /// </summary>
        protected override string RequestNameSpace => "urn:dslforum-org:service:X_AVM-DE_RemoteAccess:1";

        /// <summary>
        /// Method to get the remote access info
        /// </summary>
        /// <returns>the remote access info</returns>
        public async Task<RemoteAccessInfo> GetInfoAsync()
        {
            XDocument document = await InvokeAsync("GetInfo", null);

            return new RemoteAccessInfo
            {
                Enabled = document.Descendants("NewEnabled").First().Value,
                Port = Convert.ToInt16(document.Descendants("NewPort").First().Value),
                Username = document.Descendants("NewUsername").First().Value
            };
        }

        /// <summary>
        /// Method to set remote access config
        /// </summary>
        /// <param name="enable">flag if remote access should be enabled</param>
        /// <param name="port">port for remote access</param>
        /// <param name="userName">username for remote access</param>
        /// <param name="password">password for remote access</param>
        /// <returns></returns>
        public async Task SetConfigAsync(bool enable, UInt16 port, string userName, string password)
        {
            List<SoapRequestParameter> parameters = new List<SoapRequestParameter>()
            {
                new SoapRequestParameter("NewEnabled", enable ? 1 : 0),
                new SoapRequestParameter("NewPort", port),
                new SoapRequestParameter("NewUsername", userName),
                new SoapRequestParameter("NewPassword", password)
            };

            await InvokeAsync("SetConfig", parameters.ToArray());
        }

        /// <summary>
        /// Method to get DDNS info
        /// </summary>
        /// <returns>the ddns info</returns>
        public async Task<DdnInfo> GetDDNSInfoAsync()
        {
            XDocument document = await InvokeAsync("GetDDNSInfo", null);

            return new DdnInfo
            {
                Domain = document.Descendants("NewDomain").First().Value,
                Enabled = document.Descendants("NewEnabled").First().Value,
                Mode = (DdnsMode)Enum.Parse(typeof(DdnsMode), document.Descendants("NewMode").First().Value),
                ProviderName = document.Descendants("NewProviderName").First().Value,
                ServerIPv4 = IPAddress.TryParse(document.Descendants("NewServerIPv4").First().Value, out IPAddress v4) ? v4 : IPAddress.None,
                ServerIPv6 = IPAddress.TryParse(document.Descendants("NewServerIPv6").First().Value, out IPAddress v6) ? v6 : IPAddress.None,
                StatusIPv4 = (DdnsStatus)Enum.Parse(typeof(DdnsStatus), document.Descendants("NewStatusIPv4").First().Value.Replace("-", "_")),
                StatusIPv6 = (DdnsStatus)Enum.Parse(typeof(DdnsStatus), document.Descendants("NewStatusIPv6").First().Value.Replace("-", "_")),
                UpdateUrl = document.Descendants("NewUpdateUrl").First().Value,
                Username = document.Descendants("NewUsername").First().Value
            };
        }

        /// <summary>
        /// Method to get the dyn dns providers
        /// </summary>
        /// <returns>the dyn dns providers</returns>
        public async Task<ICollection<DdnsProvider>> GetDDNSProvidersAsync()
        {
            XDocument document = await InvokeAsync("GetDDNSProviders", null);

            // parse the provider list
            XDocument providerList = XDocument.Parse(document.Descendants("NewProviderList").First().Value);

            List<DdnsProvider> providers = new List<DdnsProvider>();

            foreach(XElement element in GetElements(providerList.Root, "Item"))
            {
                providers.Add(new DdnsProvider()
                {
                    ProviderName = GetElementValue(element, "ProviderName"),
                    InfoUrl = GetElementValue(element, "InfoURL")
                });
            }           

            return providers;
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
    }
}
