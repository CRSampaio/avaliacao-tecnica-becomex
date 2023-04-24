using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Membros.Bracos;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.Services.Tests.Membros.Bracos;

[TestFixture]
public class CotoveloServiceTests
{
    private RoboDbContext _context = null!;

    [SetUp]
    public void Setup()
    {
        var _options = new DbContextOptionsBuilder<RoboDbContext>()
            .UseInMemoryDatabase(databaseName: "PulsoServiceTests")
            .Options;

        _context = new RoboDbContext(_options);
        _context.Database.EnsureDeleted();

        _context.Robos.Add(new Robo(
                       new Braco(new Cotovelo(EstadoCotovelo.EmRepouso), new Pulso(EstadoPulso.Repouso)),
                       new Braco(new Cotovelo(EstadoCotovelo.EmRepouso), new Pulso(EstadoPulso.Repouso)),
                       new Cabeca(EstadoInclinacao.Repouso, EstadoRotacao.Repouso)));

        _context.SaveChanges();
    }

    [TearDown]
    public void Teardown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task RelaxarCotoveloBracoDireitoQuandoEstaEmRepousoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoDireito.Cotovelo.EstadoCotovelo = EstadoCotovelo.EmRepouso;
        await _context.SaveChangesAsync();

        ICotoveloService bracoService = new CotoveloService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RelaxarCotoveloBracoDireito());
    }

    [Test]
    public async Task RelaxarCotoveloBracoEsquerdoQuandoEstaEmRepousoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoEsquerdo.Cotovelo.EstadoCotovelo = EstadoCotovelo.EmRepouso;
        await _context.SaveChangesAsync();

        ICotoveloService bracoService = new CotoveloService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RelaxarCotoveloBracoEsquerdo());
    }

    [Test]
    public async Task ContrairCotoveloBracoEsquerdoQuandoEstaFortementeContraidoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoEsquerdo.Cotovelo.EstadoCotovelo = EstadoCotovelo.FortementeContraido;
        await _context.SaveChangesAsync();

        ICotoveloService bracoService = new CotoveloService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.ContrairCotoveloBracoEsquerdo());
    }

    [Test]
    public async Task ContrairCotoveloBracoDireitoQuandoEstaFortementeContraidoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoDireito.Cotovelo.EstadoCotovelo = EstadoCotovelo.FortementeContraido;
        await _context.SaveChangesAsync();

        ICotoveloService bracoService = new CotoveloService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.ContrairCotoveloBracoDireito());
    }
}