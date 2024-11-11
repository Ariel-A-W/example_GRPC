using Grpc.Net.Client;
using GrpcServer.Protos;

class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5010");

        var client = new Pedido.PedidoClient(channel);        

        var replay = client.GetPedidoAsync(new PedidoRequest() { PedidoId = 1 });

        Console.WriteLine("Ordenes Procesadas");
        Console.WriteLine("");
        Console.WriteLine($"Orden: {replay.PedidoId}, {replay.Descripcion}, $ {replay.Precio}");
        Console.WriteLine("");
        Console.WriteLine("Presionar Enter para Cerrar la Consulta.");
        Console.ReadLine();
    }
}

