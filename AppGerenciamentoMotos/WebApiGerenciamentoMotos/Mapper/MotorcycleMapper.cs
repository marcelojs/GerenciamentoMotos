using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.ViewModel;

namespace WebApiGerenciamentoMotos.Mapper
{
    public static class MotorcycleMapper
    {
        public static Motorcycle MapperViewModelToEntityDomain(MotorcycleViewModel motorcycleViewModel)
        {
            return new Motorcycle()
            {
                MotorcycleId = motorcycleViewModel.MotorcycleId,
                Model = motorcycleViewModel.Model,
                Plate = motorcycleViewModel.Plate,
                Year = motorcycleViewModel.Year
            };
        }

        public static MotorcycleViewModel MapperEntityDomainToViewModel(Motorcycle motorcycle)
        {
            return new MotorcycleViewModel()
            {
                MotorcycleId = motorcycle.MotorcycleId,
                Model = motorcycle.Model,
                Plate = motorcycle.Plate,
                Year = motorcycle.Year
            };
        }

        public static ICollection<MotorcycleViewModel> MapperEntitiesDomainToViewModel(List<Motorcycle> motorcycles)
        {
            var motorcyclesList = new List<MotorcycleViewModel>();

            motorcycles.ForEach(motorcycle =>
            {
                var motorcycleViewModel = new MotorcycleViewModel()
                {
                    MotorcycleId = motorcycle.MotorcycleId,
                    Model = motorcycle.Model,
                    Plate = motorcycle.Plate,
                    Year = motorcycle.Year
                };

                motorcyclesList.Add(motorcycleViewModel);

            });

            return motorcyclesList;
        }
    }
}
