using EventPlannerApi.RequestHandlers.Subscriptions;
using FluentValidation;

namespace EventPlannerApi.RequestValidators
{
    public class GetSubscriptionQueryValidator: AbstractValidator<GetSubscriptionsQuery>
    {
        [System.Obsolete]
        public GetSubscriptionQueryValidator()
        {
            RuleFor(r => r.eventPlanId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Event Plan Id is empty. This is a required field");
        }
    }
}
