using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;
using MongoDB.Driver;
using WebApiGerenciamentoMotos.Data.Context;


namespace WebApiGerenciamentoMotos.Data
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IMongoCollection<Plan> _planCollection;

        public PlanRepository(MongoContext mongoContext)
        {
            _planCollection = mongoContext.Plan;
        }

        public async Task<ICollection<Plan>> GetAll()
        {
            return await _planCollection.Find(p => true).ToListAsync();
        }
    }
}
