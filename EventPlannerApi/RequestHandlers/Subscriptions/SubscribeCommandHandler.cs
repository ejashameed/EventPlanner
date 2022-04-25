using AutoMapper;
using EventPlannerApi.DataServices.Repositories;
using EventPlannerApi.Models;
using EventPlannerApi.RequestResponses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventPlannerApi.RequestHandlers.Subscriptions
{
    public class SubscribeCommandHandler : IRequestHandler<SubscribeCommand, SubscriptionResponse>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public SubscribeCommandHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<SubscriptionResponse> Handle(SubscribeCommand request, CancellationToken cancellationToken)
        {
            var requestToDomainEntity = _mapper.Map<Subscription>(request);
            var enqueuedSubscription = await _subscriptionRepository.EnqueueSubscription(requestToDomainEntity);
            var subscriptionToResponse = _mapper.Map<SubscriptionResponse>(enqueuedSubscription);
            return subscriptionToResponse;
        }
    }

}
