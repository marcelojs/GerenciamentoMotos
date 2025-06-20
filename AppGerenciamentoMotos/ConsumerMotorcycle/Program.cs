using Confluent.Kafka;
using System.Text;
using static Confluent.Kafka.ConfigPropertyNames;
using Newtonsoft;
using System.Text.Json;
using ConsumerMotorcycle.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ConsumerMotorcycle.Repository.Interface;
using ConsumerMotorcycle.Repository;
using System.ComponentModel.Design;

namespace ConsumerMotorcycle
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) => {
                    services.AddTransient<IMotorcycleRepository, MotorcycleRepository> ();
                }).Build();

            Consumer(host.Services);
            await host.RunAsync();
        }

        static async void Consumer(IServiceProvider serviceProvider)
        {
            var _motorcycleRepository = serviceProvider.GetService<IMotorcycleRepository>();

            const string groupId = "motorcycle-group";
            const string Topico = "motorcycle-topic";
            var clientId = Guid.NewGuid().ToString().Substring(0, 5);

            var conf = new ConsumerConfig
            {
                ClientId = clientId,
                GroupId = groupId,
                BootstrapServers = "localhost:9092",
                
                EnablePartitionEof = true,
                EnableAutoCommit = false,
                EnableAutoOffsetStore = false,
            };

            using var consumer = new ConsumerBuilder<string, string>(conf).Build();

            consumer.Subscribe(Topico);

            try
            {
                while (true)
                {
                    var result = consumer.Consume();

                    if (result.IsPartitionEOF)
                    {
                        continue;
                    }

                    var headers = result
                        .Message
                        .Headers
                        .ToDictionary(p => p.Key, p => Encoding.UTF8.GetString(p.GetValueBytes()));

                    var application = headers["application"];
                    var transactionId = headers["transactionId"];

                    var messsage = "<< Recebida: \t" + result.Message.Value;
                    Console.WriteLine(messsage);

                    var motorcycle = JsonSerializer.Deserialize<Motorcycle>(result.Message.Value);

                    await _motorcycleRepository.Create(motorcycle);

                    consumer.Commit(result);
                    consumer.StoreOffset(result.TopicPartitionOffset);
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Houve um falha ao cosumir mensagem");
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
