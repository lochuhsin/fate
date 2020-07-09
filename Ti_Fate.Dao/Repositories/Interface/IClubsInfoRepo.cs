using System.Collections.Generic;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IClubsInfoRepo
    {
        ClubsInfo GetClubsInfoById(int id);
        List<ClubsInfo> GetClubsInfosByTitle(string searchString);
        List<ClubsInfo> GetAllClubsInfo();
        void AddClubsInfo(ClubsInfo clubsInfo);
        void UpdateClubsInfo(ClubsInfo newClubsInfo);
        void DeleteClubsInfo(int id);
    }
}