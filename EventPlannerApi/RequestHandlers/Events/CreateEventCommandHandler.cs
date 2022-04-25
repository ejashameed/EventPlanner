using AutoMapper;
using EventPlannerApi.DataServices.Repositories;
using EventPlannerApi.Models;
using EventPlannerApi.RequestResponses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventPlannerApi.RequestHandlers.Events
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, EventPlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventsRepository;
        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRespository)
        {
            _mapper = mapper;
            _eventsRepository = eventRespository;
        }

        public async Task<EventPlanResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // create eventPlanId & ClientId
            request.EventPlanId = Guid.NewGuid().ToString();

            // map API request object to domain entity of eventplan
            var requestEventToDomain = _mapper.Map<EventPlan>(request);

            //make db call to store the event data
            var result = await _eventsRepository.CreateEventAsync(requestEventToDomain);

            //map domain object to API response 
            var response = _mapper.Map<EventPlanResponse>(result);

            return response;
        }
    }
}
