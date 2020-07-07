using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    public class MeetUpInfoController:Controller
    {
        private readonly IMeetUpDbService _meetUpDbService;

        public MeetUpInfoController(IMeetUpDbService meetUpDbService)
        {
            _meetUpDbService = meetUpDbService;
        }

        public IActionResult MeetUpInfo()
        {
            var meetUpInfo = _meetUpDbService.GetMeetUpDomainModel();
            return View(nameof(meetUpInfo), new MeetUpViewModel(meetUpInfo));
        }

    }
}
