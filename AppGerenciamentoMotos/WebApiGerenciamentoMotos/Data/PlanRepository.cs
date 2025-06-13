using Dapper;
using System.Data.SqlClient;
using WebApiGerenciamentoMotos.Data.Interface;
using WebApiGerenciamentoMotos.Models;

namespace WebApiGerenciamentoMotos.Data
{
    public class PlanRepository : IPlanRepository
    {
        private IConfiguration _configuration;

        public PlanRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ICollection<Plan>> GetAll()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var select = "";
                var result = await connection.QueryAsync<Plan>(select);
                return result.ToList();
            }
        }
    }
}
