using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.ViewModel;

namespace WebApiGerenciamentoMotos.Mapper
{
    public static class DeliveryManMapper
    {
        public static DeliveryMan MapperViewModelToDomain(DeliveryManViewModel deliveryManViewModel)
        {
            return new DeliveryMan()
            {
                DeliveryManId = deliveryManViewModel.DeliveryManId,
                BirthdayDate = deliveryManViewModel.BirthdayDate,
                CNHImageName = deliveryManViewModel.CNHImageName,
                CNHNumber = deliveryManViewModel.CNHNumber,
                CNHType = deliveryManViewModel.CNHType,
                CNPJ = deliveryManViewModel.CNPJ,
                Name = deliveryManViewModel.Name,
            };
        }
    }
}
