using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IRentRepository
    {
        Task<bool> Create(Rent rent);
        Task<Rent> GetById(Guid rentId);
        Task<bool> UpdateDateDevolutionRent(Guid rentId, DateTime dateDevolution); 
    }
}
