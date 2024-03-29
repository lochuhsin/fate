﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class JobsInfoRepo : IJobsInfoRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;

        public JobsInfoRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public List<JobsInfo> GetAllJobsInfos()
        {
            return _tiFateDbContext.JobsInfo.OrderByDescending(m => m.JobName).ToList();
        }

        public void UpdateLastExecuteTime(string jobName, DateTime lastTime)
        {
            var job = _tiFateDbContext.JobsInfo.Where(m => m.JobName == jobName).ToList();
            job[0].LastExecute = lastTime;
            _tiFateDbContext.SaveChanges();
        }
    }
}