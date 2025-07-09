namespace EcommerceAPI.Interfaces;
using EcommerceAPI.Entities;

public interface IProductsRepository
{
    List<Products> GetAllProducts();
    Products? GetProductsById(string id);
}