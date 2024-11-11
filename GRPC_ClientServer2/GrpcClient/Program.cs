using Grpc.Net.Client;
using GrpcServer.Protos;

class Program
{
    static void Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5149");

        var client = new Stocker.StockerClient(channel);

        var lstStock = client.GetAllAsync(new EmptyParams());

        Console.WriteLine("Listado del Stock");
        Console.WriteLine("");        
        foreach (var item in lstStock.Stocks)
        {
            Console.WriteLine(
                $"ID: {item.Id} Producto: {item.Producto} " +
                $"Cantidad: {item.Cantidad} Precio: {item.Precio}"
            );
        }
        Console.WriteLine("");
        Console.WriteLine("Consultando unos Productos.");
        
        var stk1 = client.GetByIdAsync(new StockByIdRequest() { Id = 1 });
        var stk2 = client.GetByIdAsync(new StockByIdRequest() { Id = 3 });

        Console.WriteLine("Consulta Producto ID=1");
        Console.WriteLine(
            $"ID: {stk1.Id} Producto: {stk1.Producto} " +
            $"Cantidad: {stk1.Cantidad} Precio: {stk1.Precio}"
        );
        Console.WriteLine("");
        Console.WriteLine("Consulta Producto ID=3");
        Console.WriteLine(
            $"ID: {stk2.Id} Producto: {stk2.Producto} " +
            $"Cantidad: {stk2.Cantidad} Precio: {stk2.Precio}"
        );
        Console.WriteLine("");
        Console.WriteLine("Presionar <Enter> para salir.");
        Console.ReadLine();                
    }
}
