using EventPlannerApi.RequestResponses;
using MediatR;
using System;

namespace EventPlannerApi.RequestHandlers.Subscriptions
{
    public class SubscribeCommand: IRequest<SubscriptionResponse>
    {
        public string eventPlanId { get; set; }
        public string clientId { get; set; }            
        public SubscriberResponse subscriber { get; set; }
    }
}
