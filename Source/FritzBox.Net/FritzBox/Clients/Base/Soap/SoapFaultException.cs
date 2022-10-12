using System;

namespace FritzBox.Net.FritzBox.Clients.Base.Soap
{
    public class SoapFaultException : Exception
    {
        public SoapFaultException(string faultCode, string faultString, string upnpError) : base($"{faultCode}; {faultString} {Environment.NewLine}{upnpError}")
        {
            FaultCode = faultCode;
            FaultString = faultString;
        }

        /// <summary>
        /// Gets or sets the fault code
        /// </summary>
        public string FaultCode { get; internal set; }

        /// <summary>
        /// gets or sets the fault string
        /// </summary>
        public string FaultString { get; internal set; }

        /// <summary>
        /// Gets or sets the error details
        /// </summary>
        public string Detail { get; set; }
    }
}
