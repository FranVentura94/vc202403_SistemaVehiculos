namespace Domain;

public class Vehiculo
{
    public int Id { get; set; }
    public string Modelo { get; set; }
    public int Anio { get; set; }
    public int CantidadPuertas { get; set; }
    public int MarcaId { get; set; }
    public Marca Marca { get; set; }
    public ICollection<Venta> Ventas { get; set; }
}