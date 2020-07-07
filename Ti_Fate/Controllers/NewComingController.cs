using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
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
            var newFaterViewModel = new NewFaterViewModel(_profileDbService.GetNewFater(3));
            return View(nameof(NewComing), newFaterViewModel);
        }
    }
}