using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Data;

namespace EcommerceAPI.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly DatabaseContext _dbContext;

    public ProductsRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Products> GetAllProducts()
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM products";

        var products = new List<Products>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(new Products
            {
                ProductId = reader.GetString(0),
                ProductCategoryName = reader.IsDBNull(1) ? null : reader.GetString(1),
                ProductNameLength = reader.IsDBNull(2) ? null : reader.GetDouble(2),
                ProductDescriptionLength = reader.IsDBNull(3) ? null : reader.GetDouble(3),
                ProductPhotosQty = reader.IsDBNull(4) ? null : reader.GetDouble(4),
                ProductWeightG = reader.IsDBNull(5) ? null : reader.GetDouble(5),
                ProductLengthCm = reader.IsDBNull(6) ? null : reader.GetDouble(6),
                ProductHeightCm = reader.IsDBNull(7) ? null : reader.GetDouble(7),
                ProductWidthCm = reader.IsDBNull(8) ? null : reader.GetDouble(8)
            });
        }

        return products;
    }
}