using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<MeetUp> GetMeetUpById(int id)
        {
            return await _tiFateDbContext.MeetUp.FindAsync(id);
        }

        public async Task<List<MeetUp>> GetAllMeetUp()
        {
            var meetUp = _tiFateDbContext.MeetUp.Where(m => !m.IsDelete).OrderByDescending(m => m.Id);
            return meetUp.Any() ? await meetUp.ToListAsync() : new List<MeetUp>();
        }

        public async Task<List<MeetUp>> GetMeetUpByTitle(string title)
        {
            var meetUps = _tiFateDbContext.MeetUp.Where(m => m.Title.Contains(title) && !m.IsDelete);
            return meetUps.Any() ? await meetUps.ToListAsync() : new List<MeetUp>();
        }

        public async Task AddMeetUp(MeetUp meetUp)
        {
            _tiFateDbContext.MeetUp.Add(meetUp);
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateMeetUp(MeetUp newMeetUp)
        {
            var oldMeetUp = _tiFateDbContext.MeetUp.Find(newMeetUp.Id);

            oldMeetUp.EndTime = newMeetUp.EndTime;
            oldMeetUp.StartTime = newMeetUp.StartTime;
            oldMeetUp.Title = newMeetUp.Title;
            oldMeetUp.PublishTime = newMeetUp.PublishTime;
            oldMeetUp.Content = newMeetUp.Content;

            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task DeleteMeetUp(int id)
        {
            var deleteMeetUp =await _tiFateDbContext.MeetUp.FindAsync(id);
            if (deleteMeetUp == null)
            {
                return;
            }
            deleteMeetUp.IsDelete = true;
            await _tiFateDbContext.SaveChangesAsync();
        }

    }
}
