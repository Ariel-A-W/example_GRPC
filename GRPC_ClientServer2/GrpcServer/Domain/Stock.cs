namespace GrpcServer.Domain;

public class Stock
{
    public int Id { get; set; }
    public string? Producto { get; set; }
    public int Cantidad { get; set; }
    public float Precio { get; set; }
}
