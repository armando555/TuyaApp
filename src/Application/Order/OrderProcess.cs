using Domain.Order;
using Domain.Order.Dtos;

namespace Application.Order;

using Domain.Order.Repositories;
using Domain.Order.Entities;
    
public class OrderProcess: IOrderProcess
{
    private readonly IOrderRepository _orderRepository;
    public OrderProcess(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<int> AddOrderAsync(Order order)
    {
        return await _orderRepository.AddOrderAsync(order);
    }

    public async Task<int> UpdateOrderAsync(Order order, OrderUpdateDto orderUpdateDto)
    {
        order.Update(orderUpdateDto);
        
        return await _orderRepository.UpdatedOrderAsync(order);
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetOrderByIdAsync(id);
    }

    public async Task<IList<Order?>> GetOrdersAsync()
    {
        return await _orderRepository.GetOrdersAsync();
    }

    public async Task<int> DeleteOrderASync(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        if (order is null)
        {
            return 0;
        }
        return await _orderRepository.DeleteOrderAsync(order);
    }
}