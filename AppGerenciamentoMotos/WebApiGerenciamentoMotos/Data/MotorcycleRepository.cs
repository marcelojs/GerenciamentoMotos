using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        public Task<bool> Create(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid motorcycleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Motorcycle>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetByPlate(string plate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlate(Guid motorcycleId, string newPlate)
        {
            throw new NotImplementedException();
        }
    }
}
