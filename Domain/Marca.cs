namespace Domain;

public class Marca
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Vehiculo> Vehiculos { get; set; }
}