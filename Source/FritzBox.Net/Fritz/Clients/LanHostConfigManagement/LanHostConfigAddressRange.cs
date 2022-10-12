using System.Net;

namespace FritzBox.Net.Fritz.Clients.LanHostConfigManagement
{
    /// <summary>
    /// class for holding ip address range
    /// </summary>
    public class LanHostConfigAddressRange
    {
        /// <summary>
        /// Gets the min address
        /// </summary>
        public IPAddress MinAddress { get; internal set; }

        /// <summary>
        /// Gets the max address
        /// </summary>
        public IPAddress MaxAddress { get; internal set; }
    }
}
