using EventPlannerFunctionApp.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlannerFunctionApp.DataContext
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly CosmosDbContext _dbContext;
        public SubscriptionRepository(CosmosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Subscription> CreateSubscription(Subscription subscription)
        {
            var partitionKey = new PartitionKey(subscription.eventPlanId);
            var result = await _dbContext.SubscriptionContainer.CreateItemAsync(subscription, partitionKey);

            return result.Resource;
        }
    }
}
