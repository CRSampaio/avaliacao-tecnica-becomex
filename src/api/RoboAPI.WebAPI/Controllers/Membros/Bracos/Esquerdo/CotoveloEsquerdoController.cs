using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboAPI.Entities;
using RoboAPI.Infrastructure.Persistencia;
using RoboAPI.Services.Interfaces;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.WebAPI.Controllers.Bracos.Esquerdo;

[Route("Robo/Braco/Esquerdo/Cotovelo/[action]")]
[ApiController]
public class CotoveloEsquerdoController : ControllerBase
{
    private readonly ICotoveloService _bracoService;
    private readonly IRoboService _roboService;

    public CotoveloEsquerdoController(ICotoveloService bracoService, IRoboService roboService)
    {
        _bracoService = bracoService;
        _roboService = roboService;
    }

    [HttpGet]
    public async Task<ActionResult<Cotovelo>> StatusAsync()
    {
        var cotoveloEsquerdo = await _roboService.RetornarSingleton();

        return await Task.FromResult(Ok(cotoveloEsquerdo.BracoEsquerdo.Cotovelo));
    }

    [HttpPost]
    public async Task<IActionResult> ContrairAsync()
    {
        await _bracoService.ContrairCotoveloBracoEsquerdo();

        return await Task.FromResult(Ok());
    }

    [HttpPost]
    public async Task<IActionResult> RelaxarAsync()
    {
        await _bracoService.RelaxarCotoveloBracoEsquerdo();

        return await Task.FromResult(Ok());
    }
}
