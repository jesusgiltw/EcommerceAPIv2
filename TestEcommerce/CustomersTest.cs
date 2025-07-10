using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Services;
using Moq;
using Xunit;

namespace TestEcommerce;

public class CustomersTest
{
    [Fact]
    public async Task GetAllCustomers_ShouldReturnListOfCustomers()
    {
        var mockRepository = new Mock<ICustomerRepository>();
        mockRepository.Setup(repo => repo.GetAllCustomersAsync()).ReturnsAsync(new List<Customer>
        {
            new Customer { CustomerId = "1", CustomerCity = "New York", CustomerState = "NY", CustomerZipCodePrefix = 10001, CustomerUniqueId = "unique1" },
            new Customer { CustomerId = "2", CustomerCity = "Los Angeles", CustomerState = "CA", CustomerZipCodePrefix = 90001, CustomerUniqueId = "unique2" }
        });

        var service = new CustomerService(mockRepository.Object);

        var result = await service.GetAllCustomersAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("1", result[0].CustomerId);
    }
}
