using MongoDB.Driver;
using WebApiGerenciamentoMotos.Data.Context;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public class RentRepository : IRentRepository
    {
        private readonly IMongoCollection<Rent> _rentCollection;

        public RentRepository(MongoContext mongoContext)
        {
            _rentCollection = mongoContext.Rent;
        }

        public async Task Create(Rent rent) =>
             await _rentCollection.InsertOneAsync(rent);

        public async Task<Rent> GetById(string rentId) =>
             await _rentCollection.Find(r => r.RentId == rentId).FirstOrDefaultAsync();

        public async Task<ICollection<Rent>> GetAllRentsByMotorcycleId(string motorcycleId) =>
             await _rentCollection.Find(r => r.MotorcycleId == motorcycleId).ToListAsync();

        public async Task UpdateDateDevolutionRent(string rentId, DateTime dateDevolution)
        {
            var filter = Builders<Rent>.Filter.Eq(rent => rent.RentId, rentId);
            var update = Builders<Rent>.Update.Set(rent => rent.EndDate, dateDevolution);
            await _rentCollection.UpdateOneAsync(filter, update);
        }
    }
}
