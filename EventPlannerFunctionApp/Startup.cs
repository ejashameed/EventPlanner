using EventPlannerFunctionApp;
using EventPlannerFunctionApp.DataContext;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebJobsStartup(typeof(Startup))]
namespace EventPlannerFunctionApp
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddSingleton<CosmosDbContext>();
            builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        }
    }
}
