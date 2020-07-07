using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
   public interface IClubsRepo
    {
        Task<List<Clubs>> GetAllClubs();
        Task<Clubs> GetClubNameById(int id);
        Task<List<Clubs>> GetClubIdByName(string name);
    }
}
