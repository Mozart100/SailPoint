
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

<<<<<<< HEAD
        services.AddSingleton<ICityLocaterValidationService, CityLocaterValidationService>();
=======
        //services.AddSingleton<ICarRentalService, CarRentalService>();
>>>>>>> 0b7b8d59cb5fdab65559c7a8522d0dcc8fc2566a
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