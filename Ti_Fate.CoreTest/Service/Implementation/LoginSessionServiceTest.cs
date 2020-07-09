using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Implementation;

namespace Ti_Fate.CoreTest.Service.Implementation
{
    public class LoginSessionServiceTest
    {
        private IProfileDbService _profileDbService;
        private LoginSessionService _loginSessionService;

        [SetUp]
        public void SetUp()
        {
            _profileDbService = Substitute.For<IProfileDbService>();
            _loginSessionService = new LoginSessionService(_profileDbService);
        }

        [Test]
        public void Get_LoginSession_By_Account()
        {
            _profileDbService.GetProfileByAccount(Arg.Any<string>()).Returns(new ProfileDomainModel()
            {
                Id = 2,
                Account = "Willy",
                Picture = "a|b|c"
            });
            var actual = _loginSessionService.GetLoginSessionByAccount("Willy");
            var expected = new LoginSession(new ProfileDomainModel() { Id = 2, Account = "Willy" }, "a");
            expected.Should().BeEquivalentTo(actual);


        }
    }
}
