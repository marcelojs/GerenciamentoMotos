using Microsoft.AspNetCore.Mvc;
using WebApiGerenciamentoMotos.Mapper;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiGerenciamentoMotos.Controllers
{
    [ApiController]
    [Route("api/rent")]
    public class RentController : Controller
    {
        private readonly IRentService _rentService;
        private readonly ILogger<RentController> _logger;

        public RentController(IRentService rentService, ILogger<RentController> logger)
        {
            _rentService = rentService;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RentViewModel rentViewModel)
        {
            try
            {
                var rent = RentMapper.MapperViewModelToEntityDomain(rentViewModel);

                var result = await _rentService.Create(rent);

                if (result.IsValid)
                    return Ok();

                _logger.LogError("Não foi possível inserir dados da locação para o entregador {DeliveryManId} e moto {MotorcycleId}", rentViewModel.DeliveryManId, rentViewModel.MotorcycleId);
                return BadRequest(result.Errors);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar salvar locação para o entregador {DeliveryManId} e moto {MotorcycleId}", rentViewModel.DeliveryManId, rentViewModel.MotorcycleId);
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }

        [HttpGet("{rentId}")]
        public async Task<IActionResult> GetByRentId([FromRoute] string rentId)
        {
            try
            {
                var result = await _rentService.GetById(rentId);

                if (result == null)
                    return NotFound();

                var rentViewModel = RentMapper.MapperEntityDomainToViewModel(result);

                return Ok(rentViewModel);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar obter dados da locação para o Id informado {rentId}", rentId);
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }

        [HttpPut("{rentId}/date-devolution")]
        public async Task<IActionResult> SendDateDevolution([FromRoute] string rentId, [FromBody] DateDevolutionViewModel dateDevolutionViewModel)
        {
            try
            {
                var result = await _rentService.UpdateDateDevolutionRentAndReturnFinalValueAllocation(rentId, dateDevolutionViewModel.Devolution);

                if (result.ValidationResult.IsValid)
                    return Ok(result.FinalValue);

                _logger.LogError("Não foi possível salvar a data de devolução da locação de Id {rentId}", rentId);
                return BadRequest(result.ValidationResult.Errors);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar salvar data de devolução da locação para o Id informado {rentId}", rentId);
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }
    }
}
