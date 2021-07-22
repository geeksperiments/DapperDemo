using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DapperDemo.Repository
{
    public class CompanyRepositorySqlServer : AbCompanyRepository
    {
        public CompanyRepositorySqlServer(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("SqlServerConnection"));
            _scriptManager = SQLScripts.sql_server_scripts.ResourceManager;
        }
    }
}
