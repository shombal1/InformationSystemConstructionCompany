using System.Reflection;
using ISCC.Domain;
using ISCC.Domain.UseCase.CreateProjectUseCase;
using ISCC.Domain.UseCase.GetAllProjects;
using ISCC.Storage.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ISCC.Storage.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddStorage(this IServiceCollection services, string dbConnectionStringPostgres)
    {
        services.AddDbContextPool<MainDbContext>(
            options => { options.UseNpgsql(dbConnectionStringPostgres); });

        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(MainDbContext).Assembly); });

        services.AddAutoMapper(config =>
            config.AddMaps(Assembly.GetAssembly(typeof(MainDbContext))));

        services.AddSingleton<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IGetAllProjectStorage, GetAllProjectStorage>();
        services.AddScoped<ICreateProjectPlanStorage, CreateProjectPlanStorage>();
        services.AddScoped<ICreateProjectStorage, CreateProjectStorage>();
        services.AddScoped<ICreateResourceStorage, CreateResourceStorage>();
        services.AddScoped<IGetProjectStorage, GetProjectStorage>();
        
        return services;
    }
}