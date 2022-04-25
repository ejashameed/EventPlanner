using EventPlannerApi.RequestHandlers.Subscriptions;
using FluentValidation;

namespace EventPlannerApi.RequestValidators
{
    public class SubscribeCommandValidator: AbstractValidator<SubscribeCommand>
    {
        [System.Obsolete]
        public SubscribeCommandValidator()
        {
            RuleFor(r => r.eventPlanId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Event Plan Id is empty. This is a required field");

            RuleFor(r => r.clientId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Client Id is empty. This is a required field");

            RuleFor(r => r.subscriber.subscriberName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Subscriber Name is empty. This is a required field");

            RuleFor(r => r.subscriber.subscriberEmailId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Subscriber Email Id is empty. This is a required field");

            RuleFor(r => r.subscriber.subscriberPhone)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Subscriber Phone number is empty. This is a required field");


        }
    }
}
