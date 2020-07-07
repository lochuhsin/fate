using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class ClubsInfoController : Controller
    {
        private readonly IClubsDbService _clubsDbService;
        private readonly ICombineClubInfosService _combineClubInfosService;

        public ClubsInfoController(IClubsDbService clubsDbService, ICombineClubInfosService combineClubInfosService)
        {
            _clubsDbService = clubsDbService;
            _combineClubInfosService = combineClubInfosService;
        }

        public IActionResult ClubsInfo()
        {
            var combineClubsInfo = _combineClubInfosService.GetAllCombineClubInfosDomainModels();
            var allClubNames = _clubsDbService.GetClubsDomainModelList();
            return View("ClubsInfo", new ClubsInfoViewModel(combineClubsInfo, allClubNames));
        }
    }
}
