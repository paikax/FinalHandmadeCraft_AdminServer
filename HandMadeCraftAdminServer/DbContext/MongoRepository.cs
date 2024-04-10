using MongoDB.Driver;

namespace HandMadeCraftAdminServer.DbContext
{
    public class MongoRepository
    {
        private readonly IMongoClient _mongoClient;

        public MongoRepository(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            return _mongoClient.GetDatabase(databaseName);
        }
    }
}