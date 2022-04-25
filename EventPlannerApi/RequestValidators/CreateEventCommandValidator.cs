using EventPlannerApi.RequestHandlers.Events;
using FluentValidation;

namespace EventPlannerApi.RequestValidators
{
    public class CreateEventCommandValidator: AbstractValidator<CreateEventCommand>
    {
        [System.Obsolete]
        public CreateEventCommandValidator()
        {
            RuleFor(r => r.ClientId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Client Id is empty. This is a required field");
            RuleFor(r => r.EventName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Event Name is empty. This is a required field");

            RuleFor(r => r.EventDescription)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Event Description is empty. This is a required field");

            RuleFor(r => r.EventStartDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Event Start Date is empty. This is a required field");

            RuleFor(r => r.EventEndDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Event End Date is empty. This is a required field");
        }
    }
}
