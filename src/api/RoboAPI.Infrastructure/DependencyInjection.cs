using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;

namespace RoboAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<RoboDbContext>(options =>
        {
            options.UseInMemoryDatabase("robo-becomex");
        });

        return services;
    }
}