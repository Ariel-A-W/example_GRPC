using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.Services;

public class PedidoService : Pedido.PedidoBase
{
    public override Task<PedidoResponse> GetPedidoAsync(PedidoRequest request, ServerCallContext context)
    {
        var response = new PedidoResponse
        {
            PedidoId = request.PedidoId,
            Descripcion = "Carga N°: RF2345-56RS",
            Precio = 14500.50f
        };

        return Task.FromResult(response);
    }
}
