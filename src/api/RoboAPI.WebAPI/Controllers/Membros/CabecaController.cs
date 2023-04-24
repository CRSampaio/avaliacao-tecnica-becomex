using Microsoft.AspNetCore.Mvc;
using RoboAPI.Entities;
using RoboAPI.Services.Interfaces;
using RoboAPI.Services.Membros.Interfaces;

namespace RoboAPI.WebAPI.Controllers.Membros;

[Route("Robo/[controller]/[action]")]
[ApiController]
public class CabecaController : ControllerBase
{
    private readonly IRoboService _roboService;
    private readonly ICabecaService _cabecaService;

    public CabecaController(IRoboService roboService, ICabecaService cabecaService)
    {
        _roboService = roboService;
        _cabecaService = cabecaService;
    }

    [HttpGet]
    public async Task<ActionResult<EstadoRotacao>> StatusRotacao()
    {
        var estadoRotacao = await _roboService.RetornarSingleton();

        return await Task.FromResult(Ok(estadoRotacao.Cabeca.EstadoRotacao));
    }

    [HttpGet]
    public async Task<ActionResult<EstadoInclinacao>> StatusInclinacao()
    {
        var estadoInclinacao = await _roboService.RetornarSingleton();

        return await Task.FromResult(Ok(estadoInclinacao.Cabeca.EstadoInclinacao));
    }

    [HttpGet]
    public async Task<ActionResult<Cabeca>> StatusAsync()
    {
        var cabeca = await _roboService.RetornarSingleton();

        return await Task.FromResult(Ok(cabeca.Cabeca));
    }

    [HttpPost]
    public async Task<IActionResult> AbaixarAsync()
    {
        await _cabecaService.Abaixar();

        return await Task.FromResult(Ok());
    }

    [HttpPost]
    public async Task<IActionResult> SubirAsync()
    {
        await _cabecaService.Subir();

        return await Task.FromResult(Ok());
    }

    [HttpPost]
    public async Task<IActionResult> RotacionarPositivoAsync()
    {
        await _cabecaService.RotacionarPositivo();

        return await Task.FromResult(Ok());
    }

    [HttpPost]
    public async Task<IActionResult> RotacionarNegativoAsync()
    {
        await _cabecaService.RotacionarNegativo();

        return await Task.FromResult(Ok());
    }
}