using System;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Quartz;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.HttpClients.Interface;
using Ti_Fate.Core.Jobs;

namespace Ti_Fate.CoreTest.Jobs
{
    public class CallForRequestTest
    {
        private ICallForRequestClient _callForRequestClient;
        private ILogger<CallForRequest> _logger;
        private IManageJobsDbService _manageJobsDbService;
        private IJobExecutionContext _context;
        private CallForRequest _callForRequest;

        [SetUp]
        public void SetUp()
        {
            _callForRequestClient = Substitute.For<ICallForRequestClient>();
            _logger = Substitute.For<ILogger<CallForRequest>>();
            _manageJobsDbService = Substitute.For<IManageJobsDbService>();
            _context = Substitute.For<IJobExecutionContext>();
            _callForRequest = new CallForRequest(_callForRequestClient, _logger, _manageJobsDbService);
        }

        [Test]
        public void when_execute_send_request()
        {
            var result = _callForRequest.Execute(_context);

            _callForRequestClient.Received(1).SendRequestTask();
            _manageJobsDbService.Received(1).UpdateLastExecute(Arg.Is(nameof(CallForRequest)), Arg.Any<DateTime>());
        }
    }
}
