using Dapper;
using DapperDemo.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;

namespace DapperDemo.Repository
{
    public abstract class AbCompanyRepository : ICompanyRepository
    {
        protected IDbConnection _db;
        protected ResourceManager _scriptManager;

        virtual public Company Add(Company company)
        {
            var id = _db.Query<int>(_scriptManager.GetString("companies_add"), company).Single();
            company.CompanyId = id;
            return company;
        }

        virtual public Company Find(int id)
        {
            return _db.Query<Company>(_scriptManager.GetString("companies_find"), new { @CompanyId = id }).Single();
        }

        virtual public List<Company> GetAll()
        {
            return _db.Query<Company>(_scriptManager.GetString("companies_get_all")).ToList();
        }

        virtual public void Remove(int id)
        {
            _db.Execute(_scriptManager.GetString("companies_remove"), new { id });
        }

        virtual public Company Update(Company company)
        {
            _db.Execute(_scriptManager.GetString("companies_update"), company);
            return company;
        }
    }
}
