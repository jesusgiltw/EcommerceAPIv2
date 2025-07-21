using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Services;

public class SellersService
{
    private readonly ISellersRepository _sellersRepository;

    public SellersService(ISellersRepository sellersRepository)
    {
        _sellersRepository = sellersRepository;
    }

    public List<Sellers> GetAllSellers()
    {
        return _sellersRepository.GetAllSellers();
    }

    public Sellers? GetSellersById(string id)
    {
        return _sellersRepository.GetSellersById(id);
    }
}
