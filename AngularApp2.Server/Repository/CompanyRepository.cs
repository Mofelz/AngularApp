using AngularApp2.Server.Context;
using AngularApp2.Server.Interfaces;
using AngularApp2.Server.Modelz;

namespace AngularApp2.Server.Repository
{
    public class CompanyRepository : ICompany
    {
        private DazaBannixContext _context;

        public CompanyRepository(DazaBannixContext context)
        {
            _context = context;
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

        public IEnumerable<Company> GetAll()
        {
            return _context.Companies;
        }
    }
}
