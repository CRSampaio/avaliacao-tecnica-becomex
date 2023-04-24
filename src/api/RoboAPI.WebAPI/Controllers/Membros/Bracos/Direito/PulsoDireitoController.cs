using Microsoft.AspNetCore.Mvc;
using RoboAPI.Entities;
using RoboAPI.Services.Interfaces;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.WebAPI.Controllers.Bracos.Direito;

[ApiController]
[Route("Robo/Braco/Direito/Pulso/[action]")]
public class PulsoDireitoController : ControllerBase
{
    private readonly IPulsoService _pulsoService;
    private readonly IRoboService _roboService;

    public PulsoDireitoController(IRoboService context, IPulsoService pulsoService)
    {
        _roboService = context;
        _pulsoService = pulsoService;
    }

    [HttpGet]
    public async Task<ActionResult<Pulso>> StatusAsync()
    {
        var pulso = await _roboService.RetornarSingleton();

        return await Task.FromResult(Ok(pulso.BracoDireito.Pulso));
    }

    [HttpPost]
    public async Task<IActionResult> RotacionarPositivoAsync()
    {
        await _pulsoService.RotacionarPositivamentePulsoBracoDireito();

        return await Task.FromResult(Ok());
    }

    [HttpPost]
    public async Task<IActionResult> RotacionarNegativoAsync()
    {
        await _pulsoService.RotacionarNegativamentePulsoBracoDireito();

        return await Task.FromResult(Ok());
    }
}