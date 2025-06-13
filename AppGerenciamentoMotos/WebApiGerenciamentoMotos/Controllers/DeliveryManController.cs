using Microsoft.AspNetCore.Mvc;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;

namespace WebApiGerenciamentoMotos.Controllers
{
    [ApiController]
    [Route("api/entregador")]
    public class DeliveryManController : Controller
    {
        private readonly IDeliveryManService _deliveryManService;

        public DeliveryManController(IDeliveryManService deliveryManService)
        {
            _deliveryManService = deliveryManService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] DeliveryMan deliveryMan)
        {
            try
            {
                var result = await _deliveryManService.Create(deliveryMan);
                if(result.IsValid)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception error) 
            {
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }

        [HttpPost("send-photo/{deliveryManId:guid}/cnh")]
        public async Task<IActionResult> Update([FromRoute] Guid ddeliveryManId, [FromBody] string photo)
        {
            try
            {
                var result = await _deliveryManService.AddPhoto(ddeliveryManId, photo);

                if(result.IsValid)
                    return Ok();
                else 
                    return BadRequest();
            }
            catch (Exception error) 
            {
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }
    }
}
