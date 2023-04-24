using Microsoft.Extensions.DependencyInjection;
using RoboAPI.Entities;

namespace RoboAPI.Infrastructure.Persistencia.Configuracao;
public static class ConfiguracaoRoboDbContext
{
    public static void CriarRobo(this IServiceProvider services)
    {
        using var serviceScope = services.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<RoboDbContext>();

        dbContext.Robos.Add(new Robo(
                        new Braco(new Cotovelo(EstadoCotovelo.EmRepouso), new Pulso(EstadoPulso.Repouso)),
                        new Braco(new Cotovelo(EstadoCotovelo.EmRepouso), new Pulso(EstadoPulso.Repouso)),
                        new Cabeca(EstadoInclinacao.Repouso, EstadoRotacao.Repouso)));

        dbContext.SaveChanges();
    }
}