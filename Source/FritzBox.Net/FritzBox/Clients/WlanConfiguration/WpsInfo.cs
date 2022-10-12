namespace FritzBox.Net.FritzBox.Clients.WlanConfiguration
{
    /// <summary>
    /// class for wps informations
    /// </summary>
    public class WpsInfo
    {
        /// <summary>
        /// gets the wps status
        /// </summary>
        public WpsStatus Status { get; internal set; }

        /// <summary>
        /// Gets the wps mode
        /// </summary>
        public WpsMode Mode { get; internal set; }
    }
}