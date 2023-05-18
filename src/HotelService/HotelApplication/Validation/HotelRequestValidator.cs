using FluentValidation;
using Hotel.Application.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Validation
{
    public class HotelRequestValidator : AbstractValidator<HotelsRequest>
    {
        public HotelRequestValidator()
        {
            RuleFor(request => request.Country)
                .NotEmpty().WithMessage("Country must be provided.");

            RuleFor(request => request.City)
                .NotEmpty().WithMessage("City must be provided.");

            RuleFor(request => request.From)
                .NotEmpty().WithMessage("Arrival date must be provided.");

            RuleFor(request => request.To)
                .NotEmpty().WithMessage("Departure date must be provided.");

            RuleFor(request => request.To.ToDateTime())
                .Must(to => to.Date > DateTime.UtcNow.Date)
                .WithMessage("Departure date must be in the future.")
                .When(request => request.To != null);

            RuleFor(request => request.From.ToDateTime())
                .Must(from => from.Date >= DateTime.UtcNow.Date)
                .WithMessage("Arrival date must be in the future or today.")
                .When(request => request.From != null);

            RuleFor(request => request)
                .Must(req => req.From < req.To)
                .WithMessage("The departure date must be earlier than the arrival date.")
                .When(request => request.To != null && request.From != null);
        }
    }
}
