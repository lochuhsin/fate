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
    class ManageJobsDbServiceTest
    {
        private IJobsInfoRepo _jobsInfoRepo;
        private ManageJobsDbService _manageJobDbService;

        [SetUp]
        public void Setup()
        {
            _jobsInfoRepo = Substitute.For<IJobsInfoRepo>();
            _manageJobDbService = new ManageJobsDbService(_jobsInfoRepo);
        }

        [Test]
        public void when_call_update_last_execute_time()
        {
            _manageJobDbService.UpdateLastExecute("testName", new DateTime(2020, 06, 01, 05, 30, 00));
            _jobsInfoRepo.Received(1).UpdateLastExecuteTime(Arg.Is<string>(m => m == "testName"),
                Arg.Is<DateTime>(m => m == new DateTime(2020, 06, 01, 05, 30, 00)));
        }

        [Test]
        public void when_call_GetAllJobsInfos()
        {
            var jobsList = GivenJobInfoList();
            var jobsDomainModelList = new List<JobsInfoDomainModel>()
            {
                new JobsInfoDomainModel(jobsList[0]),
                new JobsInfoDomainModel(jobsList[1]),
                new JobsInfoDomainModel(jobsList[2])
            };
            _jobsInfoRepo.GetAllJobsInfos().Returns(jobsList);

            var actual = _manageJobDbService.GetAllJobsInfos();

            actual.Should().BeEquivalentTo(jobsDomainModelList);
        }

        private static List<JobsInfo> GivenJobInfoList()
        {
            return new List<JobsInfo>()
            {
                new JobsInfo()
                {
                    CronTrigger = "test1 cron",
                    JobName = "test1 job",
                    LastExecute = new DateTime(2020,06,01)
                },
                new JobsInfo()
                {
                    CronTrigger = "test2 cron",
                    JobName = "test2 job",
                    LastExecute = new DateTime(2020,06,02)
                },
                new JobsInfo()
                {
                    CronTrigger = "test3 cron",
                    JobName = "test3 job",
                    LastExecute = new DateTime(2020,06,03)
                }
            };
        }
    }
}
