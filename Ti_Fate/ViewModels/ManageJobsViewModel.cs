using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class ManageJobsViewModel
    {
        public List<JobsInfoDomainModel> JobsInfoList { get; set; }
        public ManageJobsViewModel() { }

        public ManageJobsViewModel(List<JobsInfoDomainModel> manageJobsViewModelList)
        {
            JobsInfoList = manageJobsViewModelList;
        }
    }
}
