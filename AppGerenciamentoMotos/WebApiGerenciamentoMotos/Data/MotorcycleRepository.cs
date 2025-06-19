using MongoDB.Driver;
using WebApiGerenciamentoMotos.Data.Context;
using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly IMongoCollection<Motorcycle> _motorcycleCollection;

        public MotorcycleRepository(MongoContext mongoContext)
        {
            _motorcycleCollection = mongoContext.Motorcycle;
        }

        public async Task Create(Motorcycle motorcycle) =>
            await _motorcycleCollection.InsertOneAsync(motorcycle);

        public async Task Delete(string motorcycleId) =>
            await _motorcycleCollection.DeleteOneAsync(m => m.MotorcycleId == motorcycleId);

        public async Task<List<Motorcycle>> GetAll() =>
            await _motorcycleCollection.Find(m => true).ToListAsync();

        public async Task<Motorcycle> GetByPlate(string plate) =>
            await _motorcycleCollection.Find(m => m.Plate == plate).FirstOrDefaultAsync();

        public async Task<long> UpdatePlate(string motorcycleId, string newPlate)
        {
            var filter = Builders<Motorcycle>.Filter.Eq(m => m.MotorcycleId, motorcycleId);
            var update = Builders<Motorcycle>.Update.Set(m => m.Plate, newPlate);
            var result = await _motorcycleCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount;
        }
    }
}
