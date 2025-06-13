using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public class DeliveryManRepository : IDeliveryManRepository
    {
        public Task<bool> Create(DeliveryMan deliveryMan)
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetByCNHOrCNPJ(string cnh, string cnpj)
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetByCNPJ(string cnh)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryMan> GetById(Guid deliveryManId)
        {
            throw new NotImplementedException();
        }
    }
}
