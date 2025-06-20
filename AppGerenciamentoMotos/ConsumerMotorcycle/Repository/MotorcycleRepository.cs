using ConsumerMotorcycle.Model;
using ConsumerMotorcycle.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerMotorcycle.Repository
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        public Task Create(Motorcycle motorcycle)
        {
            //ToDo: Implementar insert no mongo, configurar MongoContext para acessar as propriedades básicas
            return Task.CompletedTask;
        }
    }
}
