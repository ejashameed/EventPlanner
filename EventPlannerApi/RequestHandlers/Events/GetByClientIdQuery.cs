using EventPlannerApi.RequestResponses;
using MediatR;
using System.Collections.Generic;

namespace EventPlannerApi.RequestHandlers.Events
{
    public class GetByClientIdQuery: IRequest<IEnumerable<EventPlanResponse>>
    {
        public string clientId { get; set; }
    }
}
