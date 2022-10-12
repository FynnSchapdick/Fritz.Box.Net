using FritzBox.Net.FritzBox.Clients.Base;

namespace FritzBox.Net.FritzBox.Clients.WlanConfiguration
{
    /// <summary>
    /// client for wlan configuration service for the 5GHz network
    /// </summary>
    public class WlanConfigurationClient2 : WlanConfigurationClient
    {
        public WlanConfigurationClient2(string url, int timeout) : base(url, timeout)
        {
        }

        public WlanConfigurationClient2(string url, int timeout, string username) : base(url, timeout, username)
        {
        }

        
        public WlanConfigurationClient2(string url, int timeout, string username, string password) : base(url, timeout, username, password)
        {
        }

        
        public WlanConfigurationClient2(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
        }

        /// <summary>
        /// Gets the control url
        /// </summary>
        protected override string ControlUrl => "/upnp/control/wlanconfig2";

        /// <summary>
        /// Gets the request namespace
        /// </summary>
        protected override string RequestNameSpace => "urn:dslforum-org:service:WLANConfiguration:2";
    }
}
