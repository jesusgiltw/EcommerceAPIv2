using EcommerceAPI.Entities;

namespace EcommerceAPI.Interfaces;

public interface IOrderItemsRepository
{
    List<OrderItem> GetAllOrderItems();
    OrderItem? GetOrderItemById(string orderItemId);
    List<OrderItem> GetOrderItemsByOrderId(string orderId);
    void AddOrderItem(OrderItem orderItem);
    void UpdateOrderItem(OrderItem orderItem);
    void DeleteOrderItem(string orderItemId);
}
