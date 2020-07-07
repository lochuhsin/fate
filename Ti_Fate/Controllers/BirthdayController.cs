using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.ViewModels;

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
            var birthdayViewModel = new BirthdayViewModel(_profileDbService.GetBirthdayFaters());
            return View(nameof(Birthday), birthdayViewModel);
        }
    }
}