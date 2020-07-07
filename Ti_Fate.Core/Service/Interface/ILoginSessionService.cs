using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.Service.Interface
{
    public interface ILoginSessionService
    {
        LoginSession GetLoginSessionByAccount(string account);
    }
}
