using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.Net.Http.Headers;
using Ti_Fate.ActionFilter;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    public class ManageMeetUpController : Controller
    {
        private readonly IMeetUpDbService _meetUpDbService;
        private readonly IConvertContextService _convertContextService;

        public ManageMeetUpController(IMeetUpDbService meetUpDbService, IConvertContextService convertContextService)
        {
            _meetUpDbService = meetUpDbService;
            _convertContextService = convertContextService;
        }

        [ValidateAnnouncementPermission]
        public IActionResult AddMeetUp(string announcementType)
        {
            HttpContext.Session.Remove("MeetUpId");
            return View(nameof(ManageMeetUp), new ManageMeetUpViewModel());
        }

        [ValidateAnnouncementPermission]
        public IActionResult EditMeetUp(string announcementType, int id)
        {
            HttpContext.Session.SetInt32("MeetUpId", id);
            var meetUpDomainModel = _meetUpDbService.GetMeetUpById(id);
            return View(nameof(ManageMeetUp), new ManageMeetUpViewModel(meetUpDomainModel));
        }

        [HttpPost]
        public IActionResult ManageMeetUp(ManageMeetUpViewModel manageMeetUp)
        {
            if (!ModelState.IsValid || !EndTimeIsValid(manageMeetUp))
            {
                return View(nameof(manageMeetUp), manageMeetUp);
            }

            manageMeetUp.Id = GetIdFromSessionAndRemove();
            var meetUpDomainModel = ConvertToDomainModel(manageMeetUp);
            if (manageMeetUp.IsAddMeetUp())
            {
                _meetUpDbService.AddMeetUp(meetUpDomainModel);
            }
            else
            {
                _meetUpDbService.UpdateMeetUp(meetUpDomainModel);
            }

            return RedirectToAction("MeetUpInfo", "MeetUpInfo");
        }

        private bool EndTimeIsValid(ManageMeetUpViewModel manageMeetUp)
        {
            if (manageMeetUp.EndTime < manageMeetUp.StartTime)
            {
                ModelState.AddModelError(nameof(manageMeetUp.EndTime), "活動結束時間不可小於開始時間");
                return false;
            }
            return true;
        }

        [ValidateAnnouncementPermission]
        public IActionResult DeleteMeetUp(string announcementType, int id)
        {
            _meetUpDbService.DeleteMeetUp(id);
            return RedirectToAction("MeetUpInfo", "MeetUpInfo");
        }
        private int GetIdFromSessionAndRemove()
        {
            var meetUpId = HttpContext.Session.GetInt32("MeetUpId") ?? 0;
            HttpContext.Session.Remove("MeetUpId");
            return meetUpId;
        }

        private MeetUpDomainModel ConvertToDomainModel(ManageMeetUpViewModel manageMeetUp)
        {
            return new MeetUpDomainModel()
            {
                Id = manageMeetUp.Id,
                Title = HttpUtility.HtmlEncode(manageMeetUp.Title),
                PublishTime = manageMeetUp.PublishTime,
                StartTime = manageMeetUp.StartTime,
                EndTime = manageMeetUp.EndTime,
                Content = _convertContextService.ConvertBase64ContextToUrl(manageMeetUp.Content)
            };
        }
    }
}
