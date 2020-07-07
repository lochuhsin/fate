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
    public class ManageWelfareController : Controller
    {
        private readonly IWelfareDbService _welfareDbService;
        private readonly IConvertContextService _convertContextService;

        public ManageWelfareController(IWelfareDbService welfareDbService, IConvertContextService convertContextService)
        {
            _welfareDbService = welfareDbService;
            _convertContextService = convertContextService;
        }

        [ValidatePermission]
        public IActionResult AddWelfare(string announcementType)
        {
            HttpContext.Session.Remove("WelfareId");
            return View("ManageWelfare", new ManageWelfareViewModel());
        }

        [ValidatePermission]
        public IActionResult EditWelfare(string announcementType, int id)
        {
            HttpContext.Session.SetInt32("WelfareId", id);
            var welfareDomainModel = _welfareDbService.GetWelfareById(id);
            return View("ManageWelfare", new ManageWelfareViewModel(welfareDomainModel));
        }

        [HttpPost]
        public IActionResult ManageWelfare(ManageWelfareViewModel manageWelfare)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(manageWelfare), manageWelfare);
            }

            manageWelfare.Id = GetIdFromSessionAndRemove();

            var welfareDomainModel = ConvertToDomainModel(manageWelfare);

            if (manageWelfare.IsAddWelfare())
            {
                _welfareDbService.AddWelfare(welfareDomainModel);
            }
            else
            {
                _welfareDbService.UpdateWelfare(welfareDomainModel);
            }
            return RedirectToAction("Welfare", "Welfare");
        }

        [ValidatePermission]
        public IActionResult DeleteWelfare(string announcementType, int id)
        {
            _welfareDbService.DeleteWelfare(id);
            return RedirectToAction("Welfare", "Welfare");
        }

        private int GetIdFromSessionAndRemove()
        {
            var welfareId = HttpContext.Session.GetInt32("WelfareId") ?? 0;
            HttpContext.Session.Remove("WelfareId");
            return welfareId;
        }

        private WelfareDomainModel ConvertToDomainModel(ManageWelfareViewModel manageWelfare)
        {
            return new WelfareDomainModel()
            {
                Id = manageWelfare.Id,
                Title = HttpUtility.HtmlEncode(manageWelfare.Title),
                PublishTime = manageWelfare.PublishTime,
                StartTime = manageWelfare.StartTime,
                EndTime = manageWelfare.EndTime,
                Content = _convertContextService.ConvertBase64ContextToUrl(manageWelfare.Content)
            };
        }
    }
}
