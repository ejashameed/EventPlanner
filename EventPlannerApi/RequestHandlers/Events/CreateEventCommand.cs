using EventPlannerApi.RequestResponses;
using MediatR;
using System;

namespace EventPlannerApi.RequestHandlers.Events
{
    public class CreateEventCommand: IRequest<EventPlanResponse>
    {
        public string? ClientId { get; set; }

        public string? EventPlanId { get; set; }

        public string? EventName { get; set; }

        public string? EventDescription { get; set; }
        
        public DateTime EventStartDate { get; set; }
       
        public DateTime EventEndDate { get; set; }
    }
}
