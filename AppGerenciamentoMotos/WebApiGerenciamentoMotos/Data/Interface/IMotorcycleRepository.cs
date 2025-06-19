using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IMotorcycleRepository
    {
        Task Create(Motorcycle motorcycle);

        Task<List<Motorcycle>> GetAll();

        Task<long> UpdatePlate(string motorcycleId, string newPlate);

        Task<Motorcycle> GetByPlate(string plate);

        Task Delete(string motorcycleId);
    }
}
