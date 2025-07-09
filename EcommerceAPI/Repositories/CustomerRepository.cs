using EcommerceAPI.Data;
using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DatabaseContext _dbContext;

    public CustomerRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO customers (customer_id, customer_unique_id, customer_zip_code_prefix, customer_city, customer_state)
            VALUES (@CustomerId, @CustomerUniqueId, @CustomerZipCodePrefix, @CustomerCity, @CustomerState);
        ";

        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
        command.Parameters.AddWithValue("@CustomerUniqueId", customer.CustomerUniqueId);
        command.Parameters.AddWithValue("@CustomerZipCodePrefix", customer.CustomerZipCodePrefix);
        command.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
        command.Parameters.AddWithValue("@CustomerState", customer.CustomerState);

        await command.ExecuteNonQueryAsync();

        return customer;
    }

    public async Task<Customer?> GetCustomerByIdAsync(int customerId)
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM customers WHERE customer_id = @CustomerId";
        command.Parameters.AddWithValue("@CustomerId", customerId);

        using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Customer
            {
                CustomerId = reader.GetString(0),
                CustomerUniqueId = reader.GetString(1),
                CustomerZipCodePrefix = reader.GetInt32(2),
                CustomerCity = reader.GetString(3),
                CustomerState = reader.GetString(4)
            };
        }

        return null;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM customers";

        using var reader = await command.ExecuteReaderAsync();
        var customers = new List<Customer>();

        while (await reader.ReadAsync())
        {
            customers.Add(new Customer
            {
                CustomerId = reader.GetString(0),
                CustomerUniqueId = reader.GetString(1),
                CustomerZipCodePrefix = reader.GetInt32(2),
                CustomerCity = reader.GetString(3),
                CustomerState = reader.GetString(4)
            });
        }

        return customers;
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE customers
            SET customer_unique_id = @CustomerUniqueId,
                customer_zip_code_prefix = @CustomerZipCodePrefix,
                customer_city = @CustomerCity,
                customer_state = @CustomerState
            WHERE customer_id = @CustomerId;
        ";

        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
        command.Parameters.AddWithValue("@CustomerUniqueId", customer.CustomerUniqueId);
        command.Parameters.AddWithValue("@CustomerZipCodePrefix", customer.CustomerZipCodePrefix);
        command.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
        command.Parameters.AddWithValue("@CustomerState", customer.CustomerState);

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM customers WHERE customer_id = @CustomerId";
        command.Parameters.AddWithValue("@CustomerId", customerId);

        await command.ExecuteNonQueryAsync();
    }
}