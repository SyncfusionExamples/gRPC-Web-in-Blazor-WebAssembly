using BlazorGRPC.Server.Services;
using BlazorGRPC.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorGRPC.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrdersController:ControllerBase
    {
        private static readonly string[] Countries = new[] { "Berlin", "Tokyo", "Denmark", "Tokyo", "Olso" };
        private static readonly string[] Names = new[] { "VINET", "RIO", "RAJ", "MAH", "RAM" };
        private static readonly string[] Cities = new[] { "New York", "London", "Hue" };

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Orders> Get([FromServices] Services.OrdersService ordersService)
        {
            return ordersService.GetOrders().ToArray();
        }
    }
}
