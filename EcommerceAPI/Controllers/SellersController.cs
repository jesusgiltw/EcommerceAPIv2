using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers;

[ApiController]
[Route("sellers")]
public class SellersController : ControllerBase
{
    private readonly ISellersRepository _sellersRepository;

    public SellersController(ISellersRepository sellersRepository)
    {
        _sellersRepository = sellersRepository;
    }

    [HttpGet]
    public ActionResult<List<Sellers>> GetAllSellers()
    {
        var sellers = _sellersRepository.GetAllSellers();
        return Ok(sellers);
    }
    [HttpGet("{id}")]
    public ActionResult<Sellers?> GetSellersById(string id)
    {
        #region Validation
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest("Seller ID is required.");
        #endregion
        var seller = _sellersRepository.GetSellersById(id);
        if (seller == null)
        {
            return NotFound();
        }
        return Ok(seller);
    }
}
