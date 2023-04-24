using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Membros.Bracos;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.Services.Tests.Membros.Bracos;

[TestFixture]
public class PulsoServiceTests
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
    public async Task RotacionarPulsoBracoDireitoNegativamenteQuandoEsta90GrausNegativoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoDireito.Pulso.EstadoPulso = EstadoPulso.Rotacao90GrausNegativo;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarNegativamentePulsoBracoDireito());
    }

    [Test]
    public async Task RotacionarPulsoBracoEsquerdoNegativamenteQuandoEsta90GrausNegativoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoEsquerdo.Pulso.EstadoPulso = EstadoPulso.Rotacao90GrausNegativo;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarNegativamentePulsoBracoEsquerdo());
    }

    [Test]
    public async Task RotacionarPulsoBracoDireitoPostivamenteQuandoEsta90GrausNegativoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoDireito.Pulso.EstadoPulso = EstadoPulso.Rotacao90Graus;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarPositivamentePulsoBracoDireito());
    }

    [Test]
    public async Task RotacionarPulsoBracoEsquerdoPostivamenteQuandoEsta90GrausNegativoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoEsquerdo.Pulso.EstadoPulso = EstadoPulso.Rotacao90Graus;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarPositivamentePulsoBracoEsquerdo());
    }

    [Test]
    public async Task RotacionarPulsoNegativamenteBracoEsquerdoSemCotoveloFortementeContraidoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoEsquerdo.Cotovelo.EstadoCotovelo = EstadoCotovelo.EmRepouso;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarNegativamentePulsoBracoEsquerdo());
    }

    [Test]
    public async Task RotacionarPulsoNegativamenteBracoDireitoSemCotoveloFortementeContraidoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoDireito.Cotovelo.EstadoCotovelo = EstadoCotovelo.EmRepouso;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarNegativamentePulsoBracoDireito());
    }

    [Test]
    public async Task RotacionarPulsoPositivamenteBracoEsquerdoSemCotoveloFortementeContraidoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoEsquerdo.Cotovelo.EstadoCotovelo = EstadoCotovelo.EmRepouso;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarPositivamentePulsoBracoEsquerdo());
    }

    [Test]
    public async Task RotacionarPulsoPositivamenteBracoDireitoSemCotoveloFortementeContraidoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().BracoDireito.Cotovelo.EstadoCotovelo = EstadoCotovelo.EmRepouso;
        await _context.SaveChangesAsync();

        IPulsoService bracoService = new PulsoService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await bracoService.RotacionarPositivamentePulsoBracoDireito());
    }
}