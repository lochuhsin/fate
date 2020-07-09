using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Models;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class NewComingController : Controller
    {
        private readonly IProfileDbService _profileDbService;

        public NewComingController(IProfileDbService profileDbService)
        {
            _profileDbService = profileDbService;
        }

        public IActionResult NewComing()
        {
            return View(nameof(NewComing));
        }

        public IActionResult GetNewComingProfileWithMonth()
        {
            var newComingViewModel = new NewComingViewModel(_profileDbService.GetNewFater(3));
            return Json(newComingViewModel);
        }
    }
}