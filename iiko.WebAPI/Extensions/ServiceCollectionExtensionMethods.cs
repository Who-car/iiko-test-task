using Microsoft.EntityFrameworkCore;
using WebAPI.Abstractions.Repositories;
using WebAPI.Abstractions.Services;
using WebAPI.Configurations;
using WebAPI.DataAccess;
using WebAPI.DataAccess.Repositories;
using WebAPI.Middlewares;
using WebAPI.Services;

namespace WebAPI.Extensions;

public static class ServiceCollectionExtensionMethods
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(builder =>
        {
            builder
                .UseNpgsql(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IClientRepository, ClientRepository>();
        
        return services;
    }
    
    public static IServiceCollection RegisterRequiredServices(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        
        return services;
    }
    
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(expression =>
        {
            expression.AddProfile<ClientMapperProfile>();
        });
        
        return services;
    }
    
    public static IServiceCollection AddGlobalExceptionHandler(
        this IServiceCollection services)
    {
        return services.AddScoped<ExceptionMiddleware>();
    }
}