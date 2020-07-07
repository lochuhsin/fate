using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IClubsDbService
    {
        ClubsDomainModel GetClubNameById(int id);
        List<ClubsDomainModel> GetClubsDomainModelList();
    }
}