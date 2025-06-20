using Microsoft.AspNetCore.Mvc;
using WebApiGerenciamentoMotos.Mapper;
using WebApiGerenciamentoMotos.Models;
using WebApiGerenciamentoMotos.Service.Interface;
using WebApiGerenciamentoMotos.ViewModel;

namespace WebApiGerenciamentoMotos.Controllers
{
    [ApiController]
    [Route("api/deliveryman")]
    public class DeliveryManController : Controller
    {
        private readonly IDeliveryManService _deliveryManService;
        private readonly ILogger<DeliveryManController> _logger;

        public DeliveryManController(IDeliveryManService deliveryManService, ILogger<DeliveryManController> logger)
        {
            _deliveryManService = deliveryManService;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] DeliveryManViewModel deliveryManViewModel)
        {
            try
            {
                var deliveryMan = DeliveryManMapper.MapperViewModelToDomain(deliveryManViewModel);

                var result = await _deliveryManService.Create(deliveryMan);

                if (result.IsValid)
                    return Ok();

                _logger.LogError("Dados do entregador {DeliveryManId} não persistido na base ", deliveryManViewModel.DeliveryManId);
                return BadRequest(result.Errors);
            }
            catch (Exception error)
            {
                _logger.LogError(error, "Houve uma falha ao tentar inserir dados do entregador na base");
                return StatusCode(500, "Houve uma falha ao tentar executar inserção");
            }
        }

        [HttpPost("send-photo/{deliveryManId}/cnh")]
        public async Task<IActionResult> Update([FromRoute] Guid ddeliveryManId, [FromBody] string photo)
        {
            try
            {
                var result = await _deliveryManService.AddPhoto(ddeliveryManId, photo);

                if (result.IsValid)
                    return Ok();

                _logger.LogError("Imagem do documento do entregador {DeliveryManId} sofreu uma falha ao tentar salvar no sistema", ddeliveryManId);
                return BadRequest(result.Errors);
            }
            catch (Exception error)
            {
                return StatusCode(500, $"Houve uma falha ao tentar executar o upload do documento do entregador {ddeliveryManId}");
            }
        }
    }
}
