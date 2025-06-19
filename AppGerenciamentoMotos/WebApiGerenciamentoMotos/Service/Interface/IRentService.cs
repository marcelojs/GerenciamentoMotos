using WebApiGerenciamentoMotos.Response;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service.Interface
{
    public interface IRentService
    {
        Task<ValidationResult> Create(Rent rent);
        Task<Rent> GetById(string rentId);
        Task<ResponseWrapper> UpdateDateDevolutionRentAndReturnFinalValueAllocation(string rentId, DateTime dateDevolution);

        Task<ICollection<Plan>> ApenasTeste();
        
    }
}
