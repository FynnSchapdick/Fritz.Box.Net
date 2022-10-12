using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using FritzBox.Net.Fritz.Clients.Base;

namespace FritzBox.Net.Fritz.Clients.WanEthernetLinkConfig
{
    /// <summary>
    /// client for WAN Ethernet Link Config service
    /// </summary>
    public class WanEthernetLinkConfigClient : FritzTr64Client
    {
        public WanEthernetLinkConfigClient(string url, int timeout) : base(url, timeout)
        {
        }

        public WanEthernetLinkConfigClient(string url, int timeout, string username) : base(url, timeout, username)
        {
        }

        public WanEthernetLinkConfigClient(string url, int timeout, string username, string password) : base(url, timeout, username, password)
        {
        }

        public WanEthernetLinkConfigClient(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
        }

        /// <summary>
        /// Gets the control url
        /// </summary>
        protected override string ControlUrl => "/upnp/control/wanethlinkconfig1";

        /// <summary>
        /// Gets the request namespace
        /// </summary>                                 
        protected override string RequestNameSpace => "urn:dslforum-org:service:WANEthernetLinkConfig:1";

        /// <summary>
        /// Method to get the ethernet link status
        /// </summary>
        /// <returns>the ethernet link status</returns>
        public async Task<EthernetLinkStatus> GetEthernetLinkStatusAsync()
        {
            XDocument document = await InvokeAsync("GetEthernetLinkStatus", null);
            return (EthernetLinkStatus)Enum.Parse(typeof(EthernetLinkStatus), document.Descendants("NewEthernetLinkStatus").First().Value);
        }
    }
}
