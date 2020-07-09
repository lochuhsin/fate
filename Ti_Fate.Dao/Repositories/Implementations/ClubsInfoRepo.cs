using System.Collections.Generic;
using System.Linq;
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

        public ClubsInfo GetClubsInfoById(int id)
        {
            return _tiFateDbContext.ClubsInfo.Find(id);
        }

        public List<ClubsInfo> GetClubsInfosByTitle(string searchString)
        {
            var clubInfos = _tiFateDbContext.ClubsInfo.Where(clubs => clubs.Title.Contains(searchString) && !clubs.IsDelete).ToList();
            return clubInfos.Any() ? clubInfos : new List<ClubsInfo>();

        }

        public List<ClubsInfo> GetAllClubsInfo()
        {
            var clubsInfos = _tiFateDbContext.ClubsInfo.Where(c => !c.IsDelete).OrderByDescending(c => c.Id);
            return clubsInfos.Any() ? clubsInfos.ToList() : new List<ClubsInfo>();
        }

        public void AddClubsInfo(ClubsInfo clubsInfo)
        {
            _tiFateDbContext.ClubsInfo.Add(clubsInfo);
            _tiFateDbContext.SaveChanges();
        }

        public void UpdateClubsInfo(ClubsInfo newClubsInfo)
        {
            var oldClubsInfo = _tiFateDbContext.ClubsInfo.Find(newClubsInfo.Id);

            oldClubsInfo.ClubId = newClubsInfo.ClubId;
            oldClubsInfo.Title = newClubsInfo.Title;
            oldClubsInfo.Content = newClubsInfo.Content;
            oldClubsInfo.StartTime = newClubsInfo.StartTime;
            oldClubsInfo.EndTime = newClubsInfo.EndTime;

            _tiFateDbContext.SaveChanges();
        }

        public void DeleteClubsInfo(int id)
        {
            var deleteClubsInfo = _tiFateDbContext.ClubsInfo.Find(id);
            if (deleteClubsInfo == null)
            {
                return;
            }

            deleteClubsInfo.IsDelete = true;
            _tiFateDbContext.SaveChanges();
        }
    }
}
