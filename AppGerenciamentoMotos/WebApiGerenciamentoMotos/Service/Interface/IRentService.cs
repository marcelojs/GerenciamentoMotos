using WebApiGerenciamentoMotos.Response;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service.Interface
{
    public interface IRentService
    {
        Task<ValidationResult> Create(Rent rent);
        Task<Rent> GetById(Guid rentId);
        Task<ResponseWrapper> UpdateDateDevolutionRentAndReturnFinalValueAllocation(Guid rentId, DateTime dateDevolution);
    }
}
