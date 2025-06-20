using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Producer
{
    public interface IProducerKafka
    {
        Task ProducerMessage(Motorcycle motorcycle);
    }
}
