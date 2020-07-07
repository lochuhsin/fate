using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.HttpClients.Interface;

namespace Ti_Fate.Core.Jobs
{
    public class CallForRequest : IJob
    {
        private readonly ICallForRequestClient _callForRequestClient;
        private readonly ILogger<CallForRequest> _logger;
        private readonly IManageJobsDbService _manageJobsDbService;

        public CallForRequest(ICallForRequestClient callForRequestClient, ILogger<CallForRequest> logger, IManageJobsDbService manageJobsDbService)
        {
            _callForRequestClient = callForRequestClient;
            _logger = logger;
            _manageJobsDbService = manageJobsDbService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _callForRequestClient.SendRequestTask();
            _manageJobsDbService.UpdateLastExecute(nameof(CallForRequest), DateTime.Now);
            _logger.LogInformation("Execute Job: " + nameof(CallForRequest));
            return Task.CompletedTask;
        }
    }
}
