using GrpcServer.Domain;

namespace GrpcServer.Application;

public class UseCaseApplication
{
    private readonly IStock _stock;

    public UseCaseApplication(IStock stock)
    {
        _stock = stock;
    }

    public async Task<IEnumerable<Stock>> GetAll()
    { 
        return await Task.FromResult(_stock.GetAll());    
    }

    public async Task<Stock> GetById(int id)
    {
        return await Task.FromResult(_stock.GetById(id));
    }
}
