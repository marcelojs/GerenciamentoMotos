using Microsoft.AspNetCore.Mvc;
using WebApiGerenciamentoMotos.Mapper;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiGerenciamentoMotos.Controllers
{
    [ApiController]
    [Route("api/motorcycle")]
    public class MotorcycleController : Controller
    {
        private readonly IMotorcycleService _motorcycleService;
        private ILogger<MotorcycleController> _logger;

        public MotorcycleController(IMotorcycleService motorcycleService, ILogger<MotorcycleController> logger)
        {
            _motorcycleService = motorcycleService;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] MotorcycleViewModel motorcycleViewModel)
        {
            try
            {
                var motorcycle = MotorcycleMapper.MapperViewModelToEntityDomain(motorcycleViewModel);
                var result = await _motorcycleService.Create(motorcycle);

                if (result.IsValid)
                    return Ok();

                _logger.LogError("Não foi possível inserir dados da moto {Model} e placa {Plate}", motorcycleViewModel.Model, motorcycleViewModel.Plate);
                return BadRequest();
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar inserir dados da moto {Model} e placa {Plate}", motorcycleViewModel.Model, motorcycleViewModel.Plate);
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }

        [HttpGet("by-plate/{plate}")]
        public async Task<IActionResult> GetByPlate([FromRoute] string plate)
        {
            try
            {
                var result = await _motorcycleService.GetByPlate(plate);

                if (result == null)
                    return NotFound();

                var motorcycle = MotorcycleMapper.MapperEntityDomainToViewModel(result);

                return Ok(motorcycle);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar obter dados da moto pela placa {Plate}", plate);
                return StatusCode(500, $"Houve uma falha ao tentar buscar dados da moto pela placa {plate}");
            }
        }

        [HttpPost("{motorcycleId}/plate")]
        public async Task<IActionResult> Update([FromRoute] string motorcycleId, [FromBody] PlateViewModel plateViewModel)
        {
            try
            {
                var result = await _motorcycleService.UpdatePlate(motorcycleId, plateViewModel.Plate);
                if (result.IsValid)
                    return Ok();

                _logger.LogError("Não foi possível atualizar dados da moto da placa {Plate} e Id {motorcycleId}", plateViewModel.Plate, motorcycleId);
                return BadRequest(result.Errors);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar atualizar dados da moto da placa {Plate} e Id {motorcycleId}", plateViewModel.Plate, motorcycleId);
                return StatusCode(500, "Houve uma falha ao tentar atualizar para nova placa");
            }
        }

        [HttpGet("all-motorcycles")]
        public async Task<IActionResult> GetAllMotorcycles()
        {
            try
            {
                var result = await _motorcycleService.GetAll();

                if (result.Count == 0)
                    return NoContent();

                var motorcycles = MotorcycleMapper.MapperEntitiesDomainToViewModel(result);
                return Ok(motorcycles);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar obter dados de todas as motos");
                return StatusCode(500, "Houve uma falha ao tentar carregar todas as motos");
            }
        }

        [HttpDelete("{motorcycleId}")]
        public async Task<IActionResult> DeleteMotorcycle([FromRoute] string motorcycleId)
        {
            try
            {
                var result = await _motorcycleService.Remove(motorcycleId);

                if (result.IsValid)
                    return Ok();

                _logger.LogError("Não foi possível deletar dados da moto de Id {motorcycleId}",  motorcycleId);
                return BadRequest(result.Errors);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar deletar dados da moto de Id {motorcycleId}", motorcycleId);
                return StatusCode(500, "Houve uma falha ao tentar deletar a moto");
            }
        }
    }
}
