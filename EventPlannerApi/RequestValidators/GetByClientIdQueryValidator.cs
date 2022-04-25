using EventPlannerApi.RequestHandlers.Events;
using FluentValidation;

namespace EventPlannerApi.RequestValidators
{
    public class GetByClientIdQueryValidator: AbstractValidator<GetByClientIdQuery>
    {
        [System.Obsolete]
        public GetByClientIdQueryValidator()
        {
            RuleFor(r => r.clientId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Client Id is empty. This is a required field");
        }
    }
}
