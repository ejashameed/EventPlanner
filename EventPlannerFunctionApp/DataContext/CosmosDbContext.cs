using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerFunctionApp.DataContext
{
    public class CosmosDbContext
    {
        public CosmosDbContext()
        {
            string endPoint = Environment.GetEnvironmentVariable("ConnectionStrings:EndPoint");
            string key = Environment.GetEnvironmentVariable("ConnectionStrings:Key");
            string databaseName = Environment.GetEnvironmentVariable("ConnectionStrings:DatabaseName");

            CosmosClient cosmosClient = new CosmosClient(endPoint, key);
            
            SubscriptionContainer = cosmosClient.GetContainer(databaseName, "subscriptions");
            EventPlansContainer = cosmosClient.GetContainer(databaseName, "eventplans");

        }
        public Container EventPlansContainer { get; }
        public Container SubscriptionContainer { get; }
    }
}
