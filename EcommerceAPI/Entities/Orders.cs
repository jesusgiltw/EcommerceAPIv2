namespace EcommerceAPI.Entities;

public class Order
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public string CustomerId { get; set; } = string.Empty;
    public string OrderStatus { get; set; } = string.Empty;
    public DateTime OrderPurchasedDate { get; set; } = DateTime.UtcNow;
}