using Microsoft.Extensions.DependencyInjection;
using RoboAPI.Services.Membros.Bracos.Interfaces;
using RoboAPI.Services.Membros;
using RoboAPI.Services.Membros.Interfaces;
using RoboAPI.Services.Membros.Bracos;
using RoboAPI.Services.Interfaces;

namespace RoboAPI.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddTransient<ICotoveloService, CotoveloService>();
        services.AddTransient<IPulsoService, PulsoService>();
        services.AddTransient<ICabecaService, CabecaService>();
        services.AddTransient<IRoboService, RoboService>();

        return services;
    }
}