using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiGerenciamentoMotos.Configuration;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Context
{
    public class MongoContext
    {
        public MongoContext(IMongoClient mongoClient, IOptions<MMStoreDatabaseSettings> options)
        {
            _database = mongoClient.GetDatabase(options.Value.DatabaseName);
        }

        public MMStoreDatabaseSettings _connectionSettings;
        public MongoClient _mongoClient;
        public IMongoDatabase _database;

        public IMongoCollection<DeliveryMan> DeliveryMan => _database.GetCollection<DeliveryMan>("deliveryman");
        public IMongoCollection<Plan> Plan => _database.GetCollection<Plan>("plan");
        public IMongoCollection<Motorcycle> Motorcycle => _database.GetCollection<Motorcycle>("motorcycle");
        public IMongoCollection<Rent> Rent => _database.GetCollection<Rent>("rent");
    }
}
