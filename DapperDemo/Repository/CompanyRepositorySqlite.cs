using Microsoft.Extensions.Configuration;
using System;
using System.Data.SQLite;
using System.IO;

namespace DapperDemo.Repository
{
    public class CompanyRepositorySqlite : AbCompanyRepository
    {
        public CompanyRepositorySqlite(IConfiguration configuration)
        {
            var dbFileLocation = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\..\..\..\.."));
            _db = new SQLiteConnection(configuration.GetConnectionString("SqliteConnection").Replace("{AppDir}", dbFileLocation));
            _scriptManager = SQLScripts.sqlite_scripts.ResourceManager;
        }
    }
}
