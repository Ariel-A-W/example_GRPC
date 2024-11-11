using Grpc.Core;
using GrpcServer.Application;
using GrpcServer.Protos;

namespace GrpcServer.Services;

public class StockService : Stocker.StockerBase
{
    private readonly UseCaseApplication _app;

    public StockService(UseCaseApplication app)
    {
        _app = app;
    }

    public override async Task<StockAllResponse> GetAllAsync(
        EmptyParams request,
        ServerCallContext context)
    {
        var lstStock = await _app.GetAll();
        var response = new StockAllResponse(); 
        response.Stocks.AddRange(lstStock.Select(s => new StockResponse() 
        { 
            Id = s.Id,
            Producto = s.Producto,
            Cantidad = s.Cantidad,
            Precio = s.Precio,
        }));
        return await Task.FromResult(response);
    }

    public override async Task<StockResponse> GetByIdAsync(
        StockByIdRequest request, 
        ServerCallContext context
    )
    { 
        var stock = await _app.GetById(request.Id);
        
        if (stock == null)
            throw new RpcException(
                new Status(StatusCode.NotFound, "Producto no existente."));

        return await Task.FromResult(
            new StockResponse()
            { 
                Id = stock.Id, 
                Producto = stock.Producto,
                Cantidad = stock.Cantidad,
                Precio = stock.Precio,
            }
        );
    }
}