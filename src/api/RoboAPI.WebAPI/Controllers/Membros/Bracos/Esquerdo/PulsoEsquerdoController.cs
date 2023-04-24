using Microsoft.AspNetCore.Mvc;
using RoboAPI.Entities;
using RoboAPI.Services.Interfaces;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.WebAPI.Controllers.Bracos.Esquerdo;

[ApiController]
[Route("Robo/Braco/Esquerdo/Pulso/[action]")]
public class PulsoEsquerdoController : ControllerBase
{
    private readonly IPulsoService _pulsoService;
    private readonly IRoboService _roboService;

    public PulsoEsquerdoController(IRoboService context, IPulsoService pulsoService)
    {
        _roboService = context;
        _pulsoService = pulsoService;
    }

    [HttpGet]
    public async Task<ActionResult<Pulso>> StatusAsync()
    {
        var pulso = await _roboService.RetornarSingleton();

        return await Task.FromResult(Ok(pulso.BracoEsquerdo.Pulso));
    }

    [HttpPost]
    public async Task<IActionResult> RotacionarPositivoAsync()
    {
        await _pulsoService.RotacionarPositivamentePulsoBracoEsquerdo();

        return await Task.FromResult(Ok());
    }

    [HttpPost]
    public async Task<IActionResult> RotacionarNegativoAsync()
    {
        await _pulsoService.RotacionarNegativamentePulsoBracoEsquerdo();

        return await Task.FromResult(Ok());
    }
}