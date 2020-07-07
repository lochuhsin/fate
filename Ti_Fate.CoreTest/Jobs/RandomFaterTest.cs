using System;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Quartz;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.Jobs;

namespace Ti_Fate.CoreTest.Jobs
{
    public class RandomFaterTest
    {
        private IProfileDbService _profileDbService;
        private ILogger<RandomFater> _logger;
        private IManageJobsDbService _manageJobsDbService;
        private IJobExecutionContext _context;
        private RandomFater _randomFater;

        [SetUp]
        public void SetUp()
        {
            _profileDbService = Substitute.For<IProfileDbService>();
            _logger = Substitute.For<ILogger<RandomFater>>();
            _manageJobsDbService = Substitute.For<IManageJobsDbService>();
            _context = Substitute.For<IJobExecutionContext>();
            _randomFater = new RandomFater(_profileDbService, _logger, _manageJobsDbService);
        }

        [Test]
        public void when_execute_random_faters()
        {
            var result = _randomFater.Execute(_context);

            _profileDbService.Received(1).RandomFater();
            _manageJobsDbService.Received(1).UpdateLastExecute(Arg.Is<string>(nameof(RandomFater)), Arg.Any<DateTime>());
        }
    }
}
