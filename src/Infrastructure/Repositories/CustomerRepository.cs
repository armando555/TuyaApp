using Domain.Customer.Entities;
using Domain.Customer.Repositories;
using Infrastructure.Repositories.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository: ICustomerRepository
{
    private readonly AppDbContext _appDbContext;

    public CustomerRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> AddCustomerAsync(Customer customer)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer),"Error the entity doesn't exist");
        }
        await _appDbContext.Customer.AddAsync(customer);
        await _appDbContext.SaveChangesAsync();
        return customer.Id;
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new ArgumentNullException(nameof(id), "Error the id is negative number");
        }

        return await _appDbContext.Customer.FirstOrDefaultAsync(i => i.Id == id);
        
    }

    public async Task<IList<Customer?>> GetCustomersAsync()
    {   
        return await _appDbContext.Customer.ToListAsync();
    }

    public async Task<int> DeleteCustomerAsync(Customer customer)
    {
        _appDbContext.Customer.Remove(customer);
        return await _appDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdatedCustomerAsync(Customer customer)
    {
        _appDbContext.Entry(customer).State = EntityState.Modified; 
        return await _appDbContext.SaveChangesAsync();
    }
}