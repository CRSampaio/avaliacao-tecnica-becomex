using Microsoft.AspNetCore.Mvc;
using RoboAPI.Entities;
using RoboAPI.Services.Interfaces;

namespace RoboAPI.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RoboController : ControllerBase
{
    private readonly IRoboService _roboService;

    public RoboController(IRoboService roboService)
    {
        _roboService = roboService;
    }

    [HttpGet]
    public async Task<ActionResult<Robo>> Statusasync()
    {
        return await _roboService.RetornarSingleton();
    }
}
