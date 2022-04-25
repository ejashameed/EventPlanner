using AutoMapper;
using EventPlannerApi.Models;
using EventPlannerApi.RequestResponses;

namespace EventPlannerApi.Mappers
{
    public class DomainToResponse: Profile
    {
        public DomainToResponse()
        {
            CreateMap<EventPlan, EventPlanResponse>();
            CreateMap<Subscription, SubscriptionResponse>();
            CreateMap<Subscriber, SubscriberResponse>();
        }
    }
}
