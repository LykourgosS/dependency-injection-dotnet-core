using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.Interfaces
{
    public interface IOrderSender
    {
        public Task<string> Send(Order order);
    }
}
