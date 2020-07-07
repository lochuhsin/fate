using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Core.Tools;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    [TestFixture]
    class ProfileDbServiceTest
    {
        private IProfileRepo _profileRepo;
        private IManageFileService _manageFileService;
        private ProfileDbService _profileDbService;
        private IConvertContextService _convertContextService;

        private Profile _profile = new Profile()
        {
            Id = 1,
            Account = "test",
            Birth = new DateTime(1996, 01, 01),
            Book = "testBook",
            Constellation = "testConstellation",
            Country = "testTaiwan",
            Department = "testDepart",
            Drink = "testDrink",
            Food = "testFood",
            Introduce = "testIntroduce",
            Name = "testName",
            Picture = "testPic",
            Position = "tesPosition",
            TeamName = "testTeamName",
            Skills = "testSkills",
            Music = "testMusic",
            Movie = "testMovie",
            Sport = "testSport",
            Others = "testOthers",
            Relationship = "testRelationship",
            PermissionId = 1,
            FaterId = 4
        };

        [SetUp]
        public void SetUp()
        {
            _profileRepo = Substitute.For<IProfileRepo>();
            _manageFileService = Substitute.For<IManageFileService>();
            _profileDbService = new ProfileDbService(_profileRepo, _manageFileService, _convertContextService);
        }

        [Test]
        public void when_insert_profile_check_faterId()
        {
            var allProfileList = new List<Profile>()
            {
                new Profile(){Id = 1},
                new Profile(){Id = 2},
                new Profile(){Id = 4}
            };
            _profileRepo.GetAllProfile().Returns(allProfileList);

            _profileDbService.InsertProfile(new ProfileDomainModel());

            _profileRepo.Received(1).InsertProfile(Arg.Is<Profile>(m => m.FaterId <= 4 && m.FaterId != 3));
        }

        [Test]
        public void when_update()
        {
            var givenProfileDomainModel = new ProfileDomainModel()
            {
                Id = 0,
                Name = "helloName",
                Account = "hello"
            };

            _profileDbService.UpdateProfile(givenProfileDomainModel);

            _profileRepo.Received(1).UpdateProfile(Arg.Is<Profile>(m => m.Id == givenProfileDomainModel.Id
                                                                        && m.Name.Equals(givenProfileDomainModel.Name)
                                                                        && m.Account.Equals(givenProfileDomainModel.Account)));
        }

        [Test]
        public void when_remove_picture()
        {
            var givenId = 0;
            var givenOriPath = "path1|path2|path3|path4";
            GivenPicturePath(givenId, givenOriPath);

            _profileDbService.RemoveProfilePicture(givenId, 2);

            _profileRepo.Received(1).UpdateProfilePicturePath(Arg.Is<Profile>(m => m.Picture == "path1|path2|path4"
                                                                                 && m.Id == givenId));
        }

        private void GivenPicturePath(int id, string givenOriPath)
        {
            _profileRepo.GetProfile(Arg.Any<int>()).Returns(new Profile()
            {
                Picture = givenOriPath
            });
        }

        [Test]
        public void when_random_fater()
        {
            var profileIdList = new List<int>();
            _profileRepo.GetAllProfile().Returns(new List<Profile>()
            {
                new Profile()
                {
                    Id = 1
                },
                new Profile()
                {
                    Id = 2
                },
                new Profile()
                {
                Id = 3
            }
            });
            ShuffleTool.ShuffleList(profileIdList);
            _profileDbService.RandomFater();
            _profileRepo.Received().UpdateFaterId(Arg.Any<List<int>>());
        }

        [Test]
        public void get_new_fater_when_given_month()
        {
            var profileList = new List<Profile>()
            {
                _profile
            };

            _profileRepo.GetProfileByOnBoardDate(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(profileList);
            var actualList = new List<ProfileDomainModel>()
            {
                new ProfileDomainModel(_profile)
            };
            var expected = _profileDbService.GetNewFater(3);
            expected.Should().BeEquivalentTo(actualList);
        }

        [Test]
        public void when_call_new_fater_pass_date_to_repo()
        {
            var profileService = new ProfileDbServiceForTest(_profileRepo, _manageFileService, _convertContextService);
            profileService.GetNewFater(3);
            _profileRepo.Received(1)
                .GetProfileByOnBoardDate(Arg.Is<DateTime>(m => m.Month == 5), Arg.Is<DateTime>(m => m.Month == 3));

        }

        [Test]
        public void when_call_birthday_fater_pass_data_to_repo()
        {
            var profileServiceForTest = new ProfileDbServiceForTest(_profileRepo, _manageFileService, _convertContextService);
            profileServiceForTest.GetBirthdayFaters();
            _profileRepo.Received(1).GetProfileByBirthday(Arg.Any<int>());
        }

        [Test]
        public void get_birthday_fater_when_call_birthday_fater()
        {
            var profileList = new List<Profile>()
            {
                _profile
            };
            _profileRepo.GetProfileByBirthday(Arg.Any<int>()).Returns(profileList);
            var actualList = new List<ProfileDomainModel>()
            {
                new ProfileDomainModel(_profile)
            };
            var expected = _profileDbService.GetBirthdayFaters();
            expected.Should().BeEquivalentTo(actualList);
        }
    }

    public class ProfileDbServiceForTest : ProfileDbService
    {
        public ProfileDbServiceForTest(IProfileRepo profileRepo, IManageFileService manageFileService, IConvertContextService convertContext) : base(profileRepo, manageFileService, convertContext)
        {
        }

        protected override DateTime GetNow()
        {
            return new DateTime(2020, 05, 01);
        }

        protected override int GetNowMonth()
        {
            const int month = 6;
            return month;
        }
    }
}
