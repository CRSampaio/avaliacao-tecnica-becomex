using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Interfaces;

namespace RoboAPI.Services.Tests;

[TestFixture]
public class RoboServiceTests
{
    private RoboDbContext _context = null!;

    [SetUp]
    public void Setup()
    {
        var _options = new DbContextOptionsBuilder<RoboDbContext>()
            .UseInMemoryDatabase(databaseName: "RoboServiceTests")
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
    public async Task RoboSingletonNaoDeveSerNulo()
    {
        // Arrange
        IRoboService roboService = new RoboService(_context);

        // Act
        Robo robo = await roboService.RetornarSingleton();

        // Assert
        Assert.That(robo, Is.Not.Null);

        _context.Dispose();
    }
}