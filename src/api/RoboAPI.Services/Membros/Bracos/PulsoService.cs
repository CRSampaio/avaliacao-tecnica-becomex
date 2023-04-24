using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.Services.Membros.Bracos;

public class PulsoService : IPulsoService
{
    private readonly RoboDbContext _context;

    public PulsoService(RoboDbContext context)
    {
        _context = context;
    }

    public async Task RotacionarNegativamentePulsoBracoDireito()
    {
        var robo = _context.Robos
                            .Include(x => x.BracoDireito.Pulso)
                            .Include(x => x.BracoDireito.Cotovelo)
                            .First();

        if (robo.BracoDireito.Cotovelo.EstadoCotovelo != EstadoCotovelo.FortementeContraido)
        {
            throw new Exception("Pulso só será movimentado se estiver fortemente contraido");
        }

        if (robo.BracoDireito.Pulso.EstadoPulso == EstadoPulso.Rotacao90GrausNegativo)
        {
            throw new Exception("Pulso rotacionado ao máximo negativamente");
        }

        int estadoPulso = (int) robo.BracoDireito.Pulso.EstadoPulso;

        estadoPulso--;

        robo.BracoDireito.Pulso.EstadoPulso = (EstadoPulso) estadoPulso;

        await _context.SaveChangesAsync();
    }

    public async Task RotacionarNegativamentePulsoBracoEsquerdo()
    {
        var robo = _context.Robos
                            .Include(x => x.BracoEsquerdo.Pulso)
                            .Include(x => x.BracoEsquerdo.Cotovelo)
                            .First();

        if (robo.BracoEsquerdo.Cotovelo.EstadoCotovelo != EstadoCotovelo.FortementeContraido)
        {
            throw new Exception("Pulso só será movimentado se estiver fortemente contraido");
        }

        if (robo.BracoEsquerdo.Pulso.EstadoPulso == EstadoPulso.Rotacao90GrausNegativo)
        {
            throw new Exception("Pulso rotacionado ao máximo negativamente");
        }

        int estadoPulso = (int) robo.BracoEsquerdo.Pulso.EstadoPulso;

        estadoPulso--;

        robo.BracoEsquerdo.Pulso.EstadoPulso = (EstadoPulso) estadoPulso;

        await _context.SaveChangesAsync();
    }

    public async Task RotacionarPositivamentePulsoBracoDireito()
    {
        var robo = _context.Robos
                            .Include(x => x.BracoDireito.Pulso)
                            .Include(x => x.BracoDireito.Cotovelo)
                            .First();

        if (robo.BracoDireito.Cotovelo.EstadoCotovelo != EstadoCotovelo.FortementeContraido)
        {
            throw new Exception("Pulso só será movimentado se estiver fortemente contraido");
        }

        if (robo.BracoDireito.Pulso.EstadoPulso == EstadoPulso.Rotacao180Graus)
        {
            throw new Exception("Pulso rotacionado ao máximo positivamente");
        }

        int estadoPulso = (int) robo.BracoDireito.Pulso.EstadoPulso;

        estadoPulso++;

        robo.BracoDireito.Pulso.EstadoPulso = (EstadoPulso) estadoPulso;

        await _context.SaveChangesAsync();
    }

    public async Task RotacionarPositivamentePulsoBracoEsquerdo()
    {
        var robo = _context.Robos
                            .Include(x => x.BracoEsquerdo.Pulso)
                            .Include(x => x.BracoEsquerdo.Cotovelo)
                            .First();

        if (robo.BracoEsquerdo.Cotovelo.EstadoCotovelo != EstadoCotovelo.FortementeContraido)
        {
            throw new Exception("Pulso só será movimentado se estiver fortemente contraido");
        }

        if (robo.BracoEsquerdo.Pulso.EstadoPulso == EstadoPulso.Rotacao180Graus)
        {
            throw new Exception("Pulso rotacionado ao máximo positivamente");
        }

        int estadoPulso = (int) robo.BracoEsquerdo.Pulso.EstadoPulso;

        estadoPulso++;

        robo.BracoEsquerdo.Pulso.EstadoPulso = (EstadoPulso) estadoPulso;

        await _context.SaveChangesAsync();
    }
}