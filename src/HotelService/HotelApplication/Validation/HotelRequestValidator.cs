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

            RuleFor(request => request.To.ToDateTime())
                .Must(to => to >= DateTime.UtcNow)
                .WithMessage("Arrival date must be in the future or today.");

            RuleFor(request => request.From.ToDateTime())
                .Must(from => from >= DateTime.UtcNow)
                .WithMessage("Departure date must be in the future.");

            RuleFor(request => request)
                .Must(req => req.From < req.To)
                .WithMessage("The departure date must be earlier than the arrival date.");
        }
    }
}
