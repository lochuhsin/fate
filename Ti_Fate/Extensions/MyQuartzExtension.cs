using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ti_Fate.Core.Service.Interface;

namespace Ti_Fate.Extensions
{
    public static class MyQuartzExtension
    {
        public static void UseQuartz(this IApplicationBuilder app)
        {
            var scheduler = app.ApplicationServices
                .GetService<IJobSchedulerProvider>();
            scheduler.Start();
        }
    }
}
