using ConsumerMotorcycle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerMotorcycle.Repository.Interface
{
    internal interface IMotorcycleRepository
    {
        Task Create(Motorcycle motorcycle);
    }
}
