using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IDeliveryManRepository
    {
        Task<bool> Create(DeliveryMan deliveryMan);

        Task<DeliveryMan> GetByCNHOrCNPJ(string cnh, string cnpj);

        Task<DeliveryMan> GetByCNPJ(string cnh);

        Task<DeliveryMan> GetById(Guid deliveryManId);
    }
}
