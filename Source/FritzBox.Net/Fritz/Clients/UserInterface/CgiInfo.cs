namespace FritzBox.Net.Fritz.Clients.UserInterface
{
    /// <summary>
    /// cgi info 
    /// </summary>
    public class CgiInfo
    {
        /// <summary>
        /// cgi update path
        /// </summary>
        public string CGIPath { get; internal set; }
        /// <summary>
        /// session id valid up to 60 seconds
        /// </summary>
        public string SessionID { get; internal set; }
    }
}