using System;
using EventPlannerFunctionApp.DataContext;
using EventPlannerFunctionApp.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventPlannerFunctionApp.SubscriptionFunc
{
    public class CreateNewSubscription
    {
        //private readonly ISubscriptionRepository _subscriptionRepository;
        //public CreateNewSubscription(ISubscriptionRepository subscriptionRepository)
        //{
        //    _subscriptionRepository = subscriptionRepository;
        //}

        [FunctionName("CreateNewSubscription")]
        public void Run([ServiceBusTrigger("newsubscription", Connection = "QueueConnectionString")] string queueItem,
            [CosmosDB(
            databaseName: "eventplanner-db",
            collectionName: "subscriptions",
            ConnectionStringSetting = "AzureCosmosDB")] out Subscription document,
            ILogger log)
        {

            var subscriptionObject = JsonConvert.DeserializeObject<Subscription>(queueItem);

            if (subscriptionObject == null)
            {
                log.LogError($"C# ServiceBus queue trigger function processed with error: queue item is null");
                throw new ArgumentNullException(nameof(subscriptionObject));
            }

            subscriptionObject.subscriptionStatus = "subscribed";
            document = subscriptionObject;

            //var newSubscription = _subscriptionRepository.CreateSubscription(subscriptionObject);
            log.LogInformation($"C# ServiceBus queue trigger function processed message successfully: {queueItem}");
        }
    }
}

