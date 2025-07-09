namespace EcommerceAPI.Entities;

public class Sellers
{
    public required string SellerId { get; set; }
    public int SellerZipCode { get; set; }
    public string? SellerCity { get; set; }
    public string? SellerState { get; set; }
}
