using System;
using EcommerceAPI.Data;
using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Repositories;

public class SellersRepository : ISellersRepository
{
    private readonly DatabaseContext _dbContext;

    public SellersRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Sellers> GetAllSellers()
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM sellers";

        var sellers = new List<Sellers>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            sellers.Add(new Sellers
            {
                SellerId = reader.GetString(0),
                SellerZipCode = reader.GetInt32(1),
                SellerCity = reader.IsDBNull(2) ? null : reader.GetString(2),
                SellerState = reader.IsDBNull(3) ? null : reader.GetString(3)
            });
        }

        return sellers;
    }
}
