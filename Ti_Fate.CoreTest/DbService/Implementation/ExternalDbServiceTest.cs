using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Dao.Model;
using Ti_Fate.Dao.Repositories.Interface;

namespace Ti_Fate.CoreTest.DbService.Implementation
{
    [TestFixture]
    public class ExternalDbServiceTest
    {
        private const int GivenId = 1;
        private IExternalInfoRepo _externalInfoRepo;
        private IExternalDbService _externalInfoService;

        [SetUp]
        public void SetUp()
        {
            _externalInfoRepo = Substitute.For<IExternalInfoRepo>();
            _externalInfoService = new ExternalDbService(_externalInfoRepo);
        }

        [Test]
        public void call_external_by_id_should_return_that_external()
        {
            GivenFakeExternal();
            var result = _externalInfoService.GetExternalById(GivenId);
            ExternalRepoByIdGetResultShouldEqualTo(result);
        }


        [Test]
        public void get_all_external()
        {
            GivenFakeExternalList();
            var result = _externalInfoService.GetMeetUpDomainModel();
            ExternalRepoGetResultShouldEqualTo(result);
        }

        [Test]
        public void get_new_external_data_add_to_repo()
        {
            var testDomainModel = GivenTestDomainModel();
            _externalInfoService.AddExternal(testDomainModel);
            ExternalRepoAddResultShouldEqualTo(testDomainModel);
        }

        [Test]
        public void get_old_external_data_update_repo()
        {
            var testDomainModel = GivenTestDomainModel();
            _externalInfoService.UpdateExternal(testDomainModel);
            ExternalRepoUpdateResultShouldEqualTo(testDomainModel);
        }

        private void ExternalRepoUpdateResultShouldEqualTo(ExternalInfoDomainModel testDomainModel)
        {
            _externalInfoRepo.Received(1).UpdateExternalInfo(Arg.Is<ExternalInfo>(m => m.Id.Equals(testDomainModel.Id) &&
                                                                                       m.Content.Equals(testDomainModel
                                                                                           .Content) &&
                                                                                       m.PublishTime.Equals(testDomainModel
                                                                                           .PublishTime) &&
                                                                                       m.StartTime.Equals(testDomainModel
                                                                                           .StartTime) &&
                                                                                       m.EndTime.Equals(testDomainModel
                                                                                           .EndTime)));
        }

        private void ExternalRepoAddResultShouldEqualTo(ExternalInfoDomainModel testDomainModel)
        {
            _externalInfoRepo.Received(1).AddExternalInfo(Arg.Is<ExternalInfo>(m => m.Id.Equals(testDomainModel.Id) &&
                                                                                    m.Content.Equals(testDomainModel.Content) &&
                                                                                    m.PublishTime.Equals(testDomainModel
                                                                                        .PublishTime) &&
                                                                                    m.StartTime.Equals(
                                                                                        testDomainModel.StartTime) &&
                                                                                    m.EndTime.Equals(testDomainModel.EndTime)));
        }

        private static ExternalInfoDomainModel GivenTestDomainModel()
        {
            var testDomainModel = new ExternalInfoDomainModel()
            {
                Id = 1,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue
            };
            return testDomainModel;
        }

        private static void ExternalRepoGetResultShouldEqualTo(List<ExternalInfoDomainModel> result)
        {
            result.Should().BeEquivalentTo(new List<ExternalInfoDomainModel>()
            {
                new ExternalInfoDomainModel()
                {
                    Id = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ExternalInfoDomainModel()
                {
                    Id = 2,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ExternalInfoDomainModel()
                {
                    Id = 3,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                }
            });
        }

        private static void ExternalRepoByIdGetResultShouldEqualTo(ExternalInfoDomainModel result)
        {
            result.Should().BeEquivalentTo(new ExternalInfoDomainModel()
            {
                Id = GivenId,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue
            });
        }
        private void GivenFakeExternalList()
        {
            _externalInfoRepo.GetAllExternalInfo().Returns(new List<ExternalInfo>()
            {
                new ExternalInfo()
                {
                    Id = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ExternalInfo()
                {
                    Id = 2,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                },
                new ExternalInfo()
                {
                    Id = 3,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue
                }
            });
        }

        private void GivenFakeExternal()
        {
            _externalInfoRepo.GetExternalInfoById(Arg.Any<int>()).Returns(new ExternalInfo()
            {
                Id = GivenId,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue
            });
        }
    }
}
