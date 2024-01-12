using SailPoint.Models.Dtos;

namespace SailPoint.Services.Validations;

public interface ICityValidationService
{
    Task AddCarRequestValidateAsync(AddCityDetailRequest request);
}
public class CityValidationService : ServiceValidatorBase, ICityValidationService
{
    private readonly ILogger<CityValidationService> _logger;

    public CityValidationService(ILogger<CityValidationService> logger)
    {
        _logger = logger;
    }

    public async Task AddCarRequestValidateAsync(AddCityDetailRequest request)
    {
        var validator = new AddCityRequestValidator();
        var validationResult = validator.Validate(request);

        var errors = Dissect(validationResult);

        Validate(errors);
    }
}
