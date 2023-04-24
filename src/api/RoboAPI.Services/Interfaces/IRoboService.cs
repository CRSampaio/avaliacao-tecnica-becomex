using RoboAPI.Entities;

namespace RoboAPI.Services.Interfaces;

public interface IRoboService
{
    Task<Robo> RetornarSingleton();
}