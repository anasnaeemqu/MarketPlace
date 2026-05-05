using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Marketplace.API.Infrastructure;
using Marketplace.API.Domain;

namespace Marketplace.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    // PLACE ORDER
    [HttpPost]
    public IActionResult PlaceOrder(Order order)
    {
        order.OrderDate = DateTime.UtcNow;
        order.Status = "Pending";

        _context.Orders.Add(order);
        _context.SaveChanges();

        return Ok(order);
    }

    // GET ALL ORDERS
    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = _context.Orders
            .Include(o => o.Items)
            .ToList();

        return Ok(orders);
    }

    // GET SINGLE ORDER
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _context.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound("Order not found");

        return Ok(order);
    }
}