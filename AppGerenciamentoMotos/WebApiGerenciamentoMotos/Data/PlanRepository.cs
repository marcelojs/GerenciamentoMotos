using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data
{
    public class PlanRepository : IPlanRepository
    {
        public Task<ICollection<Plan>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
