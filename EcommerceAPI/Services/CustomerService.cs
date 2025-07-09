using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Services;

public class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> RegisterCustomer(Customer customer)
    {
        return await _repository.AddCustomerAsync(customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
    await _repository.UpdateCustomerAsync(customer);
    }
}