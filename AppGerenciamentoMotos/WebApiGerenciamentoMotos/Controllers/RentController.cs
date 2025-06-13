using Microsoft.AspNetCore.Mvc;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.ViewModel;

namespace WebApiGerenciamentoMotos.Controllers
{
    [ApiController]
    [Route("api/rent")]
    public class RentController : Controller
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Rent rent)
        {
            try
            {
                var result = await _rentService.Create(rent);

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

        [HttpGet("{rentId:guid}")]
        public async Task<IActionResult> GetByRentId([FromRoute] Guid rentId)
        {
            try
            {
                var result = await _rentService.GetById(rentId);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }

        [HttpPut("{rentId:guid}/devolution")]
        public async Task<IActionResult> SendDevolution([FromRoute] Guid rentId, [FromBody] DateDevolutionViewModel dateDevolutionViewModel)
        {
            try
            {
                var result = await _rentService.UpdateDateDevolutionRentAndReturnFinalValueAllocation(rentId, dateDevolutionViewModel.Devolution);

                if(result.ValidationResult.IsValid)
                    return Ok(result.FinalValue);
                else
                    return BadRequest(result.ValidationResult);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }
    }
}
