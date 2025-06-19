using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IRentRepository
    {
        Task Create(Rent rent);
        Task<Rent> GetById(string rentId);
        Task UpdateDateDevolutionRent(string rentId, DateTime dateDevolution);

        Task<ICollection<Rent>> GetAllRentsByMotorcycleId(string motorcycleId);
    }
}
