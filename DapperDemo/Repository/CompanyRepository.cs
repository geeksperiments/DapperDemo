using Dapper;
using DapperDemo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Resources;

namespace DapperDemo.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private IDbConnection _db;
        private ResourceManager _scriptManager;

        public CompanyRepository(IConfiguration configuration)
        {
            //sql server database
            //_db = new SqlConnection(configuration.GetConnectionString("SqlServerConnection"));
            //_scriptManager = SQLScripts.sql_server_scripts.ResourceManager;

            //sql lite database
            var dbFileLocation = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\..\..\..\.."));
            _db = new SQLiteConnection(configuration.GetConnectionString("SqliteConnection").Replace("{AppDir}", dbFileLocation));
            _scriptManager = SQLScripts.sqlite_scripts.ResourceManager;
        }

        public Company Add(Company company)
        {
            var id = _db.Query<int>(_scriptManager.GetString("add"), company).Single();
            company.CompanyId = id;
            return company;
        }

        public Company Find(int id)
        {
            return _db.Query<Company>(_scriptManager.GetString("find"), new { @CompanyId = id }).Single();
        }

        public List<Company> GetAll()
        {
            return _db.Query<Company>(_scriptManager.GetString("get_all")).ToList();
        }

        public void Remove(int id)
        {
            _db.Execute(_scriptManager.GetString("remove"), new { id });
        }

        public Company Update(Company company)
        {
            _db.Execute(_scriptManager.GetString("update"), company);
            return company;
        }
    }
}
