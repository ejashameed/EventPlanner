using EventPlannerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventPlannerApi.DataServices.Repositories
{
    public interface IEventRepository
    {
        Task<EventPlan> CreateEventAsync(EventPlan eventPlan);
        Task<IEnumerable<EventPlan>> GetByClientIdAsync(string clientId);
    }
}
