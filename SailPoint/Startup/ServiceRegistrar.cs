
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SailPoint.Errors;

namespace SailPoint.Startup;

public static class ServiceRegistrar
{
    public static IServiceCollection CustomServiceRegistration(this IServiceCollection services)
    {
        //services.AddSingleton<ICarRepository, CarRepository>();
        //services.AddSingleton<ICarService, CarService>();
        //services.AddSingleton<ICarValidationService, CarValidationService>();


        //services.AddSingleton<ICarRentalRepository, CarRentalRepository>();
        //services.AddSingleton<ICarRentalService, CarRentalService>();
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