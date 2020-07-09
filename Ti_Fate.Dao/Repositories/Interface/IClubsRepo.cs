using System.Collections.Generic;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IClubsRepo
    {
        List<Clubs> GetAllClubs();
        Clubs GetClubNameById(int id);
        List<Clubs> GetClubIdByName(string name);
    }
}