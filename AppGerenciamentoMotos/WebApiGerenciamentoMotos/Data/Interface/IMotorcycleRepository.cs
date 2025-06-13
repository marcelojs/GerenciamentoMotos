using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IMotorcycleRepository
    {
        Task<bool> Create(Motorcycle motorcycle);

        Task<List<Motorcycle>> GetAll();

        Task<bool> UpdatePlate(Guid motorcycleId, string newPlate);

        Task<Motorcycle> GetByPlate(string plate);

        Task<bool> Delete(Guid motorcycleId);
    }
}
