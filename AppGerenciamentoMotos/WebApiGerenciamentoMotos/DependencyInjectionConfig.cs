using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiGerenciamentoMotos.Configuration;
using WebApiGerenciamentoMotos.Data;
using WebApiGerenciamentoMotos.Data.Context;
using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Service;
using WebApiGerenciamentoMotos.Service.Interface;

namespace WebApiGerenciamentoMotos
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddScoped<IMotorcycleService, MotorcycleService>();
            services.AddScoped<IDeliveryManService, DeliveryManService>();
            services.AddScoped<IRentService, RentService>();

            //Repository
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
            services.AddScoped<IDeliveryManRepository, DeliveryManRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();

            services.AddSingleton<IMongoClient>(serviceProvider => {
                var config = serviceProvider.GetRequiredService<IOptions<MMStoreDatabaseSettings>>().Value;
                return new MongoClient(config.ConnectionString);
            });

            services.AddSingleton<MongoContext>();
        }
    }
}
