using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class ExternalInfofViewModel
    {
         public ExternalInfofViewModel(IEnumerable<ExternalInfoDomainModel> domainModelList)
        {
            DomainModelList = domainModelList ;
        }

        public IEnumerable<ExternalInfoDomainModel> DomainModelList { get; set; }

    }
}
