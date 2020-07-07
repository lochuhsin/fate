using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IJobsInfoRepo
    {
        Task<List<JobsInfo>> GetAllJobsInfos();
        Task UpdateLastExecuteTime(string jobName, DateTime lastTime);
    }
}
