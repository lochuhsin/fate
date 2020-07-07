using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IClubsInfoRepo
    {
        Task<ClubsInfo> GetClubsInfoById(int id);
        Task<List<ClubsInfo>> GetClubsInfosByTitle(string searchString);
        Task<List<ClubsInfo>> GetAllClubsInfo();
        Task AddClubsInfo(ClubsInfo clubsInfo);
        Task UpdateClubsInfo(ClubsInfo newClubsInfo);
        Task DeleteClubsInfo(int id);
    }
}
