using FritzBox.Net.Fritz.Clients.Base;

namespace FritzBox.Net.Fritz.Clients.WlanConfiguration
{
    /// <summary>
    /// client for wlan configuration service for the Guest network
    /// </summary>
    public class WlanConfigurationClient3 : WlanConfigurationClient
    {
        public WlanConfigurationClient3(string url, int timeout) : base(url, timeout)
        {
        }

        
        public WlanConfigurationClient3(string url, int timeout, string username) : base(url, timeout, username)
        {
        }

        
        public WlanConfigurationClient3(string url, int timeout, string username, string password) : base(url, timeout, username, password)
        {
        }

        
        public WlanConfigurationClient3(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
        }

        /// <summary>
        /// Gets the control url
        /// </summary>
        protected override string ControlUrl => "/upnp/control/wlanconfig3";

        /// <summary>
        /// Gets the request namespace
        /// </summary>
        protected override string RequestNameSpace => "urn:dslforum-org:service:WLANConfiguration:3";
    }
}
