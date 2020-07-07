using System;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Extensions;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class EditProfileController : Controller
    {
        private readonly IProfileDbService _profileDbService;

        public EditProfileController(IProfileDbService profileDbService)
        {
            _profileDbService = profileDbService;
        }

        public IActionResult EditProfile()
        {
            var loginSession = HttpContext.Session.GetObject<LoginSession>("LoginSession");
            var profile = _profileDbService.GetProfile(loginSession.ProfileId);
            return View(nameof(EditProfile), new EditProfileViewModel(profile));
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel editProfile)
        {
            if (!IsModelValid(editProfile))
            {
                return View(nameof(EditProfile), editProfile);
            }

            var loginSession = HttpContext.Session.GetObject<LoginSession>("LoginSession");
            var profileDomain = new ProfileDomainModel()
            {
                Id = loginSession.ProfileId,
                Account = loginSession.Account,
                Name = HttpUtility.HtmlEncode(editProfile.Name),
                Birth = editProfile.Birth,
                OnBoardDate = editProfile.OnBoardDate,
                Location = HttpUtility.HtmlEncode(editProfile.Location),
                Position = HttpUtility.HtmlEncode(editProfile.Position),
                Department = HttpUtility.HtmlEncode(editProfile.Department),
                TeamName = HttpUtility.HtmlEncode(editProfile.TeamName),
                Introduce = HttpUtility.HtmlEncode(editProfile.Introduce),


                Relationship = HttpUtility.HtmlEncode(editProfile.Relationship),
                Constellation = HttpUtility.HtmlEncode(editProfile.Constellation),
                Skills = HttpUtility.HtmlEncode(editProfile.Skills),

                Music = HttpUtility.HtmlEncode(editProfile.Music),
                Movie = HttpUtility.HtmlEncode(editProfile.Movie),
                Sport = HttpUtility.HtmlEncode(editProfile.Sport),
                Book = HttpUtility.HtmlEncode(editProfile.Book),
                Food = HttpUtility.HtmlEncode(editProfile.Food),
                Country = HttpUtility.HtmlEncode(editProfile.Country),
                Drink = HttpUtility.HtmlEncode(editProfile.Drink),
                Others = HttpUtility.HtmlEncode(editProfile.Others),
            };
            _profileDbService.UpdateProfile(profileDomain);

            return RedirectToAction(nameof(Profile), nameof(Profile), new { profileId = loginSession.ProfileId });
        }


        private bool IsModelValid(EditProfileViewModel editProfile)
        {
            return ModelState.IsValid && BirthdayDateIsValid(editProfile) && LocationIsValid(editProfile) &&
                   OnboardDateIsValid(editProfile);
        }

        private bool BirthdayDateIsValid(EditProfileViewModel editProfile)
        {
            if (editProfile.Birth < new DateTime(1900, 1, 1))
            {
                ModelState.AddModelError(nameof(editProfile.Birth), "生日不可小於 1900/01/01");
                return false;
            }
            else if(editProfile.Birth > DateTime.Now)
            {
                ModelState.AddModelError(nameof(editProfile.Birth), "生日不可超過今天");
                return false;
            }
            return true;
        }

        private bool OnboardDateIsValid(EditProfileViewModel editProfile)
        {
            if (editProfile.OnBoardDate < new DateTime(2000, 01, 01))
            {
                ModelState.AddModelError(nameof(editProfile.OnBoardDate),"到職日不可小於 2020/01");
                return false;
            }
            else if (editProfile.OnBoardDate > DateTime.Now)
            {
                ModelState.AddModelError(nameof(editProfile.OnBoardDate),errorMessage:"到職日不可超過本月");
                return false;
            }
            return true;
        }

        private bool LocationIsValid(EditProfileViewModel editProfile)
        {
            if (editProfile.Location == "臺北" || editProfile.Location == "臺中") return true;
            ModelState.AddModelError(nameof(editProfile.Location), "請選擇地區");
            return false;
        }
    }
}
