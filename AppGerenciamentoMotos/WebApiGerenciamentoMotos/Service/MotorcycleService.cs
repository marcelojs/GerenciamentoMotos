using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<ValidationResult> Create(Motorcycle motorcycle)
        {
            var validation = new ValidationResult();

            var motorcycleFound = _motorcycleRepository.GetByPlate(motorcycle.Plate);

            if (motorcycleFound != null)
            {
                validation.AddMessageError($"Já existe uma moto com a placa {motorcycle.Plate}");
                return validation;
            }

            await _motorcycleRepository.Create(motorcycle);

            if (motorcycle.Year == 2024)
            { 
                //ToDo: Send MEssage
            }

            return validation;
        }

        public async Task<List<Motorcycle>> GetAll()
        {
            return await _motorcycleRepository.GetAll();
        }

        public async Task<Motorcycle> GetByPlate(string plate)
        {
            return await _motorcycleRepository.GetByPlate(plate);
        }

        public async Task<ValidationResult> Remove(Guid motorcycleId)
        {
            var validation = new ValidationResult();
            var result = await _motorcycleRepository.Delete(motorcycleId);

            //ToDo: Validar se existe alocacoes

            if (!result)
            {
                validation.AddMessageError("Houve uma falha ao tentar deletar a moto");
            }

            return validation;

        }

        public async Task<ValidationResult> UpdatePlate(Guid motorcycleId, string newPlate)
        {
            var validation = new ValidationResult();
            var result = await _motorcycleRepository.UpdatePlate(motorcycleId, newPlate);

            if (!result)
            {
                validation.AddMessageError($"Houve uma falha ao tentar atualizar a placa do veículo");
            }

            return validation;
        }
    }
}
