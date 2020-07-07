using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;

namespace Ti_Fate.Core.Service.Implementation
{
    public class DummyAuthenticationService : IAuthenticationService
    {
        public UserAuthenticateInfo GetAuthenticateInfo(string account, string password)
        {
            
            var authenticationInfo = new UserAuthenticateInfo()
            {
                IsAuthenticate = true,
                Name = null,
                Description = null
            };
            return authenticationInfo;
        }
    }
}