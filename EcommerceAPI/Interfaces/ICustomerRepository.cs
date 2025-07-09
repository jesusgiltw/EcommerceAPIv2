using EcommerceAPI.Entities;

namespace EcommerceAPI.Interfaces;

public interface ICustomerRepository
{
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
}
