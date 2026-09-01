using MediatR;
using Domain;
using Application.Interfaces;

namespace Application.Features.Vehiculos.Commands;

public class CreateVehiculoCommandHandler : IRequestHandler<CreateVehiculoCommand, Vehiculo>
{
    private readonly IRepository<Vehiculo> _repository;

    public CreateVehiculoCommandHandler(IRepository<Vehiculo> repository)
    {
        _repository = repository; // Inyección de dependencias del repositorio
    }

    public async Task<Vehiculo> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = new Vehiculo
        {
            Modelo = request.Modelo,
            Anio = request.Anio,
            CantidadPuertas = request.CantidadPuertas,
            MarcaId = request.MarcaId
        };

        return await _repository.AddAsync(vehiculo);
    }
}