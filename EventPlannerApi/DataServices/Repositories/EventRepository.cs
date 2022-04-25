using EventPlannerApi.Models;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlannerApi.DataServices.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IEventPlansCosmosContext _cosmosContext;
        public EventRepository(IEventPlansCosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext;
        }

        public async Task<EventPlan> CreateEventAsync(EventPlan eventPlan)
        {
            var partitionKey = new PartitionKey(eventPlan.ClientId);
            var result = await _cosmosContext.EventPlansContainer.CreateItemAsync(eventPlan,partitionKey);
            
            return result.Resource;
        }

        public async Task<IEnumerable<EventPlan>> GetByClientIdAsync(string clientId)
        {
            // reading all items (all events) in a partition key
            var queryDefinition = new QueryDefinition("Select * from eventplans");
            var paritionKey = new PartitionKey(clientId);   
            var iterator = _cosmosContext.EventPlansContainer
                .GetItemQueryIterator<EventPlan>(queryDefinition, requestOptions: new QueryRequestOptions() { PartitionKey = paritionKey});

            var result = new List<EventPlan>();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                if (response != null)
                    result.AddRange(response.ToList());
            }

            return result;
        }
    }
}
