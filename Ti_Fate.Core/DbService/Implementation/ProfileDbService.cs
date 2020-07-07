using System;
using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Core.Tools;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class ProfileDbService : IProfileDbService
    {
        private readonly IProfileRepo _profileRepo;
        private readonly IManageFileService _manageFileService;
        private readonly IConvertContextService _convertContext;

        public ProfileDbService(IProfileRepo profileRepo, IManageFileService manageFileService, IConvertContextService convertContext)
        {
            _profileRepo = profileRepo;
            _manageFileService = manageFileService;
            _convertContext = convertContext;
        }

        public ProfileDomainModel GetProfile(int id)
        {
            var profile = _profileRepo.GetProfile(id).Result;
            return new ProfileDomainModel(profile);
        }

        public ProfileDomainModel GetFaterById(int profileId)
        {
            var faterId = _profileRepo.GetProfile(profileId).Result.FaterId;
            var faterProfile = _profileRepo.GetProfile(faterId).Result;
            if (faterProfile == null)
            {
                var newFaterId = GetFaterId();
                _profileRepo.UpdateFaterId(profileId, newFaterId);
                faterProfile = _profileRepo.GetProfile(newFaterId).Result;
            }
            return new ProfileDomainModel(faterProfile);
        }

        public ProfileDomainModel GetProfileByAccount(string account)
        {
            var profileByAccount = _profileRepo.GetProfileByAccount(account).Result;
            return new ProfileDomainModel(profileByAccount);
        }

        public List<ProfileDomainModel> GetProfileByName(string searchString)
        {
            var profileByName = _profileRepo.GetProfileByName(searchString).Result;
            return profileByName.Select(profile => new ProfileDomainModel(profile)).ToList();
        }

        public List<ProfileDomainModel> GetNewFater(int numOfMonths)
        {
            var startDate = GetNow();
            var endDate = new DateTime(startDate.Year, startDate.Month - 3 + 1, startDate.Day);
            var profileByDate = _profileRepo.GetProfileByOnBoardDate(startDate, endDate).Result;

            return profileByDate?.Select(profile => new ProfileDomainModel(profile)).ToList();
        }

        public List<ProfileDomainModel> GetBirthdayFaters()
        {
            var profileList = _profileRepo.GetProfileByBirthday(GetNowMonth()).Result;
            return profileList?.Select(profile => new ProfileDomainModel(profile)).ToList();
        }

        public bool IsProfileExist(string account)
        {
            var profile = _profileRepo.GetProfileByAccount(account).Result;
            if (profile == null) return false;
            return true;
        }

        public void InsertProfile(ProfileDomainModel profileDomainModel)
        {
            var profile = new Profile()
            {
                Name = profileDomainModel.Name,
                Account = profileDomainModel.Account,
                Picture = profileDomainModel.Picture,
                Position = profileDomainModel.Position,
                Department = profileDomainModel.Department,
                TeamName = profileDomainModel.TeamName,
                Introduce = profileDomainModel.Introduce,
                Birth = profileDomainModel.Birth,
                PermissionId = profileDomainModel.PermissionId,
                OnBoardDate = profileDomainModel.OnBoardDate,
                FaterId = GetFaterId(),
                Location = profileDomainModel.Location
            };
            _profileRepo.InsertProfile(profile);
        }

        private int GetFaterId()
        {
            var allProfile = _profileRepo.GetAllProfile().Result;
            var profileCount = allProfile.Count() - 1;

            var random = new Random();
            var index = random.Next(0, profileCount);
            return allProfile[index].Id;
        }

        public void RandomFater()
        {
            var profileIdList = _profileRepo.GetAllProfile().Result.Select(profile => profile.Id).ToList();
            ShuffleTool.ShuffleList(profileIdList);
            _profileRepo.UpdateFaterId(profileIdList);
        }

        public void UpdateProfile(ProfileDomainModel profileDomainModel)
        {
            var profile = new Profile()
            {
                Id = profileDomainModel.Id,
                Account = profileDomainModel.Account,
                Name = profileDomainModel.Name,
                Birth = profileDomainModel.Birth,
                OnBoardDate = profileDomainModel.OnBoardDate,
                Location = profileDomainModel.Location,
                Position = profileDomainModel.Position,
                Department = profileDomainModel.Department,
                TeamName = profileDomainModel.TeamName,
                Introduce = profileDomainModel.Introduce,

                Relationship = profileDomainModel.Relationship,
                Constellation = profileDomainModel.Constellation,
                Skills = profileDomainModel.Skills,

                Music = profileDomainModel.Music,
                Movie = profileDomainModel.Movie,
                Sport = profileDomainModel.Sport,
                Book = profileDomainModel.Book,
                Food = profileDomainModel.Food,
                Country = profileDomainModel.Country,
                Drink = profileDomainModel.Drink,
                Others = profileDomainModel.Others
            };
            _profileRepo.UpdateProfile(profile);
        }

        public void InsertProfilePicture(int id, string base64)
        {
            var picInfo = GetPictureInfo(base64);
            UploadBase64File(picInfo);
            UpdateProfilePicture(id, picInfo);
        }

        public void RemoveProfilePicture(int id, int pictureIndex)
        {
            var profile = _profileRepo.GetProfile(id).Result;
            var pictureList = profile.Picture.Split('|').ToList();

            RemoveFile(pictureList[pictureIndex]);
            pictureList.RemoveAt(pictureIndex);
            profile.Picture = string.Join("|", pictureList.ToArray());
            _profileRepo.UpdateProfilePicturePath(profile);
        }

        private void RemoveFile(string picturePath)
        {
            _manageFileService.DeleteFile(picturePath);
        }

        protected virtual DateTime GetNow()
        {
            return DateTime.Now;
        }

        protected virtual int GetNowMonth()
        {
            return DateTime.Now.Month;
        }

        private void UploadBase64File(PictureInfo picInfo)
        {
            _manageFileService.UploadBase64File(picInfo.Base64, picInfo.FileName);
        }

        private void UpdateProfilePicture(int id, PictureInfo picInfo)
        {
            var profile = _profileRepo.GetProfile(id).Result;
            profile.Picture = profile.Picture + "|" + picInfo.PicPath;
            _profileRepo.UpdateProfilePicturePath(profile);
        }

        private PictureInfo GetPictureInfo(string base64)
        {
            var (base64Picture, fileType) = _convertContext.CutTagBase64String(base64);
            var fileName = _manageFileService.CreateFileName(fileType);
            var newPicturePath = _manageFileService.GetFileUrl(fileName);
            var pictureInfo = new PictureInfo()
            {
                FileName = fileName,
                Base64 = base64Picture,
                FileType = fileType,
                PicPath = newPicturePath
            };

            return pictureInfo;
        }
    }
}
