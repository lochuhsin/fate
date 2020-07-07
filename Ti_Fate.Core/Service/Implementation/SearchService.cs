using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;

namespace Ti_Fate.Core.Service.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly IWelfareDbService _welfareDbService;
        private readonly IProfileDbService _profileDbService;
        private readonly IMeetUpDbService _meetUpDbService;
        private readonly IExternalDbService _externalDbService;
        private readonly ICombineClubInfosService _combineClubInfoService;

        public SearchService(IWelfareDbService welfareDbService, IProfileDbService profileDbService, IMeetUpDbService meetUpDbService,
            IExternalDbService externalDbService, ICombineClubInfosService combineClubInfoService)
        {
            _welfareDbService = welfareDbService;
            _profileDbService = profileDbService;
            _meetUpDbService = meetUpDbService;
            _externalDbService = externalDbService;
            _combineClubInfoService = combineClubInfoService;
        }

        public SearchDomainModel SearchInfos(string searchString)
        {
            var searchResult = new SearchDomainModel()
            {
                Welfare = _welfareDbService.GetWelfareByTitle(searchString),
                MeetUp = _meetUpDbService.GetMeetUpByTitle(searchString),
                ExternalInfo = _externalDbService.GetExternalInfosByTitle(searchString),
                CombineClubInfos = _combineClubInfoService.GetCombineClubInfosDomainModelsByTitle(searchString)
            };

            return searchResult;
        }

        public SearchDomainModel SearchProfile(string searchString)
        {
            var searchResult = new SearchDomainModel()
            {
                Profile = _profileDbService.GetProfileByName(searchString)
            };

            return searchResult;
        }
    }
}