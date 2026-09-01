using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Vehiculos.Commands;

namespace CRUD_de_Vehiculos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculosController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiculosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Endpoint de prueba GET para ver estado desde el navegador o Swagger
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Mensaje = "API de Vehículos lista para procesar peticiones" });
    }

    // Endpoint POST mapeado a MediatR
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehiculoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}