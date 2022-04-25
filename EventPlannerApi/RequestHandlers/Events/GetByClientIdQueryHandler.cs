using AutoMapper;
using EventPlannerApi.DataServices.Repositories;
using EventPlannerApi.Models;
using EventPlannerApi.RequestResponses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EventPlannerApi.RequestHandlers.Events
{
    public class GetByClientIdQueryHandler : IRequestHandler<GetByClientIdQuery, IEnumerable<EventPlanResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventsRepository;
        public GetByClientIdQueryHandler(IMapper mapper, IEventRepository eventRespository)
        {
            _mapper = mapper;
            _eventsRepository = eventRespository;
        }

        public async Task<IEnumerable<EventPlanResponse>> Handle(GetByClientIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<EventPlan> response = await _eventsRepository.GetByClientIdAsync(request.clientId);
            IEnumerable<EventPlanResponse> result = _mapper.Map<IEnumerable<EventPlanResponse>>(response);
            return result;
        }
    }
}
