using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IMeetUpRepo
    {
        Task<MeetUp> GetMeetUpById(int id);
        Task<List<MeetUp>> GetAllMeetUp();
        Task<List<MeetUp>> GetMeetUpByTitle(string title);
        Task AddMeetUp(MeetUp meetUp);
        Task UpdateMeetUp(MeetUp newMeetUp);
        Task DeleteMeetUp(int id);

    }
}
