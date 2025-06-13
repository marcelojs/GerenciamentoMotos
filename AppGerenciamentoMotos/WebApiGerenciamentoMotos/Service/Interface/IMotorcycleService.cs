using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service.Interface
{
    public interface IMotorcycleService
    {
        Task<ValidationResult> Create(Motorcycle motorcycle);

        Task<List<Motorcycle>> GetAll();

        Task<ValidationResult> UpdatePlate(Guid motorcycleId, string newPlate);

        Task<Motorcycle> GetByPlate(string plate);

        Task<ValidationResult> Remove(Guid motorcycleId);
    }
}
