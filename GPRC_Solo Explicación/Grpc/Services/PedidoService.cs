using Grpc.Core;

namespace Grpc.Services;
using Grpc.Protos;

public class PedidoService : Pedido.PedidoBase
{
    public override Task<PedidoResponse> GetPedido(PedidoRequest request, ServerCallContext context)
    {
        var response = new PedidoResponse
        {
            PedidoId = request.PedidoId,
            Descripcion = "Orden de Pedido",
            Precio = 100.50f
        };

        return Task.FromResult(response);
    }
}
