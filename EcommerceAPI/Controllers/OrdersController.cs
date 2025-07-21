using EcommerceAPI.Entities;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly OrdersService _ordersService;
    private readonly CustomerService _customerService;

    public OrdersController(OrdersService ordersService, CustomerService customerService)
    {
        _ordersService = ordersService;
        _customerService = customerService;
    }

    [HttpGet]
    public ActionResult<List<Order>> GetAllOrders()
    {
        var orders = _ordersService.GetAllOrders();
        var result = orders.Select(async order => new Order
        {
            OrderId = order.OrderId,
            CustomerId = order.CustomerId,
            Customer = await _customerService.GetCustomerByIdAsync(order.CustomerId),
            OrderStatus = order.OrderStatus,
            OrderPurchasedDate = order.OrderPurchasedDate
        }).ToList();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrderById(string id)
    {
        #region Validation
        if (string.IsNullOrEmpty(id)) return BadRequest("Order ID cannot be null or empty.");
        #endregion
        var order = _ordersService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        var result = new Order
        {
            OrderId = order.OrderId,
            CustomerId = order.CustomerId,
            Customer = await _customerService.GetCustomerByIdAsync(order.CustomerId),
            OrderStatus = order.OrderStatus,
            OrderPurchasedDate = order.OrderPurchasedDate
        };
        return Ok(result);
    }

    [HttpGet("by-date")]
    public async Task<ActionResult<List<Order>>> GetOrdersByDateRangeAsync([FromBody] DateRangeRequest dateRange)
    {
        #region Validation
        if (dateRange == null || dateRange.StartDate == default || dateRange.EndDate == default)
        {
            return BadRequest("Invalid date range provided.");
        }
        if (dateRange.StartDate > dateRange.EndDate)
        {
            return BadRequest("Start date cannot be after end date.");
        }
        if (dateRange.EndDate > DateTime.UtcNow)
        {
            return BadRequest("End date cannot be in the future.");
        }
        #endregion
        var orders = _ordersService.GetOrdersBetweenPurchasedDates(dateRange.StartDate, dateRange.EndDate);
        if (orders == null || !orders.Any())
        {
            return NotFound("No orders found in the specified date range.");
        }
        foreach (var order in orders)
        {
            order.Customer = await _customerService.GetCustomerByIdAsync(order.CustomerId);
        }
        return Ok(orders);
    }
}