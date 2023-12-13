using Domain.Common;
using Domain.Customer.Dtos;

namespace Domain.Customer.Entities;

public class Customer: BaseAuditableEntity
{
    public string Name { get;set; } = null!;
    
    public static Customer FromCustomerDtoToCustomer(CustomerDto customerDto)
    {
        return new Customer
        {
            Name = customerDto.Name,
        };
    }

    public void Update(CustomerUpdateDto customerUpdateDto)
    {
        Name = customerUpdateDto.Name;
        LastModified = DateTime.Now;
    }
}
