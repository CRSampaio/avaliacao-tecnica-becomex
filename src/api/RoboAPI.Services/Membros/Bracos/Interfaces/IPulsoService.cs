namespace RoboAPI.Services.Membros.Bracos.Interfaces;

public interface IPulsoService
{
    Task RotacionarPositivamentePulsoBracoDireito();

    Task RotacionarPositivamentePulsoBracoEsquerdo();

    Task RotacionarNegativamentePulsoBracoDireito();

    Task RotacionarNegativamentePulsoBracoEsquerdo();
    
}