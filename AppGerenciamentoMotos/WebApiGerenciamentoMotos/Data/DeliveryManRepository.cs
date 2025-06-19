using MongoDB.Driver;
using WebApiGerenciamentoMotos.Data.Context;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public class DeliveryManRepository : IDeliveryManRepository
    {
        private readonly IMongoCollection<DeliveryMan> _deliveryManCollection;

        public DeliveryManRepository(MongoContext mongoContext)
        {
            _deliveryManCollection = mongoContext.DeliveryMan;
        }

        public async Task Create(DeliveryMan deliveryMan) =>
            await _deliveryManCollection.InsertOneAsync(deliveryMan);

        public async Task<DeliveryMan> GetByCNPJ(string cnpj) =>
            await _deliveryManCollection.Find(m => m.CNPJ == cnpj).FirstOrDefaultAsync();

        public async Task<DeliveryMan> GetById(string deliveryManId) =>
            await _deliveryManCollection.Find(m => m.DeliveryManId == deliveryManId).FirstOrDefaultAsync();

        public async Task<DeliveryMan> GetByCNHOrCNPJ(string cnh, string cnpj)
        {
            var builder = Builders<DeliveryMan>.Filter;
            var filter = builder.Or(builder.Eq(x => x.CNHNumber, cnh), builder.Eq(x => x.CNPJ, cnpj));
            return await _deliveryManCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
