using CarRent.Application.Grpc;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Application.Validators
{
    public class CarsRequestValidator : AbstractValidator<CarsRequest>
    {
        public CarsRequestValidator()
        {
            RuleFor(request => request.Country)
                .NotEmpty().WithMessage("Country must be provided.");

            RuleFor(request => request.City)
                .NotEmpty().WithMessage("City must be provided.");

            RuleFor(request => request.To.ToDateTime())
                .Must(to => to >= DateTime.UtcNow)
                .WithMessage("Start rent date must be in the future or today.");

            RuleFor(request => request.From.ToDateTime())
                .Must(from => from >= DateTime.UtcNow)
                .WithMessage("Complite rent date must be in the future or today.");

            RuleFor(request => request)
                .Must(req => req.From < req.To)
                .WithMessage("The start rent date must be earlier than the complite rent date.");

        }
    }
}
