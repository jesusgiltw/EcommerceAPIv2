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
        #region Validation
        if (customer == null)
            return BadRequest("Customer data is required.");
        if (string.IsNullOrWhiteSpace(customer.CustomerUniqueId))
            return BadRequest("CustomerUniqueId is required.");
        if (customer.CustomerZipCodePrefix <= 0)
            return BadRequest("CustomerZipCodePrefix must be a positive number.");
        if (string.IsNullOrWhiteSpace(customer.CustomerCity))
            return BadRequest("CustomerCity is required.");
        if (string.IsNullOrWhiteSpace(customer.CustomerState))
            return BadRequest("CustomerState is required.");
        #endregion
        var createdCustomer = await _service.RegisterCustomer(customer);
        return CreatedAtAction(nameof(RegisterCustomer), new { id = createdCustomer.CustomerId }, createdCustomer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(string id, [FromBody] Customer customer)
    {
        #region Validation
        if (id != customer.CustomerId)
        {
            return BadRequest("Customer ID in the URL does not match the ID in the body.");
        }
        #endregion
        await _service.UpdateCustomerAsync(customer);
        return NoContent(); // Devuelve 204 No Content si la actualización fue exitosa
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAllCustomers()
    {
        var customers = await _service.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(string id)
    {
        #region Validation
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest("Customer ID is required.");
        #endregion
        var customer = await _service.GetCustomerByIdAsync(id);
        if (customer == null)
        {
            return NotFound(); // Devuelve 404 Not Found si el cliente no existe
        }
        return Ok(customer);
    }
}