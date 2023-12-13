namespace Domain.Customer.Repositories;

public interface ICustomerRepository
{
    public Task<int> AddCustomerAsync(Entities.Customer customer);
    public Task<Entities.Customer?> GetCustomerByIdAsync(int id);
    public Task<IList<Entities.Customer?>> GetCustomersAsync();
    public Task<int> DeleteCustomerAsync(Entities.Customer customer);
    public Task<int> UpdatedCustomerAsync(Entities.Customer customer);
}
