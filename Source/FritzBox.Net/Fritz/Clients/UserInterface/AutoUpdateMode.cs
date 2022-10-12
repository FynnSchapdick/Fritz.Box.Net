namespace FritzBox.Net.Fritz.Clients.UserInterface
{
    /// <summary>
    /// enum for update mode
    /// </summary>
    public enum AutoUpdateMode
    {
        /// <summary>
        /// auto update disabled
        /// </summary>
        off,
        /// <summary>
        /// auto update for all updates
        /// </summary>
        all,
        /// <summary>
        /// auto update for important updates
        /// </summary>
        important,
        /// <summary>
        /// only check automatically for updates
        /// </summary>
        check
    }
}