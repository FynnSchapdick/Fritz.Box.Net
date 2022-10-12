using System;

namespace FritzBox.Net.Fritz.Clients.LanEthernetInterface
{
    /// <summary>
    /// Informations about lan ethernet interface
    /// </summary>
    public class LanEthernetInterfaceInfo
    {
        /// <summary>
        /// gets the enable state
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// gets the interface status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets the mac address
        /// </summary>
        public string MACAddress { get; set; }
        /// <summary>
        /// gets the max bit rate
        /// </summary>
        public UInt32 MaxBitRate { get; set; }
        /// <summary>
        /// Gets the duplex mode
        /// </summary>
        public string DuplexMode { get; set; }

    }
}