using System.Collections.Generic;
using Ti_Fate.Core.DomainModel;

namespace Ti_Fate.Core.DbService.Interface
{
    public interface IProfileDbService
    {
        ProfileDomainModel GetProfile(int id);
        ProfileDomainModel GetFaterById(int profileId);
        ProfileDomainModel GetProfileByAccount(string account);
        List<ProfileDomainModel> GetProfileByName(string searchString);
        List<ProfileDomainModel> GetNewFater(int numOfMonths);
        List<ProfileDomainModel> GetBirthdayFaters();
        List<ProfileDomainModel> GetAllProfileDomainModels();
        bool IsProfileExist(string account);
        void InsertProfile(ProfileDomainModel profileDomainModel);
        void UpdateProfile(ProfileDomainModel profileDomainModel);
        void InsertProfilePicture(int id, string base64);
        void RemoveProfilePicture(int id, int pictureIndex);
        void RandomFater();
    }
}
