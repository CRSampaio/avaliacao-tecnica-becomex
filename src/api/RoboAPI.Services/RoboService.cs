using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Interfaces;

namespace RoboAPI.Services;

public class RoboService : IRoboService
{
    private readonly RoboDbContext _context;

    public RoboService(RoboDbContext context)
    {
        _context = context;
    }

    public async Task<Robo> RetornarSingleton()
    {
        return await _context.Robos
                        .Include(x => x.BracoDireito)
                            .ThenInclude(x => x.Cotovelo)
                        .Include(x => x.BracoDireito)
                            .ThenInclude(x => x.Pulso)
                        .Include(x => x.BracoEsquerdo)
                            .ThenInclude(x => x.Cotovelo)
                        .Include(x => x.BracoEsquerdo)
                            .ThenInclude(x => x.Pulso)
                        .Include(x => x.Cabeca)
                        .FirstAsync();
    }
}