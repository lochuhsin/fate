using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class WelfareViewModel
    {
        public WelfareViewModel(List<WelfareDomainModel> domainModelList)
        {
            DomainModelList = domainModelList;
        }

        public List<WelfareDomainModel> DomainModelList { get; set; }

    }
}
