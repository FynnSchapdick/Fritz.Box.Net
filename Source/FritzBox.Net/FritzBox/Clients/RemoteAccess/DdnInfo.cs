using System.Net;

namespace FritzBox.Net.FritzBox.Clients.RemoteAccess
{
    /// <summary>
    /// class representing dyndns info
    /// </summary>
    public class DdnInfo
    {
        /// <summary>
        /// Gets or sets the dyn dns domain
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets if dyn dns is enabled
        /// </summary>
        public string Enabled { get; set; }

        /// <summary>
        /// Gets or sets the dyn dns mode
        /// </summary>
        public DdnsMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the provider
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 address
        /// </summary>
        public IPAddress ServerIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 address
        /// </summary>
        public IPAddress ServerIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 status
        /// </summary>
        public DdnsStatus StatusIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 status
        /// </summary>
        public DdnsStatus StatusIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the update url
        /// </summary>
        public string UpdateUrl { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }
    }
}