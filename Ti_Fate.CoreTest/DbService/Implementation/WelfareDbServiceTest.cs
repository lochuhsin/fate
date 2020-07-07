using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    public class WelfareDbServiceTest
    {
        private const int GivenId = 1;
        private IWelfareRepo _welfareRepo;
        private IWelfareDbService _welfareDbService;

        [SetUp]
        public void SetUp()
        {
            _welfareRepo = Substitute.For<IWelfareRepo>();
            _welfareDbService = new WelfareDbService(_welfareRepo);
        }

        [Test]
        public void get_all_welfare()
        {
            GivenFakeWelfareList();
            var result = ServiceGetWelfare();
            result.Should().BeEquivalentTo(new List<WelfareDomainModel>()
            {
                new WelfareDomainModel()
                {
                    Id = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new WelfareDomainModel()
                {
                    Id = 2,
                    Title = "testTitle2",
                    Content = "testContent2",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new WelfareDomainModel()
                {
                    Id = 3,
                    Title = "testTitle3",
                    Content = "testContent3",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                }
            });
        }

        [Test]
        public void call_welfare_by_Id_should_return_that_welfare()
        {
            GivenFakeWelfare();
            var result = _welfareDbService.GetWelfareById(GivenId);
            result.Should().BeEquivalentTo(new WelfareDomainModel()
            {
                Id = GivenId,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue
            });
        }

        [Test]
        public void get_new_welfare_data_add_to_repo()
        {
            var testAnnouncementDomainModel = GivenTestAnnouncementDomainModel();
            WhenGetNewWelfare(testAnnouncementDomainModel);
            WelfareRepoAddResultShouldEqualTo(testAnnouncementDomainModel);
        }

        [Test]
        public void get_old_welfare_data_update_repo()
        {
            var testAnnouncementDomainModel = GivenTestAnnouncementDomainModel();
            WhenGetUpdateWelfare(testAnnouncementDomainModel);
            WelfareRepoUpdateResultShouldEqualTo(testAnnouncementDomainModel);
        }

        private void GivenFakeWelfare()
        {
            _welfareRepo.GetWelfareById(Arg.Any<int>()).Returns(new Welfare()
            {
                Id = GivenId,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue
            });
        }


        private List<WelfareDomainModel> ServiceGetWelfare()
        {
            var result = _welfareDbService.GetWelfareDomainModel();
            return result;
        }

        private void GivenFakeWelfareList()
        {
            _welfareRepo.GetAllWelfare().Returns(new List<Welfare>()
            {
                new Welfare()
                {
                    Id = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new Welfare()
                {
                    Id = 2,
                    Title = "testTitle2",
                    Content = "testContent2",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new Welfare()
                {
                    Id = 3,
                    Title = "testTitle3",
                    Content = "testContent3",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                }
            });
        }

        private void WelfareRepoAddResultShouldEqualTo(WelfareDomainModel testWelfareDomainModel)
        {
            _welfareRepo.Received(1).AddWelfare(Arg.Is<Welfare>(m => m.Id.Equals(testWelfareDomainModel.Id) &&
                                                                     m.Content.Equals(testWelfareDomainModel.Content) &&
                                                                     m.Title.Equals(testWelfareDomainModel.Title) &&
                                                                     m.PublishTime.Equals(testWelfareDomainModel
                                                                         .PublishTime) &&
                                                                     m.StartTime.Equals(testWelfareDomainModel
                                                                         .StartTime) &&
                                                                     m.EndTime.Equals(testWelfareDomainModel.EndTime)
            ));
        }

        private void WhenGetNewWelfare(WelfareDomainModel testWelfareDomainModel)
        {
            _welfareDbService.AddWelfare(testWelfareDomainModel);
        }

        private void WelfareRepoUpdateResultShouldEqualTo(WelfareDomainModel testWelfareDomainModel)
        {
            _welfareRepo.Received(1).UpdateWelfare(Arg.Is<Welfare>(
                m => m.Id == testWelfareDomainModel.Id &&
                     m.Title == testWelfareDomainModel.Title &&
                     m.Content == testWelfareDomainModel.Content &&
                     m.PublishTime == testWelfareDomainModel.PublishTime &&
                     m.StartTime == testWelfareDomainModel.StartTime &&
                     m.EndTime == testWelfareDomainModel.EndTime
            ));
        }

        private void WhenGetUpdateWelfare(WelfareDomainModel testWelfareDomainModel)
        {
            _welfareDbService.UpdateWelfare(testWelfareDomainModel);
        }

        private static WelfareDomainModel GivenTestAnnouncementDomainModel()
        {
            var testAnnouncementDomainModel = new WelfareDomainModel()
            {
                Id = 1,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
            };
            return testAnnouncementDomainModel;
        }
    }
}