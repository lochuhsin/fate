using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Models;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class BirthdayController : Controller
    {
        private readonly IProfileDbService _profileDbService;
        public BirthdayController(IProfileDbService profileDbService)
        {
            _profileDbService = profileDbService;
        }

        public IActionResult Birthday()
        {
            return View(nameof(Birthday));
        }

        public IActionResult GetBirthdayList()
        {
            var profileDomainModels = _profileDbService.GetBirthdayFaters();
            var faterBirthday = profileDomainModels.Select(profile => new BasicProfileModel(profile)).ToList();
            return Json(faterBirthday);
        }
    }
}