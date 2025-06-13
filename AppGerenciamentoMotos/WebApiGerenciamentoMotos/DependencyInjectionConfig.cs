using WebApiGerenciamentoMotos.Data;
using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Service;
using WebApiGerenciamentoMotos.Service.Interface;

namespace WebApiGerenciamentoMotos
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
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
        }
    }
}
