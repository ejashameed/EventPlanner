using Microsoft.Azure.Cosmos;

namespace EventPlannerApi.DataServices
{
    public interface IEventPlansCosmosContext
    {
        Container EventPlansContainer { get; }        
        Container SubscriptionContainer { get; }
    }
}
