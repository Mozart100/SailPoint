using FluentValidation;
using SailPoint.Models.Dtos;

namespace SailPoint.Services.Validations;

public class AddCityRequestValidator : AbstractValidator<AddCityDetailRequest>
{
    public AddCityRequestValidator()
    {
        RuleFor(req => req.City).NotNull().WithMessage("{PropertyName} shouldnt be empty.");
    }
}
