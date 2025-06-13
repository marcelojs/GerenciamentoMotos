using Dapper;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private IConfiguration _configuration;

        public MotorcycleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Create(Motorcycle motorcycle)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var insert = "";

                var data = new
                {
                    Id = motorcycle.Id,
                    Year = motorcycle.Year,
                    Model = motorcycle.Model,
                    Plate = motorcycle.Plate
                };

                var result = await connection.ExecuteAsync(insert, data);
                return result == 1;
            }
        }

        public async Task<bool> Delete(Guid motorcycleId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var delete = "";
                var data = new { motorcycleId = motorcycleId };
                var result = await connection.ExecuteAsync(delete, data);
                return result == 1;
            }
        }

        public async Task<List<Motorcycle>> GetAll()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var select = "";
                var result = await connection.QueryAsync<Motorcycle>(select);
                return result.ToList();
            }
        }

        public async Task<Motorcycle> GetByPlate(string plate)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var select = "";
                var parameters = new { plate = plate};
                var result = await connection.QueryFirstAsync<Motorcycle>(select, parameters);
                return result;
            }
        }

        public async Task<bool> UpdatePlate(Guid motorcycleId, string newPlate)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var update = "";
                var data = new { plate = newPlate, motorcycleId = motorcycleId };
                var result = await connection.ExecuteAsync(update, data);
                return result == 1;
            }
        }
    }
}
