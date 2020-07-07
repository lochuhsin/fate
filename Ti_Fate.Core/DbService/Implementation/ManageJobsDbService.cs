using System;
using System.Collections.Generic;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class ManageJobsDbService : IManageJobsDbService
    {
        private readonly IJobsInfoRepo _jobsInfoRepo;

        public ManageJobsDbService(IJobsInfoRepo jobsInfoRepo)
        {
            _jobsInfoRepo = jobsInfoRepo;
        }

        public void UpdateLastExecute(string name, DateTime lastTime)
        {
            _jobsInfoRepo.UpdateLastExecuteTime(name, lastTime);
        }

        public List<JobsInfoDomainModel> GetAllJobsInfos()
        {
            var jobsInfoDomainModelList = new List<JobsInfoDomainModel>();
            foreach (var jobsInfo in _jobsInfoRepo.GetAllJobsInfos().Result)
            {
                jobsInfoDomainModelList.Add(new JobsInfoDomainModel(jobsInfo));
            }
            return jobsInfoDomainModelList;
        }
    }
}
