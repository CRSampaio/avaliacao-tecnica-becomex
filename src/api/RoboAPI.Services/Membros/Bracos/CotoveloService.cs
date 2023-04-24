using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.Services.Membros.Bracos;

public class CotoveloService : ICotoveloService
{
    private readonly RoboDbContext _context;

    public CotoveloService(RoboDbContext context)
    {
        _context = context;
    }

    public async Task ContrairCotoveloBracoDireito()
    {
        var robo = _context.Robos
                                .Include(x => x.BracoDireito)
                                    .ThenInclude(x => x.Cotovelo)
                                .Include(x => x.BracoDireito)
                                    .ThenInclude(x => x.Pulso)
                                .Include(x => x.Cabeca)
                                .First();

        if (robo.BracoDireito.Cotovelo.EstadoCotovelo == EstadoCotovelo.FortementeContraido)
        {
            throw new Exception("Cotovelo direito contraido ao maximo");
        }

        int estadoCotovelo = (int) robo.BracoDireito.Cotovelo.EstadoCotovelo;

        estadoCotovelo++;

        robo.BracoDireito.Cotovelo.EstadoCotovelo = (EstadoCotovelo) estadoCotovelo;

        await _context.SaveChangesAsync();
    }

    public async Task ContrairCotoveloBracoEsquerdo()
    {
        var robo = _context.Robos
                                .Include(x => x.BracoEsquerdo)
                                    .ThenInclude(x => x.Cotovelo)
                                .Include(x => x.BracoEsquerdo)
                                    .ThenInclude(x => x.Pulso)
                                .Include(x => x.BracoEsquerdo)
                                    .ThenInclude(x => x.Cotovelo)
                                .First();

        if (robo.BracoEsquerdo.Cotovelo.EstadoCotovelo == EstadoCotovelo.FortementeContraido)
        {
            throw new Exception("Cotovelo esquerdo contraido ao maximo");
        }

        int estadoCotovelo = (int) robo.BracoEsquerdo.Cotovelo.EstadoCotovelo;

        estadoCotovelo++;

        robo.BracoEsquerdo.Cotovelo.EstadoCotovelo = (EstadoCotovelo) estadoCotovelo;

        await _context.SaveChangesAsync();
    }

    public async Task RelaxarCotoveloBracoDireito()
    {
        var robo = _context.Robos
                                .Include(x => x.BracoDireito)
                                    .ThenInclude(x => x.Cotovelo)
                                .Include(x => x.BracoDireito)
                                    .ThenInclude(x => x.Pulso)
                                .First();

        if (robo.BracoDireito.Cotovelo.EstadoCotovelo == EstadoCotovelo.EmRepouso)
        {
            throw new Exception("Cotovelo direito relaxado ao maximo");
        }

        int estadoCotovelo = (int) robo.BracoDireito.Cotovelo.EstadoCotovelo;

        estadoCotovelo--;

        robo.BracoDireito.Cotovelo.EstadoCotovelo = (EstadoCotovelo) estadoCotovelo;

        await _context.SaveChangesAsync();
    }

    public async Task RelaxarCotoveloBracoEsquerdo()
    {
        var robo = _context.Robos
                                .Include(x => x.BracoEsquerdo)
                                    .ThenInclude(x => x.Cotovelo)
                                .Include(x => x.BracoEsquerdo)
                                    .ThenInclude(x => x.Pulso)
                                .First();

        if (robo.BracoEsquerdo.Cotovelo.EstadoCotovelo == EstadoCotovelo.EmRepouso)
        {
            throw new Exception("Cotovelo esquerdo relaxado ao maximo");
        }

        int estadoCotovelo = (int) robo.BracoEsquerdo.Cotovelo.EstadoCotovelo;

        estadoCotovelo--;

        robo.BracoEsquerdo.Cotovelo.EstadoCotovelo = (EstadoCotovelo) estadoCotovelo;

        await _context.SaveChangesAsync();
    }
}