using Domain.Order.Dtos;

namespace Domain.Order;
using Entities;

public interface IOrderProcess
{
    public Task<int> AddOrderAsync(Order order);

    public Task<int> UpdateOrderAsync(Order order, OrderUpdateDto orderUpdateDto);

    public Task<Order?> GetOrderByIdAsync(int id);

    public Task<IList<Order?>> GetOrdersAsync();

    public Task<int> DeleteOrderASync(int id);
}