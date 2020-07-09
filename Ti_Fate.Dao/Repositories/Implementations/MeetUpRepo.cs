using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class MeetUpRepo : IMeetUpRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;
        public MeetUpRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public MeetUp GetMeetUpById(int id)
        {
            return _tiFateDbContext.MeetUp.Find(id);
        }

        public List<MeetUp> GetAllMeetUp()
        {
            var meetUp = _tiFateDbContext.MeetUp.Where(m => !m.IsDelete).OrderByDescending(m => m.Id);
            return meetUp.Any() ? meetUp.ToList() : new List<MeetUp>();
        }

        public List<MeetUp> GetMeetUpByTitle(string title)
        {
            var meetUps = _tiFateDbContext.MeetUp.Where(m => m.Title.Contains(title) && !m.IsDelete);
            return meetUps.Any() ? meetUps.ToList() : new List<MeetUp>();
        }

        public void AddMeetUp(MeetUp meetUp)
        {
            _tiFateDbContext.MeetUp.Add(meetUp);
            _tiFateDbContext.SaveChanges();
        }

        public void UpdateMeetUp(MeetUp newMeetUp)
        {
            var oldMeetUp = _tiFateDbContext.MeetUp.Find(newMeetUp.Id);

            oldMeetUp.EndTime = newMeetUp.EndTime;
            oldMeetUp.StartTime = newMeetUp.StartTime;
            oldMeetUp.Title = newMeetUp.Title;
            oldMeetUp.PublishTime = newMeetUp.PublishTime;
            oldMeetUp.Content = newMeetUp.Content;

            _tiFateDbContext.SaveChanges();
        }

        public void DeleteMeetUp(int id)
        {
            var deleteMeetUp = _tiFateDbContext.MeetUp.Find(id);
            if (deleteMeetUp == null)
            {
                return;
            }
            deleteMeetUp.IsDelete = true;
            _tiFateDbContext.SaveChanges();
        }

    }
}
