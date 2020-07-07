using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.ViewModels;

namespace Ti_Fate.Controllers
{
    [Authorize]
    public class ManageJobsController : Controller
    {
        private readonly IManageJobsDbService _manageJobsDbService;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public ManageJobsController(IManageJobsDbService manageJobsDbService, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _manageJobsDbService = manageJobsDbService;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public IActionResult ManageJobs()
        {
            var manageJobsViewModel = new ManageJobsViewModel(_manageJobsDbService.GetAllJobsInfos());
            return View(manageJobsViewModel);
        }
        public IActionResult ExecuteJob(string jobName)
        {
            var job = (IJob)GetJobInstance(jobName);
            job.Execute(null);

            return RedirectToAction(nameof(ManageJobs));
        }

        private object GetJobInstance(string jobName)
        {
            var jobNameWithNamespace = GetJobNameWithNamespace(jobName);
            var jobType = GetJobType(jobNameWithNamespace);
            var jobInstance = ActivatorUtilities.CreateInstance(_serviceProvider, jobType);
            return jobInstance;
        }

        private static Type GetJobType(string jobNameWithNamespace)
        {
            var assembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();
            var jobType = assembliesLoaded
                .Select(assembly => assembly.GetType(jobNameWithNamespace))
                .FirstOrDefault(type => type != null);
            return jobType;
        }

        private string GetJobNameWithNamespace(string jobName)
        {
            var jobsFolder = _configuration.GetValue<string>("JobsFolder");
            var jobsInfoJobName = jobsFolder + "." + jobName;
            return jobsInfoJobName;
        }
    }
}