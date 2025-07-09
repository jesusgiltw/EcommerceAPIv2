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
}
