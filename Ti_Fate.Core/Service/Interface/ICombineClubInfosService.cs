using System;
using System.Collections.Generic;
using System.Text;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.Service.Interface
{
    public interface ICombineClubInfosService
    {
        List<CombineClubInfosDomainModel> GetAllCombineClubInfosDomainModels();
        List<CombineClubInfosDomainModel> GetCombineClubInfosDomainModelsByTitle(string searchString);
    }
}
