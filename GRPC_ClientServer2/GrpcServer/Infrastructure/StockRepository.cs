using GrpcServer.Domain;

namespace GrpcServer.Infrastructure;

public class StockRepository : IStock
{
    private readonly List<Stock> _stocks = new List<Stock>() 
    {
        new Stock()
        { 
           Id = 1, 
           Producto = "Balde Plástico",
           Cantidad = 150, 
           Precio = 45.67F
        },
        new Stock()
        {
           Id = 2,
           Producto = "Escoba",
           Cantidad = 180,
           Precio = 32.83F
        },
        new Stock()
        {
           Id = 3,
           Producto = "Trapo de Piso",
           Cantidad = 214,
           Precio = 8.39F
        },
    }; 

    public IEnumerable<Stock> GetAll()
    {
        return _stocks.ToList();
    }

    public Stock GetById(int id)
    {
        return _stocks.FirstOrDefault(s => s.Id == id)!; 
    }
}
