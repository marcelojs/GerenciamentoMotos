using Microsoft.AspNetCore.Mvc;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.ViewModel;

namespace WebApiGerenciamentoMotos.Controllers
{
    [ApiController]
    [Route("api/moto")]
    public class MotosController : Controller
    {
        private readonly IMotorcycleService _motorcycleService;
        private ILogger<MotosController> _logger;

        public MotosController(IMotorcycleService motorcycleService, ILogger<MotosController> logger)
        {
            _motorcycleService = motorcycleService;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Motorcycle motorcycle)
        {
            try
            {
                var result = await _motorcycleService.Create(motorcycle);

                if (result.IsValid)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception error)
            {
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }

        [HttpGet("by-plate/{plate}")]
        public async Task<IActionResult> GetByPlate([FromRoute] string plate)
        {
            try
            {
                var result = await _motorcycleService.GetByPlate(plate);
                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Houve uma falha ao tentar buscar dados");
            }
        }

        [HttpPost("/{motorcycleId:guid}/plate")]
        public async Task<IActionResult> Update([FromRoute] Guid motorcycleId, [FromBody] PlateViewModel plateViewModel)
        {
            try
            {
                var result = await _motorcycleService.UpdatePlate(motorcycleId, plateViewModel.Plate);

                if (result.IsValid)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception error)
            {
                return StatusCode(500, "Houve uma falha ao tentar atualizar para nova placa");
            }
        }

        [HttpGet("all-motorcycles")]
        public async Task<IActionResult> GetAllMotorcycles()
        {
            try
            {
                var result = await _motorcycleService.GetAll();
                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Houve uma falha ao tentar carregar todas as motos");
            }
        }

        [HttpDelete("{motorcycleId:guid}")]
        public async Task<IActionResult> DeleteMotorcycle([FromRoute] Guid motorcycleId)
        {
            try
            {
                var result = await _motorcycleService.Remove(motorcycleId);

                if (result.IsValid)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception error)
            {
                return StatusCode(500, "Houve uma falha ao tentar deletar a moto");
            }
        }
    }
}
