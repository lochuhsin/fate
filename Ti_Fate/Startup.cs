using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz.Spi;
using System;
using Ti_Fate.Core.DbService.Implementation;
using Ti_Fate.Core.DbService.Interface;
using Ti_Fate.Core.DomainModel;
using Ti_Fate.Core.HttpClients.Implement;
using Ti_Fate.Core.HttpClients.Interface;
using Ti_Fate.Core.Jobs;
using Ti_Fate.Core.Service.Implementation;
using Ti_Fate.Core.Service.Interface;
using Ti_Fate.Dao.Repositories.DBContext;
using Ti_Fate.Dao.Repositories.Implementations;
using Ti_Fate.Dao.Repositories.Interface;
using Ti_Fate.Extensions;

namespace Ti_Fate
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var loginExpireMinute = _configuration.GetValue<double>("LoginExpireMinute");
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = new PathString("/Home/Login");//登入頁 //
                option.LogoutPath = new PathString("/Home/Logout");//登出Action
                option.ExpireTimeSpan = TimeSpan.FromMinutes(loginExpireMinute);//沒給預設14天
            });

            services.AddSingleton(x => _configuration.GetSection("Login").Get<LdapConfig>());
            if (_configuration.GetValue<bool>("Login:IsLdap"))
            {
                services.AddTransient<IAuthenticationService, LdapAuthenticationService>();
            }
            else
            {
                services.AddTransient<IAuthenticationService, DummyAuthenticationService>();
            }

            services.AddTransient<IManageFileService, ManageFileService>();
            services.AddTransient<ILoginSessionService, LoginSessionService>();
            services.AddTransient<IConvertContextService, ConvertContextService>();

            services.AddTransient<IProfileDbService, ProfileDbService>();
            services.AddTransient<IWelfareDbService, WelfareDbService>();
            services.AddTransient<IImportantDbService, ImportantDbService>();
            services.AddTransient<IManageJobsDbService, ManageJobsDbService>();
            services.AddTransient<IClubsInfoDbService, ClubsInfoDbService>();
            services.AddTransient<IClubsDbService, ClubsDbService>();
            services.AddTransient<IMeetUpDbService, MeetUpDbService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IExternalDbService, ExternalDbService>();
            services.AddTransient<ICombineClubInfosService, CombineClubInfoServices>();


            services.AddTransient<IWelfareRepo, WelfareRepo>();
            services.AddTransient<IProfileRepo, ProfileRepo>();
            services.AddTransient<IImportantRepo, ImportantRepo>();
            services.AddTransient<IJobsInfoRepo, JobsInfoRepo>();
            services.AddTransient<IClubsInfoRepo, ClubsInfoRepo>();
            services.AddTransient<IClubsRepo, ClubsRepo>();
            services.AddTransient<IMeetUpRepo, MeetUpRepo>();
            services.AddTransient<IExternalInfoRepo, ExternalInfoRepo>();

            services.AddSingleton<IJobSchedulerProvider, JobSchedulerProvider>();
            services.AddTransient<IJobFactory, MyDIJobFactory>();
            services.AddTransient<RandomFater>();
            services.AddTransient<CallForRequest>();

            var dbContext = _configuration.GetValue<string>("ConnectionStrings:DBContext");
            services.AddDbContext<TiFateDbContext>(options => options.UseSqlServer(dbContext), ServiceLifetime.Singleton);

            services.AddHttpClient();
            services.AddHttpClient<ICallForRequestClient, CallForRequestClient>();

            services.AddMvc();
            services.AddApplicationInsightsTelemetry();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Login");
            }

            app.UseStatusCodePagesWithRedirects("~/404page.html");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            loggerFactory.AddConsole();

            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });

            app.UseQuartz();
        }
    }
}
