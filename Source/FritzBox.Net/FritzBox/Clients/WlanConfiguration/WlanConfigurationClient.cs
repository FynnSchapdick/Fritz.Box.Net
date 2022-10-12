using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using FritzBox.Net.FritzBox.Clients.Base;
using FritzBox.Net.FritzBox.Clients.Base.Soap;

namespace FritzBox.Net.FritzBox.Clients.WlanConfiguration
{
    /// <summary>
    /// client for wlan configuration service 
    /// </summary>
    public class WlanConfigurationClient : FritzTr64Client
    {
        public WlanConfigurationClient(string url, int timeout) : base(url, timeout)
        {
        }

        
        public WlanConfigurationClient(string url, int timeout, string username) : base(url, timeout, username)
        {
        }

        
        public WlanConfigurationClient(string url, int timeout, string username, string password) : base(url, timeout, username, password)
        {
        }

        
        public WlanConfigurationClient(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
        }

        /// <summary>
        /// Gets the control url
        /// </summary>
        protected override string ControlUrl => "/upnp/control/wlanconfig1";

        /// <summary>
        /// Gets the request namespace
        /// </summary>
        protected override string RequestNameSpace => "urn:dslforum-org:service:WLANConfiguration:1";

        /// <summary>
        /// Method to enable or disable the wlan
        /// </summary>
        /// <param name="enabled">true or false (enabled or disabled)</param>
        /// <returns></returns>
        public async Task SetEnableAsync(bool enabled)
        {
            await InvokeAsync("SetEnable", new SoapRequestParameter("NewEnable", enabled ? "1" : "0"));
        }

        /// <summary>
        /// Method to get the wlan info
        /// </summary>
        /// <returns></returns>
        public async Task<WlanInfo> GetInfoAsync()
        {            
            XDocument document = await InvokeAsync("GetInfo", null);
            return new WlanInfo()
            {
                Config = new WlanConfig()
                {
                    BasicEncryptionModes = (BasicEncryptionModes)Enum.Parse(typeof(BasicEncryptionModes), document.Descendants("NewBasicEncryptionModes").First().Value),
                    BeaconType = Enum.TryParse<BeaconType>(document.Descendants("NewBeaconType").First().Value, out BeaconType result) ? result : BeaconType._11i,
                    Channel = Convert.ToUInt16(document.Descendants("NewChannel").First().Value),
                    MACAddressControlEnabled = document.Descendants("NewMACAddressControlEnabled").First().Value == "1",
                    SSID = document.Descendants("NewSSID").First().Value,
                },
                BSSID = document.Descendants("NewBSSID").First().Value,
                Enabled = document.Descendants("NewEnable").First().Value == "1",
                Standard = (WlanStandard)Enum.Parse(typeof(WlanStandard), document.Descendants("NewStandard").First().Value),
                Status = document.Descendants("NewStatus").First().Value,
                PSKValidationInfo = new DataValidationInfo()
                {
                    MinChars = Convert.ToUInt16(document.Descendants("NewMinCharsPSK").First().Value),
                    MaxChars = Convert.ToUInt16(document.Descendants("NewMaxCharsPSK").First().Value),
                    AllowedChars = document.Descendants("NewAllowedCharsPSK").First().Value
                },
                SSIDValidationInfo = new DataValidationInfo()
                {
                    MinChars = Convert.ToUInt16(document.Descendants("NewMinCharsSSID").First().Value),
                    MaxChars = Convert.ToUInt16(document.Descendants("NewMaxCharsSSID").First().Value),
                    AllowedChars = document.Descendants("NewAllowedCharsSSID").First().Value
                }
            };
        }

        /// <summary>
        /// Method to set the wlan configuration
        /// </summary>
        /// <param name="config">the configuration</param>
        /// <returns></returns>
        public async Task SetConfigAsync(WlanConfig config)
        {
            List<SoapRequestParameter> parameters = new List<SoapRequestParameter>()
            {
                new SoapRequestParameter("NewChannel", config.Channel),
                new SoapRequestParameter("NewSSID", config.SSID),
                new SoapRequestParameter("NewBeaconType", config.BeaconType != BeaconType._11i ? config.BeaconType.ToString() : "11i"),
                new SoapRequestParameter("NewMacAddressControlEnabled", config.MACAddressControlEnabled ? "1" : "0"),
                new SoapRequestParameter("NewBasicEncryptionModes", config.BasicEncryptionModes.ToString()),
            };

            await InvokeAsync("SetConfig", parameters.ToArray());
        }

        /// <summary>
        /// Method to get the security key information
        /// </summary>
        /// <returns></returns>
        public async Task<SecurityKeyConfig> GetSecurityKeysAsync()
        {
            XDocument document = await InvokeAsync("GetSecurityKeys", null);
            return new SecurityKeyConfig()
            {
                WEPKey0 = document.Descendants("NewWEPKey0").First().Value,
                WEPKey1 = document.Descendants("NewWEPKey1").First().Value,
                WEPKey2 = document.Descendants("NewWEPKey2").First().Value,
                WEPKey3 = document.Descendants("NewWEPKey3").First().Value,
                PreSharedKey = document.Descendants("NewPreSharedKey").First().Value,
                KeyPassphrase = document.Descendants("NewKeyPassphrase").First().Value
            };
        }

        /// <summary>
        /// Method to set the security keys
        /// </summary>
        /// <param name="config">the security key config</param>
        /// <returns></returns>
        public async Task SetSecurityKeysAsync(SecurityKeyConfig config)
        {
            List<SoapRequestParameter> parameters = new List<SoapRequestParameter>()
            {
                new SoapRequestParameter("NewWEPKey0", config.WEPKey0),
                new SoapRequestParameter("NewWEPKey1", config.WEPKey1),
                new SoapRequestParameter("NewWEPKey2", config.WEPKey2),
                new SoapRequestParameter("NewWEPKey3", config.WEPKey3),
                new SoapRequestParameter("NewPreSharedKey", config.PreSharedKey),
                new SoapRequestParameter("NewKeyPassphrase", config.KeyPassphrase)
            };

            await InvokeAsync("SetSecurityKeys", parameters.ToArray());
        }

        /// <summary>
        /// Method to get the default wep key index
        /// </summary>
        /// <returns>the default wep key index</returns>
        public async Task<UInt16> GetDefaultWEPKeyIndexAsync()
        {
            XDocument document = await InvokeAsync("GetDefaultWEPKeyIndex", null);
            return Convert.ToUInt16(document.Descendants("NewDefaultWEPKeyIndex").First().Value);
        }

        /// <summary>
        /// Method to set the default wep key index
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns></returns>
        public async Task SetDefaultWEPKeyIndexAsync(UInt16 index)
        {
            await InvokeAsync("SetDefaultWEPKeyIndex", new SoapRequestParameter("NewDefaultWEPKeyIndex", index));
        }

        /// <summary>
        /// Method to get the basic beacon security properties
        /// </summary>
        /// <returns>encryption mode</returns>
        public async Task<BasicEncryptionModes> GetBasBeaconSecurityPropertiesAsync()
        {
            XDocument document = await InvokeAsync("GetBasBeaconSecurityProperties", null);
            return (BasicEncryptionModes)Enum.Parse(typeof(BasicEncryptionModes), document.Descendants("NewBasicEncryptionModes").First().Value);
        }

        /// <summary>
        /// Method to set the basic beacon security properties
        /// </summary>
        /// <returns></returns>
        public async Task SetBasBeaconSecurityPropertiesAsync(BasicEncryptionModes encryptionMode)
        {
            await InvokeAsync("SetBasBeaconSecurityProperties", new SoapRequestParameter("NewBasicEncryptionModes", encryptionMode.ToString()));
        }

        /// <summary>
        /// Method to get the bssid
        /// </summary>
        /// <returns>the bssid</returns>
        public async Task<string> GetBSSIDAsync()
        {
            XDocument document = await InvokeAsync("GetBSSID", null);
            return document.Descendants("NewBSSID").First().Value;
        }

        /// <summary>
        /// Method to get the bssid
        /// </summary>
        /// <returns>the bssid</returns>
        public async Task<string> GetSSIDAsync()
        {
            XDocument document = await InvokeAsync("GetSSID", null);
            return document.Descendants("NewSSID").First().Value;
        }

        /// <summary>
        /// Method to set the bssid
        /// </summary>
        /// <param name="ssid">the new ssid</param>
        public async Task SetSSIDAsync(string ssid)
        {
            await InvokeAsync("SetSSID", new SoapRequestParameter("NewSSID", ssid));
        }

        /// <summary>
        /// Method to get the beacon type
        /// </summary>
        /// <returns>the beacon type</returns>
        public async Task<BeaconType> GetBeaconTypeAsync()
        {
            XDocument document = await InvokeAsync("GetBeaconType", null);
            return Enum.TryParse<BeaconType>(document.Descendants("NewBeaconType").First().Value, out BeaconType result) ? result : BeaconType._11i;
        }

        /// <summary>
        /// Method to set the beacon type
        /// </summary>
        /// <param name="type">the new beacon type</param>
        /// <returns></returns>
        public async Task SetBeaconTypeAsync(BeaconType type)
        {
            await InvokeAsync("SetBeaconType", new SoapRequestParameter("NewBeaconType", type == BeaconType._11i ? "11i" : type.ToString()));
        }

        /// <summary>
        /// Method to get the channel info
        /// </summary>
        /// <returns>the channel info</returns>
        public async Task<ChannelInfo> GetChannelInfoAsync()
        {
            XDocument document = await InvokeAsync("GetChannelInfo", null);
            return new ChannelInfo()
            {
                Channel = Convert.ToUInt16(document.Descendants("NewChannel").First().Value),
                PossibleChannels = document.Descendants("NewPossibleChannels").First().Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select((entry) => UInt16.Parse(entry.Trim())).ToList()
            };
        }

        /// <summary>
        /// Method to set the channel
        /// </summary>
        /// <param name="channel">the new channel</param>
        /// <returns></returns>
        public async Task SetChannelAsync(UInt16 channel)
        {
            await InvokeAsync("SetChannel", new SoapRequestParameter("NewChannel", channel));
        }

        /// <summary>
        /// Method to get the total assiciations
        /// </summary>
        /// <returns>the total associations</returns>
        public async Task<UInt16> GetTotalAssociationsAsync()
        {
            XDocument document = await InvokeAsync("GetTotalAssociations", null);
            return Convert.ToUInt16(document.Descendants("NewTotalAssociations").First().Value);
        }

        /// <summary>
        /// Method to get a generic associated device info
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns>the device info</returns>
        public async Task<WlanDeviceInfo> GetGenericAssociatedDeviceInfoAsync(int index)
        {
            XDocument document = await InvokeAsync("GetGenericAssociatedDeviceInfo", new SoapRequestParameter("NewAssociatedDeviceIndex", index));
            return new WlanDeviceInfo()
            {
                MACAddress = document.Descendants("NewAssociatedDeviceMACAddress").First().Value,
                IPAddress = IPAddress.TryParse(document.Descendants("NewAssociatedDeviceIPAddress").First().Value, out IPAddress ip) ? ip : IPAddress.None,
                DeviceAuthState = document.Descendants("NewAssociatedDeviceAuthState").First().Value == "0",
                Speed = Convert.ToUInt16(document.Descendants("NewX_AVM-DE_Speed").First().Value),
                SignalStrength = Convert.ToUInt16(document.Descendants("NewX_AVM-DE_SignalStrength").First().Value)
            };
        }

        /// <summary>
        /// Method to get the associated devices
        /// </summary>
        /// <returns>the associated devices</returns>
        public async Task<IEnumerable<WlanDeviceInfo>> GetAssociatedDevicesAsync()
        {
            List<WlanDeviceInfo> devices = new List<WlanDeviceInfo>();

            for (int i = 0; i < await GetTotalAssociationsAsync(); i++)
                devices.Add(await GetGenericAssociatedDeviceInfoAsync(i));

            return devices;
        }

        /// <summary>
        /// Method to get a specific associated device by the mac address
        /// </summary>
        /// <param name="macAddress">the mac address</param>
        /// <returns>the device info</returns>
        public async Task<WlanDeviceInfo> GetSpecificAssociatedDeviceInfoAsync(string macAddress)
        {
            XDocument document = await InvokeAsync("GetSpecificAssociatedDeviceInfo", new SoapRequestParameter("NewAssociatedDeviceMACAddress", macAddress));
            return new WlanDeviceInfo()
            {
                MACAddress = macAddress,
                IPAddress = IPAddress.TryParse(document.Descendants("NewAssociatedDeviceIPAddress").First().Value, out IPAddress ip) ? ip : IPAddress.None,
                DeviceAuthState = document.Descendants("NewAssociatedDeviceAuthState").First().Value == "0",
                Speed = Convert.ToUInt16(document.Descendants("NewX_AVM-DE_Speed").First().Value),
                SignalStrength = Convert.ToUInt16(document.Descendants("NewX_AVM-DE_SignalStrength").First().Value)
            };
        }

        /// <summary>
        /// Method to get a specific associated device by the ip address
        /// </summary>
        /// <param name="ipAddress">the ip address</param>
        /// <returns>the device info</returns>
        public async Task<WlanDeviceInfo> GetSpecificAssociatedDeviceInfoByIpAsync(IPAddress ipAddress)
        {
            XDocument document = await InvokeAsync("GetSpecificAssociatedDeviceInfoByIp", new SoapRequestParameter("NewAssociatedDeviceIPAddress", ipAddress.ToString()));
            return new WlanDeviceInfo()
            {
                MACAddress = document.Descendants("NewAssociatedDeviceMACAddress").First().Value,
                IPAddress = ipAddress,
                DeviceAuthState = document.Descendants("NewAssociatedDeviceAuthState").First().Value == "0",
                Speed = Convert.ToUInt16(document.Descendants("NewX_AVM-DE_Speed").First().Value),
                SignalStrength = Convert.ToUInt16(document.Descendants("NewX_AVM-DE_SignalStrength").First().Value)
            };
        }

        /// <summary>
        /// Method to enable or disable the surfstick
        /// </summary>
        /// <param name="enabled">new enabled value</param>
        /// <returns></returns>
        public async Task SetStickSurfEnableAsync(bool enabled)
        {
            await InvokeAsync("X_AVM-DE_SetStickSurfEnable", new SoapRequestParameter("NewStickSurfEnable", enabled ? "1" : "0"));
        }

        /// <summary>
        /// Method to get if the connection is ip tv optimized
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetIPTVOptimizedAsync()
        {
            XDocument document = await InvokeAsync("X_AVM-DE_GetIPTVOptimized", null);
            return document.Descendants("NewX_AVM-DE_IPTVoptimize").First().Value == "1";            
        }

        /// <summary>
        /// Method to set optimize state for ip tv
        /// </summary>
        /// <param name="optimize">the new optimize state</param>
        /// <returns></returns>
        public async Task SetIPTVOptimizedAsync(bool optimize)
        {
            await InvokeAsync("X_AVM-DE_SetIPTVOptimized", new SoapRequestParameter("NewX_AVM-DE_IPTVoptimize", optimize ? "1" : "0"));
        }

        /// <summary>
        /// Method to get night control informations
        /// </summary>
        /// <returns>the night control informations</returns>
        public async Task<NightControlInfo> GetNightControlAsync()
        {
            XDocument document = await InvokeAsync("X_AVM-DE_GetNightControl", null);
            return new NightControlInfo()
            {
                NightControl = document.Descendants("NewNightControl").First().Value,
                NightTimeControlNoForcedOff = document.Descendants("NewNightTimeControlNoForcedOff").First().Value == "1"
            };
        }

        /// <summary>
        /// Method to get wps informations
        /// </summary>
        /// <returns></returns>
        public async Task<WpsInfo> GetWPSInfoAsync()
        {
            XDocument document = await InvokeAsync("X_AVM-DE_GetWPSInfo", null);
            return new WpsInfo()
            {
                Mode = (WpsMode)Enum.Parse(typeof(WpsMode), document.Descendants("NewX_AVM-DE_WPSMode").First().Value),
                Status = (WpsStatus)Enum.Parse(typeof(WpsStatus), document.Descendants("NewX_AVM-DE_WPSStatus").First().Value)
            };
        }

        /// <summary>
        /// Method to get paket statistics
        /// </summary>
        /// <returns>the packet statistics</returns>
        public async Task<WlanStatistics> GetStatisticsAsync()
        {
            XDocument document = await InvokeAsync("GetStatistics", null);
            return FillWLanStatistics(document);
        }

        /// <summary>
        /// Method to get paket statistics
        /// </summary>
        /// <returns>the packet statistics</returns>
        public async Task<WlanStatistics> GetPacketStatisticsAsync()
        {
            XDocument document = await InvokeAsync("GetPacketStatistics", null);
            return FillWLanStatistics(document);
        }

        /// <summary>
        /// Method to fill packet statistics
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private WlanStatistics FillWLanStatistics(XDocument document)
        {
            return new WlanStatistics()
            {
                TotalPacketsSent = Convert.ToUInt64(document.Descendants("NewTotalPacketsSent").First().Value),
                TotalPacketsReceived = Convert.ToUInt64(document.Descendants("NewTotalPacketsReceived").First().Value)
            };
        }

        /// <summary>
        /// Method to enable or disable the 5GHz WLAN
        /// </summary>
        /// <returns></returns>
        public async Task SetHighFrequencyBandAsync(bool enableHighFrequency)
        {
            XDocument document = await InvokeAsync("X_SetHighFrequencyBand", new SoapRequestParameter("NewEnableHighFrequency", enableHighFrequency ? 1 : 0));
        }
    }
}
