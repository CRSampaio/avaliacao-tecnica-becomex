using Microsoft.AspNetCore.Mvc;
using RoboAPI.Entities;
using RoboAPI.Services.Interfaces;
using RoboAPI.Services.Membros.Bracos.Interfaces;

namespace RoboAPI.WebAPI.Controllers.Bracos.Direito;

[ApiController]
[Route("Robo/Braco/Direito/Cotovelo/[action]")]
public class CotoveloDireitoController : ControllerBase
{
    private readonly ICotoveloService _bracoService;
    private readonly IRoboService _roboService;

    public CotoveloDireitoController(ICotoveloService bracoService, IRoboService roboService)
    {
        _bracoService = bracoService;
        _roboService = roboService;
    }

    [HttpGet]
    public async Task<ActionResult<Cotovelo>> StatusAsync()
    {
        var cotoveloEsquerdo = await _roboService.RetornarSingleton();

        return await Task.FromResult(Ok(cotoveloEsquerdo.BracoDireito.Cotovelo));
    }

    [HttpPost]
    public async Task<IActionResult> ContrairAsync()
    {
        await _bracoService.ContrairCotoveloBracoDireito();

        return await Task.FromResult(Ok());
    }

    [HttpPost]
    public async Task<IActionResult> RelaxarAsync()
    {
        await _bracoService.RelaxarCotoveloBracoDireito();

        return await Task.FromResult(Ok());
    }
}