using Domain.Common;
using Domain.Order.Dtos;
using Domain.Customer.Entities;


namespace Domain.Order.Entities;

public class Order: BaseAuditableEntity
{
    public string ProductName { get;set; } = null!;
    public int Quantity { get;set; } = 0!;

    public double Price { get;set; } = 0!;

    public Customer.Entities.Customer Customer { get;set; }
    
    public static Order FromOrderDtoToOrder(OrderDto orderDto)
    {
        return new Order
        {
            ProductName = orderDto.ProductName,
            Quantity = orderDto.Quantity,
            Price = orderDto.Price,
            Customer = orderDto.Customer,
        };
    }

    public void Update(OrderUpdateDto orderUpdateDto)
    {
        ProductName = orderUpdateDto.ProductName;
        Quantity = orderUpdateDto.Quantity;
        Price = orderUpdateDto.Price;
        Customer = orderUpdateDto.Customer;
        LastModified = DateTime.Now;
    }
}
