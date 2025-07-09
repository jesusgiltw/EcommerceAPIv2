using EcommerceAPI.Data;
using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly DatabaseContext _dbContext;

    public OrdersRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Order> GetAllOrders()
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM orders";

        var orders = new List<Order>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            orders.Add(new Order
            {
                OrderId = reader.GetString(0),
                CustomerId = reader.GetString(1),
                OrderStatus = reader.GetString(2)
            });
        }

        return orders;
    }
    public Order GetOrderById(string orderId)
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM orders WHERE order_id = @OrderId";
        command.Parameters.AddWithValue("@OrderId", orderId);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Order
            {
                OrderId = reader.GetString(0),
                CustomerId = reader.GetString(1),
                OrderStatus = reader.GetString(2)
            };
        }

        throw new Exception("Order not found");
    }
    public List<Order> GetOrdersBetweenPurchasedDates(DateTime startDate, DateTime endDate)
    {
        using var connection = _dbContext.GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM orders WHERE order_purchase_timestamp BETWEEN @StartDate AND @EndDate";
        command.Parameters.AddWithValue("@StartDate", startDate);
        command.Parameters.AddWithValue("@EndDate", endDate);

        var orders = new List<Order>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            orders.Add(new Order
            {
                OrderId = reader.GetString(0),
                CustomerId = reader.GetString(1),
                OrderStatus = reader.GetString(2)
            });
        }

        return orders;
    }
}