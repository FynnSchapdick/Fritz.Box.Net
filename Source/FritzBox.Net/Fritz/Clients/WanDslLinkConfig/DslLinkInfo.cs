namespace FritzBox.Net.Fritz.Clients.WanDslLinkConfig
{
    /// <summary>
    /// class representing dsl link info
    /// </summary>
    public class DslLinkInfo
    {
        /// <summary>
        /// Gets or sets the link status
        /// </summary>
        public WanDslLinkStatus LinkStatus { get; set; }

        /// <summary>
        /// Gets or sets the link type
        /// </summary>
        public WanDslLinkType LinkType { get; set; }
    }
}