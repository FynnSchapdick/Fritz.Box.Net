using FritzBox.Net.FritzBox.Clients.Base;

namespace FritzBox.Net.FritzBox.Clients.Wan
{
    public class ConnectionTypeInfo
    {
        /// <summary>
        /// Gets the connection type
        /// </summary>
        public ConnectionType ConnectionType { get; internal set; }

        /// <summary>
        /// Gets the possible connection types
        /// </summary>
        public PossibleConnectionTypes PossibleConnectionTypes { get; internal set; }
    }
}
