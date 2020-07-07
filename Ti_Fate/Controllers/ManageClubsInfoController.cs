using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Ti_Fate.ActionFilter;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class ManageClubsInfoController : Controller
    {
        private readonly IClubsInfoDbService _clubsInfoDbService;
        private readonly IConvertContextService _convertContextService;
        private readonly IClubsDbService _clubsDbService;

        public ManageClubsInfoController(IClubsInfoDbService clubsInfoDbService, IConvertContextService convertContextService, IClubsDbService clubsDbService)
        {
            _clubsInfoDbService = clubsInfoDbService;
            _convertContextService = convertContextService;
            _clubsDbService = clubsDbService;
        }

        [ValidatePermission]
        public IActionResult AddClubsInfo(string announcementType)
        {
            HttpContext.Session.Remove("ClubsInfoId");
            return View("ManageClubsInfo", new ManageClubsInfoViewModel(_clubsDbService.GetClubsDomainModelList()));
        }

        [ValidatePermission]
        public IActionResult EditClubsInfo(string announcementType, int id)
        {
            HttpContext.Session.SetInt32("ClubsInfoId", id);
            var clubsInfoDomainModel = _clubsInfoDbService.GetClubsInfoById(id);
            return View("ManageClubsInfo", new ManageClubsInfoViewModel(clubsInfoDomainModel, _clubsDbService.GetClubsDomainModelList()));
        }

        [HttpPost]
        public IActionResult ManageClubsInfo(ManageClubsInfoViewModel manageClubsInfo)
        {
            if (!ModelState.IsValid || !ClubNameIsValid(manageClubsInfo))
            {
                manageClubsInfo.InitializeDropDownList(_clubsDbService.GetClubsDomainModelList());
                return View(nameof(manageClubsInfo), manageClubsInfo);
            }

            manageClubsInfo.Id = GetIdFromSessionAndRemove();

            var clubsInfoDomainModel = ConvertToDomainModel(manageClubsInfo);

            if (manageClubsInfo.IsAddClubsInfo())
            {
                _clubsInfoDbService.AddClubsInfo(clubsInfoDomainModel);
            }
            else
            {
                _clubsInfoDbService.UpdateClubsInfo(clubsInfoDomainModel);
            }
            return RedirectToAction("ClubsInfo", "ClubsInfo");
        }

        [ValidatePermission]
        public IActionResult DeleteClubsInfo(string announcementType, int id)
        {
            _clubsInfoDbService.DeleteClubsInfo(id);
            return RedirectToAction("ClubsInfo", "ClubsInfo");
        }

        private int GetIdFromSessionAndRemove()
        {
            var clubsInfoId = HttpContext.Session.GetInt32("ClubsInfoId") ?? 0;
            HttpContext.Session.Remove("ClubsInfoId");
            return clubsInfoId;
        }

        private bool ClubNameIsValid(ManageClubsInfoViewModel manageClubsInfo)
        {
            var findClubId = _clubsDbService.GetClubNameById(manageClubsInfo.ClubId);
            if (findClubId != null)
            {
                return true;
            }
            ModelState.AddModelError(nameof(manageClubsInfo.ClubId), "請選擇社團名稱");
            return false;
        }
        private ClubsInfoDomainModel ConvertToDomainModel(ManageClubsInfoViewModel manageClubsInfo)
        {
            return new ClubsInfoDomainModel()
            {
                Id = manageClubsInfo.Id,
                Title = HttpUtility.HtmlEncode(manageClubsInfo.Title),
                PublishTime = manageClubsInfo.PublishTime,
                StartTime = manageClubsInfo.StartTime,
                EndTime = manageClubsInfo.EndTime,
                ClubId = manageClubsInfo.ClubId,
                Content = _convertContextService.ConvertBase64ContextToUrl(manageClubsInfo.Content)
            };

        }
    }
}