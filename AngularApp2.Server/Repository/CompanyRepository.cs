using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AngularApp2.Server.Repository
{
    public class CompanyRepository : ICompany
    {
        private ContextDB _context;


        public CompanyRepository(ContextDB context)
        {
            _context = context;
        }

        public Company GetById(int id)
        {
            return _context.Companies.Find(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies;
        }

        public Company Add(Company company)
        {
            try
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
                return company;
            }
            catch
            {
                return null;
            }
        }

        public string Update(Company company)
        {
            try
            {
                Company currentCompany = GetById(company.Id);
                if (currentCompany != null)
                {
                    currentCompany.NameCompany = company.NameCompany;
                    currentCompany.AddresCompany = company.AddresCompany;

                    _context.Companies.Update(currentCompany);
                    _context.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Enter anything!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Company currentCompany = GetById(id);
                if (currentCompany != null)
                {
                    _context.Companies.Remove(currentCompany);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
