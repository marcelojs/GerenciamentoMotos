using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.ViewModel;

namespace WebApiGerenciamentoMotos.Mapper
{
    public static class RentMapper
    {
        public static Rent MapperViewModelToEntityDomain(RentViewModel rentViewModel)
        {
            return new Rent()
            {
                RentId = rentViewModel.RentId,
                MotorcycleId = rentViewModel.MotorcycleId,
                DeliveryManId = rentViewModel.DeliveryManId,
                Plan = rentViewModel.Plan,
                StartDate = rentViewModel.StartDate,
                EndDate = rentViewModel.EndDate,
                PrevisionFinish = rentViewModel.PrevisionFinish
            };
        }

        public static RentViewModel MapperEntityDomainToViewModel(Rent rent)
        {
            return new RentViewModel()
            {
                RentId = rent.RentId,
                MotorcycleId = rent.MotorcycleId,
                DeliveryManId = rent.DeliveryManId,
                Plan = rent.Plan,
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                PrevisionFinish = rent.PrevisionFinish
            };
        }
    }
}
