using System.Threading.Tasks;
using OrderManagement.Interfaces;
using OrderManagement.Models;

namespace OrderManagement.Managers
{
    public class OrderManager : IOrderManager
    {
        private IOrderSender sender;

        public OrderManager(IOrderSender sender)
        {
            this.sender = sender;
        }

        public async Task<string> Transmit(Order order)
        {
            return await sender.Send(order);
        }
    }
}
