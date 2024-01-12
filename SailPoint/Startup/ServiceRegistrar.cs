
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SailPoint.DataAccess.Repository;
using SailPoint.Errors;
using SailPoint.Services;
using SailPoint.Services.Validations;

namespace SailPoint.Startup;

public static class ServiceRegistrar
{
    public static IServiceCollection CustomServiceRegistration(this IServiceCollection services)
    {
        services.AddSingleton<ICityRepository, CityRepository>();
        services.AddTransient<ICityDetailService, CityDetailService>();
        services.AddTransient<ICityValidationService, CityValidationService>();
        services.AddSingleton<ICityLocaterService, CityLocaterService>();

        services.AddSingleton<ICityLocaterValidationService, CityLocaterValidationService>();
        //services.AddSingleton<ICarRentalValidationService, CarRentalValidationService>();

        //services.AddSingleton<IRentalDateSlotService, RentalDateSlotService>();
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

        return services;
    }

    public static IServiceCollection NativeServiceRegistration(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(typeof(Program).Assembly);

        return services;
    }
}