namespace FritzBox.Net.Fritz.Clients.Base.Soap
{
    /// <summary>
    /// class representing soap request parameters
    /// </summary>
    internal class SoapRequestParameter
    {
        public SoapRequestParameter(string name, object value)
        {
            ParameterName = name;
            ParameterValue = value;
        }

        /// <summary>
        /// Gets or sets the parameter name
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the parameter value
        /// </summary>
        public object ParameterValue { get; set; }
    }
}
