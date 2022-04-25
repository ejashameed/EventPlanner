using AutoMapper;
using EventPlannerApi.Models;
using EventPlannerApi.RequestHandlers.Events;
using EventPlannerApi.RequestHandlers.Subscriptions;
using EventPlannerApi.RequestResponses;

namespace EventPlannerApi.Mappers
{
    public class RequestToDomain: Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateEventCommand, EventPlan>();
            CreateMap<SubscribeCommand, Subscription>();
            CreateMap<SubscriberResponse, Subscriber>();

        }        
    }
}
