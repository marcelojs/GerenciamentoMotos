using Dapper;
using System.Data.SqlClient;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public class RentRepository : IRentRepository
    {
        private IConfiguration _configuration;

        public RentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Create(Rent rent)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var insert = "";

                var data = new { 
                    Id = rent.Id,
                    MotorcycleId = rent.MotorcycleId,
                    DeliveryManId = rent.DeliveryManId,
                    StartDate = rent.StartDate,
                    EndDate = rent.EndDate,
                    PrevisionFinish = rent.PrevisionFinish,
                    Plan = rent.Plan
                };

                var result = await connection.ExecuteAsync(insert, data);
                return result == 1;
            }
        }

        public async Task<Rent> GetById(Guid rentId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var select = "";
                var parameters = new { rentId = rentId };
                var result = await connection.QueryFirstAsync<Rent>(select, parameters);
                return result;
            }
        }

        public async Task<bool> UpdateDateDevolutionRent(Guid rentId, DateTime dateDevolution)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var update = "UPDATE Rent set EndDate = @_dateDevolution where RentId = @_rentId";
                var data = new { _dateDevolution = dateDevolution, _rentId = rentId };
                var result = await connection.ExecuteAsync(update, data);
                return result == 1;
            }
        }
    }
}
