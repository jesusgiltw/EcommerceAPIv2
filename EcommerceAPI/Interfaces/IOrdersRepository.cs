using EcommerceAPI.Entities;

namespace EcommerceAPI.Interfaces;

public interface IOrdersRepository
{
    List<Order> GetAllOrders();
    Order GetOrderById(string orderId);
    List<Order> GetOrdersBetweenPurchasedDates(DateTime startDate, DateTime endDate);
}