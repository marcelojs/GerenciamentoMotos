using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public interface IDeliveryManRepository
    {
        Task<bool> Create(DeliveryMan deliveryMan);

        Task<Motorcycle> GetByCNHOrCNPJ(string cnh, string cnpj);

        Task<Motorcycle> GetByCNPJ(string cnh);

        Task<DeliveryMan> GetById(Guid deliveryManId);
    }
}
