using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Extensions;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class UploadPictureController : Controller
    {
        private readonly IProfileDbService _profileDbService;
        private readonly IConfiguration _configuration;

        public UploadPictureController(IProfileDbService profileDbService, IConfiguration configuration)
        {
            _profileDbService = profileDbService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var loginSession = HttpContext.Session.GetObject<LoginSession>("LoginSession");
            var getProfileDomainModel = _profileDbService.GetProfile(loginSession.ProfileId);
            var numOfPicture = _configuration.GetValue<int>("NumOfPicture");
            var uploadPictureViewModel = new UploadPictureViewModel(getProfileDomainModel, numOfPicture);
            return View("UploadPicture", uploadPictureViewModel);
        }


        [HttpPost]
        public IActionResult UploadPicture(UploadPictureViewModel uploadPictureViewModel)
        {
            _profileDbService.InsertProfilePicture(uploadPictureViewModel.ProfileId, uploadPictureViewModel.NewBase64Picture);
            return RedirectToAction("Index", "UploadPicture", new { profileId = uploadPictureViewModel.ProfileId });
        }

        public IActionResult RemovePicture(int pictureIndex)
        {
            var loginSession = HttpContext.Session.GetObject<LoginSession>("LoginSession");
            _profileDbService.RemoveProfilePicture(loginSession.ProfileId, pictureIndex);
            return RedirectToAction("Index", "UploadPicture");
        }
    }
}