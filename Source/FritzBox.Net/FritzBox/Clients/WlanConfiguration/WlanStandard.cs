using System;

namespace FritzBox.Net.FritzBox.Clients.WlanConfiguration
{
    /// <summary>
    /// enumeration of wlan standards
    /// </summary>
    [Flags]
    public enum WlanStandard
    {
        /// <summary>
        /// WLAN standard a
        /// </summary>
        a,
        /// <summary>
        /// WLAN standard b
        /// </summary>
        b,
        /// <summary>
        /// WLAN standard g
        /// </summary>
        g,
        /// <summary>
        /// WLAN standard n
        /// </summary>
        n,
        /// <summary>
        /// WLAN standard ac
        /// </summary>
        ac
    }
}