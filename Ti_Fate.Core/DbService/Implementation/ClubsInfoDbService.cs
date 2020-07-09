using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.Core.DbService.Implementation
{
    public class ClubsInfoDbService : IClubsInfoDbService
    {
        private readonly IClubsInfoRepo _clubsInfoRepo;

        public ClubsInfoDbService(IClubsInfoRepo clubsInfoRepo)
        {
            _clubsInfoRepo = clubsInfoRepo;
        }

        public ClubsInfoDomainModel GetClubsInfoById(int id)
        {
            return new ClubsInfoDomainModel(_clubsInfoRepo.GetClubsInfoById(id));
        }

        public List<ClubsInfoDomainModel> GetClubsInfoByTitle(string searchString)
        {
            var clubsInfos = _clubsInfoRepo.GetClubsInfosByTitle(searchString);
            return clubsInfos.Select(c => new ClubsInfoDomainModel(c)).ToList();
        }

        public List<ClubsInfoDomainModel> GetClubsInfoDomainModelList()
        {
            var clubsInfos = _clubsInfoRepo.GetAllClubsInfo();
            return clubsInfos.Select(c => new ClubsInfoDomainModel(c)).ToList();
        }

        public void AddClubsInfo(ClubsInfoDomainModel clubsInfoDomainModel)
        {
            var clubsInfo = new ClubsInfo()
            {
                Id = clubsInfoDomainModel.Id,
                ClubId = clubsInfoDomainModel.ClubId,
                Title = clubsInfoDomainModel.Title,
                Content = clubsInfoDomainModel.Content,
                PublishTime = clubsInfoDomainModel.PublishTime,
                StartTime = clubsInfoDomainModel.StartTime,
                EndTime = clubsInfoDomainModel.EndTime,
                IsDelete = false
            };
            _clubsInfoRepo.AddClubsInfo(clubsInfo);
        }

        public void UpdateClubsInfo(ClubsInfoDomainModel clubsInfoDomainModel)
        {
            var clubsInfo = new ClubsInfo()
            {
                Id = clubsInfoDomainModel.Id,
                ClubId = clubsInfoDomainModel.ClubId,
                Title = clubsInfoDomainModel.Title,
                Content = clubsInfoDomainModel.Content,
                StartTime = clubsInfoDomainModel.StartTime,
                EndTime = clubsInfoDomainModel.EndTime,
                PublishTime = clubsInfoDomainModel.PublishTime
            };
            _clubsInfoRepo.UpdateClubsInfo(clubsInfo);
        }

        public void DeleteClubsInfo(int id)
        {
            _clubsInfoRepo.DeleteClubsInfo(id);
        }
    }
}
