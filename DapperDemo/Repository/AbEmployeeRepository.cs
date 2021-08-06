using Dapper;
using DapperDemo.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;

namespace DapperDemo.Repository
{
    public abstract class AbEmployeeRepository : IEmployeeRepository
    {
        protected IDbConnection _db;
        protected ResourceManager _scriptManager;

        virtual public Employee Add(Employee Employee)
        {
            var id = _db.Query<int>(_scriptManager.GetString("employees_add"), Employee).Single();
            Employee.EmployeeId = id;
            return Employee;
        }

        virtual public Employee Find(int id)
        {
            return _db.Query<Employee>(_scriptManager.GetString("employees_find"), new { @EmployeeId = id }).Single();
        }

        virtual public List<Employee> GetAll()
        {
            return _db.Query<Employee>(_scriptManager.GetString("employees_get_all")).ToList();
        }

        virtual public void Remove(int id)
        {
            _db.Execute(_scriptManager.GetString("employees_remove"), new { id });
        }

        virtual public Employee Update(Employee Employee)
        {
            _db.Execute(_scriptManager.GetString("employees_update"), Employee);
            return Employee;
        }
    }
}
