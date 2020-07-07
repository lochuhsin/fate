using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IClubsInfoDbService
    {
        ClubsInfoDomainModel GetClubsInfoById(int id);
        List<ClubsInfoDomainModel> GetClubsInfoByTitle(string searchString);
        List<ClubsInfoDomainModel> GetClubsInfoDomainModelList();
        void AddClubsInfo(ClubsInfoDomainModel clubsInfoDomainModel);
        void UpdateClubsInfo(ClubsInfoDomainModel clubsInfoDomainModel);
        void DeleteClubsInfo(int id);
    }
}
