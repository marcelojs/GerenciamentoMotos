using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IDeliveryManRepository
    {
        Task Create(DeliveryMan deliveryMan);

        Task<DeliveryMan> GetByCNHOrCNPJ(string cnh, string cnpj);

        Task<DeliveryMan> GetByCNPJ(string cnpj);

        Task<DeliveryMan> GetById(string deliveryManId);
    }
}
