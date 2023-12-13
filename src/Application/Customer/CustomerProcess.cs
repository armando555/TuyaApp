using Domain.Customer;
using Domain.Customer.Dtos;

namespace Application.Customer;

using Domain.Customer.Repositories;
using Domain.Customer.Entities;
    
public class CustomerProcess: ICustomerProcess
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerProcess(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<int> AddCustomerAsync(Customer customer)
    {
        return await _customerRepository.AddCustomerAsync(customer);
    }

    public async Task<int> UpdateCustomerAsync(Customer customer, CustomerUpdateDto customerUpdateDto)
    {
        customer.Update(customerUpdateDto);
        
        return await _customerRepository.UpdatedCustomerAsync(customer);
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _customerRepository.GetCustomerByIdAsync(id);
    }

    public async Task<IList<Customer?>> GetCustomersAsync()
    {
        return await _customerRepository.GetCustomersAsync();
    }

    public async Task<int> DeleteCustomerASync(int id)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(id);
        if (customer is null)
        {
            return 0;
        }
        return await _customerRepository.DeleteCustomerAsync(customer);
    }
}