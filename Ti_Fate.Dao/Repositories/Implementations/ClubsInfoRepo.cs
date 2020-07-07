using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class ClubsInfoRepo : IClubsInfoRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;

        public ClubsInfoRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public async Task<ClubsInfo> GetClubsInfoById(int id)
        {
            return await _tiFateDbContext.ClubsInfo.FindAsync(id);
        }

        public async Task<List<ClubsInfo>> GetClubsInfosByTitle(string searchString)
        {
            var clubInfos = _tiFateDbContext.ClubsInfo.Where(clubs => clubs.Title.Contains(searchString) && !clubs.IsDelete);
            return clubInfos.Any() ? await clubInfos.ToListAsync() : new List<ClubsInfo>();
        }

        public async Task<List<ClubsInfo>> GetAllClubsInfo()
        {
            var clubsInfos = _tiFateDbContext.ClubsInfo.Where(c => !c.IsDelete).OrderByDescending(c => c.Id);
            return clubsInfos.Any() ? await clubsInfos.ToListAsync() : new List<ClubsInfo>();
        }

        public async Task AddClubsInfo(ClubsInfo clubsInfo)
        {
            _tiFateDbContext.ClubsInfo.Add(clubsInfo);
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateClubsInfo(ClubsInfo newClubsInfo)
        {
            var oldClubsInfo = _tiFateDbContext.ClubsInfo.Find(newClubsInfo.Id);

            oldClubsInfo.ClubId = newClubsInfo.ClubId;
            oldClubsInfo.Title = newClubsInfo.Title;
            oldClubsInfo.Content = newClubsInfo.Content;
            oldClubsInfo.StartTime = newClubsInfo.StartTime;
            oldClubsInfo.EndTime = newClubsInfo.EndTime;

            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task DeleteClubsInfo(int id)
        {
            var deleteClubsInfo = _tiFateDbContext.ClubsInfo.Find(id);
            if (deleteClubsInfo == null)
            {
                return;
            }

            deleteClubsInfo.IsDelete = true;
            await _tiFateDbContext.SaveChangesAsync();
        }
    }
}
