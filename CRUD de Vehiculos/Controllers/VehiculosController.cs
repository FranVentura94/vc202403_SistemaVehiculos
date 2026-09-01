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
        _mediator = mediator; // Solo inyectamos MediatR, no el repositorio directamente
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVehiculoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}