using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Response;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.Validation;

namespace WebApiGerenciamentoMotos.Service
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IDeliveryManRepository _deliveryManRepository;

        public RentService(IRentRepository rentRepository, IPlanRepository planRepository, IDeliveryManRepository deliveryManRepository)
        {
            _rentRepository = rentRepository;
            _planRepository = planRepository;
            _deliveryManRepository = deliveryManRepository;
        }

        public async Task<ValidationResult> Create(Rent rent)
        {
            var validation = new ValidationResult();

            var allPlans = await _planRepository.GetAll();

            var planFound = allPlans.Where(plan => plan.Days == rent.Plan);

            if (!planFound.Any())
            {
                validation.AddMessageError($"Quantidade de dias {rent.Plan} informado inválido");
                return validation;
            }

            var datesIsValid = rent.AllDatesIsValid();

            if (!datesIsValid)
            {
                validation.AddMessageError("Datas informadas inválidas, favor preencher todas as datas solicitadas");
                return validation;
            }

            //ToDo: inserir log
            rent.SetExtraDay();

            var deliveryMan = await _deliveryManRepository.GetById(rent.DeliveryManId);

            if (deliveryMan == null)
            {
                validation.AddMessageError("Entregador não encontrado");
                return validation;
            }

            bool cnhIsValid = deliveryMan.CNHIsValidForRent();

            if (!cnhIsValid)
            {
                validation.AddMessageError("CNH do entregador inválida para alocação da moto");
                return validation;
            }

            return validation;
        }

        public async Task<Rent> GetById(Guid rentId) => await _rentRepository.GetById(rentId);

        public async Task<ResponseWrapper> UpdateDateDevolutionRentAndReturnFinalValueAllocation(Guid rentId, DateTime dateDevolution)
        {
            var validation = new ValidationResult();
            var rent = await _rentRepository.GetById(rentId);
            var allPlans = await _planRepository.GetAll();
            var planFound = allPlans.Where(plan => plan.Days == rent.Plan).FirstOrDefault();
            var finalValue = 0.0M;

            if (planFound == null)
            {
                validation.AddMessageError("Houve uma falha ao tentar atualizar a data de devolução do veículo");
                return new ResponseWrapper(validation, finalValue); 
            }

            if (dateDevolution < rent.PrevisionFinish)
            {
                var remainingDays = rent.PrevisionFinish.Value.Day - dateDevolution.Day;

                if (planFound.Days == 7)
                {
                    var valueMulctFromRemainingDays = remainingDays * 0.2M;
                    finalValue = planFound.Value + valueMulctFromRemainingDays;
                }
                else if (planFound.Days == 15)
                {
                    var valueMulctFromRemainingDays = remainingDays * 0.4M;
                    finalValue = planFound.Value + valueMulctFromRemainingDays;
                }
            }

            if (dateDevolution > rent.PrevisionFinish)
            {
                var extraDays = dateDevolution.Day - rent.PrevisionFinish.Value.Day;
                finalValue = 50.0M * extraDays;
            }

            var result = await _rentRepository.UpdateDateDevolutionRent(rentId, dateDevolution);

            if (!result)
            {
                validation.AddMessageError("Houve uma falha ao tentar atualizar a data de devolução do veículo");
                return new ResponseWrapper(validation, finalValue);
            }

            return new ResponseWrapper(validation, finalValue);
        }
    }
}
