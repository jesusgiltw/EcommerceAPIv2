namespace EcommerceAPI.Entities;

public class Order
{
    public required string OrderId { get; set; } = Guid.NewGuid().ToString();

    public required string CustomerId { get; set; } = string.Empty;
    public Customer Customer { get; set; } = new Customer();
    public string OrderStatus { get; set; } = string.Empty;
    public DateTime OrderPurchasedDate { get; set; } = DateTime.UtcNow;
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

public class OrderItem
{
    public required string OrderId { get; set; }
    public required string OrderItemId { get; set; }
    public required string ProductId { get; set; }
    public required string SellerId { get; set; }
    public DateTime ShippingLimitDate { get; set; }
    public decimal Price { get; set; }
    public decimal FreightValue { get; set; }
}