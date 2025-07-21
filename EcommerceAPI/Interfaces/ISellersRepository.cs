using EcommerceAPI.Entities;

namespace EcommerceAPI.Interfaces;


public interface ISellersRepository
{
    List<Sellers> GetAllSellers();
    Sellers? GetSellersById(string id);
}
