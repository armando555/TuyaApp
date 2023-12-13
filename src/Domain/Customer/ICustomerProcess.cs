using Domain.Customer.Dtos;

namespace Domain.Customer;
using Entities;

public interface ICustomerProcess
{
    public Task<int> AddCustomerAsync(Customer customer);

    public Task<int> UpdateCustomerAsync(Customer customer, CustomerUpdateDto customerUpdateDto);

    public Task<Customer?> GetCustomerByIdAsync(int id);

    public Task<IList<Customer?>> GetCustomersAsync();

    public Task<int> DeleteCustomerASync(int id);
}