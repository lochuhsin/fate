using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    class PermissionDbServiceTest
    {
        private IPermissionRepo _permissionRepo;
        private PermissionDbService _permissionDbService;

        [SetUp]
        public void SetUp()
        {
            _permissionRepo = Substitute.For<IPermissionRepo>();
            _permissionDbService = new PermissionDbService(_permissionRepo);
        }
        [Test]
        public void Given_id_get_permission()
        {
            _permissionRepo.GetPermissionById(Arg.Any<int>()).Returns(new Permission()
            {
                Id = 1,
                ModifyClubs = false,
                ModifyMeetUp = false,
                ModifyWelfare = false,
                ModifyExternal = false,
                ModifyImportant = false
            });
            var expected = _permissionDbService.GetPermissionById(1);
            expected.Should().BeEquivalentTo(new PermissionDomainModel()
            {
                Id = 1,
                ModifyClubs = false,
                ModifyMeetUp = false,
                ModifyWelfare = false,
                ModifyExternal = false,
                ModifyImportant = false
            });
        }
    }
}
