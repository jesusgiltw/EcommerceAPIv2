using EcommerceAPI.Entities;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers;

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomersController(CustomerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> RegisterCustomer([FromBody] Customer customer)
    {
        var createdCustomer = await _service.RegisterCustomer(customer);
        return CreatedAtAction(nameof(RegisterCustomer), new { id = createdCustomer.CustomerId }, createdCustomer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(string id, [FromBody] Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return BadRequest("Customer ID in the URL does not match the ID in the body.");
        }

        await _service.UpdateCustomerAsync(customer);
        return NoContent(); // Devuelve 204 No Content si la actualización fue exitosa
    }
}