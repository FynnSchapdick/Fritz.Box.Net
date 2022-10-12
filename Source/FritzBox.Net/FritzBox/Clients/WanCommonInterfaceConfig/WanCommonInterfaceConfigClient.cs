using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using FritzBox.Net.FritzBox.Clients.Base;
using FritzBox.Net.FritzBox.Clients.Base.Soap;

namespace FritzBox.Net.FritzBox.Clients.WanCommonInterfaceConfig
{
    /// <summary>
    /// client for wan common interface config service
    /// </summary>
    public class WanCommonInterfaceConfigClient : FritzTr64Client
    {
        #region Construction / Destruction
        
        public WanCommonInterfaceConfigClient(string url, int timeout) : base(url, timeout)
        {
        }
        
        public WanCommonInterfaceConfigClient(string url, int timeout, string username) : base(url, timeout, username)
        {
        }
        
        public WanCommonInterfaceConfigClient(string url, int timeout, string username, string password) : base(url, timeout, username, password)
        {
        }
        
        public WanCommonInterfaceConfigClient(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
        }

        #endregion
        /// <summary>
        /// Gets the control url
        /// </summary>
        protected override string ControlUrl => "/upnp/control/wancommonifconfig1";

        /// <summary>
        /// Gets the request namespace
        /// </summary>
        protected override string RequestNameSpace => "urn:dslforum-org:service:WANCommonInterfaceConfig:1";

        /// <summary>
        /// async Method to get the common link properties
        /// </summary>
        /// <remarks>Internal invokes GetCommonLinkProperties on device</remarks>
        /// <returns>the common link properties</returns>
        public async Task<CommonLinkProperties> GetCommonLinkPropertiesAsync()
        {
            XDocument document = await InvokeAsync("GetCommonLinkProperties", null);

            CommonLinkProperties properties = new CommonLinkProperties();
            properties.WANAccessType = document.Descendants("NewWANAccessType").First().Value;
            properties.PhysicalLinkStatus = document.Descendants("NewPhysicalLinkStatus").First().Value;
            properties.Layer1DownstreamMaxBitRate = Convert.ToUInt32(document.Descendants("NewLayer1DownstreamMaxBitRate").First().Value);
            properties.Layer1UpstreamMaxBitRate = Convert.ToUInt32(document.Descendants("NewLayer1UpstreamMaxBitRate").First().Value);

            return properties;
        }

        /// <summary>
        /// async Method to get the total bytes sent
        /// </summary>
        /// <remarks>Internal invokes GetTotalBytesSent on device</remarks>
        /// <returns>the total bytes sent</returns>
        public async Task<UInt64> GetTotalBytesSentAsync()
        {
            XDocument document = await InvokeAsync("GetTotalBytesSent", null);
            return Convert.ToUInt64(document.Descendants("NewTotalBytesSent").First().Value);
        }
        
        /// <summary>
        /// async Method to get the total bytes received
        /// </summary>
        /// <remarks>Internal invokes GetTotalBytesReceived on device</remarks>
        /// <returns>the total bytes received</returns>
        public async Task<UInt64> GetTotalBytesReceivedAsync()
        {
            XDocument document = await InvokeAsync("GetTotalBytesReceived", null);
            return Convert.ToUInt64(document.Descendants("NewTotalBytesReceived").First().Value);
        }
        
        /// <summary>
        /// async Method to get the total packets sent
        /// </summary>
        /// <remarks>Internal invokes GetTotalPacketsSent on device</remarks>
        /// <returns>the total packets sent</returns>
        public async Task<UInt64> GetTotalPacketsSentAsync()
        {
            XDocument document = await InvokeAsync("GetTotalPacketsSent", null);
            return Convert.ToUInt64(document.Descendants("NewTotalPacketsSent").First().Value);
        }

        /// <summary>
        /// async Method to get the total packets received
        /// </summary>
        /// <remarks>Internal invokes GetTotalPacketsReceived on device</remarks>
        /// <returns>the total packets received</returns>
        public async Task<UInt64> GetTotalPacketsReceivedAsync()
        {
            XDocument document = await InvokeAsync("GetTotalPacketsReceived", null);            
            return Convert.ToUInt64(document.Descendants("NewTotalPacketsReceived").First().Value);
        }

        /// <summary>
        /// async Method to set the wan access type
        /// </summary>
        /// <remarks>Internal invokes X_AVM-DE_SetWANAccessType on device</remarks>
        /// <param name="accessType">the new wan access type</param>
        public async Task SetWANAccessTypeAsync(string accessType)
        {
            XDocument document = await InvokeAsync("X_AVM-DE_SetWANAccessType", new SoapRequestParameter("NewAccessType", accessType));
        }

        /// <summary>
        /// Method to get the online monitor
        /// </summary>
        /// <remarks>Internal invokes X_AVM-DE_GetOnlineMonitor on device</remarks>
        /// <param name="groupIndex">the group index to request the online monitor for</param>
        /// <returns>the online monitor info</returns>
        public async Task<OnlineMonitorInfo> GetOnlineMonitorAsync(UInt32 groupIndex)  
        {
            XDocument document = await InvokeAsync("X_AVM-DE_GetOnlineMonitor", new SoapRequestParameter("NewSyncGroupIndex", groupIndex));

            OnlineMonitorInfo info = new OnlineMonitorInfo();
            info.SyncGroupMode = document.Descendants("NewSyncGroupMode").First().Value;
            info.SyncGroupName = document.Descendants("NewSyncGroupName").First().Value;
            info.TotalNumberSyncGroups = Convert.ToUInt32(document.Descendants("NewTotalNumberSyncGroups").First().Value);
            info.DownStream = UpDownValuesToList(document.Descendants("Newds_current_bps").First().Value);
            info.DownStream_Media = UpDownValuesToList(document.Descendants("Newmc_current_bps").First().Value);
            info.MaxUpStream = Convert.ToUInt32(document.Descendants("Newmax_us").First().Value);
            info.MaxDownStream = Convert.ToUInt32(document.Descendants("Newmax_ds").First().Value);
            info.UpStream = UpDownValuesToList(document.Descendants("Newus_current_bps").First().Value);
            info.UpstreamDefaultPrio = UpDownValuesToList(document.Descendants("Newprio_default_bps").First().Value);
            info.UpstreamHighPrio = UpDownValuesToList(document.Descendants("Newprio_high_bps").First().Value);
            info.UpstreamLowPrio = UpDownValuesToList(document.Descendants("Newprio_low_bps").First().Value);
            info.UpstreamRealtimePrio = UpDownValuesToList(document.Descendants("Newprio_realtime_bps").First().Value);

            return info;
        }        

        /// <summary>
        /// Method to get values from string as List<UInt32>
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private List<UInt32> UpDownValuesToList(string values)
        {
            return values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select((entry) => UInt32.Parse(entry.Trim())).ToList();
        }
    }
}
