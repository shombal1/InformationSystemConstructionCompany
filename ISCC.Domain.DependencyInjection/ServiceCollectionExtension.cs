using Microsoft.Extensions.DependencyInjection;

namespace ISCC.Domain.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            
            cfg.RegisterServicesFromAssembly(typeof(IUnitOfWork).Assembly);
        });
        
        return services;
    }
}