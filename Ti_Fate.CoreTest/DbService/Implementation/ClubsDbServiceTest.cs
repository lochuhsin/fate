using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    class ClubsDbServiceTest
    {
        private IClubsRepo _clubsRepo;
        private IClubsDbService _clubsDbService;

        [SetUp]
        public void SetUp()
        {
            _clubsRepo = Substitute.For<IClubsRepo>();
            _clubsDbService = new ClubsDbService(_clubsRepo);
        }

        [Test]
        public void when_call_GetClubNameById()
        {
            _clubsRepo.GetClubNameById(1).Returns(GivenClubs());
            var actual = _clubsDbService.GetClubNameById(1);
            actual.Should().BeEquivalentTo(GivenClubs());
        }

        [Test]
        public void when_call_GetClubsDomainModelList()
        {
            _clubsRepo.GetAllClubs().Returns(GivenClubsList());
            var actual = _clubsDbService.GetClubsDomainModelList();
            actual.Should().BeEquivalentTo(GivenClubsDomainModels());
        }

        public Clubs GivenClubs()
        {
            return new Clubs()
            {
                Id = 1,
                ClubName = "TestClub"
            };
        }

        public List<ClubsDomainModel> GivenClubsDomainModels()
        {
            return new List<ClubsDomainModel>()
            {
                new ClubsDomainModel()
                {
                    Id = 1,
                    ClubName = "TestClub1"
                },
                new ClubsDomainModel()
                {
                    Id = 2,
                    ClubName = "TestClub2"
                }
            };
        }
        public List<Clubs> GivenClubsList()
        {
            return new List<Clubs>()
            {
                new Clubs()
                {
                    Id = 1,
                    ClubName = "TestClub1"
                },
                new Clubs()
                {
                    Id = 2,
                    ClubName = "TestClub2"
                }
            };
        }


    }
}
