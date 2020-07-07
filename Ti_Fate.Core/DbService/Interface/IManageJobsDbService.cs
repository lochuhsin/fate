using System;
using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IManageJobsDbService
    {
        void UpdateLastExecute(string name, DateTime lastTime);
        List<JobsInfoDomainModel> GetAllJobsInfos();
    }
}
