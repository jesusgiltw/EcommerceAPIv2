using EcommerceAPI.Entities;

namespace EcommerceAPI.Interfaces;

public interface ICustomerRepository
{
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(string id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(string id);
}
