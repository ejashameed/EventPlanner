using EventPlannerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlannerApi.DataServices.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptions(string eventPlandId);
        Task<Subscription> EnqueueSubscription(Subscription subscription);
    }
}
