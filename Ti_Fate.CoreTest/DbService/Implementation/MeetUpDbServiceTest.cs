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
    public class MeetUpDbServiceTest
    {
        private const int GivenId = 1;
        private IMeetUpRepo _meetUpRepo;
        private IMeetUpDbService _meetUpDbService;

        [SetUp]
        public void SetUp()
        {
            _meetUpRepo = Substitute.For<IMeetUpRepo>();
            _meetUpDbService = new MeetUpDbService(_meetUpRepo);
        }

        [Test]
        public void call_meetUp_by_id_should_return_that_meetUp()
        {
            GivenFakeMeetUp();
            var result = _meetUpDbService.GetMeetUpById(GivenId);
            result.Should().BeEquivalentTo(new MeetUpDomainModel()
            {
                Id = GivenId,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
            });
        }

        [Test]
        public void get_all_meetUp()
        {
            GivenFakeMeetUpList();
            var result = _meetUpDbService.GetMeetUpDomainModel();
            result.Should().BeEquivalentTo(new List<MeetUpDomainModel>()
            {
                new MeetUpDomainModel()
                {
                    Id = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                },
                new MeetUpDomainModel()
                {
                    Id = 2,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                },
                new MeetUpDomainModel()
                {
                    Id = 3,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                }
            });
        }


        [Test]
        public void get_new_meetUp_data_add_to_repo()
        {
            var testDomainModel = GivenTestDomainModel();
            _meetUpDbService.AddMeetUp(testDomainModel);
            _meetUpRepo.Received(1).AddMeetUp(Arg.Is<MeetUp>(m => m.Id.Equals(testDomainModel.Id) &&
                                                                m.Content.Equals(testDomainModel.Content) &&
                                                                m.Title.Equals(testDomainModel.Title) &&
                                                                m.PublishTime.Equals(testDomainModel.PublishTime) &&
                                                                m.StartTime.Equals(testDomainModel.StartTime) &&
                                                                m.EndTime.Equals(testDomainModel.EndTime)));
        }

        [Test]
        public void get_old_meetUp_data_update_repo()
        {
            var testDomainModel = GivenTestDomainModel();
            _meetUpDbService.UpdateMeetUp(testDomainModel);
            _meetUpRepo.Received(1).UpdateMeetUp(Arg.Is<MeetUp>(m => m.Id.Equals(testDomainModel.Id) &&
                                                                                                   m.Content.Equals(testDomainModel.Content) &&
                                                                                                   m.PublishTime.Equals(testDomainModel.PublishTime) &&
                                                                                                   m.StartTime.Equals(testDomainModel.StartTime) &&
                                                                                                   m.EndTime.Equals(testDomainModel.EndTime)));
        }

        private static MeetUpDomainModel GivenTestDomainModel()
        {
            var testDomainModel = new MeetUpDomainModel()
            {
                Id = GivenId,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue
            };
            return testDomainModel;
        }
        private void GivenFakeMeetUpList()
        {
            _meetUpRepo.GetAllMeetUp().Returns(new List<MeetUp>()
            {
                new MeetUp()
                {
                    Id = 1,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                },
                new MeetUp()
                {
                    Id = 2,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                },
                new MeetUp()
                {
                    Id = 3,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishTime = DateTime.MaxValue,
                    StartTime = DateTime.MaxValue,
                    EndTime = DateTime.MaxValue,
                }
            });
        }

        private void GivenFakeMeetUp()
        {
            _meetUpRepo.GetMeetUpById(Arg.Any<int>()).Returns(new MeetUp()
            {
                Id = GivenId,
                Title = "testTitle",
                Content = "testContent",
                PublishTime = DateTime.MaxValue,
                StartTime = DateTime.MaxValue,
                EndTime = DateTime.MaxValue,
            });
        }
    }
}
