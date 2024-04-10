using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.Models.Order;

namespace HandMadeCraftAdminServer.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(string id);
        Task<Order> CreateOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(string id, Order order);
        Task<bool> DeleteOrderAsync(string id);
    }
}