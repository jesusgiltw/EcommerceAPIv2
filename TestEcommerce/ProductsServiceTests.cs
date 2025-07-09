using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Services;
using Moq;
using Xunit;

namespace EcommerceAPI.Tests;

public class ProductsServiceTests
{
    [Fact]
    public void GetAllProducts_ShouldReturnListOfProducts()
    {
        // Arrange
        var mockRepository = new Mock<IProductsRepository>();
        mockRepository.Setup(repo => repo.GetAllProducts()).Returns(new List<Products>
        {
            new Products { ProductId = "1", ProductCategoryName = "Electronics", ProductNameLength = 10 },
            new Products { ProductId = "2", ProductCategoryName = "Books", ProductNameLength = 5 }
        });

        var service = new ProductsService(mockRepository.Object);

        // Act
        var result = service.GetAllProducts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("1", result[0].ProductId);
        Assert.Equal("Electronics", result[0].ProductCategoryName);
    }
}