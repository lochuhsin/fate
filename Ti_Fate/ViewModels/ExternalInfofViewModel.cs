using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.ViewModels
{
    public class ExternalInfofViewModel
    {
         public ExternalInfofViewModel(List<ExternalInfoDomainModel> domainModelList)
        {
            DomainModelList = domainModelList ;
        }

        public List<ExternalInfoDomainModel> DomainModelList { get; set; }

    }
}
