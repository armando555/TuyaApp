using Domain.Order.Entities;
using Domain.Order.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> AddOrderAsync(Order order)
    {
        if (order is null)
        {
            throw new ArgumentNullException(nameof(order),"Error the entity doesn't exist");
        }
        await _appDbContext.Order.AddAsync(order);
        await _appDbContext.SaveChangesAsync();
        return order.Id;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentNullException(nameof(id), "Error the id is negative number");
        }

        return await _appDbContext.Order.FirstOrDefaultAsync(i => i.Id == id);
        
    }

    public async Task<IList<Order?>> GetOrderAsync()
    {   
        return await _appDbContext.Order.ToListAsync();
    }

    public async Task<int> DeleteOrderAsync(Order order)
    {
        _appDbContext.Order.Remove(order);
        return await _appDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdatedOrderAsync(Order order)
    {
        _appDbContext.Entry(order).State = EntityState.Modified; 
        return await _appDbContext.SaveChangesAsync();
    }

    public async Task<IList<Order?>> GetOrdersAsync()
    {
        return await _appDbContext.Order.ToListAsync();
    }
}