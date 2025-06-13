using Dapper;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data.Interface
{
    public class DeliveryManRepository : IDeliveryManRepository
    {
        private IConfiguration _configuration;

        public DeliveryManRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Create(DeliveryMan deliveryMan)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var insert = "";

                var data = new
                {
                    Id = deliveryMan.Id,
                    Name = deliveryMan.Name,
                    CNPJ = deliveryMan.CNPJ,
                    BirthdayDate = deliveryMan.BirthdayDate,
                    CNHNumber = deliveryMan.CNHNumber,
                    CNHType = deliveryMan.CNHType,
                    CNHImage = deliveryMan.CNHImageName
                };

                var result = await connection.ExecuteAsync(insert, data);
                return result == 1;
            }
        }

        public async Task<DeliveryMan> GetByCNHOrCNPJ(string cnh, string cnpj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var select = "";
                var parameters = new { cnh = cnh, cnpj = cnpj };
                var result = await connection.QueryFirstAsync<DeliveryMan>(select, parameters);
                return result;
            }
        }

        public async Task<DeliveryMan> GetByCNPJ(string cnh)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var select = "";
                var parameters = new { cnh = cnh };
                var result = await connection.QueryFirstAsync<DeliveryMan>(select, parameters);
                return result;
            }
        }

        public async Task<DeliveryMan> GetById(Guid deliveryManId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var select = "";
                var parameters = new { deliveryManId = deliveryManId };
                var result = await connection.QueryFirstAsync<DeliveryMan>(select, parameters);
                return result;
            }
        }
    }
}
