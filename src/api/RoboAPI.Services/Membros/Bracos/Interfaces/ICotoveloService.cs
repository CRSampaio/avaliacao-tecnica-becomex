using RoboAPI.Entities;

namespace RoboAPI.Services.Membros.Bracos.Interfaces;

public interface ICotoveloService
{
    Task ContrairCotoveloBracoDireito();

    Task ContrairCotoveloBracoEsquerdo();

    Task RelaxarCotoveloBracoDireito();

    Task RelaxarCotoveloBracoEsquerdo();
}