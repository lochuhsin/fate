using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class ClubsRepo : IClubsRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;

        public ClubsRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public List<Clubs> GetAllClubs()
        {
            var clubs = _tiFateDbContext.Clubs;
            return clubs.Any() ? clubs.ToList() : new List<Clubs>();
        }

        public Clubs GetClubNameById(int id)
        {
            return _tiFateDbContext.Clubs.Find(id);
        }

        public List<Clubs> GetClubIdByName(string name)
        {
            var clubs = _tiFateDbContext.Clubs.Where(w => w.ClubName.Contains(name));
            return clubs.Any() ? clubs.ToList() : new List<Clubs>();
        }
    }
}