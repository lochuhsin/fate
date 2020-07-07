using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Dao.Repositories.Implementations
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly TiFateDbContext _tiFateDbContext;
        public ProfileRepo(TiFateDbContext tiFateDbContext)
        {
            _tiFateDbContext = tiFateDbContext;
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await _tiFateDbContext.Profile.FindAsync(id);
        }

        public async Task<Profile> GetProfileByAccount(string account)
        {
            return await _tiFateDbContext.Profile.SingleOrDefaultAsync(x => x.Account == account);
        }

        public async Task<List<Profile>> GetProfileByOnBoardDate(DateTime startTime, DateTime endTime)
        {
            var profileByOnBoardDate = await _tiFateDbContext.Profile.Where(m => m.OnBoardDate >= endTime && m.OnBoardDate <= startTime).ToListAsync();
            return profileByOnBoardDate.OrderBy(m => m.Name).ToList();
        }

        public async Task<List<Profile>> GetProfileByBirthday(int month)
        {
            var profileByBirthday = await _tiFateDbContext.Profile.Where(m => m.Birth.Month == month).ToListAsync();
            return profileByBirthday.OrderBy(m => m.Name).ToList();
        }

        public async Task<List<Profile>> GetProfileByName(string searchString)
        {
            var profiles = _tiFateDbContext.Profile.Where(w => w.Name.Contains(searchString));
            return profiles.Any() ? await profiles.ToListAsync() : new List<Profile>();
        }

        public async Task<List<Profile>> GetAllProfile()
        {
            return await _tiFateDbContext.Set<Profile>().ToListAsync();
        }

        public async Task InsertProfile(Profile profile)
        {
            _tiFateDbContext.Profile.Add(profile);
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateProfile(Profile newProfile)
        {
            var oldProfile = _tiFateDbContext.Profile.Find(newProfile.Id);

            oldProfile.Name = newProfile.Name;
            oldProfile.Birth = newProfile.Birth;
            oldProfile.OnBoardDate = newProfile.OnBoardDate;
            oldProfile.Location = newProfile.Location;
            oldProfile.Position = newProfile.Position;
            oldProfile.Department = newProfile.Department;
            oldProfile.TeamName = newProfile.TeamName;
            oldProfile.Introduce = newProfile.Introduce;

            oldProfile.Relationship = newProfile.Relationship; 
            oldProfile.Constellation = newProfile.Constellation;
            oldProfile.Skills = newProfile.Skills;

            oldProfile.Music = newProfile.Music;
            oldProfile.Movie = newProfile.Movie;
            oldProfile.Sport = newProfile.Sport;
            oldProfile.Book = newProfile.Book;
            oldProfile.Food = newProfile.Food;
            oldProfile.Country = newProfile.Country;
            oldProfile.Drink = newProfile.Drink;
            oldProfile.Others = newProfile.Others;

            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateProfilePicturePath(Profile newProfile)
        {
            var oldProfile = _tiFateDbContext.Profile.Find(newProfile.Id);
            oldProfile.Picture = newProfile.Picture;
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateFaterId(List<int> faterIdList)
        {
            var allProfile = _tiFateDbContext.Set<Profile>().ToList();
            for (var i = 0; i < allProfile.Count; i++)
            {
                allProfile[i].FaterId = faterIdList[i];
            }
            await _tiFateDbContext.SaveChangesAsync();
        }

        public async Task UpdateFaterId(int profileId, int newFaterId)
        {
            var oldProfile = _tiFateDbContext.Profile.Find(profileId);
            oldProfile.FaterId = newFaterId;
            await _tiFateDbContext.SaveChangesAsync();
        }
    }
}
