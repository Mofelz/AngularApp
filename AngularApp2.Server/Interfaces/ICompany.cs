using AngularApp2.Server.Models;

namespace AngularApp2.Server.Interfaces
{
    public interface ICompany
    {
        IEnumerable<Company> GetAll();
        Company Add(Company company);
        string Update(Company company);
        bool Delete(int id);
        Company GetById(int id);
    }
}
