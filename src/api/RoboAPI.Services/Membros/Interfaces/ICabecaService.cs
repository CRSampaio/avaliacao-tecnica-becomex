namespace RoboAPI.Services.Membros.Interfaces;

public interface ICabecaService
{
    Task Abaixar();

    Task Subir();

    Task RotacionarPositivo();

    Task RotacionarNegativo();
}