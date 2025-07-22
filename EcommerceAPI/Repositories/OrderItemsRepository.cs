using EcommerceAPI.Data;
using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Repositories;

public class OrderItemsRepository : IOrderItemsRepository
{
    private readonly DatabaseContext _dbContext;
    public OrderItemsRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<OrderItem> GetAllOrderItems()
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }

    public OrderItem? GetOrderItemById(string orderItemId)
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }

    public List<OrderItem> GetOrderItemsByOrderId(string orderId)
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM order_items WHERE order_id = @OrderId";
        command.Parameters.AddWithValue("@OrderId", orderId);

        using var reader = command.ExecuteReader();
        var orderItems = new List<OrderItem>();
        while (reader.Read())
        {
            var orderItem = new OrderItem
            {
                OrderId = reader.GetString(0),
                OrderItemId = reader.GetString(1),
                ProductId = reader.GetString(2),
                SellerId = reader.GetString(3),
                ShippingLimitDate = reader.GetDateTime(4),
                Price = reader.GetDecimal(5),
                FreightValue = reader.GetDecimal(6)
            };
            orderItems.Add(orderItem);
        }
        return orderItems;
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }

    public void UpdateOrderItem(OrderItem orderItem)
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }

    public void DeleteOrderItem(string orderItemId)
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }
}
