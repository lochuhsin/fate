using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    class ImportantDbServiceTest
    {
        private IImportantRepo _importantDbRepo;
        private ImportantDbService _importantDbService;
        private Important _important;

        [SetUp]
        public void SetUp()
        {
            _importantDbRepo = Substitute.For<IImportantRepo>();
            _importantDbService = new ImportantDbService(_importantDbRepo);
        }

        [Test]
        public void when_get_important()
        {
            _important = new Important()
            {
                Id = 1,
                Content = "this is test content"
            };
            _importantDbRepo.GetLastImportant().Returns(_important);
            var expected = _importantDbService.GetImportant();
            expected.Should().BeEquivalentTo(new ImportantDomainModel(_important));
        }
    }
}
