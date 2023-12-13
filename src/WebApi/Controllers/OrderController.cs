using Domain.Order;
using Domain.Order.Dtos;
using Domain.Order.Entities;
using Domain.Customer;
namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrderController: ControllerBase
{
    private readonly IOrderProcess _orderProcess;
    private readonly ICustomerProcess _customerProcess;
    private readonly ILogger<OrderController> _logger;
    public OrderController(ILogger<OrderController> iLogger, IOrderProcess orderProcess, ICustomerProcess customerProcess)
    {
        _orderProcess = orderProcess;
        _logger = iLogger;
        _customerProcess = customerProcess;
    }

    [HttpGet]
    public async Task<IEnumerable<Order?>> Get() => await _orderProcess.GetOrdersAsync();
    
    [HttpGet("id")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var hiker = await _orderProcess.GetOrderByIdAsync(id);
        return hiker == null ? NotFound() : Ok(hiker);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Order), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(OrderDto hiker)
    {
        var id = await _orderProcess.AddOrderAsync(Order.FromOrderDtoToOrder(hiker));
        return CreatedAtAction(nameof(GetById), new { id}, id);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update(OrderUpdateDto hikerUpdateDto,int id)
    {
        var hiker = await _orderProcess.GetOrderByIdAsync(id);
        if (hiker is null)
        {
            return NotFound();
        }
        await _orderProcess.UpdateOrderAsync(hiker,hikerUpdateDto);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderProcess.DeleteOrderASync(id);
        return NoContent();
    }
}