using HandMadeCraftAdminServer.Models.Order;
using MongoDB.Driver;

namespace HandMadeCraftAdminServer.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient mongoClient, string databaseName)
        {
            _database = mongoClient.GetDatabase(databaseName);
        }
        
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("orders");
    }
}