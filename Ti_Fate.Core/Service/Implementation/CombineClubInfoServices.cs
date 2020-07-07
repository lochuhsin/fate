using System.Collections.Generic;
using System.Linq;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;

namespace Ti_Fate.Core.Service.Implementation
{
    public class CombineClubInfoServices : ICombineClubInfosService
    {
        private readonly IClubsInfoDbService _clubsInfoDbService;
        private readonly IClubsDbService _clubsDbService;

        public CombineClubInfoServices(IClubsInfoDbService clubsInfoDbService, IClubsDbService clubsDbService)
        {
            _clubsInfoDbService = clubsInfoDbService;
            _clubsDbService = clubsDbService;
        }

        public List<CombineClubInfosDomainModel> GetAllCombineClubInfosDomainModels()
        {
            var clubInfos = _clubsInfoDbService.GetClubsInfoDomainModelList();
            var allClubs = _clubsDbService.GetClubsDomainModelList();

            var combineClubInfoList = new List<CombineClubInfosDomainModel>();
            foreach (var clubsInfo in clubInfos)
            {
                var clubName = allClubs.First(c => c.Id == clubsInfo.ClubId).ClubName;
                combineClubInfoList.Add(new CombineClubInfosDomainModel(clubsInfo, clubName));
            }

            return combineClubInfoList;
        }
        public List<CombineClubInfosDomainModel> GetCombineClubInfosDomainModelsByTitle(string searchString)
        {
            var clubInfos = _clubsInfoDbService.GetClubsInfoByTitle(searchString);
            var allClubs = _clubsDbService.GetClubsDomainModelList();

            var combineList = new List<CombineClubInfosDomainModel>();
            foreach (var clubInfo in clubInfos)
            {
                var clubName = allClubs.First(c => c.Id == clubInfo.ClubId).ClubName;
                combineList.Add(new CombineClubInfosDomainModel(clubInfo, clubName));
            }
            return combineList;
        }
    }
}