using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Core.DomainModel
{
    public class JobsInfoDomainModel
    {
        public string JobName { get; set; }
        public string CronTrigger { get; set; }
        public DateTime LastExecute { get; set; }
        public JobsInfoDomainModel() { }

        public JobsInfoDomainModel(JobsInfo jobsInfo)
        {
            JobName = jobsInfo.JobName;
            CronTrigger = jobsInfo.CronTrigger;
            if (jobsInfo.LastExecute != null) LastExecute = (DateTime) jobsInfo.LastExecute;
        }

    }

}
