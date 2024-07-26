using System.Threading.Tasks;
using Auth0.ManagementApi;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Interfaces;
using OrderManagement.Managers;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderManager orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Welcome! Use POST to place an order.");
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Order order)
        {
            await orderManager.Transmit(order);
            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromServices] IOrderManager orderManager, Order order)
        {
            orderManager.Transmit(order);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetWithAuth0([FromServices] IManagementConnection managementConnection)
        {
            // ... code ...
            var managementApiClient = new ManagementApiClient("YOUR_MANAGEMENT_TOKEN", "YOUR_AUTH0_DOMAIN", managementConnection);
            // ... code ...
            return await Task.FromResult(Ok());
        }
    }
}