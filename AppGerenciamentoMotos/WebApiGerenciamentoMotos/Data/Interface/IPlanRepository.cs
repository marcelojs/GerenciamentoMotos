using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IPlanRepository
    {
        Task<ICollection<Plan>> GetAll();
    }
}
