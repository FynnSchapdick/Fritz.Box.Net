using System;

namespace FritzBox.Net.FritzBox.Clients.Base
{
    /// <summary>
    /// flags enumeration for possible connection types
    /// </summary>
    [Flags]
    public enum PossibleConnectionTypes
    {
        /// <summary>
        /// unconfigured
        /// </summary>
        Unconfigured,
        /// <summary>
        /// ip routed
        /// </summary>
        IP_Routed,
        /// <summary>
        /// ip bridged
        /// </summary>
        IP_Bridged
    }
}
