using Coords.Domain.Errors;
using Coords.Domain.ViewModels;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Coords.App.Validators
{
    public class CreateCoordValidator : AbstractValidator<CreateCoordViewModel>
    {
        public CreateCoordValidator()
        {
            RuleFor(x => x.Details)
                .NotEmpty().WithMessage(CreateCoordErrors.DetailsRequired);

            RuleFor(x => x.Latitude)
                .NotEmpty()
                .NotNull().WithMessage(CreateCoordErrors.LatitudeRequired);

            RuleFor(x => x.Longitude)
                .NotEmpty()
                .NotNull().WithMessage(CreateCoordErrors.LongitudeRequired);

            RuleFor(x => x.UserToken)
                .NotEmpty()
                .NotNull().WithMessage(CreateCoordErrors.TokenRequired);

            //RuleFor(x => x.User.PhoneNumber)//123-456-78-90 - length - 13
            //    .NotEmpty()
            //    .NotNull().WithMessage(CreateCoordErrors.PhoneNumberRequired) 
            //    .Length(13).WithMessage(CreateCoordErrors.PhoneNumberLength)
            //    .Matches(new Regex(@"\d{3}-\d{3}-\d{2}-\d{2}$")).WithMessage(CreateCoordErrors.PhoneNumberInvalid);
        }
    }
}
