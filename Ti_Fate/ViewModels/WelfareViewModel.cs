using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class WelfareViewModel
    {
        public WelfareViewModel(IEnumerable<WelfareDomainModel> domainModelList)
        {
            DomainModelList = domainModelList;
        }

        public IEnumerable<WelfareDomainModel> DomainModelList { get; set; }

    }
}
