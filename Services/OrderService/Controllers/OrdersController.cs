using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Service;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly ClientService _clientService;
        public OrdersController(IOrdersService ordersService, ClientService clientService)
        {
            _ordersService = ordersService;
            _clientService = clientService;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _ordersService.GetAllOrders();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var isAvailable = await _clientService.IsProductAvailableAsync(order.ProductId, order.Quantity);
            if (!isAvailable)
                return BadRequest("product is not avilable in sufficien activity");
            var createdOrder = _ordersService.AddOrder(order);
            return CreatedAtAction(nameof(GetOrders), new { id = createdOrder.Id }, createdOrder);
        }
    }
}
