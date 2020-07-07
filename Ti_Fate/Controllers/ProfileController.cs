using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileDbService _profileDbService;

        public ProfileController(IProfileDbService profileDbService)
        {
            _profileDbService = profileDbService;
        }

        public IActionResult Profile(int profileId)
        {
            var profileDomain = _profileDbService.GetProfile(profileId);
            var profileViewModel = new ProfileViewModel(profileDomain);
            return View(nameof(Profile), profileViewModel);
        }

    }
}