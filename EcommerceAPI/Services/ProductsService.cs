using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Services;

public class ProductsService
{
    private readonly IProductsRepository _repository;

    public ProductsService(IProductsRepository repository)
    {
        _repository = repository;
    }

    public List<Products> GetAllProducts()
    {
        return _repository.GetAllProducts();
    }
}