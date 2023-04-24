using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;

namespace RoboAPI.Infrastructure.Persistencia;

public class RoboDbContext : DbContext
{
    public RoboDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Robo> Robos { get; set; } = null!;
    private DbSet<Braco> Bracos { get; set; } = null!;
    private DbSet<Cotovelo> Cotovelos { get; set; } = null!;
    private DbSet<Pulso> Pulsos { get; set; } = null!;
    private DbSet<Cabeca> Cabecas { get; set; } = null!;
}