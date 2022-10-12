﻿using System.Net;

namespace FritzBox.Net.Fritz.Clients.WlanConfiguration
{
    /// <summary>
    /// class holding informations about wlan devices
    /// </summary>
    public class WlanDeviceInfo
    {
        /// <summary>
        /// the mac address
        /// </summary>
        public string MACAddress { get; internal set; }

        /// <summary>
        /// the ip address
        /// </summary>
        public IPAddress IPAddress { get; internal set; }

        /// <summary>
        /// the authentication state (true authenticated, false not authenticated)
        /// </summary>
        public bool DeviceAuthState { get; internal set; }

        /// <summary>
        /// the connection speed
        /// </summary>
        public ushort Speed { get; internal set; }

        /// <summary>
        /// the signal strength
        /// </summary>
        public ushort SignalStrength { get; internal set; }
    }
}