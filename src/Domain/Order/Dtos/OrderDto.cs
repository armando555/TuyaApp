using Domain.Customer.Entities;

namespace Domain.Order.Dtos;

public class OrderDto
{
    public string ProductName { get;set; }

    public int Quantity { get;set; }

    public double Price { get;set; } 

    public Customer.Entities.Customer Customer { get;set; }
    
}