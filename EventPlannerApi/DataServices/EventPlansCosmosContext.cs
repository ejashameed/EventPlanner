using EventPlannerApi.DataServices.Settings;
using Microsoft.Azure.Cosmos;

namespace EventPlannerApi.DataServices
{
    public class EventPlansCosmosContext : IEventPlansCosmosContext
    {
        private readonly CosmosSettings _cosmosSettings;

        public EventPlansCosmosContext(CosmosSettings cosmosSettings)
        {
            _cosmosSettings = cosmosSettings;

            string endPoint = _cosmosSettings.endPoint;
            string key = _cosmosSettings.key;
            string databaseName = _cosmosSettings.databaseName;

            CosmosClient cosmosClient = new CosmosClient(endPoint, key);
            EventPlansContainer = cosmosClient.GetContainer(databaseName, "eventplans");           
            SubscriptionContainer = cosmosClient.GetContainer(databaseName, "subscriptions");
        }
        public Container EventPlansContainer { get;  }
        public Container SubscriptionContainer { get; }
    }
}
