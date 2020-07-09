using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.ActionFilter;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    public class ManageExternalInfoController:Controller
    {
        private readonly IExternalDbService _externalDbService;
        private readonly IConvertContextService _convertContextService;

        public ManageExternalInfoController(IExternalDbService externalDbService, IConvertContextService convertContextService)
        {
            _externalDbService = externalDbService;
            _convertContextService = convertContextService;
        }

        [ValidateAnnouncementPermission]
        public IActionResult AddExternalInfo(string announcementType)
        {
            HttpContext.Session.Remove("ExternalInfoId");
            return View("ManageExternalInfo", new ManageExternalInfoViewModel());
        }

        [ValidateAnnouncementPermission]
        public IActionResult EditExternalInfo(string announcementType, int id)
        {
            HttpContext.Session.SetInt32("ExternalInfoId", id);
            var externalDomainModel = _externalDbService.GetExternalById(id);
            return View("ManageExternalInfo", new ManageExternalInfoViewModel(externalDomainModel));
        }
        
        [HttpPost]
        public IActionResult ManageExternal(ManageExternalInfoViewModel manageExternalInfo)
        {
            if (!ModelState.IsValid||!EndTimeIsValid(manageExternalInfo))
            {
                return View(nameof(manageExternalInfo), manageExternalInfo);
            }

            manageExternalInfo.Id = GetIdFromSessionAndRemove();

            var externalDomainModel = ConvertToDomainModel(manageExternalInfo);

            if (manageExternalInfo.IsAddExternal())
            {
                _externalDbService.AddExternal(externalDomainModel);
            }
            else
            {
                _externalDbService.UpdateExternal(externalDomainModel);
            }
            return RedirectToAction("ExternalInfo", "ExternalInfo");
        }

        [ValidateAnnouncementPermission]
        public IActionResult DeleteExternalInfo(string announcementType, int id)
        {
            _externalDbService.DeleteExternal(id);
            return RedirectToAction("ExternalInfo", "ExternalInfo");
        }

        private bool EndTimeIsValid(ManageExternalInfoViewModel manageExternalInfo)
        {
            if (manageExternalInfo.EndTime < manageExternalInfo.StartTime)
            {
                ModelState.AddModelError(nameof(manageExternalInfo.EndTime), "活動結束時間不可小於開始時間");
                return false;
            }

            return true;
        }

        private int GetIdFromSessionAndRemove()
        {
            var welfareId = HttpContext.Session.GetInt32("ExternalInfoId") ?? 0;
            HttpContext.Session.Remove("ExternalInfoId");
            return welfareId;
        }

        private ExternalInfoDomainModel ConvertToDomainModel(ManageExternalInfoViewModel manageExternalInfo)
        {
            return new ExternalInfoDomainModel()
            {
                Id = manageExternalInfo.Id,
                Title = HttpUtility.HtmlEncode(manageExternalInfo.Title),
                PublishTime = manageExternalInfo.PublishTime,
                StartTime = manageExternalInfo.StartTime,
                EndTime = manageExternalInfo.EndTime,
                Content = _convertContextService.ConvertBase64ContextToUrl(manageExternalInfo.Content)
            };
        }
    }
}
