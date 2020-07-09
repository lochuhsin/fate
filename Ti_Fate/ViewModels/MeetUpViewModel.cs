using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class MeetUpViewModel
    {
        public MeetUpViewModel(List<MeetUpDomainModel> domainModelList)
        {
            DomainModelList = domainModelList ;
        }

        public List<MeetUpDomainModel> DomainModelList { get; set; }
    }
}
