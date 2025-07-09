using EcommerceAPI.Entities;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly OrdersService _service;

    public OrdersController(OrdersService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Order>> GetAllOrders()
    {
        var orders = _service.GetAllOrders();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public ActionResult<Order> GetOrderById(string id)
    {
        var order = _service.GetOrderById(id);
        return Ok(order);
    }

    [HttpGet("by-date")]
    public ActionResult<List<Order>> GetOrdersByDateRange([FromBody] DateRangeRequest dateRange)
    {
        var orders = _service.GetOrdersBetweenPurchasedDates(dateRange.StartDate, dateRange.EndDate);
        return Ok(orders);
    }
}