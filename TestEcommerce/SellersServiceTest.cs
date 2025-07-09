using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Services;
using Moq;
using Xunit;

namespace TestEcommerce;

public class SellersServiceTest
{
    [Fact]
    public void GetAllSellers_ShouldReturnListOfSellers()
    {
        var mockRepository = new Mock<ISellersRepository>();
        mockRepository.Setup(repo => repo.GetAllSellers()).Returns(new List<Sellers>
        {
            new Sellers { SellerId = "1", SellerZipCode = 12345, SellerCity = "City One", SellerState = "State One" },
            new Sellers { SellerId = "2", SellerZipCode = 67890, SellerCity = "City Two", SellerState = "State Two" }
        });

        var service = new SellersService(mockRepository.Object);

        var result = service.GetAllSellers();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("1", result[0].SellerId);
    }
}
