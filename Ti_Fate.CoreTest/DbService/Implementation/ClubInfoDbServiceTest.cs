using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    public class ClubInfoDbServiceTest
    {
        private const int GivenId = 1;
        private IClubsInfoRepo _clubsInfoRepo;
        private ClubsInfoDbService _clubsInfoDbService;

        [SetUp]
        public void SetUp()
        {
            _clubsInfoRepo = Substitute.For<IClubsInfoRepo>();
            _clubsInfoDbService = new ClubsInfoDbService(_clubsInfoRepo);
        }

        [Test]
        public void get_all_clubInfo()
        {
            GivenFakeClubInfoList();
            var result = ServiceGetClubsInfo();
            result.Should().BeEquivalentTo(new List<ClubsInfoDomainModel>()
            {
                new ClubsInfoDomainModel()
                {
                    Id = 1,
                    ClubId = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ClubsInfoDomainModel()
                {
                    Id = 2,
                    ClubId = 2,
                    Title = "testTitle2",
                    Content = "testContent2",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ClubsInfoDomainModel()
                {
                    Id = 3,
                    ClubId = 1,
                    Title = "testTitle3",
                    Content = "testContent3",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                }
            });
        }

        private List<ClubsInfoDomainModel> ServiceGetClubsInfo()
        {
            var result = _clubsInfoDbService.GetClubsInfoDomainModelList();
            return result;
        }

        [Test]
        public void call_club_by_Id_should_return_clubs_info()
        {
            GivenFakeClubsInfo();
            var result = _clubsInfoDbService.GetClubsInfoById(GivenId);
            result.Should().BeEquivalentTo(new ClubsInfoDomainModel()
            {
                Id = GivenId,
                ClubId = 1,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue
            });
        }

        [Test]
        public void call_add_clubInfo()
        {
            _clubsInfoDbService.AddClubsInfo(GivenClubsInfoDomainModel());
            ClubsInfoRepoShouldBeEqualTo(GivenFakeClubInfo());
        }

        [Test]
        public void call_update_clubInfo()
        {
            _clubsInfoDbService.UpdateClubsInfo(GivenClubsInfoDomainModel());
            UpdateClubsInfoRepoShouldBeEqualTo(GivenFakeClubInfo());
        }
        private void UpdateClubsInfoRepoShouldBeEqualTo(ClubsInfo clubsInfo)
        {
            _clubsInfoRepo.Received(1).UpdateClubsInfo(Arg.Is<ClubsInfo>(clubs =>
                clubs.Id.Equals(clubsInfo.Id) &&
                clubs.ClubId.Equals(clubsInfo.ClubId) &&
                clubs.Title.Equals(clubsInfo.Title) &&
                clubs.Content.Equals(clubsInfo.Content) &&
                clubs.EndTime.Equals(clubsInfo.EndTime) &&
                clubs.PublishTime.Equals(clubsInfo.PublishTime) &&
                clubs.StartTime.Equals(clubsInfo.StartTime)
                ));
        }
        private void ClubsInfoRepoShouldBeEqualTo(ClubsInfo clubsInfo)
        {
            _clubsInfoRepo.Received(1).AddClubsInfo(Arg.Is<ClubsInfo>(clubs =>
                clubs.Id.Equals(clubsInfo.Id) &&
                clubs.ClubId.Equals(clubsInfo.ClubId) &&
                clubs.Title.Equals(clubsInfo.Title) &&
                clubs.Content.Equals(clubsInfo.Content) &&
                clubs.EndTime.Equals(clubsInfo.EndTime) &&
                clubs.PublishTime.Equals(clubsInfo.PublishTime) &&
                clubs.StartTime.Equals(clubsInfo.StartTime)));
        }

        private ClubsInfoDomainModel GivenClubsInfoDomainModel()
        {
            return new ClubsInfoDomainModel()
            {
                Id = GivenId,
                ClubId = 1,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue
            };
        }
        private void GivenFakeClubsInfo()
        {
            _clubsInfoRepo.GetClubsInfoById(Arg.Any<int>()).Returns(new ClubsInfo()
            {
                Id = GivenId,
                ClubId = 1,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue
            });
        }
        private ClubsInfo GivenFakeClubInfo()
        {
            return new ClubsInfo()
            {
                Id = GivenId,
                ClubId = 1,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue
            };
        }
        private void GivenFakeClubInfoList()
        {
            _clubsInfoRepo.GetAllClubsInfo().Returns(new List<ClubsInfo>()
            {
                new ClubsInfo()
                {
                    Id = 1,
                    ClubId = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ClubsInfo()
                {
                    Id = 2,
                    ClubId = 2,
                    Title = "testTitle2",
                    Content = "testContent2",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ClubsInfo()
                {
                    Id = 3,
                    ClubId = 1,
                    Title = "testTitle3",
                    Content = "testContent3",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                }
            });
        }


    }

}
