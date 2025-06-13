using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service.Interface
{
    public interface IDeliveryManService
    {
        Task<ValidationResult> Create(DeliveryMan deliveryMan);

        Task<ValidationResult> AddPhoto(Guid deluveryManId, string photo);
    }
}
