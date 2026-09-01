using MediatR;
using Domain;

namespace Application.Features.Vehiculos.Commands;

public class CreateVehiculoCommand : IRequest<Vehiculo>
{
    public string Modelo { get; set; }
    public int Anio { get; set; }
    public int CantidadPuertas { get; set; }
    public int MarcaId { get; set; }
}