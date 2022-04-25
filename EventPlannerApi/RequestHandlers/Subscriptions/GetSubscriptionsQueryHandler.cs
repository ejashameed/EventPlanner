using AutoMapper;
using EventPlannerApi.DataServices.Repositories;
using EventPlannerApi.RequestResponses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EventPlannerApi.RequestHandlers.Subscriptions
{
    public class GetSubscriptionsQueryHandler : IRequestHandler<GetSubscriptionsQuery, IEnumerable<SubscriptionResponse>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public GetSubscriptionsQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubscriptionResponse>> Handle(GetSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _subscriptionRepository.GetSubscriptions(request.eventPlanId);
            var subscriptions = _mapper.Map<List<SubscriptionResponse>>(response);
            return subscriptions;
        }
    }
}
