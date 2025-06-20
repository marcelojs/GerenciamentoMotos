using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service
{
    public class MotorcycleService : ServiceBase, IMotorcycleService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IRentRepository _rentRepository;

        public MotorcycleService(IMotorcycleRepository motorcycleRepository, IRentRepository rentRepository)
        {
            _motorcycleRepository = motorcycleRepository;
            _rentRepository = rentRepository;
        }

        public async Task<ValidationResult> Create(Motorcycle motorcycle)
        {
            var validation = new ValidationResult();

            var motorcycleFound = await _motorcycleRepository.GetByPlate(motorcycle.Plate);

            if (motorcycleFound != null)
            {
                validation.AddMessageError($"Já existe uma moto com a placa {motorcycle.Plate}");
                return validation;
            }

            motorcycle.NewId();
            var resultIfIsValid = ValidDataMotorcycle(motorcycle);

            if(!resultIfIsValid.IsValid)
                return resultIfIsValid;

            //Observacao: deixei aberto o create para teste
            await _motorcycleRepository.Create(motorcycle);

            if (motorcycle.Year == 2024)
            {
                //ToDo: Enviar msg para que o consumer grave no banco
            }

            return validation;
        }

        public async Task<List<Motorcycle>> GetAll() =>
             await _motorcycleRepository.GetAll();

        public async Task<Motorcycle> GetByPlate(string plate) =>
             await _motorcycleRepository.GetByPlate(plate);

        public async Task<ValidationResult> Remove(string motorcycleId)
        {
            var validation = new ValidationResult();

            var rents = await _rentRepository.GetAllRentsByMotorcycleId(motorcycleId);

            if (!rents.Any())
            {
                validation.AddMessageError("Existem locações para esse veículo, processo abortado");
                return validation;
            }

            await _motorcycleRepository.Delete(motorcycleId);
            return validation;
        }

        public async Task<ValidationResult> UpdatePlate(string motorcycleId, string newPlate)
        {
            var validation = new ValidationResult();
            var result = await _motorcycleRepository.UpdatePlate(motorcycleId, newPlate);

            if (result == 1)
                return validation;

            validation.AddMessageError($"Não foi encontrado um veículo de ID {motorcycleId} para atualizara a placa");
            return validation;
        }

        public ValidationResult ValidDataMotorcycle(Motorcycle motorcycle)
        {
            var validation = new ValidationResult();
            if (FieldIsValid(motorcycle.Model)) validation.AddMessageError("Modelo não informado");
            if (FieldIsValid(motorcycle.Plate)) validation.AddMessageError("Placa não informada");
            if (motorcycle.Year.Equals(0)) validation.AddMessageError("Ano não informado");

            return validation;
        }
    }
}
