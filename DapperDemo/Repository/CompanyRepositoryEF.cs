﻿using DapperDemo.Data;
using DapperDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace DapperDemo.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepositoryEF(ApplicationDbContext db)
        {
            _db = db;
        }

        public Company Add(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();

            return company;
        }

        public Company Find(int id)
        {
            return _db.Companies.FirstOrDefault(u => u.CompanyId == id);
        }

        public List<Company> GetAll()
        {
            return _db.Companies.ToList();
        }

        public void Remove(int id)
        {
            _db.Remove(Find(id));
            _db.SaveChanges();
        }

        public Company Update(Company company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();

            return company;
        }
    }
}
