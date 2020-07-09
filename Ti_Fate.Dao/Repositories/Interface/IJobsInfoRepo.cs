using System;
using System.Collections.Generic;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IJobsInfoRepo
    {
        List<JobsInfo> GetAllJobsInfos();
        void UpdateLastExecuteTime(string jobName, DateTime lastTime);
    }
}