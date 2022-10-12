using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using FritzBox.Net.FritzBox.Clients.Base;
using FritzBox.Net.FritzBox.Clients.Base.Soap;

namespace FritzBox.Net.FritzBox.Clients.LanConfigSecurity
{
    /// <summary>
    /// client for lan config security service
    /// </summary>
    public class LanConfigSecurityClient : FritzTr64Client
    {
        public LanConfigSecurityClient(string url, int timeout) : base(url, timeout)
        {
        }
        
        public LanConfigSecurityClient(string url, int timeout, string username) : base(url, timeout, username)
        {
        }
        
        public LanConfigSecurityClient(string url, int timeout, string username, string password) : base(url, timeout, username, password)
        {
        }
        
        public LanConfigSecurityClient(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
        }

        /// <summary>
        /// Gets the control url
        /// </summary>
        protected override string ControlUrl => "/upnp/control/lanconfigsecurity";

        /// <summary>
        /// Gets the request namespace
        /// </summary>
        protected override string RequestNameSpace => "urn:dslforum-org:service:LANConfigSecurity:1";


        /// <summary>
        /// Method to get the password info
        /// </summary>
        /// <returns>the password info</returns>
        public async Task<DataValidationInfo> GetInfoAsync()
        {
            XDocument document = await InvokeAsync("GetInfo", null);
            DataValidationInfo info = new DataValidationInfo();

            info.AllowedChars = document.Descendants("NewAllowedCharsPassword").First().Value;
            info.MinChars = Convert.ToUInt16(document.Descendants("NewMinCharsPassword").First().Value);
            info.MaxChars = Convert.ToUInt16(document.Descendants("NewMaxCharsPassword").First().Value);

            return info;
        }

        /// <summary>
        /// Method to get if anonymous login is enabled
        /// </summary>
        /// <returns>true if anonymous login is enabled</returns>
        public async Task<bool> GetAnonymousLoginAsync()
        {
            XDocument document = await InvokeAsync("X_AVM-DE_GetAnonymousLogin", null);
            return document.Descendants("NewX_AVM-DE_AnonymousLoginEnabled").First().Value == "1";
        }

        /// <summary>
        /// Method to get the current user
        /// </summary>
        /// <returns>the current user</returns>
        public async Task<LanConfigSecurityUser> GetCurrentUserAsync()
        {
            XDocument document = await InvokeAsync("X_AVM-DE_GetCurrentUser", null);
            LanConfigSecurityUser user = new LanConfigSecurityUser();
            user.Username = document.Descendants("NewX_AVM-DE_CurrentUsername").First().Value;

            string rightsString = document.Descendants("NewX_AVM-DE_CurrentUserRights").First().Value;
            XDocument rightsDocument = XDocument.Parse(rightsString);

            IEnumerable<XElement> paths = rightsDocument.Descendants("path");
            IEnumerable<XElement> rights = rightsDocument.Descendants("access");
            
            for(int i = 0; i < paths.Count(); i++)
            {
                LanConfigSecurityRight right = new LanConfigSecurityRight();
                right.Path = paths.Skip(i).Take(1).First().Value;
                right.Access = rights.Skip(i).Take(1).First().Value;
                user.Rights.Add(right);
            }

            return user;
        }

        

        /// <summary>
        /// Method to set the password for the current user
        /// </summary>
        /// <param name="password">the password</param>
        public async Task SetConfigPasswordAsync(string password)
        {
            XDocument document = await InvokeAsync("SetConfigPassword", new SoapRequestParameter("NewPassword", password));
        }
    }
}
