using EventPlannerApi.RequestResponses;
using MediatR;
using System.Collections.Generic;

namespace EventPlannerApi.RequestHandlers.Subscriptions
{
    public class GetSubscriptionsQuery:IRequest<IEnumerable<SubscriptionResponse>>
    {
        public string eventPlanId { get; set; }
    }
}
