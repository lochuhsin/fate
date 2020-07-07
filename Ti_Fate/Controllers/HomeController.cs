using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Extensions;
using Ti_Fate.ViewModels;
using IAuthenticationService = Ti_Fate.Core.Service.Interface.IAuthenticationService;

namespace Ti_Fate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IProfileDbService _profileDbService;
        private readonly ILoginSessionService _loginSessionService;
        private readonly IWelfareDbService _welfareDbService;
        private readonly IImportantDbService _importantDbService;
        private readonly IClubsInfoDbService _clubsInfoDbService;
        private readonly IMeetUpDbService _meetUpDbService;
        private readonly IExternalDbService _externalDbService;
        private const int NumOfMonths = 3;

        public HomeController(IAuthenticationService authenticationService, IProfileDbService profileDbService,
            ILoginSessionService loginSessionService, IWelfareDbService welfareDbService,
            IImportantDbService importantDbService, IClubsInfoDbService clubsInfoDbService, IMeetUpDbService meetUpDbService, IExternalDbService externalDbService)
        {
            _authenticationService = authenticationService;
            _profileDbService = profileDbService;
            _loginSessionService = loginSessionService;
            _welfareDbService = welfareDbService;
            _importantDbService = importantDbService;
            _clubsInfoDbService = clubsInfoDbService;
            _meetUpDbService = meetUpDbService;
            _externalDbService = externalDbService;
        }

        [Authorize]
        public IActionResult Home()
        {
            var loginSession = HttpContext.Session.GetObject<LoginSession>("LoginSession");

            var todayFaterDomainModel = _profileDbService.GetFaterById(loginSession.ProfileId);
            var important = _importantDbService.GetImportant();
            var welfareInfo = _welfareDbService.GetWelfareDomainModel();
            var clubsInfo = _clubsInfoDbService.GetClubsInfoDomainModelList();
            var newFaters = _profileDbService.GetNewFater(NumOfMonths);
            var birthdayFaters = _profileDbService.GetBirthdayFaters();
            var meetUpInfo = _meetUpDbService.GetMeetUpDomainModel();
            var externalInfo = _externalDbService.GetMeetUpDomainModel();
            var homeViewModel = new HomeViewModel(todayFaterDomainModel, important, welfareInfo, clubsInfo, newFaters, birthdayFaters,meetUpInfo,externalInfo);
            return View(homeViewModel);
        }

        public IActionResult Login()
        {
            return View("Login", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string account, string password, string returnUrl)
        {
            var authenticateInfo = _authenticationService.GetAuthenticateInfo(account, password);
            if (!authenticateInfo.IsAuthenticate)
            {
                ViewBag.errMsg = "帳號或密碼有誤";
                return View("Login");
            }

            if (!_profileDbService.IsProfileExist(account))
            {
                HttpContext.Session.SetString("Account", account);
                return RedirectToAction("Register", "Register");
            }

            var claims = new[] { new Claim("Account", account) };
            var claimsIdentity =
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(principal,
                new AuthenticationProperties()
                {
                    IsPersistent = false,
                });

            var loginSession = _loginSessionService.GetLoginSessionByAccount(account);

            HttpContext.Session.SetObject("LoginSession", loginSession);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);

            return RedirectToAction(nameof(Home));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Home"); //導至登入頁
        }

        [Authorize]
        public IActionResult ComingSoon()
        {
            return View("ComingSoon");
        }

        [HttpPost]
        public IActionResult Important(HomeViewModel homeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Home));
            }
            var importantDomainModel = new ImportantDomainModel()
            {
                Content = HttpUtility.HtmlEncode(homeViewModel.ImportantContent)
            };
            _importantDbService.UpdateImportant(importantDomainModel);
            return RedirectToAction(nameof(Home));
        }
    }
}
