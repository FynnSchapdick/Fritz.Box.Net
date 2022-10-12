using System.Collections.Generic;

namespace FritzBox.Net.FritzBox.Clients.LanConfigSecurity
{
    /// <summary>
    /// class representing a user
    /// </summary>
    public class LanConfigSecurityUser
    {
        /// <summary>
        /// gets or sets the user name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the security rights
        /// </summary>
        public List<LanConfigSecurityRight> Rights { get; set; } = new List<LanConfigSecurityRight>();
    }
}
