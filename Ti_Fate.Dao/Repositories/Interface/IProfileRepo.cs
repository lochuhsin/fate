using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IProfileRepo
    {
        Task<Profile> GetProfile(int id);
        Task<Profile> GetProfileByAccount(string account);
        Task<List<Profile>> GetProfileByOnBoardDate(DateTime startTime, DateTime endTime);
        Task<List<Profile>> GetProfileByBirthday(int month);
        Task<List<Profile>> GetProfileByName(string searchString);
        Task<List<Profile>> GetAllProfile();
        Task InsertProfile(Profile profile);
        Task UpdateProfile(Profile newProfile);
        Task UpdateProfilePicturePath(Profile newProfile);
        Task UpdateFaterId(List<int> faterIdList);
        Task UpdateFaterId(int profileId, int newFaterId);
    }
}
