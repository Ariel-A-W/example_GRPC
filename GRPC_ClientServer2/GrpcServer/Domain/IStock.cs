namespace GrpcServer.Domain;

public interface IStock
{
    public IEnumerable<Stock> GetAll();
    public Stock GetById(int id);
}
