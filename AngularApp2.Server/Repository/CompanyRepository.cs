using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Modelz;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AngularApp2.Server.Repository
{
    public class CompanyRepository : ICompany
    {
        private DazaBannixContext _context;


        public CompanyRepository(DazaBannixContext context)
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

        public bool Add(Company company)
        {
            try
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Update(Company company) 
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
