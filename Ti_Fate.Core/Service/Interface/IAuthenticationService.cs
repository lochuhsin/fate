using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.Service.Interface
{
    public interface IAuthenticationService
    {
        UserAuthenticateInfo GetAuthenticateInfo(string account , string password);
    }
}