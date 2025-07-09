using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Services;
using Moq;
using Xunit;

namespace TestEcommerce;

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

    [Fact]
    public void GetProductsById_ShouldReturnProduct_WhenExists()
    {
        // Arrange
        var mockRepository = new Mock<IProductsRepository>();
        mockRepository.Setup(repo => repo.GetProductsById("1")).Returns(new Products { ProductId = "1", ProductCategoryName = "Electronics", ProductNameLength = 10 });

        var service = new ProductsService(mockRepository.Object);

        // Act
        var result = service.GetProductsById("1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("1", result.ProductId);
        Assert.Equal("Electronics", result.ProductCategoryName);
    }
}