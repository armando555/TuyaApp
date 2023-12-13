using Domain.Customer;
using Domain.Customer.Dtos;
using Domain.Customer.Entities;

namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CustomerController: ControllerBase
{
    private readonly ICustomerProcess _customerProcess;
    private readonly ILogger<CustomerController> _logger;
    public CustomerController(ILogger<CustomerController> iLogger, ICustomerProcess customerProcess)
    {
        _customerProcess = customerProcess;
        _logger = iLogger;
    }

    [HttpGet]
    public async Task<IEnumerable<Customer?>> Get() => await _customerProcess.GetCustomersAsync();
    
    [HttpGet("id")]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _customerProcess.GetCustomerByIdAsync(id);
        return customer == null ? NotFound() : Ok(customer);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CustomerDto customer)
    {
        var id = await _customerProcess.AddCustomerAsync(Customer.FromCustomerDtoToCustomer(customer));
        return CreatedAtAction(nameof(GetById), new { id}, id);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> Update(CustomerUpdateDto customerUpdateDto,int id)
    {
        var customer = await _customerProcess.GetCustomerByIdAsync(id);
        if (customer is null)
        {
            return NotFound();
        }
        await _customerProcess.UpdateCustomerAsync(customer,customerUpdateDto);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await _customerProcess.DeleteCustomerASync(id);
        return NoContent();
    }
}