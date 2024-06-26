using System.Threading.Tasks;
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
    }
}