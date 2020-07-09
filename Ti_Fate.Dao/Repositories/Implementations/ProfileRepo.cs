using System;
using System.Collections.Generic;
using System.Linq;
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

        public Profile GetProfile(int id)
        {
            return _tiFateDbContext.Profile.Find(id);
        }

        public Profile GetProfileByAccount(string account)
        {
            return _tiFateDbContext.Profile.SingleOrDefault(x => x.Account == account);
        }

        public List<Profile> GetProfileByOnBoardDate(DateTime startTime, DateTime endTime)
        {
            var profileByOnBoardDate = _tiFateDbContext.Profile.Where(m => m.OnBoardDate >= endTime && m.OnBoardDate <= startTime).ToList();
            return profileByOnBoardDate.OrderBy(m => m.Name).ToList();
        }

        public List<Profile> GetProfileByBirthday(int month)
        {
            var profileByBirthday = _tiFateDbContext.Profile.Where(m => m.Birth.Month == month).OrderBy(m=>m.Birth).ToList();
            return profileByBirthday.OrderBy(m => m.Name).ToList();
        }

        public List<Profile> GetProfileByName(string searchString)
        {
            var profiles = _tiFateDbContext.Profile.Where(w => w.Name.Contains(searchString));
            return profiles.Any() ? profiles.ToList() : new List<Profile>();
        }

        public List<Profile> GetAllProfile()
        {
            return _tiFateDbContext.Set<Profile>().ToList();
        }

        public void InsertProfile(Profile profile)
        {
            _tiFateDbContext.Profile.Add(profile);
            _tiFateDbContext.SaveChanges();
        }

        public void UpdateProfile(Profile newProfile)
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

            _tiFateDbContext.SaveChanges();
        }

        public void UpdateProfilePicturePath(Profile newProfile)
        {
            var oldProfile = _tiFateDbContext.Profile.Find(newProfile.Id);
            oldProfile.Picture = newProfile.Picture;
            _tiFateDbContext.SaveChanges();
        }

        public void UpdateFaterId(List<int> faterIdList)
        {
            var allProfile = _tiFateDbContext.Set<Profile>().ToList();
            for (var i = 0; i < allProfile.Count; i++)
            {
                allProfile[i].FaterId = faterIdList[i];
            }
            _tiFateDbContext.SaveChanges();
        }

        public void UpdateFaterId(int profileId, int newFaterId)
        {
            var oldProfile = _tiFateDbContext.Profile.Find(profileId);
            oldProfile.FaterId = newFaterId;
            _tiFateDbContext.SaveChanges();
        }
    }
}
