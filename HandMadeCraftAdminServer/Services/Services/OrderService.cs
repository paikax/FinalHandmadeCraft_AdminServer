using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.Models.Order;
using MongoDB.Driver;

namespace HandMadeCraftAdminServer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _ordersCollection;

        public OrderService(IMongoDatabase database)
        {
            _ordersCollection = database.GetCollection<Order>("orders");
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _ordersCollection.Find(order => true).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            return await _ordersCollection.Find(order => order.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            order.OrderDate = DateTime.UtcNow;
            order.LastUpdated = order.OrderDate;
            await _ordersCollection.InsertOneAsync(order);
            return order;
        }

        public async Task<bool> UpdateOrderAsync(string id, Order order)
        {
            order.LastUpdated = DateTime.UtcNow;
            var result = await _ordersCollection.ReplaceOneAsync(o => o.Id == id, order);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteOrderAsync(string id)
        {
            var result = await _ordersCollection.DeleteOneAsync(order => order.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}