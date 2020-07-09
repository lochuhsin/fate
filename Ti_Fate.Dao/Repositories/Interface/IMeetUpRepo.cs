using System.Collections.Generic;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IMeetUpRepo
    {
        MeetUp GetMeetUpById(int id);
        List<MeetUp> GetAllMeetUp();
        List<MeetUp> GetMeetUpByTitle(string title);
        void AddMeetUp(MeetUp meetUp);
        void UpdateMeetUp(MeetUp newMeetUp);
        void DeleteMeetUp(int id);

    }
}