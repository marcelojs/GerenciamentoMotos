using Confluent.Kafka;
using Microsoft.Extensions.Options;
using WebApiGerenciamentoMotos.Configuration;
using WebApiGerenciamentoMotos.Models;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebApiGerenciamentoMotos.Producer
{
    public class ProducerKafka : IProducerKafka
    {
        public ProducerKafka(IOptions<KafkaConfig> kafkaConfig)
        {
            _bootstrapServers = kafkaConfig.Value.BootstrapServers;
            _topic = kafkaConfig.Value.Topic;
        }

        private readonly string _bootstrapServers;
        private readonly string _topic;

        public async Task ProducerMessage(Motorcycle motorcycle)
        {
            var config = new ProducerConfig { BootstrapServers = _bootstrapServers };
            //Tem a forma de configurar tbm pela propria startup ou program

            var message = JsonConvert.SerializeObject(motorcycle);

            using var producer = new ProducerBuilder<string, string>(config).Build();
            var result = await producer.ProduceAsync(_topic, new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = message });

            //Log aqui
        }
    }
}
