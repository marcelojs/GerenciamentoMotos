using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public class RentRepository : IRentRepository
    {
        public Task<bool> Create(Rent rent)
        {
            throw new NotImplementedException();
        }

        public Task<Rent> GetById(Guid rentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDateDevolutionRent(Guid rentId, DateTime dateDevolution)
        {
            throw new NotImplementedException();
        }
    }
}
