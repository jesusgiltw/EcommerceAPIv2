using EcommerceAPI.Entities;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _service;

    public ProductsController(ProductsService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Products>> GetAllProducts()
    {
        var products = _service.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Products?> GetProductsById(string id)
    {
        #region Validation
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest("Product ID is required.");
        #endregion
        var product = _service.GetProductsById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}