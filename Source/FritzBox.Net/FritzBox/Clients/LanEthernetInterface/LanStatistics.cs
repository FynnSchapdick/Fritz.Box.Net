using System;

namespace FritzBox.Net.FritzBox.Clients.LanEthernetInterface
{
    /// <summary>
    /// Lan statistic informations
    /// </summary>
    public class LanStatistics
    {
        /// <summary>
        /// Gets the bytes sent
        /// </summary>
        public UInt32 BytesSent { get; set; }
        /// <summary>
        /// Gets the bytes received
        /// </summary>
        public UInt32 BytesReceived { get; set; }
        /// <summary>
        /// Gets the packets sent
        /// </summary>
        public UInt32 PacketsSent { get; set; }
        /// <summary>
        /// Gets the packets received
        /// </summary>
        public UInt32 PacketsReceived { get; set; }
    }
}