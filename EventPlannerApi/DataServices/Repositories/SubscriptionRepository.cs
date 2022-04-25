using Azure.Messaging.ServiceBus;
using EventPlannerApi.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventPlannerApi.DataServices.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IServiceBusContext _serviceBusContext;
        private readonly IEventPlansCosmosContext _cosmosContext;
        public SubscriptionRepository(IServiceBusContext serviceBusContext, IEventPlansCosmosContext cosmosContext)
        {
            _serviceBusContext = serviceBusContext;
            _cosmosContext = cosmosContext;
        }
        public async Task<Subscription> EnqueueSubscription(Subscription subscription)
        {
            try
            {
                // set Ids to subscription and subscriber
                subscription.subscriptionId = Guid.NewGuid().ToString();
                subscription.subscriber.subscriberId = Guid.NewGuid().ToString();

                //set subcribtion request date time
                subscription.subscribedDateTime = DateTime.Now;

                //set subscription status
                subscription.subscriptionStatus = "Pending";

                // serialize the message & send to queue
                string jsonEntity = JsonSerializer.Serialize(subscription);
                await _serviceBusContext.sender.SendMessageAsync(new ServiceBusMessage(jsonEntity));
                
                return subscription;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await _serviceBusContext.sender.DisposeAsync();
                await _serviceBusContext.client.DisposeAsync();
            }
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptions(string eventPlandId)
        {
            QueryDefinition query = new QueryDefinition("SELECT * FROM C");
            List<Subscription> subscriptions = new List<Subscription>();

            using (FeedIterator<Subscription> iterator = _cosmosContext.SubscriptionContainer.GetItemQueryIterator<Subscription>(
                query, null, new QueryRequestOptions() { PartitionKey = new PartitionKey(eventPlandId) }))
            {
                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    subscriptions.AddRange(response.ToList());
                }
            }
            return subscriptions;
        }
    }
}
