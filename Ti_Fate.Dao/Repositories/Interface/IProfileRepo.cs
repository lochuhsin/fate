using System;
using System.Collections.Generic;
using Ti_Fate.Dao.Model;

namespace Ti_Fate.Dao.Repositories.Interface
{
    public interface IProfileRepo
    {
        Profile GetProfile(int id);
        Profile GetProfileByAccount(string account);
        List<Profile> GetProfileByOnBoardDate(DateTime startTime, DateTime endTime);
        List<Profile> GetProfileByBirthday(int month);
        List<Profile> GetProfileByName(string searchString);
        List<Profile> GetAllProfile();
        void InsertProfile(Profile profile);
        void UpdateProfile(Profile newProfile);
        void UpdateProfilePicturePath(Profile newProfile);
        void UpdateFaterId(List<int> faterIdList);
        void UpdateFaterId(int profileId, int newFaterId);
    }
}