using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service.Interface
{
    public class DeliveryManService : IDeliveryManService
    {
        private readonly IDeliveryManRepository _deliveryManRepository;

        public DeliveryManService(IDeliveryManRepository deliveryManRepository)
        {
            _deliveryManRepository = deliveryManRepository;
        }

        public async Task<ValidationResult> Create(DeliveryMan deliveryMan)
        {
            var validation = new ValidationResult();

            var result = await _deliveryManRepository.GetByCNHOrCNPJ(deliveryMan.CNHNumber, deliveryMan.CNPJ);

            if (result != null)
            {
                validation.AddMessageError("Já existe um registro para o CNPJ ou CNH informada");
                return validation;
            }

            if (deliveryMan.CNHType != "A" && deliveryMan.CNHType != "B" && deliveryMan.CNHType == "AB")
            {
                validation.AddMessageError("Tipo de CNH informada é inválida");
                return validation;
            }

            await _deliveryManRepository.Create(deliveryMan);
            return validation;
        }

        public async Task<ValidationResult> AddPhoto(Guid deluveryManId, string photo)
        {
            return new ValidationResult();
        }
    }
}
