using System;

namespace FritzBox.Net.FritzBox.Clients.WlanConfiguration
{
    public class WlanStatistics
    {
        /// <summary>
        /// Gets or sets the number of total packets sent 
        /// </summary>
        public UInt64 TotalPacketsSent { get; set; }

        /// <summary>
        /// Gets or sets the total packets received
        /// </summary>
        public UInt64 TotalPacketsReceived { get; set; }
    }
}
