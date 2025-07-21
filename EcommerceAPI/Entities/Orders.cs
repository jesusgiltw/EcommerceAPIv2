namespace EcommerceAPI.Entities;

public class Order
{
    public required string OrderId { get; set; } = Guid.NewGuid().ToString();

    public required string CustomerId { get; set; } = string.Empty;
    public Customer Customer { get; set; } = new Customer();
    public string OrderStatus { get; set; } = string.Empty;
    public DateTime OrderPurchasedDate { get; set; } = DateTime.UtcNow;
}