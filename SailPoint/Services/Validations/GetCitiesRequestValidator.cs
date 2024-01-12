using FluentValidation;
using SailPoint.Models.Dtos;

namespace SailPoint.Services.Validations;

public class GetCitiesRequestValidator : AbstractValidator<GetCitiesRequest>
{
    public GetCitiesRequestValidator()
    {
        RuleFor(req => req.Prefix).NotNull().WithMessage("{PropertyName} shouldnt be empty.");
    }
}

