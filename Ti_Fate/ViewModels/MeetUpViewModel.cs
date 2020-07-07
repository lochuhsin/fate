using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class MeetUpViewModel
    {
        public MeetUpViewModel(IEnumerable<MeetUpDomainModel> domainModelList)
        {
            DomainModelList = domainModelList ;
        }

        public IEnumerable<MeetUpDomainModel> DomainModelList { get; set; }
    }
}
