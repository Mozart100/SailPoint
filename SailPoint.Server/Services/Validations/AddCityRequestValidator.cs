using FluentValidation;
using SailPoint.Models.Dtos;

namespace SailPoint.Services.Validations;

public class AddCityRequestValidator : AbstractValidator<AddCityRequest>
{
    public AddCityRequestValidator()
    {
        RuleFor(req => req.City).NotNull().WithMessage("{PropertyName} shouldnt be empty.");
    }
}

