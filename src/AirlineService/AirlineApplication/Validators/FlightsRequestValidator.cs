using Airline.Application.Grpc;
using FluentValidation;

namespace Airline.Application.Validators
{
    public class FlightsRequestValidator : AbstractValidator<FlightsRequest>
    {
        public FlightsRequestValidator()
        {
            RuleFor(request => request.ArrivalLocation)
                .NotEmpty().WithMessage("Arrival location must be provided.");

            RuleFor(request => request.DepartureLocation)
                .NotEmpty().WithMessage("Departure location must be provided.");

            RuleFor(request => request.To.ToDateTime())
                .Must(to => to.Date > DateTime.UtcNow.Date)
                .WithMessage("Departure date must be in the future.");

            RuleFor(request => request.From.ToDateTime())
                .Must(from => from.Date >= DateTime.UtcNow.Date)
                .WithMessage("Arrival date must be in the future or today.");

            RuleFor(request => request)
                .Must(req => req.From < req.To)
                .WithMessage("The departure date must be earlier than the arrival date.");
        }
    }
}
