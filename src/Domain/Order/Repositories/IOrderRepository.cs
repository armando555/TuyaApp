namespace Domain.Order.Repositories;

public interface IOrderRepository
{
    public Task<int> AddOrderAsync(Entities.Order order);
    public Task<Entities.Order?> GetOrderByIdAsync(int id);
    public Task<IList<Entities.Order?>> GetOrdersAsync();
    public Task<int> DeleteOrderAsync(Entities.Order order);
    public Task<int> UpdatedOrderAsync(Entities.Order order);
}
