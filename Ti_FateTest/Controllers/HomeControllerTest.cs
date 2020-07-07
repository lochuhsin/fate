using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Controllers;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.Service.Interface;

namespace Ti_FateTest.Controllers
{
    public class HomeControllerTest
    {
        private IAuthenticationService _authenticationService;
        private IProfileDbService _profileDbService;
        private ILoginSessionService _loginSessionService;
        private IWelfareDbService _welfareDbService;
        private IImportantDbService _importantDbService;
        private IClubsInfoDbService _clubsInfoDbService;
        private HomeController _homeController;
        private IMeetUpDbService _meetUpDbService;
        private IExternalDbService _externalDbService;

        [SetUp]
        public void SetUp()
        {
            _authenticationService = Substitute.For<IAuthenticationService>();
            _profileDbService = Substitute.For<IProfileDbService>();
            _loginSessionService = Substitute.For<ILoginSessionService>();
            _welfareDbService = Substitute.For<IWelfareDbService>();
            _importantDbService = Substitute.For<IImportantDbService>();
            _clubsInfoDbService = Substitute.For<IClubsInfoDbService>();
            _meetUpDbService = Substitute.For<IMeetUpDbService>();
            _externalDbService = Substitute.For<IExternalDbService>();

            _homeController = new HomeController(_authenticationService, _profileDbService, _loginSessionService, _welfareDbService, _importantDbService, _clubsInfoDbService,_meetUpDbService,_externalDbService);
        }

        [Test]
        public void when_call_Login_show_Login()
        {
            var viewResult = _homeController.Login() as ViewResult;
            Assert.That(viewResult.ViewName, Is.EqualTo("Login"));
        }
    }
}
