using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;

namespace EcommerceAPI.Services;

public class OrdersService
{
    private readonly IOrdersRepository _repository;

    public OrdersService(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public List<Order> GetAllOrders()
    {
        return _repository.GetAllOrders();
    }
    public Order GetOrderById(string orderId)
    {
        return _repository.GetOrderById(orderId);
    }
    public List<Order> GetOrdersBetweenPurchasedDates(DateTime startDate, DateTime endDate)
    {
        return _repository.GetOrdersBetweenPurchasedDates(startDate, endDate);
    }
}