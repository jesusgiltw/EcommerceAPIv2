namespace EcommerceAPI.Interfaces;
using EcommerceAPI.Entities;

public interface IProductsRepository
{
    List<Products> GetAllProducts();
}