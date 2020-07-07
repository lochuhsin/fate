using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Controllers;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.ViewModels;

namespace Ti_FateTest.Controllers
{
    [TestFixture]
    public class ManageWelfareControllerTest
    {
        private IWelfareDbService _welfareDbService;
        private IConvertContextService _convertContextService;
        private ManageWelfareController _manageWelfareController;

        [SetUp]
        public void SetUp()
        {
            _welfareDbService = Substitute.For<IWelfareDbService>();
            _convertContextService = Substitute.For<IConvertContextService>();
            _manageWelfareController = new ManageWelfareController(_welfareDbService, _convertContextService);
        }

        [Test]
        public void when_call_manage_modify_content()
        {
            var givenWelfare = GivenAddWelfare();

            var actionResult = _manageWelfareController.ManageWelfare(givenWelfare) as RedirectToActionResult;

            _convertContextService.Received(1).ConvertBase64ContextToUrl(Arg.Is("testContent"));
            Assert.That(actionResult.ActionName, Is.EqualTo("Welfare"));
            Assert.That(actionResult.ControllerName, Is.EqualTo("Welfare"));
        }

        [Test]
        public void if_add_welfare_call_add_repo()
        {
            var givenAddWelfare = GivenAddWelfare();

            var actionResult = _manageWelfareController.ManageWelfare(givenAddWelfare) as RedirectToActionResult;

            _welfareDbService.Received(0).UpdateWelfare(Arg.Any<WelfareDomainModel>());
            _welfareDbService.Received(1).AddWelfare(Arg.Any<WelfareDomainModel>());
        }

        [Test]
        public void if_update_welfare_call_update_repo()
        {
            var givenAddWelfare = GivenUpdateWelfare();

            var actionResult = _manageWelfareController.ManageWelfare(givenAddWelfare) as RedirectToActionResult;

            _welfareDbService.Received(1).UpdateWelfare(Arg.Any<WelfareDomainModel>());
            _welfareDbService.Received(0).AddWelfare(Arg.Any<WelfareDomainModel>());
        }

        private static ManageWelfareViewModel GivenAddWelfare()
        {
            var givenWelfare = new ManageWelfareViewModel()
            {
                Id = 0,
                Content = "testContent"
            };
            return givenWelfare;
        }
        private static ManageWelfareViewModel GivenUpdateWelfare()
        {
            var givenWelfare = new ManageWelfareViewModel()
            {
                Id = 5,
                Content = "testContent"
            };
            return givenWelfare;
        }
    }
}
