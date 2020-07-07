using System.Collections.Generic;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;

namespace Ti_Fate.Core.Service.Implementation
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        private readonly LdapConfig _ldapConfig;

        public LdapAuthenticationService(LdapConfig ldapConfig)
        {
            _ldapConfig = ldapConfig;
        }

        public UserAuthenticateInfo GetAuthenticateInfo(string account, string password)
        {
            var result = ConnectToLdap(account, password);
            return result != null ? AddLdapInfo(result) : AddNullInfo(null);
        }

        private static UserAuthenticateInfo AddLdapInfo(SearchResult result)
        {
            var authenticateInfo = new UserAuthenticateInfo()
            {
                IsAuthenticate = result != null,
                Name = result.Properties["name"][0].ToString(),
                Description = result.Properties["description"][0].ToString()
            };
            
            return authenticateInfo;
        }

        private static UserAuthenticateInfo AddNullInfo(SearchResult result)
        {
            var authenticateInfo = new UserAuthenticateInfo()
            {
                IsAuthenticate = result != null,
                Name = null,
                Description = null
            };
            return authenticateInfo;
        }

        private SearchResult ConnectToLdap(string account, string password)
        {
            try
            {
                var entry = new DirectoryEntry(_ldapConfig.Host, account, password);
                var search = new DirectorySearcher(entry) { Filter = "(SAMAccountName=" + account + ")" };
                return search.FindOne();
            }
            catch (COMException)
            {
                return null;
            }
        }
    }
}