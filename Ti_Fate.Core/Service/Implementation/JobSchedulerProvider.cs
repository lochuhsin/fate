using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.Jobs;
using Ti_Fate.Core.Service.Interface;

namespace Ti_Fate.Core.Service.Implementation
{
    public class JobSchedulerProvider : IJobSchedulerProvider
    {
        private readonly IServiceProvider _container;

        public JobSchedulerProvider(IServiceProvider container)
        {
            _container = container;
        }

        public async Task Start()
        {
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();
            scheduler.JobFactory = new MyDIJobFactory(_container);
            await scheduler.Start();


            var randomFaterBuilder = JobBuilder.Create<RandomFater>()
                .WithIdentity("RandomFater")
                .Build();
            var randomFaterTrigger = TriggerBuilder.Create()
                .StartNow()
                .WithIdentity("RandomFater")
                .WithCronSchedule("0 0 0 * * ?")
                .Build();
            await scheduler.ScheduleJob(randomFaterBuilder, randomFaterTrigger);

            var callForRequestBuilder = JobBuilder.Create<CallForRequest>()
                .WithIdentity("CallForRequest")
                .Build();
            var callForRequestTrigger = TriggerBuilder.Create()
                .StartNow()
                .WithIdentity("CallForRequest")
                .WithCronSchedule("30 * * * * ?")
                .Build();
            await scheduler.ScheduleJob(callForRequestBuilder, callForRequestTrigger);
        }
    }
}
