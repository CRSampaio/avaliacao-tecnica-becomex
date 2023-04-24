using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Membros;
using RoboAPI.Services.Membros.Interfaces;

namespace RoboAPI.Services.Tests.Membros;

[TestFixture]
public class CabecaServiceTests
{
    private RoboDbContext _context = null!;
    private DbContextOptions<RoboDbContext> _options = null!;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<RoboDbContext>()
            .UseInMemoryDatabase(databaseName: "CabecaServiceTest")
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
    public async Task AbaixarCabecaQuandoJaEstaPraBaixoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().Cabeca.EstadoInclinacao = EstadoInclinacao.PraBaixo;
        await _context.SaveChangesAsync();

        ICabecaService cabecaService = new CabecaService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await cabecaService.Abaixar());
    }

    [Test]
    public async Task SubirCabecaQuandoJaEstaPraCimaDeveLancarException()
    {
        // Arrange
        _context.Robos.First().Cabeca.EstadoInclinacao = EstadoInclinacao.PraCima;
        await _context.SaveChangesAsync();

        ICabecaService cabecaService = new CabecaService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await cabecaService.Subir());
    }

    [Test]
    public async Task RotacionarPositivoQuandoInclinacaoCabecaEstaPraBaixoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().Cabeca.EstadoInclinacao = EstadoInclinacao.PraBaixo;
        await _context.SaveChangesAsync();

        ICabecaService cabecaService = new CabecaService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await cabecaService.RotacionarPositivo());
    }

    [Test]
    public async Task RotacionarNegativoQuandoInclinacaoCabecaEstaPraBaixoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().Cabeca.EstadoInclinacao = EstadoInclinacao.PraBaixo;
        await _context.SaveChangesAsync();

        ICabecaService cabecaService = new CabecaService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await cabecaService.RotacionarNegativo());
    }

    [Test]
    public async Task RotacionarPositivoQuandoRotacaoCabecaEsta90GrausPositivoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().Cabeca.EstadoRotacao = EstadoRotacao.Rotacao90Graus;
        await _context.SaveChangesAsync();

        ICabecaService cabecaService = new CabecaService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await cabecaService.RotacionarPositivo());
    }

    [Test]
    public async Task RotacionarNegativoQuandoRotacaoCabecaEsta90GrausNegativoDeveLancarException()
    {
        // Arrange
        _context.Robos.First().Cabeca.EstadoRotacao = EstadoRotacao.Rotacao90GrausNegativo;
        await _context.SaveChangesAsync();

        ICabecaService cabecaService = new CabecaService(_context);

        // Act / Assert
        Assert.ThrowsAsync<Exception>(async () => await cabecaService.RotacionarNegativo());
    }
}