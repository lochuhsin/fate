using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;
using Ti_Fate.Core.DbService.Interface;

namespace Ti_Fate.Core.Jobs
{
    public class RandomFater : IJob
    {
        private readonly IProfileDbService _profileDbService;
        private readonly ILogger<RandomFater> _logger;
        private readonly IManageJobsDbService _manageJobsDbService;

        public RandomFater(IProfileDbService profileDbService, ILogger<RandomFater> logger, IManageJobsDbService manageJobsDbService)
        {
            _profileDbService = profileDbService;
            _logger = logger;
            _manageJobsDbService = manageJobsDbService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _profileDbService.RandomFater();
            _manageJobsDbService.UpdateLastExecute(nameof(RandomFater), DateTime.Now);
            _logger.LogInformation("Execute Job: " + nameof(RandomFater));
            return Task.CompletedTask;
        }
    }
}
