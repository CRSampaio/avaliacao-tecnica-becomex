using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Membros.Interfaces;

namespace RoboAPI.Services.Membros;

public class CabecaService : ICabecaService
{
    private readonly RoboDbContext _context;

    public CabecaService(RoboDbContext context)
    {
        _context = context;
    }

    public async Task Abaixar()
    {
        var robo = _context.Robos
                            .Include(x => x.Cabeca)
                            .First();

        if (robo.Cabeca.EstadoInclinacao == EstadoInclinacao.PraBaixo)
        {
            throw new Exception("A cabeca ja esta inclinada para baixo");
        }

        int estadoInclinacao = (int)robo.Cabeca.EstadoInclinacao;

        estadoInclinacao++;

        robo.Cabeca.EstadoInclinacao = (EstadoInclinacao)estadoInclinacao;

        await _context.SaveChangesAsync();
    }

    public async Task RotacionarNegativo()
    {
        var robo = _context.Robos
                            .Include(x => x.Cabeca)
                            .First();

        if (robo.Cabeca.EstadoInclinacao == EstadoInclinacao.PraBaixo)
        {
            throw new Exception("Cabeca não pode ser rotacionada, quando está inclinada para baixo");
        }

        if (robo.Cabeca.EstadoRotacao == EstadoRotacao.Rotacao90GrausNegativo)
        {
            throw new Exception("Cabeca rotacionada ao máximo negativamente");
        }

        int estadoRotacao = (int)robo.Cabeca.EstadoRotacao;

        estadoRotacao--;

        robo.Cabeca.EstadoRotacao = (EstadoRotacao)estadoRotacao;

        await _context.SaveChangesAsync();
    }

    public async Task RotacionarPositivo()
    {
        var robo = _context.Robos
                            .Include(x => x.Cabeca)
                            .First();

        if (robo.Cabeca.EstadoInclinacao == EstadoInclinacao.PraBaixo)
        {
            throw new Exception("Cabeca não pode ser rotacionada, quando está inclinada para baixo");
        }

        if (robo.Cabeca.EstadoRotacao == EstadoRotacao.Rotacao90Graus)
        {
            throw new Exception("Cabeca rotacionada ao máximo positivamente");
        }

        int estadoRotacao = (int)robo.Cabeca.EstadoRotacao;

        estadoRotacao++;

        robo.Cabeca.EstadoRotacao = (EstadoRotacao)estadoRotacao;

        await _context.SaveChangesAsync();
    }

    public async Task Subir()
    {
        var robo = _context.Robos
                            .Include(x => x.Cabeca)
                            .First();

        if (robo.Cabeca.EstadoInclinacao == EstadoInclinacao.PraCima)
        {
            throw new Exception("A cabeca ja esta inclinada para cima");
        }

        int estadoInclinacao = (int)robo.Cabeca.EstadoInclinacao;

        estadoInclinacao--;

        robo.Cabeca.EstadoInclinacao = (EstadoInclinacao)estadoInclinacao;

        await _context.SaveChangesAsync();
    }
}