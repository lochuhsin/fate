using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Clubs>> GetAllClubs()
        {
            var clubs = _tiFateDbContext.Clubs;
            return clubs.Any() ? await clubs.ToListAsync() : new List<Clubs>();
        }

        public async Task<Clubs> GetClubNameById(int id)
        {
            return await _tiFateDbContext.Clubs.FindAsync(id);
        }

        public async Task<List<Clubs>> GetClubIdByName(string name)
        {
            var clubs = _tiFateDbContext.Clubs.Where(w => w.ClubName.Contains(name));
            return clubs.Any()? await clubs.ToListAsync(): new List<Clubs>();
        }
    }
}
