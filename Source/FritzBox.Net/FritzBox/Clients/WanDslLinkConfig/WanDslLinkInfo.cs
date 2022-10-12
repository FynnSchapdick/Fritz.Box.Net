namespace FritzBox.Net.FritzBox.Clients.WanDslLinkConfig
{
    /// <summary>
    /// class representing WANDSLLinkInfo
    /// </summary>
    public class WanDslLinkInfo
    {
        /// <summary>
        /// Gets or sets if link is enabled
        /// </summary>
        public bool Enabled { get; set; }

        public DslLinkInfo LinkInfo { get; set; }

        /// <summary>
        /// Gets or sets the destination address
        /// </summary>
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Gets or sets the ATMEncapsulation
        /// </summary>
        public string ATMEncapsulation { get; set; }

        /// <summary>
        /// Gets or sets autoconfig
        /// </summary>
        public bool AutoConfig { get; set; }

        /// <summary>
        /// Gets or sets ATMQoS
        /// </summary>
        public string ATMQoS { get; set; }

        /// <summary>
        /// Gets or sets the ATM Peak cell rate
        /// </summary>
        public uint ATMPeakCellRate { get; set; }

        /// <summary>
        /// Gets or sets the ATMSustainableCellRate
        /// </summary>
        public uint ATMSustainableCellRate { get; set; }
    }
}